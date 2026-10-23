namespace SteamManager.Models
{
    public sealed class AppSettings
    {
        public string SteamApiKey { get; set; } = string.Empty;
        public string SteamId64 { get; set; } = string.Empty;
        public string SteamSessionToken { get; set; } = string.Empty;
        public string ItadApiKey { get; set; } = string.Empty;
        public string CountryCode { get; set; } = "BR";

        public bool HasSteamConfiguration => !string.IsNullOrWhiteSpace(SteamApiKey) && !string.IsNullOrWhiteSpace(SteamId64);
    }
}
