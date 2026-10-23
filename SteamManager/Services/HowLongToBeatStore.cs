using System.Text.Json;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class HowLongToBeatStore
    {
        private readonly string cachePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SteamManager", "howlongtobeat-cache.json");
        private string RecoveryPath => Path.Combine(Path.GetDirectoryName(cachePath)!, "howlongtobeat-cache.recovery.json");

        public DateTime? LastBulkSearchAtUtc { get; private set; }

        public Dictionary<uint, HowLongToBeatCacheEntry> Load()
        {
            var entries = new Dictionary<uint, HowLongToBeatCacheEntry>();
            var hasCacheFile = File.Exists(cachePath) || File.Exists(RecoveryPath);
            foreach (var path in new[] { cachePath, RecoveryPath })
            {
                var loadedFile = LoadFile(path);
                if (loadedFile.LastBulkSearchAtUtc is { } savedAt && (LastBulkSearchAtUtc is null || savedAt > LastBulkSearchAtUtc))
                    LastBulkSearchAtUtc = savedAt;
                foreach (var (appId, entry) in loadedFile.Entries)
                {
                    if (!entries.TryGetValue(appId, out var existing) || entry.SearchedAtUtc >= existing.SearchedAtUtc)
                        entries[appId] = entry;
                }
            }
            if (!hasCacheFile)
            {
                try { Save(entries); }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException) { }
            }
            return entries;
        }

        private static (Dictionary<uint, HowLongToBeatCacheEntry> Entries, DateTime? LastBulkSearchAtUtc) LoadFile(string path)
        {
            try
            {
                if (!File.Exists(path)) return (new(), null);
                using var document = JsonDocument.Parse(File.ReadAllText(path));
                if (document.RootElement.ValueKind != JsonValueKind.Object) return (new(), null);

                var root = document.RootElement;
                DateTime? lastBulkAt = root.TryGetProperty("LastBulkSearchAtUtc", out var lastBulkDate)
                    && lastBulkDate.ValueKind == JsonValueKind.String
                    && lastBulkDate.TryGetDateTime(out var parsedDate) ? parsedDate : null;
                var entriesRoot = root.TryGetProperty("Entries", out var storedEntries) && storedEntries.ValueKind == JsonValueKind.Object
                    ? storedEntries
                    : root;

                var entries = new Dictionary<uint, HowLongToBeatCacheEntry>();
                foreach (var property in entriesRoot.EnumerateObject())
                {
                    if (property.NameEquals("LastBulkSearchAtUtc") || property.NameEquals("Entries")) continue;
                    if (!uint.TryParse(property.Name, out var appId) || property.Value.ValueKind != JsonValueKind.Object) continue;

                    if (property.Value.TryGetProperty("Match", out _))
                    {
                        var entry = JsonSerializer.Deserialize<HowLongToBeatCacheEntry>(property.Value.GetRawText());
                        if (entry is not null) entries[appId] = entry;
                    }
                    else if (property.Value.TryGetProperty("game_id", out _))
                    {
                        // Migrate cache files created by the first HLTB integration version.
                        var legacyMatch = JsonSerializer.Deserialize<HowLongToBeatMatch>(property.Value.GetRawText());
                        if (legacyMatch is not null)
                            entries[appId] = new HowLongToBeatCacheEntry { Match = legacyMatch };
                    }
                }
                return (entries, lastBulkAt);
            }
            catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
            {
                return (new(), null);
            }
        }

        public void Save(Dictionary<uint, HowLongToBeatCacheEntry> matches)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(cachePath)!);
            var data = new HowLongToBeatCacheFile
            {
                LastBulkSearchAtUtc = LastBulkSearchAtUtc,
                Entries = matches
            };
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                WriteAtomically(cachePath, json);
                try { File.Delete(RecoveryPath); } catch (IOException) { }
            }
            catch (IOException)
            {
                // Windows can temporarily prevent replacing a file while it is mapped by another process.
                // Keep a separate durable copy and merge it back into the primary cache on next load.
                WriteAtomically(RecoveryPath, json);
            }
        }

        private static void WriteAtomically(string destination, string contents)
        {
            var temporaryPath = destination + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllText(temporaryPath, contents);
                IOException? lastError = null;
                for (var attempt = 0; attempt < 5; attempt++)
                {
                    try
                    {
                        File.Move(temporaryPath, destination, overwrite: true);
                        return;
                    }
                    catch (IOException ex)
                    {
                        lastError = ex;
                        if (attempt < 4) Thread.Sleep(100 * (attempt + 1));
                    }
                }
                throw lastError ?? new IOException("Could not write the local HowLongToBeat cache.");
            }
            finally
            {
                try { if (File.Exists(temporaryPath)) File.Delete(temporaryPath); } catch (IOException) { }
            }
        }

        public void MarkBulkSearchStarted() => LastBulkSearchAtUtc = DateTime.UtcNow;

        private sealed class HowLongToBeatCacheFile
        {
            public DateTime? LastBulkSearchAtUtc { get; set; }
            public Dictionary<uint, HowLongToBeatCacheEntry> Entries { get; set; } = new();
        }
    }
}
