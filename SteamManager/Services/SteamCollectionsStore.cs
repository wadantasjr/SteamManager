using System.Text.Json;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class SteamCollectionsStore
    {
        private readonly string collectionsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SteamManager", "steam-collections.json");

        public SteamCollectionsSnapshot? Load()
        {
            try
            {
                if (!File.Exists(collectionsPath))
                {
                    var emptySnapshot = new SteamCollectionsSnapshot();
                    Directory.CreateDirectory(Path.GetDirectoryName(collectionsPath)!);
                    File.WriteAllText(collectionsPath, JsonSerializer.Serialize(emptySnapshot, new JsonSerializerOptions { WriteIndented = true }));
                    return emptySnapshot;
                }
                return JsonSerializer.Deserialize<SteamCollectionsSnapshot>(File.ReadAllText(collectionsPath));
            }
            catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
            {
                return null;
            }
        }

        public void Save(SteamCollectionsSnapshot snapshot)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(collectionsPath)!);
            var temporaryPath = collectionsPath + ".tmp";
            File.WriteAllText(temporaryPath, JsonSerializer.Serialize(snapshot, new JsonSerializerOptions { WriteIndented = true }));
            File.Move(temporaryPath, collectionsPath, overwrite: true);
        }
    }
}
