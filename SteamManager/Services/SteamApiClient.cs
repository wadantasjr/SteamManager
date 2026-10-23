using System.Net;
using System.Text.Json;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class SteamApiClient
    {
        private static readonly HttpClient httpClient = new() { Timeout = TimeSpan.FromSeconds(30) };
        private static readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };

        public async Task<List<SteamGame>> GetOwnedGamesAsync(string apiKey, string steamId64, CancellationToken cancellationToken = default)
        {
            var input = JsonSerializer.Serialize(new
            {
                steamid = steamId64,
                include_appinfo = true,
                include_played_free_games = true
            });
            var url = "https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/" +
                      $"?key={Uri.EscapeDataString(apiKey)}&input_json={Uri.EscapeDataString(input)}";

            using var response = await httpClient.GetAsync(url, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                throw new SteamApiException("Steam rejected the API key. Check the key in Settings.");
            if (!response.IsSuccessStatusCode)
                throw new SteamApiException($"Steam returned HTTP status code {(int)response.StatusCode}.");

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            var payload = await JsonSerializer.DeserializeAsync<OwnedGamesEnvelope>(stream, jsonOptions, cancellationToken);
            if (payload?.Response is null)
                throw new SteamApiException("Steam returned an empty response or an unexpected format.");
            if (payload.Response.Games is null)
                throw new SteamApiException("Steam did not return a library. Check that your game details are public on your profile.");

            return payload.Response.Games
                .OrderBy(game => game.Name, StringComparer.CurrentCultureIgnoreCase)
                .ToList();
        }

        public async Task<List<SteamGame>> GetFamilyLibraryAsync(string sessionToken, CancellationToken cancellationToken = default)
        {
            var token = Uri.EscapeDataString(sessionToken);
            using var familyResponse = await httpClient.GetAsync(
                $"https://api.steampowered.com/IFamilyGroupsService/GetFamilyGroupForUser/v1/?access_token={token}&include_family_group_response=true",
                cancellationToken);
            if (!familyResponse.IsSuccessStatusCode)
                throw new FamilyApiException("Steam rejected the session token. Generate a new token using the page shown in Settings.");

            await using var familyStream = await familyResponse.Content.ReadAsStreamAsync(cancellationToken);
            using var familyDocument = await JsonDocument.ParseAsync(familyStream, cancellationToken: cancellationToken);
            if (!TryGetResponse(familyDocument.RootElement, out var familyData) ||
                !familyData.TryGetProperty("family_groupid", out var familyGroupIdElement))
                return new List<SteamGame>();

            var familyGroupId = familyGroupIdElement.ToString();
            if (string.IsNullOrWhiteSpace(familyGroupId) || familyGroupId == "0")
                return new List<SteamGame>();

            using var appsResponse = await httpClient.GetAsync(
                "https://api.steampowered.com/IFamilyGroupsService/GetSharedLibraryApps/v1/" +
                $"?access_token={token}&family_groupid={Uri.EscapeDataString(familyGroupId)}&include_own=true&include_excluded=false&include_free=true&include_non_games=false&max_apps=10000",
                cancellationToken);
            if (!appsResponse.IsSuccessStatusCode)
                throw new FamilyApiException("Could not load Steam Families shared games.");

            await using var appsStream = await appsResponse.Content.ReadAsStreamAsync(cancellationToken);
            using var appsDocument = await JsonDocument.ParseAsync(appsStream, cancellationToken: cancellationToken);
            if (!TryGetResponse(appsDocument.RootElement, out var appsData) ||
                !appsData.TryGetProperty("apps", out var appsElement) ||
                appsElement.ValueKind != JsonValueKind.Array)
                return new List<SteamGame>();

            var games = new List<SteamGame>();
            foreach (var app in appsElement.EnumerateArray())
            {
                if (!app.TryGetProperty("appid", out var appIdElement) || !appIdElement.TryGetUInt32(out var appId))
                    continue;

                var name = app.TryGetProperty("name", out var nameElement) ? nameElement.GetString() : null;
                games.Add(new SteamGame
                {
                    AppId = appId,
                    Name = string.IsNullOrWhiteSpace(name) ? $"App {appId}" : name,
                    PlaytimeKnown = false,
                    IsFamilyShared = true
                });
            }

            return games;
        }

        private static bool TryGetResponse(JsonElement root, out JsonElement response)
        {
            if (root.TryGetProperty("response", out response))
                return true;
            response = default;
            return false;
        }

        private sealed class OwnedGamesEnvelope
        {
            public OwnedGamesResponse? Response { get; set; }
        }

        private sealed class OwnedGamesResponse
        {
            public int Game_Count { get; set; }
            public List<SteamGame>? Games { get; set; }
        }
    }

    public sealed class SteamApiException(string message) : Exception(message)
    {
    }

    public sealed class FamilyApiException(string message) : Exception(message)
    {
    }
}
