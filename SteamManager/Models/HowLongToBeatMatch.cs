using System.Text.Json.Serialization;

namespace SteamManager.Models
{
    public sealed class HowLongToBeatMatch
    {
        [JsonPropertyName("game_id")]
        public int GameId { get; set; }

        [JsonPropertyName("game_name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("release_world")]
        public int ReleaseYear { get; set; }

        [JsonPropertyName("comp_main")]
        public double MainSeconds { get; set; }

        [JsonPropertyName("comp_plus")]
        public double MainExtraSeconds { get; set; }

        [JsonPropertyName("comp_100")]
        public double CompletionistSeconds { get; set; }

        [JsonPropertyName("comp_main_count")]
        public int MainCount { get; set; }

        [JsonIgnore]
        public double? MainHours => MainSeconds > 0 ? MainSeconds / 3600d : null;

        [JsonIgnore]
        public double? MainExtraHours => MainExtraSeconds > 0 ? MainExtraSeconds / 3600d : null;

        [JsonIgnore]
        public double? CompletionistHours => CompletionistSeconds > 0 ? CompletionistSeconds / 3600d : null;

        [JsonIgnore]
        public string MainDisplay => MainHours is null ? "Sem dados" : $"{MainHours:0.#} h";

        [JsonIgnore]
        public string MainExtraDisplay => MainExtraHours is null ? "—" : $"{MainExtraHours:0.#} h";

        [JsonIgnore]
        public string CompletionistDisplay => CompletionistHours is null ? "—" : $"{CompletionistHours:0.#} h";

        [JsonIgnore]
        public string ReleaseDisplay => ReleaseYear > 0 ? ReleaseYear.ToString() : "—";

        [JsonIgnore]
        public string HltbUrl => $"https://howlongtobeat.com/game/{GameId}";
    }

    public sealed class HowLongToBeatCacheEntry
    {
        public DateTime SearchedAtUtc { get; set; } = DateTime.UtcNow;
        public HowLongToBeatMatch? Match { get; set; }
        public List<HowLongToBeatMatch> SearchResults { get; set; } = new();
    }
}
