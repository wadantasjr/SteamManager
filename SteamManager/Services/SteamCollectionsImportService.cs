using System.Globalization;
using Microsoft.Win32;
using System.Text.Json;
using System.Text.RegularExpressions;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class SteamCollectionsImportService
    {
        private const ulong SteamId64Base = 76561197960265728UL;

        public static List<string> FindSteamInstallations()
        {
            var candidates = new List<string>();
            AddRegistryPath(candidates, Registry.CurrentUser, @"Software\Valve\Steam", "SteamPath");
            AddRegistryPath(candidates, Registry.CurrentUser, @"Software\Valve\Steam", "InstallPath");
            AddRegistryPath(candidates, Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath");
            AddRegistryPath(candidates, Registry.LocalMachine, @"SOFTWARE\Valve\Steam", "InstallPath");

            foreach (var path in new[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            })
            {
                if (!string.IsNullOrWhiteSpace(path)) candidates.Add(Path.Combine(path, "Steam"));
            }

            return candidates
                .Where(path => Directory.Exists(Path.Combine(path, "userdata")))
                .Select(Path.GetFullPath)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static void AddRegistryPath(List<string> candidates, RegistryKey hive, string subKey, string valueName)
        {
            try
            {
                var value = hive.OpenSubKey(subKey)?.GetValue(valueName)?.ToString();
                if (!string.IsNullOrWhiteSpace(value)) candidates.Add(value.Replace('/', Path.DirectorySeparatorChar));
            }
            catch (System.Security.SecurityException)
            {
                // Continue with standard installation locations when the registry is not readable.
            }
        }

        public SteamCollectionsSnapshot Import(string steamRoot, string steamId64)
        {
            var userDataDirectory = FindUserDataDirectory(steamRoot, steamId64);
            var cloudStorageDirectory = Path.Combine(userDataDirectory, "config", "cloudstorage");
            List<SteamCollection> cloudCollections;
            try
            {
                cloudCollections = ReadCloudCollections(cloudStorageDirectory);
            }
            catch (JsonException)
            {
                cloudCollections = new List<SteamCollection>();
            }
            if (cloudCollections.Count > 0)
            {
                return new SteamCollectionsSnapshot
                {
                    ImportedAt = DateTime.Now,
                    Source = Path.Combine(cloudStorageDirectory, "cloud-storage-namespace-*.json"),
                    Collections = cloudCollections.OrderBy(collection => collection.Name, StringComparer.CurrentCultureIgnoreCase).ToList()
                };
            }

            var legacyPath = Path.Combine(userDataDirectory, "7", "remote", "sharedconfig.vdf");
            if (File.Exists(legacyPath))
            {
                var legacyCollections = ReadLegacyCollections(legacyPath);
                if (legacyCollections.Count > 0)
                {
                    return new SteamCollectionsSnapshot
                    {
                        ImportedAt = DateTime.Now,
                        Source = legacyPath,
                        Collections = legacyCollections.OrderBy(collection => collection.Name, StringComparer.CurrentCultureIgnoreCase).ToList()
                    };
                }
            }

            throw new InvalidDataException("No collections were found in Steam's current storage or the legacy sharedconfig.vdf file. Open Steam, wait for your collections to sync, and try again.");
        }

        private static string FindUserDataDirectory(string steamRoot, string steamId64)
        {
            var userdataRoot = Path.Combine(steamRoot, "userdata");
            if (!Directory.Exists(userdataRoot))
                throw new DirectoryNotFoundException("The selected folder does not contain userdata. Select your Steam installation folder.");

            if (ulong.TryParse(steamId64, NumberStyles.None, CultureInfo.InvariantCulture, out var steamId) && steamId >= SteamId64Base)
            {
                var accountId = steamId - SteamId64Base;
                var matchingDirectory = Path.Combine(userdataRoot, accountId.ToString(CultureInfo.InvariantCulture));
                if (Directory.Exists(matchingDirectory))
                    return matchingDirectory;
            }

            var candidates = Directory.GetDirectories(userdataRoot)
                .Where(path => Directory.Exists(Path.Combine(path, "config", "cloudstorage")) ||
                               File.Exists(Path.Combine(path, "7", "remote", "sharedconfig.vdf")))
                .ToList();

            if (candidates.Count == 1)
                return candidates[0];
            if (candidates.Count > 1)
                throw new InvalidDataException("More than one Steam account was found in this installation. Enter the matching SteamID64 in Settings and try again.");
            throw new FileNotFoundException("No Steam account data was found in userdata. Check the selected installation and SteamID64 in Settings.");
        }

        private static List<SteamCollection> ReadCloudCollections(string directory)
        {
            if (!Directory.Exists(directory)) return new List<SteamCollection>();
            var namespaceId = FindActiveNamespace(directory);
            var path = namespaceId is null
                ? null
                : Path.Combine(directory, $"cloud-storage-namespace-{namespaceId}.json");
            if (path is null || !File.Exists(path)) return new List<SteamCollection>();

            using var document = JsonDocument.Parse(File.ReadAllText(path));
            if (document.RootElement.ValueKind != JsonValueKind.Array) return new List<SteamCollection>();

            var collections = new Dictionary<string, SteamCollection>(StringComparer.Ordinal);
            foreach (var entry in document.RootElement.EnumerateArray())
            {
                if (entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() < 2) continue;
                if (entry[0].ValueKind != JsonValueKind.String) continue;
                var key = entry[0].GetString();
                if (string.IsNullOrWhiteSpace(key) || !key.StartsWith("user-collections.", StringComparison.Ordinal)) continue;

                var envelope = entry[1];
                if (envelope.ValueKind != JsonValueKind.Object ||
                    (envelope.TryGetProperty("is_deleted", out var deleted) && deleted.ValueKind == JsonValueKind.True) ||
                    !envelope.TryGetProperty("value", out var value) || value.ValueKind != JsonValueKind.String)
                    continue;

                try
                {
                    using var collectionDocument = JsonDocument.Parse(value.GetString()!);
                    var data = collectionDocument.RootElement;
                    if (data.ValueKind != JsonValueKind.Object) continue;
                    var id = key["user-collections.".Length..];
                    var name = data.TryGetProperty("name", out var nameElement) && nameElement.ValueKind == JsonValueKind.String
                        ? nameElement.GetString()
                        : id;
                    if (string.IsNullOrWhiteSpace(name)) name = id;
                    var isDynamic = (data.TryGetProperty("is_dynamic", out var dynamicElement) && dynamicElement.ValueKind == JsonValueKind.True) ||
                                    data.TryGetProperty("filter", out _);
                    var added = ReadAppIds(data, "added");
                    var removed = ReadAppIds(data, "removed").ToHashSet();
                    var appIds = added.Where(appId => !removed.Contains(appId)).Distinct().ToList();
                    collections[id] = new SteamCollection { Id = id, Name = name, IsDynamic = isDynamic, AppIds = appIds };
                }
                catch (JsonException)
                {
                    // Ignore malformed individual entries and preserve other readable collections.
                }
            }
            return collections.Values.ToList();
        }

        private static string? FindActiveNamespace(string directory)
        {
            var namespacesPath = Path.Combine(directory, "cloud-storage-namespaces.json");
            if (File.Exists(namespacesPath))
            {
                try
                {
                    using var document = JsonDocument.Parse(File.ReadAllText(namespacesPath));
                    if (document.RootElement.ValueKind == JsonValueKind.Array)
                    {
                        var candidates = document.RootElement.EnumerateArray()
                            .Where(item => item.ValueKind == JsonValueKind.Array && item.GetArrayLength() >= 2)
                            .Select(item => new
                            {
                                Id = item[0].ToString(),
                                Version = ulong.TryParse(item[1].ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out var version) ? version : 0UL
                            })
                            .Where(item => item.Version > 0)
                            .OrderByDescending(item => item.Version)
                            .ToList();
                        if (candidates.Count > 0) return candidates[0].Id;
                    }
                }
                catch (JsonException)
                {
                    // Try namespace files directly if the index is unavailable or damaged.
                }
            }

            return Directory.GetFiles(directory, "cloud-storage-namespace-*.json")
                .Select(path => Regex.Match(Path.GetFileName(path), @"cloud-storage-namespace-(\d+)\.json", RegexOptions.IgnoreCase))
                .Where(match => match.Success)
                .Select(match => uint.TryParse(match.Groups[1].Value, out var id) ? (uint?)id : null)
                .Where(id => id.HasValue)
                .OrderByDescending(id => id)
                .Select(id => id!.Value.ToString(CultureInfo.InvariantCulture))
                .FirstOrDefault();
        }

        private static List<uint> ReadAppIds(JsonElement collection, string propertyName)
        {
            var ids = new List<uint>();
            if (!collection.TryGetProperty(propertyName, out var values) || values.ValueKind != JsonValueKind.Array)
                return ids;
            foreach (var value in values.EnumerateArray())
            {
                if (value.ValueKind == JsonValueKind.Number && value.TryGetUInt32(out var number)) ids.Add(number);
                else if (value.ValueKind == JsonValueKind.String && uint.TryParse(value.GetString(), NumberStyles.None, CultureInfo.InvariantCulture, out number)) ids.Add(number);
            }
            return ids;
        }

        private static List<SteamCollection> ReadLegacyCollections(string path)
        {
            var root = VdfParser.Parse(File.ReadAllText(path));
            var appsNodes = FindNodes(root, "apps");
            var collections = new Dictionary<string, HashSet<uint>>(StringComparer.CurrentCultureIgnoreCase);
            foreach (var appsNode in appsNodes)
            {
                foreach (var appNode in appsNode.Children)
                {
                    if (!uint.TryParse(appNode.Key, NumberStyles.None, CultureInfo.InvariantCulture, out var appId)) continue;
                    foreach (var tagsNode in appNode.Children.Where(child => child.Key.Equals("tags", StringComparison.OrdinalIgnoreCase)))
                    {
                        foreach (var tag in tagsNode.Children)
                        {
                            var name = tag.Value?.Trim();
                            if (string.IsNullOrWhiteSpace(name)) continue;
                            if (!collections.TryGetValue(name, out var ids))
                                collections[name] = ids = new HashSet<uint>();
                            ids.Add(appId);
                        }
                    }
                }
            }

            return collections
                .Where(pair => pair.Value.Count > 0)
                .Select(pair => new SteamCollection { Id = pair.Key, Name = pair.Key, AppIds = pair.Value.Order().ToList() })
                .ToList();
        }

        private static IEnumerable<VdfNode> FindNodes(IEnumerable<VdfNode> nodes, string key)
        {
            foreach (var node in nodes)
            {
                if (node.Key.Equals(key, StringComparison.OrdinalIgnoreCase)) yield return node;
                foreach (var child in FindNodes(node.Children, key)) yield return child;
            }
        }

        private sealed class VdfNode(string key, string? value)
        {
            public string Key { get; } = key;
            public string? Value { get; } = value;
            public List<VdfNode> Children { get; } = new();
        }

        private sealed class VdfParser
        {
            private readonly List<string> tokens;
            private int position;

            private VdfParser(string text) => tokens = Tokenize(text);

            public static List<VdfNode> Parse(string text)
            {
                var parser = new VdfParser(text);
                return parser.ParseObject(false);
            }

            private List<VdfNode> ParseObject(bool nested)
            {
                var nodes = new List<VdfNode>();
                while (position < tokens.Count)
                {
                    if (tokens[position] == "}")
                    {
                        position++;
                        if (nested) return nodes;
                        continue;
                    }
                    var key = tokens[position++];
                    if (position >= tokens.Count) break;
                    if (tokens[position] == "{")
                    {
                        position++;
                        var node = new VdfNode(key, null);
                        node.Children.AddRange(ParseObject(true));
                        nodes.Add(node);
                    }
                    else if (tokens[position] != "}")
                    {
                        nodes.Add(new VdfNode(key, tokens[position++]));
                    }
                }
                return nodes;
            }

            private static List<string> Tokenize(string text)
            {
                var tokens = new List<string>();
                for (var index = 0; index < text.Length;)
                {
                    var character = text[index];
                    if (char.IsWhiteSpace(character)) { index++; continue; }
                    if (character == '/' && index + 1 < text.Length && text[index + 1] == '/')
                    {
                        while (index < text.Length && text[index] != '\n') index++;
                        continue;
                    }
                    if (character is '{' or '}') { tokens.Add(character.ToString()); index++; continue; }
                    if (character == '"')
                    {
                        index++;
                        var value = new System.Text.StringBuilder();
                        while (index < text.Length)
                        {
                            character = text[index++];
                            if (character == '"') break;
                            if (character == '\\' && index < text.Length)
                            {
                                var escaped = text[index++];
                                value.Append(escaped switch { 'n' => '\n', 't' => '\t', _ => escaped });
                            }
                            else value.Append(character);
                        }
                        tokens.Add(value.ToString());
                        continue;
                    }
                    var start = index;
                    while (index < text.Length && !char.IsWhiteSpace(text[index]) && text[index] is not '{' and not '}') index++;
                    tokens.Add(text[start..index]);
                }
                return tokens;
            }
        }
    }
}
