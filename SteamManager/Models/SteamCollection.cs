namespace SteamManager.Models
{
    public sealed class SteamCollection
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsDynamic { get; set; }
        public List<uint> AppIds { get; set; } = new();
    }

    public sealed class SteamCollectionsSnapshot
    {
        public DateTime ImportedAt { get; set; }
        public string Source { get; set; } = string.Empty;
        public List<SteamCollection> Collections { get; set; } = new();
    }
}
