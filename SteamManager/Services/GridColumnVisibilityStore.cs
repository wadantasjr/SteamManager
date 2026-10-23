using System.Text.Json;

namespace SteamManager.Services
{
    public sealed class GridColumnVisibilityStore
    {
        private readonly string settingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SteamManager", "hidden-grid-columns.json");

        public HashSet<string> LoadHiddenColumns()
        {
            try
            {
                if (!File.Exists(settingsPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(settingsPath)!);
                    File.WriteAllText(settingsPath, JsonSerializer.Serialize(Array.Empty<string>()));
                    return new(StringComparer.OrdinalIgnoreCase);
                }
                var names = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(settingsPath)) ?? new();
                return new HashSet<string>(names, StringComparer.OrdinalIgnoreCase);
            }
            catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
            {
                return new(StringComparer.OrdinalIgnoreCase);
            }
        }

        public void SaveHiddenColumns(IEnumerable<string> names)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(settingsPath)!);
            var temporaryPath = settingsPath + ".tmp";
            File.WriteAllText(temporaryPath, JsonSerializer.Serialize(names.ToList(), new JsonSerializerOptions { WriteIndented = true }));
            File.Move(temporaryPath, settingsPath, overwrite: true);
        }
    }
}
