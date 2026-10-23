using SteamManager.Models;

namespace SteamManager
{
    public partial class HltbMatchForm : Form
    {
        public HowLongToBeatMatch? SelectedMatch { get; private set; }

        public HltbMatchForm(string steamGameName, IReadOnlyList<HowLongToBeatMatch> matches)
        {
            InitializeComponent();
            titleLabel.Text = $"Results for: {steamGameName}";
            matchesGrid.DataSource = matches.ToList();
            if (matchesGrid.Rows.Count > 0)
                matchesGrid.Rows[0].Selected = true;
            selectButton.Enabled = matchesGrid.Rows.Count > 0;
            noResultsLabel.Visible = matchesGrid.Rows.Count == 0;
        }

        private void selectButton_Click(object? sender, EventArgs e)
        {
            SelectedMatch = matchesGrid.CurrentRow?.DataBoundItem as HowLongToBeatMatch;
            if (SelectedMatch is not null)
                DialogResult = DialogResult.OK;
        }

        private void matchesGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectButton_Click(sender, EventArgs.Empty);
        }
    }
}
