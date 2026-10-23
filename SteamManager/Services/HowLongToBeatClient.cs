using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class HowLongToBeatClient
    {
        private const string BaseUrl = "https://howlongtobeat.com";
        private const string SearchPath = "/api/search/site";
        private static readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };
        private readonly HttpClient httpClient;
        private string? token;
        private DateTime tokenFetchedAt;
        private DateTime lastSearchAt;

        public HowLongToBeatClient()
        {
            var handler = new HttpClientHandler { CookieContainer = new CookieContainer(), UseCookies = true };
            httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(25) };
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Referrer = new Uri(BaseUrl + "/");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Origin", BaseUrl);
        }

        public async Task<IReadOnlyList<HowLongToBeatMatch>> SearchAsync(string gameName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(gameName))
                return Array.Empty<HowLongToBeatMatch>();

            var wait = TimeSpan.FromMilliseconds(1100) - (DateTime.UtcNow - lastSearchAt);
            if (wait > TimeSpan.Zero)
                await Task.Delay(wait, cancellationToken);

            await EnsureTokenAsync(cancellationToken);
            var terms = gameName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var emptyFilter = new { mode = "include", values = Array.Empty<string>() };
            var payload = new Dictionary<string, object?>
            {
                ["searchType"] = "games",
                ["searchTerms"] = terms,
                ["searchPage"] = 1,
                ["size"] = 20,
                ["searchOptions"] = new
                {
                    games = new { userId = 0, platform = emptyFilter, sortCategory = "popular", rangeCategory = "main", rangeTime = new { min = (int?)null, max = (int?)null }, gameplay = new { perspective = emptyFilter, flow = emptyFilter, genre = emptyFilter }, year = emptyFilter, modifier = "" },
                    users = new { sortCategory = "postcount" },
                    lists = new { sortCategory = "follows" },
                    filter = "", sort = 0, randomizer = 0
                },
                ["useCache"] = true
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + SearchPath)
            {
                Content = JsonContent.Create(payload)
            };
            request.Headers.TryAddWithoutValidation("x-auth-token", token);
            using var response = await httpClient.SendAsync(request, cancellationToken);
            lastSearchAt = DateTime.UtcNow;
            if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
            {
                token = null;
                await EnsureTokenAsync(cancellationToken);
                return await SearchAsync(gameName, cancellationToken);
            }
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
                throw new HttpRequestException("HowLongToBeat temporarily rate-limited requests. Wait a few minutes before continuing.", null, response.StatusCode);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
            if (!document.RootElement.TryGetProperty("data", out var results) || results.ValueKind != JsonValueKind.Array)
                return Array.Empty<HowLongToBeatMatch>();

            return JsonSerializer.Deserialize<List<HowLongToBeatMatch>>(results.GetRawText(), jsonOptions) ?? new List<HowLongToBeatMatch>();
        }

        private async Task EnsureTokenAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(token) && DateTime.UtcNow - tokenFetchedAt < TimeSpan.FromMinutes(10))
                return;

            var initUrl = $"{BaseUrl}{SearchPath}/init?t={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
            using var response = await httpClient.GetAsync(initUrl, cancellationToken);
            response.EnsureSuccessStatusCode();
            var session = await response.Content.ReadFromJsonAsync<TokenResponse>(jsonOptions, cancellationToken)
                ?? throw new InvalidOperationException("HowLongToBeat did not return search session data.");
            if (string.IsNullOrWhiteSpace(session.Token))
                throw new InvalidOperationException("HowLongToBeat did not return a session token. The website may be unavailable or its search interface may have changed.");
            token = session.Token;
            tokenFetchedAt = DateTime.UtcNow;
        }

        private sealed class TokenResponse
        {
            public string? Token { get; set; }
        }
    }
}
