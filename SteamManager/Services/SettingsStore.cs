using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using SteamManager.Models;

namespace SteamManager.Services
{
    public sealed class SettingsStore
    {
        private static readonly JsonSerializerOptions jsonOptions = new() { WriteIndented = true };
        private readonly string settingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SteamManager",
            "settings.json");

        public AppSettings Load()
        {
            if (!File.Exists(settingsPath))
            {
                var defaults = new AppSettings();
                try { Save(defaults); }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or Win32Exception) { }
                return defaults;
            }

            try
            {
                var stored = JsonSerializer.Deserialize<StoredSettings>(File.ReadAllText(settingsPath), jsonOptions);
                return stored is null ? new AppSettings() : new AppSettings
                {
                    SteamApiKey = Unprotect(stored.SteamApiKey),
                    SteamId64 = stored.SteamId64 ?? string.Empty,
                    SteamSessionToken = Unprotect(stored.SteamSessionToken),
                    ItadApiKey = Unprotect(stored.ItadApiKey),
                    CountryCode = string.IsNullOrWhiteSpace(stored.CountryCode) ? "BR" : stored.CountryCode
                };
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException or CryptographicException or FormatException or Win32Exception)
            {
                return new AppSettings();
            }
        }

        public void Save(AppSettings settings)
        {
            var folder = Path.GetDirectoryName(settingsPath)!;
            Directory.CreateDirectory(folder);
            var stored = new StoredSettings
            {
                SteamApiKey = Protect(settings.SteamApiKey),
                SteamId64 = settings.SteamId64.Trim(),
                SteamSessionToken = Protect(settings.SteamSessionToken),
                ItadApiKey = Protect(settings.ItadApiKey),
                CountryCode = settings.CountryCode
            };
            File.WriteAllText(settingsPath, JsonSerializer.Serialize(stored, jsonOptions), Encoding.UTF8);
        }

        private static string Protect(string value) => string.IsNullOrEmpty(value)
            ? string.Empty
            : Convert.ToBase64String(Dpapi.Protect(Encoding.UTF8.GetBytes(value)));

        private static string Unprotect(string value) => string.IsNullOrEmpty(value)
            ? string.Empty
            : Encoding.UTF8.GetString(Dpapi.Unprotect(Convert.FromBase64String(value)));

        private sealed class StoredSettings
        {
            public string SteamApiKey { get; set; } = string.Empty;
            public string SteamId64 { get; set; } = string.Empty;
            public string SteamSessionToken { get; set; } = string.Empty;
            public string ItadApiKey { get; set; } = string.Empty;
            public string CountryCode { get; set; } = "BR";
        }
    }

    internal static class Dpapi
    {
        private const int UiForbidden = 0x1;

        [StructLayout(LayoutKind.Sequential)]
        private struct DataBlob
        {
            public int Length;
            public IntPtr Data;
        }

        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptProtectData(ref DataBlob input, string? description, IntPtr entropy, IntPtr reserved, IntPtr prompt, int flags, out DataBlob output);

        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptUnprotectData(ref DataBlob input, IntPtr description, IntPtr entropy, IntPtr reserved, IntPtr prompt, int flags, out DataBlob output);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LocalFree(IntPtr memory);

        public static byte[] Protect(byte[] data) => Transform(data, true);
        public static byte[] Unprotect(byte[] data) => Transform(data, false);

        private static byte[] Transform(byte[] data, bool protect)
        {
            var inputPointer = Marshal.AllocHGlobal(data.Length);
            try
            {
                Marshal.Copy(data, 0, inputPointer, data.Length);
                var input = new DataBlob { Length = data.Length, Data = inputPointer };
                DataBlob output;
                var success = protect
                    ? CryptProtectData(ref input, "SteamManager", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, UiForbidden, out output)
                    : CryptUnprotectData(ref input, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, UiForbidden, out output);
                if (!success)
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                try
                {
                    var result = new byte[output.Length];
                    Marshal.Copy(output.Data, result, 0, result.Length);
                    return result;
                }
                finally
                {
                    LocalFree(output.Data);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inputPointer);
            }
        }
    }
}
