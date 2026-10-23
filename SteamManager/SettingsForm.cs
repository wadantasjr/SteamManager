using SteamManager.Models;

namespace SteamManager
{
    public partial class SettingsForm : Form
    {
        public AppSettings Settings { get; private set; }

        public SettingsForm(AppSettings settings)
        {
            InitializeComponent();
            Settings = new AppSettings
            {
                SteamApiKey = settings.SteamApiKey,
                SteamId64 = settings.SteamId64,
                SteamSessionToken = settings.SteamSessionToken,
                ItadApiKey = settings.ItadApiKey,
                CountryCode = settings.CountryCode
            };

            steamKeyTextBox.Text = Settings.SteamApiKey;
            steamIdTextBox.Text = Settings.SteamId64;
            steamSessionTokenTextBox.Text = Settings.SteamSessionToken;
            itadKeyTextBox.Text = Settings.ItadApiKey;
            countryComboBox.SelectedIndex = Settings.CountryCode switch { "US" => 1, "PT" => 2, _ => 0 };
        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            var steamId = steamIdTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(steamId) && !ulong.TryParse(steamId, out _))
            {
                MessageBox.Show(this, "SteamID64 must contain digits only.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                steamIdTextBox.Focus();
                return;
            }

            if ((string.IsNullOrWhiteSpace(steamKeyTextBox.Text) != string.IsNullOrWhiteSpace(steamId)))
            {
                MessageBox.Show(this, "To import your library, enter both your Steam API key and SteamID64.", "Incomplete configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Settings = new AppSettings
            {
                SteamApiKey = steamKeyTextBox.Text.Trim(),
                SteamId64 = steamId,
                SteamSessionToken = steamSessionTokenTextBox.Text.Trim(),
                ItadApiKey = itadKeyTextBox.Text.Trim(),
                CountryCode = countryComboBox.SelectedIndex switch { 1 => "US", 2 => "PT", _ => "BR" }
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
