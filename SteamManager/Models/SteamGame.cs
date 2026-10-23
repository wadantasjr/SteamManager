using System.Text.Json.Serialization;

namespace SteamManager.Models
{
    public sealed class SteamGame
    {
        [JsonPropertyName("appid")]
        public uint AppId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "Unknown game";

        [JsonPropertyName("playtime_forever")]
        public int PlaytimeForever { get; set; }

        [JsonPropertyName("rtime_last_played")]
        public long RTimeLastPlayed { get; set; }

        public bool PlaytimeKnown { get; set; } = true;
        public bool IsFamilyShared { get; set; }
        public int? HowLongToBeatId { get; set; }
        public string? HowLongToBeatName { get; set; }
        public double? HltbMainHours { get; set; }
        public double? HltbMainExtraHours { get; set; }
        public double? HltbCompletionistHours { get; set; }
        public string HltbMainDisplay => HltbMainHours is null ? "—" : $"{HltbMainHours:0.#} h";
        public string HltbMainExtraDisplay => HltbMainExtraHours is null ? "—" : $"{HltbMainExtraHours:0.#} h";
        public string SourceDisplay => IsFamilyShared ? "Steam Families" : "My account";

        public string PlaytimeDisplay => !PlaytimeKnown
            ? "Unavailable"
            : PlaytimeForever < 60
                ? $"{PlaytimeForever} min"
                : $"{PlaytimeForever / 60:N0} h {PlaytimeForever % 60:00} min";

        public string LastPlayedDisplay => !PlaytimeKnown
            ? "Unavailable"
            : RTimeLastPlayed <= 0
                ? "Never"
                : DateTimeOffset.FromUnixTimeSeconds(RTimeLastPlayed).LocalDateTime.ToString("dd/MM/yyyy");
    }
}
