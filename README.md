# SteamManager

SteamManager is a Windows Forms desktop application for browsing a Steam game library, viewing Steam collections, and looking up HowLongToBeat playtime estimates.

This is an experimental personal project created with the assistance of AI. It is intended for learning and testing, not as a production-ready or officially supported product. It is not affiliated with Valve, Steam, HowLongToBeat, or IsThereAnyDeal.

## Current features

- Import the account's owned games through the Steam Web API.
- Optionally include games shared through Steam Families using a temporary Steam session token.
- Import Steam collections from the local Steam client files.
- Filter the library by name, source, playtime, collection, and HowLongToBeat main story hours; sort it and pick a random game from the filtered results.
- Sort the library by clicking any visible grid column header, and export the current grid to an Excel workbook (`.xlsx`).
- Look up HowLongToBeat results for one game or process the library in a resumable batch.
- Cache library, collection, column preference, and HowLongToBeat data locally so they are retained between runs.
- Store Steam and IsThereAnyDeal credentials protected with Windows DPAPI for the current Windows user.

Wishlist import and price tracking through IsThereAnyDeal are not implemented yet. The optional IsThereAnyDeal API key and country settings are present in the Settings window for future development; the application does not currently use them.

## Library filters, sorting, and export

The Library page has optional **HLTB min hours** and **HLTB max hours** fields. These limits use the HowLongToBeat **main story** estimate shown in the grid. Leave either field empty to omit that limit. Decimal values can use a comma or a period. When either limit is set, games without a main story estimate are excluded.

Click a visible column header to sort the grid in ascending order; click it again to reverse the order. The existing sort selector is also available for common playtime, last played, and HowLongToBeat sorts.

Choose **Export to Excel** to save the grid as an `.xlsx` workbook. The export follows the current filter and sort order and includes only visible columns. HowLongToBeat main story hours are stored as numeric values in Excel; other columns keep their displayed values.

## Requirements

- Windows 10 or later.
- Visual Studio 2022 with the **.NET desktop development** workload, or the .NET 8 SDK with Windows Forms targeting support.
- A Steam account with the game details in its profile set to public when importing its owned library.

## Build and run

Open `SteamManager/SteamManager.sln` in Visual Studio, restore packages if prompted, then build and run the `SteamManager` project.

Alternatively, from the repository root:

```powershell
dotnet restore .\SteamManager\SteamManager.csproj
dotnet build .\SteamManager\SteamManager.csproj
dotnet run --project .\SteamManager\SteamManager.csproj
```

## Configure Steam

Open **Settings** in the application to enter the values below. The Steam API key, Family session token, and IsThereAnyDeal key are stored with Windows DPAPI and can only be decrypted by the same Windows user on that machine. Do not commit or share these credentials.

### Steam Web API key

1. Sign in to Steam in a browser.
2. Open the [Steam Web API key registration page](https://steamcommunity.com/dev/apikey).
3. Follow Steam's registration form and copy the generated key into **Steam Web API key** in Settings.

Steam's API access is subject to its [Web API documentation and terms](https://steamcommunity.com/dev).

### SteamID64

SteamID64 is the account's 17-digit numeric ID; it is different from the account name and profile display name.

1. Open your Steam Community profile and choose **Edit Profile**.
2. Find the **Custom URL** section. If you have not set a custom URL, Steam shows your 64-bit ID there.
3. If you have a custom URL, clear its text temporarily; Steam shows the 64-bit ID below the field.
4. Enter the 17-digit number in **SteamID64** in Settings.

See [Steam Support's instructions for finding a SteamID](https://help.steampowered.com/en/faqs/view/2816-BE67-5B69-0FEC).

The account's game details must be public for the owned-game API call to return the library.

### Steam Families (optional)

Steam Families access uses a temporary, account-bound `webapi_token` from the Steam website session. This is not a long-lived Web API key, and Steam may expire it.

1. Sign in to Steam in your browser.
2. Open `https://store.steampowered.com/pointssummary/ajaxgetasyncconfig` in that same browser session.
3. Copy only the value of `webapi_token` into **Temporary Steam session token** in Settings.
4. If Steam Families games stop loading, obtain a fresh token and replace the old one.

Treat this token as sensitive. It is optional; the application can still import the account's own library without it. The Family endpoint is not part of the public Steam Web API and may change without notice.

### IsThereAnyDeal (future feature)

The application does not currently make IsThereAnyDeal requests. When implementing price tracking, an API key can be created by signing in and registering an app in [IsThereAnyDeal My Apps](https://isthereanydeal.com/apps/). Review the [IsThereAnyDeal API documentation and terms](https://docs.isthereanydeal.com/) before using the API. The key field in Settings is currently reserved for future implementation.

## HowLongToBeat behavior

HowLongToBeat lookup currently queries the website's search endpoint directly; it does not use an official public API. The website may change, reject automated requests, or apply rate limits. Batch searches include a delay, save each result locally, and can resume with games that are still pending. Search results without an exact title match are cached too, so they are not automatically queried again; use the per-game search action to review and manually select a result.

## Local data and first run

The application stores its local data on the user's computer in this folder:

```text
%LOCALAPPDATA%\SteamManager
```

On a typical Windows installation, this resolves to `C:\Users\<username>\AppData\Local\SteamManager`.

The folder can contain:

- `settings.json` — credentials and account settings. Secret values are DPAPI-protected for the current Windows user.
- `steam-library.json` — the last synced library snapshot.
- `steam-collections.json` — imported collection data.
- `howlongtobeat-cache.json` and recovery files — saved search results and batch-search timestamp.
- `hidden-grid-columns.json` — grid column visibility preferences.

If these files do not exist, the application creates empty/default JSON files and continues without crashing. Add Steam credentials and run a sync to populate the library. Import collections from the **Collections** page when needed.

The repository `.gitignore` excludes these local data filenames, secrets, Visual Studio user files, and .NET build output. Keep that protection in place before pushing the project to GitHub. If credentials or personal data were committed previously, removing the files in a later commit is not enough: rotate the exposed keys and remove the sensitive content from repository history.

## Project status and limitations

- This project was created with AI assistance for testing and learning. Review the code and API behavior before relying on it.
- Steam, HowLongToBeat, and IsThereAnyDeal can change their APIs, privacy requirements, rate limits, or terms.
- Steam Families support depends on an undocumented temporary session token.
- Wishlist import and IsThereAnyDeal price tracking are planned, not implemented.
- Local credentials protected with DPAPI are tied to the Windows user and machine context; they are not portable with the repository.

