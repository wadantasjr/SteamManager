using System.Text.Json;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class SteamLibraryStore
    {
        private readonly string libraryPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SteamManager", "steam-library.json");

        public SteamLibrarySnapshot? Load()
        {
            try
            {
                if (!File.Exists(libraryPath))
                {
                    var emptySnapshot = new SteamLibrarySnapshot();
                    Directory.CreateDirectory(Path.GetDirectoryName(libraryPath)!);
                    File.WriteAllText(libraryPath, JsonSerializer.Serialize(emptySnapshot, new JsonSerializerOptions { WriteIndented = true }));
                    return emptySnapshot;
                }
                return JsonSerializer.Deserialize<SteamLibrarySnapshot>(File.ReadAllText(libraryPath));
            }
            catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
            {
                return null;
            }
        }

        public void Save(IEnumerable<SteamGame> games, DateTime synchronizedAt)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(libraryPath)!);
            var snapshot = new SteamLibrarySnapshot
            {
                SynchronizedAt = synchronizedAt,
                Games = games.ToList()
            };
            var temporaryPath = libraryPath + ".tmp";
            File.WriteAllText(temporaryPath, JsonSerializer.Serialize(snapshot, new JsonSerializerOptions { WriteIndented = true }));
            File.Move(temporaryPath, libraryPath, overwrite: true);
        }
    }

    public sealed class SteamLibrarySnapshot
    {
        public DateTime? SynchronizedAt { get; set; }
        public List<SteamGame> Games { get; set; } = new();
    }
}
