using SteamManager.Models;
using SteamManager.Services;
using System.IO.Compression;
using System.Globalization;
using System.Xml;
using System.Text;
using System.Text.Json;

namespace SteamManager
{
    public partial class MainForm : Form
    {
        private const string SpreadsheetNamespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        private const string PackageRelationshipsNamespace = "http://schemas.openxmlformats.org/package/2006/relationships";
        private const string ContentTypesNamespace = "http://schemas.openxmlformats.org/package/2006/content-types";
        private readonly SettingsStore settingsStore = new();
        private readonly SteamApiClient steamApiClient = new();
        private readonly SteamLibraryStore steamLibraryStore = new();
        private readonly HowLongToBeatClient howLongToBeatClient = new();
        private readonly HowLongToBeatStore howLongToBeatStore = new();
        private readonly GridColumnVisibilityStore gridColumnVisibilityStore = new();
        private readonly SteamCollectionsStore steamCollectionsStore = new();
        private readonly SteamCollectionsImportService steamCollectionsImportService = new();
        private readonly Dictionary<uint, HowLongToBeatCacheEntry> howLongToBeatMatches;
        private SteamCollectionsSnapshot? collectionsSnapshot;
        private ListBox collectionListBox = null!;
        private DataGridView collectionGamesGrid = null!;
        private Label collectionInfoLabel = null!;
        private Label selectedCollectionLabel = null!;
        private Button importCollectionsButton = null!;
        private CancellationTokenSource? bulkHltbSearchCts;
        private List<SteamGame> libraryGames = new();
        private List<SteamGame> visibleGames = new();
        private DateTime? lastSyncTime;
        private string syncNotice = string.Empty;
        private bool loadedLibraryFromCache;
        private string? gridSortColumnName;
        private bool gridSortAscending;
        private bool isUpdatingSortCombo;

        public MainForm()
        {
            InitializeComponent();
            InitializeCollectionsView();
            howLongToBeatMatches = howLongToBeatStore.Load();
            ApplySavedGridColumnVisibility();
            var savedLibrary = steamLibraryStore.Load();
            if (savedLibrary is not null && savedLibrary.Games.Count > 0)
            {
                libraryGames = savedLibrary.Games;
                lastSyncTime = savedLibrary.SynchronizedAt;
                loadedLibraryFromCache = true;
                ApplyCachedHowLongToBeatData(libraryGames);
            }
            collectionsSnapshot = steamCollectionsStore.Load();
            RefreshCollectionsView();
            ShowPage("Library");
        }

        private void InitializeCollectionsView()
        {
            collectionsPage.Controls.Clear();
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = collectionsPage.BackColor,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(24, 20, 24, 16)
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 76));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var header = new Panel { Dock = DockStyle.Fill };
            importCollectionsButton = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(102, 192, 244),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 22, 32),
                Size = new Size(170, 38),
                Text = "Import from Steam",
                UseVisualStyleBackColor = false
            };
            importCollectionsButton.FlatAppearance.BorderSize = 0;
            importCollectionsButton.Location = new Point(Math.Max(0, header.ClientSize.Width - importCollectionsButton.Width), 0);
            importCollectionsButton.Click += importCollectionsButton_Click;
            header.Resize += (_, _) => importCollectionsButton.Location = new Point(Math.Max(0, header.ClientSize.Width - importCollectionsButton.Width), 0);

            var heading = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(225, 234, 243),
                Location = new Point(0, 0),
                Size = new Size(440, 26),
                Text = "Your Steam collections"
            };
            collectionInfoLabel = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(160, 177, 194),
                Location = new Point(0, 31),
                Size = new Size(580, 25),
                Text = "Import collections saved by the Steam client."
            };
            header.Controls.Add(heading);
            header.Controls.Add(collectionInfoLabel);
            header.Controls.Add(importCollectionsButton);

            var split = new SplitContainer
            {
                BackColor = Color.FromArgb(35, 49, 65),
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                MinimumSize = new Size(0, 180),
                SplitterDistance = 250,
                SplitterWidth = 2
            };
            var listLayout = new TableLayoutPanel { BackColor = Color.FromArgb(20, 29, 41), Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(12) };
            listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var listHeading = new Label { Dock = DockStyle.Fill, Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(160, 177, 194), Text = "COLLECTIONS", TextAlign = ContentAlignment.MiddleLeft };
            collectionListBox = new ListBox
            {
                BackColor = Color.FromArgb(20, 29, 41),
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(225, 234, 243),
                IntegralHeight = false
            };
            collectionListBox.Format += (_, eventArgs) =>
            {
                if (eventArgs.ListItem is SteamCollection collection)
                    eventArgs.Value = $"{collection.Name}  ({collection.AppIds.Count})";
            };
            collectionListBox.SelectedIndexChanged += collectionListBox_SelectedIndexChanged;
            listLayout.Controls.Add(listHeading, 0, 0);
            listLayout.Controls.Add(collectionListBox, 0, 1);
            split.Panel1.Controls.Add(listLayout);

            var gamesLayout = new TableLayoutPanel { BackColor = Color.FromArgb(15, 22, 32), Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(16, 10, 0, 0) };
            gamesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            gamesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            selectedCollectionLabel = new Label { Dock = DockStyle.Fill, Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(225, 234, 243), Text = "Select a collection", TextAlign = ContentAlignment.MiddleLeft };
            collectionGamesGrid = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(20, 29, 41),
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeight = 38,
                Dock = DockStyle.Fill,
                EnableHeadersVisualStyles = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            collectionGamesGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 49, 65);
            collectionGamesGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(225, 234, 243);
            collectionGamesGrid.DefaultCellStyle.BackColor = Color.FromArgb(20, 29, 41);
            collectionGamesGrid.DefaultCellStyle.ForeColor = Color.FromArgb(225, 234, 243);
            collectionGamesGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 75, 98);
            collectionGamesGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            collectionGamesGrid.GridColor = Color.FromArgb(35, 49, 65);
            collectionGamesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CollectionGameRow.Name), FillWeight = 78, HeaderText = "Game", ReadOnly = true, Name = "collectionGameNameColumn" });
            collectionGamesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CollectionGameRow.AppId), FillWeight = 22, HeaderText = "AppID", ReadOnly = true, Name = "collectionGameAppIdColumn" });
            gamesLayout.Controls.Add(selectedCollectionLabel, 0, 0);
            gamesLayout.Controls.Add(collectionGamesGrid, 0, 1);
            split.Panel2.Controls.Add(gamesLayout);

            layout.Controls.Add(header, 0, 0);
            layout.Controls.Add(split, 0, 1);
            collectionsPage.Controls.Add(layout);
        }

        private void RefreshCollectionsView()
        {
            var selectedId = (collectionListBox.SelectedItem as SteamCollection)?.Id;
            var collections = collectionsSnapshot?.Collections ?? new List<SteamCollection>();

            var selectedFilterId = (collectionFilterComboBox.SelectedItem as CollectionFilterOption)?.Id;
            var collectionFilterOptions = new List<CollectionFilterOption>
            {
                new() { Id = string.Empty, Name = "All collections" }
            };
            collectionFilterOptions.AddRange(collections
                .OrderBy(collection => collection.Name, StringComparer.CurrentCultureIgnoreCase)
                .Select(collection => new CollectionFilterOption { Id = collection.Id, Name = collection.Name }));
            collectionFilterComboBox.DataSource = null;
            collectionFilterComboBox.DisplayMember = nameof(CollectionFilterOption.Name);
            collectionFilterComboBox.DataSource = collectionFilterOptions;
            collectionFilterComboBox.SelectedItem = collectionFilterOptions.FirstOrDefault(option => option.Id == selectedFilterId)
                ?? collectionFilterOptions[0];

            collectionListBox.DataSource = null;
            collectionListBox.DisplayMember = nameof(SteamCollection.Name);
            collectionListBox.DataSource = collections;

            if (selectedId is not null)
                collectionListBox.SelectedItem = collections.FirstOrDefault(collection => collection.Id == selectedId);
            if (collectionListBox.SelectedIndex < 0 && collections.Count > 0)
                collectionListBox.SelectedIndex = 0;

            collectionInfoLabel.Text = collections.Count == 0
                ? "Import collections saved by the Steam client."
                : $"{collections.Count:N0} collections · imported {collectionsSnapshot!.ImportedAt:dd/MM/yyyy HH:mm}";
            UpdateSelectedCollection();
        }

        private void collectionListBox_SelectedIndexChanged(object? sender, EventArgs e) => UpdateSelectedCollection();

        private void UpdateSelectedCollection()
        {
            if (collectionListBox.SelectedItem is not SteamCollection collection)
            {
                selectedCollectionLabel.Text = "Select a collection";
                collectionGamesGrid.DataSource = null;
                return;
            }

            var libraryById = libraryGames.GroupBy(game => game.AppId).ToDictionary(group => group.Key, group => group.First());
            var rows = collection.AppIds
                .Distinct()
                .Order()
                .Select(appId => new CollectionGameRow
                {
                    AppId = appId,
                    Name = libraryById.TryGetValue(appId, out var game) ? game.Name : $"App {appId} (not in the synced library)"
                })
                .ToList();
            var dynamicNote = collection.IsDynamic ? " · dynamic collection (members may depend on Steam filters)" : string.Empty;
            selectedCollectionLabel.Text = $"{collection.Name} · {rows.Count:N0} games{dynamicNote}";
            collectionGamesGrid.DataSource = rows;
        }

        private void importCollectionsButton_Click(object? sender, EventArgs e)
        {
            var settings = settingsStore.Load();
            if (string.IsNullOrWhiteSpace(settings.SteamId64))
            {
                MessageBox.Show(this, "Enter your SteamID64 in Settings to identify the correct account in this Steam installation.", "SteamID64 required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                settingsButton_Click(sender, e);
                return;
            }

            var installations = SteamCollectionsImportService.FindSteamInstallations();
            using var dialog = new FolderBrowserDialog
            {
                Description = "Select the Steam installation folder that contains userdata.",
                ShowNewFolderButton = false,
                SelectedPath = installations.FirstOrDefault() ?? string.Empty
            };
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            importCollectionsButton.Enabled = false;
            importCollectionsButton.Text = "Importing…";
            try
            {
                var snapshot = steamCollectionsImportService.Import(dialog.SelectedPath, settings.SteamId64);
                steamCollectionsStore.Save(snapshot);
                collectionsSnapshot = snapshot;
                RefreshCollectionsView();
                MessageBox.Show(this, $"Successfully imported {snapshot.Collections.Count:N0} collections.", "Import complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException or System.Security.SecurityException or ArgumentException)
            {
                MessageBox.Show(this, ex.Message, "Could not import collections", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                importCollectionsButton.Enabled = true;
                importCollectionsButton.Text = "Import from Steam";
            }
        }

        private sealed class CollectionGameRow
        {
            public uint AppId { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        private sealed class CollectionFilterOption
        {
            public string Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
        }

        private void ShowPage(string page)
        {
            libraryPage.Visible = page == "Library";
            collectionsPage.Visible = page == "Collections";
            wishlistPage.Visible = page == "Wishlist";
            pricesPage.Visible = page == "Prices";
            libraryPage.BringToFront();
            if (page == "Collections") collectionsPage.BringToFront();
            if (page == "Wishlist") wishlistPage.BringToFront();
            if (page == "Prices") pricesPage.BringToFront();

            pageTitleLabel.Text = page;
            syncButton.Visible = page == "Library";
            columnOptionsButton.Visible = page == "Library";
            exportButton.Visible = page == "Library";

            if (page == "Library")
            {
                if (libraryGames.Count > 0)
                    ApplyLibraryFilters();
                else
                {
                    var settings = settingsStore.Load();
                    statusLabel.Text = settings.HasSteamConfiguration
                        ? "Ready to sync your Steam library."
                        : "Set your Steam API key and SteamID64 to import your games.";
                }
            }
        }

        private void libraryButton_Click(object? sender, EventArgs e) => ShowPage("Library");
        private void collectionsButton_Click(object? sender, EventArgs e) => ShowPage("Collections");
        private void wishlistButton_Click(object? sender, EventArgs e) => ShowPage("Wishlist");
        private void pricesButton_Click(object? sender, EventArgs e) => ShowPage("Prices");

        private void libraryFilters_Changed(object? sender, EventArgs e)
        {
            if (sender == sortComboBox && !isUpdatingSortCombo)
                gridSortColumnName = null;
            ApplyLibraryFilters();
        }

        private void gamesGrid_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= gamesGrid.Columns.Count)
                return;

            var columnName = gamesGrid.Columns[e.ColumnIndex].Name;
            if (gridSortColumnName == columnName)
                gridSortAscending = !gridSortAscending;
            else
            {
                gridSortColumnName = columnName;
                gridSortAscending = true;
            }

            if (sortComboBox.SelectedIndex != 0)
            {
                isUpdatingSortCombo = true;
                sortComboBox.SelectedIndex = 0;
                isUpdatingSortCombo = false;
            }

            ApplyLibraryFilters();
        }

        private void columnOptionsButton_Click(object? sender, EventArgs e)
        {
            columnMenu.Show(columnOptionsButton, new Point(0, columnOptionsButton.Height));
        }

        private void exportButton_Click(object? sender, EventArgs e)
        {
            var visibleColumns = gamesGrid.Columns.Cast<DataGridViewColumn>()
                .Where(column => column.Visible)
                .OrderBy(column => column.DisplayIndex)
                .ToList();
            if (visibleColumns.Count == 0)
            {
                MessageBox.Show(this, "Show at least one grid column before exporting.", "Nothing to export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "xlsx",
                FileName = $"SteamLibrary-{DateTime.Now:yyyyMMdd-HHmm}.xlsx",
                Filter = "Excel workbook (*.xlsx)|*.xlsx",
                OverwritePrompt = true
            };
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                ExportCurrentGridToExcel(dialog.FileName, visibleColumns);
                statusLabel.Text = $"Exported {gamesGrid.Rows.Count:N0} games to {Path.GetFileName(dialog.FileName)}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"The Excel file could not be created.\n\nDetails: {ex.Message}", "Export failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportCurrentGridToExcel(string path, IReadOnlyList<DataGridViewColumn> columns)
        {
            using var file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using var archive = new ZipArchive(file, ZipArchiveMode.Create);
            WriteExcelPart(archive, "[Content_Types].xml", writer =>
            {
                writer.WriteStartElement("Types", ContentTypesNamespace);
                writer.WriteStartElement("Default", ContentTypesNamespace);
                writer.WriteAttributeString("Extension", "rels");
                writer.WriteAttributeString("ContentType", "application/vnd.openxmlformats-package.relationships+xml");
                writer.WriteEndElement();
                writer.WriteStartElement("Default", ContentTypesNamespace);
                writer.WriteAttributeString("Extension", "xml");
                writer.WriteAttributeString("ContentType", "application/xml");
                writer.WriteEndElement();
                writer.WriteStartElement("Override", ContentTypesNamespace);
                writer.WriteAttributeString("PartName", "/xl/workbook.xml");
                writer.WriteAttributeString("ContentType", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
                writer.WriteEndElement();
                writer.WriteStartElement("Override", ContentTypesNamespace);
                writer.WriteAttributeString("PartName", "/xl/worksheets/sheet1.xml");
                writer.WriteAttributeString("ContentType", "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml");
                writer.WriteEndElement();
                writer.WriteEndElement();
            });
            WriteExcelPart(archive, "_rels/.rels", writer =>
            {
                writer.WriteStartElement("Relationships", PackageRelationshipsNamespace);
                writer.WriteStartElement("Relationship", PackageRelationshipsNamespace);
                writer.WriteAttributeString("Id", "rId1");
                writer.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
                writer.WriteAttributeString("Target", "xl/workbook.xml");
                writer.WriteEndElement();
                writer.WriteEndElement();
            });
            WriteExcelPart(archive, "xl/workbook.xml", writer =>
            {
                writer.WriteStartElement("workbook", SpreadsheetNamespace);
                writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
                writer.WriteStartElement("sheets", SpreadsheetNamespace);
                writer.WriteStartElement("sheet", SpreadsheetNamespace);
                writer.WriteAttributeString("name", "Steam Library");
                writer.WriteAttributeString("sheetId", "1");
                writer.WriteAttributeString("r", "id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", "rId1");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
            });
            WriteExcelPart(archive, "xl/_rels/workbook.xml.rels", writer =>
            {
                writer.WriteStartElement("Relationships", PackageRelationshipsNamespace);
                writer.WriteStartElement("Relationship", PackageRelationshipsNamespace);
                writer.WriteAttributeString("Id", "rId1");
                writer.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet");
                writer.WriteAttributeString("Target", "worksheets/sheet1.xml");
                writer.WriteEndElement();
                writer.WriteEndElement();
            });
            WriteExcelPart(archive, "xl/worksheets/sheet1.xml", writer =>
            {
                writer.WriteStartElement("worksheet", SpreadsheetNamespace);
                writer.WriteStartElement("sheetData", SpreadsheetNamespace);
                WriteExcelRow(writer, 1, columns.Select(column => (object?)column.HeaderText).ToList());

                var rowNumber = 2;
                foreach (DataGridViewRow row in gamesGrid.Rows)
                {
                    if (row.IsNewRow || row.DataBoundItem is not SteamGame game)
                        continue;
                    var values = columns.Select(column => GetExcelExportValue(column, game, row)).ToList();
                    WriteExcelRow(writer, rowNumber++, values);
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            });
        }

        private static void WriteExcelPart(ZipArchive archive, string partName, Action<XmlWriter> writeContent)
        {
            var entry = archive.CreateEntry(partName, CompressionLevel.Optimal);
            using var stream = entry.Open();
            using var writer = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = new UTF8Encoding(false), CloseOutput = false });
            writer.WriteStartDocument();
            writeContent(writer);
            writer.WriteEndDocument();
        }

        private static object? GetExcelExportValue(DataGridViewColumn column, SteamGame game, DataGridViewRow row)
        {
            return column.DataPropertyName switch
            {
                nameof(SteamGame.HltbMainDisplay) => game.HltbMainHours,
                nameof(SteamGame.Name) => game.Name,
                nameof(SteamGame.SourceDisplay) => game.SourceDisplay,
                nameof(SteamGame.PlaytimeDisplay) => game.PlaytimeDisplay,
                nameof(SteamGame.LastPlayedDisplay) => game.LastPlayedDisplay,
                _ => row.Cells[column.Index].FormattedValue?.ToString()
            };
        }

        private static void WriteExcelRow(XmlWriter writer, int rowNumber, IReadOnlyList<object?> values)
        {
            writer.WriteStartElement("row", SpreadsheetNamespace);
            writer.WriteAttributeString("r", rowNumber.ToString(CultureInfo.InvariantCulture));
            for (var columnIndex = 0; columnIndex < values.Count; columnIndex++)
            {
                var value = values[columnIndex];
                if (value is null)
                    continue;

                writer.WriteStartElement("c", SpreadsheetNamespace);
                writer.WriteAttributeString("r", ExcelColumnName(columnIndex + 1) + rowNumber.ToString(CultureInfo.InvariantCulture));
                if (value is string text)
                {
                    writer.WriteAttributeString("t", "inlineStr");
                    writer.WriteStartElement("is", SpreadsheetNamespace);
                    writer.WriteStartElement("t", SpreadsheetNamespace);
                    writer.WriteAttributeString("xml", "space", "http://www.w3.org/XML/1998/namespace", "preserve");
                    writer.WriteString(text);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                else if (value is IFormattable number)
                {
                    writer.WriteStartElement("v", SpreadsheetNamespace);
                    writer.WriteString(number.ToString(null, CultureInfo.InvariantCulture));
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteAttributeString("t", "inlineStr");
                    writer.WriteStartElement("is", SpreadsheetNamespace);
                    writer.WriteElementString("t", SpreadsheetNamespace, value.ToString() ?? string.Empty);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private static string ExcelColumnName(int columnNumber)
        {
            var name = string.Empty;
            while (columnNumber > 0)
            {
                columnNumber--;
                name = (char)('A' + columnNumber % 26) + name;
                columnNumber /= 26;
            }
            return name;
        }

        private void gridColumnMenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem || menuItem.Tag is not string columnName)
                return;
            if (!gamesGrid.Columns.Contains(columnName))
                return;

            gamesGrid.Columns[columnName]!.Visible = menuItem.Checked;
            try
            {
                var hiddenColumns = gamesGrid.Columns.Cast<DataGridViewColumn>()
                    .Where(column => !column.Visible)
                    .Select(column => column.Name);
                gridColumnVisibilityStore.SaveHiddenColumns(hiddenColumns);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this, $"The column was changed, but this preference could not be saved.\n\nDetails: {ex.Message}", "Preference not saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplySavedGridColumnVisibility()
        {
            var hiddenColumns = gridColumnVisibilityStore.LoadHiddenColumns();
            foreach (var menuItem in columnMenu.Items.OfType<ToolStripMenuItem>())
            {
                if (menuItem.Tag is not string columnName || !gamesGrid.Columns.Contains(columnName))
                    continue;
                var visible = !hiddenColumns.Contains(columnName);
                gamesGrid.Columns[columnName]!.Visible = visible;
                menuItem.Checked = visible;
            }
        }

        private void ApplyLibraryFilters()
        {
            IEnumerable<SteamGame> filtered = libraryGames;
            var search = searchTextBox.Text.Trim();
            if (search.Length > 0)
                filtered = filtered.Where(game => game.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase));

            filtered = sourceFilterComboBox.SelectedIndex switch
            {
                1 => filtered.Where(game => !game.IsFamilyShared),
                2 => filtered.Where(game => game.IsFamilyShared),
                _ => filtered
            };

            filtered = playedFilterComboBox.SelectedIndex switch
            {
                1 => filtered.Where(game => game.PlaytimeKnown && game.PlaytimeForever == 0),
                2 => filtered.Where(game => game.PlaytimeKnown && game.PlaytimeForever > 0),
                3 => filtered.Where(game => !game.PlaytimeKnown),
                _ => filtered
            };

            if (collectionFilterComboBox.SelectedItem is CollectionFilterOption { Id.Length: > 0 } selectedCollection)
            {
                var collectionAppIds = collectionsSnapshot?.Collections
                    .FirstOrDefault(collection => collection.Id == selectedCollection.Id)?
                    .AppIds
                    .ToHashSet() ?? new HashSet<uint>();
                filtered = filtered.Where(game => collectionAppIds.Contains(game.AppId));
            }

            var invalidHltbBounds = false;
            var minHltbHours = ParseOptionalHoursFilter(hltbMinHoursTextBox.Text, ref invalidHltbBounds);
            var maxHltbHours = ParseOptionalHoursFilter(hltbMaxHoursTextBox.Text, ref invalidHltbBounds);
            if (minHltbHours is { } minimum)
                filtered = filtered.Where(game => game.HltbMainHours is { } hours && hours >= minimum);
            if (maxHltbHours is { } maximum)
                filtered = filtered.Where(game => game.HltbMainHours is { } hours && hours <= maximum);

            filtered = gridSortColumnName is not null
                ? SortByGridColumn(filtered)
                : sortComboBox.SelectedIndex switch
            {
                1 => filtered.OrderByDescending(game => game.PlaytimeForever).ThenBy(game => game.Name),
                2 => filtered.OrderBy(game => !game.PlaytimeKnown).ThenBy(game => game.PlaytimeForever).ThenBy(game => game.Name),
                3 => filtered.OrderByDescending(game => game.RTimeLastPlayed).ThenBy(game => game.Name),
                4 => filtered.OrderBy(game => !game.PlaytimeKnown).ThenBy(game => game.RTimeLastPlayed == 0 ? long.MinValue : game.RTimeLastPlayed).ThenBy(game => game.Name),
                5 => filtered.OrderBy(game => game.HltbMainHours is null).ThenBy(game => game.HltbMainHours).ThenBy(game => game.Name),
                6 => filtered.OrderBy(game => game.HltbMainHours is null).ThenByDescending(game => game.HltbMainHours).ThenBy(game => game.Name),
                _ => filtered.OrderBy(game => game.Name, StringComparer.CurrentCultureIgnoreCase)
            };

            visibleGames = filtered.ToList();
            gamesGrid.DataSource = null;
            gamesGrid.DataSource = visibleGames;
            foreach (DataGridViewColumn column in gamesGrid.Columns)
                column.HeaderCell.SortGlyphDirection = column.Name == gridSortColumnName
                    ? gridSortAscending ? SortOrder.Ascending : SortOrder.Descending
                    : SortOrder.None;
            var summary = lastSyncTime is null
                ? $"Showing {visibleGames.Count:N0} of {libraryGames.Count:N0} games."
                : $"Showing {visibleGames.Count:N0} of {libraryGames.Count:N0} games. Synced {lastSyncTime.Value:dd/MM/yyyy HH:mm}.";
            if (loadedLibraryFromCache)
                summary += " Showing locally saved data.";
            if (howLongToBeatStore.LastBulkSearchAtUtc is { } lastHltbBatch)
                summary += $" Last HLTB batch search: {lastHltbBatch.ToLocalTime():dd/MM/yyyy HH:mm}.";
            if (invalidHltbBounds)
                summary += " Enter valid numbers for the HLTB hour filters.";
            statusLabel.Text = string.IsNullOrWhiteSpace(syncNotice) ? summary : $"{summary} {syncNotice}";
        }

        private static double? ParseOptionalHoursFilter(string text, ref bool invalid)
        {
            var trimmed = text.Trim();
            if (trimmed.Length == 0)
                return null;

            if ((double.TryParse(trimmed, NumberStyles.Float, CultureInfo.CurrentCulture, out var hours)
                || double.TryParse(trimmed, NumberStyles.Float, CultureInfo.InvariantCulture, out hours))
                && double.IsFinite(hours)
                && hours >= 0)
                return hours;

            invalid = true;
            return null;
        }

        private IEnumerable<SteamGame> SortByGridColumn(IEnumerable<SteamGame> games)
        {
            var ascending = gridSortAscending;
            return gridSortColumnName switch
            {
                "gameNameColumn" => ascending
                    ? games.OrderBy(game => game.Name, StringComparer.CurrentCultureIgnoreCase)
                    : games.OrderByDescending(game => game.Name, StringComparer.CurrentCultureIgnoreCase),
                "sourceColumn" => ascending
                    ? games.OrderBy(game => game.IsFamilyShared).ThenBy(game => game.Name)
                    : games.OrderByDescending(game => game.IsFamilyShared).ThenBy(game => game.Name),
                "playtimeColumn" => ascending
                    ? games.OrderBy(game => !game.PlaytimeKnown).ThenBy(game => game.PlaytimeForever).ThenBy(game => game.Name)
                    : games.OrderBy(game => !game.PlaytimeKnown).ThenByDescending(game => game.PlaytimeForever).ThenBy(game => game.Name),
                "lastPlayedColumn" => ascending
                    ? games.OrderBy(game => !game.PlaytimeKnown).ThenBy(game => game.RTimeLastPlayed).ThenBy(game => game.Name)
                    : games.OrderBy(game => !game.PlaytimeKnown).ThenByDescending(game => game.RTimeLastPlayed).ThenBy(game => game.Name),
                "hltbMainColumn" => ascending
                    ? games.OrderBy(game => game.HltbMainHours is null).ThenBy(game => game.HltbMainHours).ThenBy(game => game.Name)
                    : games.OrderBy(game => game.HltbMainHours is null).ThenByDescending(game => game.HltbMainHours).ThenBy(game => game.Name),
                _ => games.OrderBy(game => game.Name, StringComparer.CurrentCultureIgnoreCase)
            };
        }

        private void randomGameButton_Click(object? sender, EventArgs e)
        {
            if (visibleGames.Count == 0)
            {
                MessageBox.Show(this, "No games match the current filters.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedGame = visibleGames[Random.Shared.Next(visibleGames.Count)];
            var row = gamesGrid.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(item => item.DataBoundItem is SteamGame game && game.AppId == selectedGame.AppId);
            if (row is not null)
            {
                gamesGrid.ClearSelection();
                row.Selected = true;
                gamesGrid.FirstDisplayedScrollingRowIndex = row.Index;
            }

            var hltbLine = selectedGame.HltbMainHours is null ? string.Empty : $"\nHowLongToBeat main story: {selectedGame.HltbMainDisplay}";
            MessageBox.Show(this,
                $"Random pick:\n\n{selectedGame.Name}\nSource: {selectedGame.SourceDisplay}\nPlaytime: {selectedGame.PlaytimeDisplay}{hltbLine}",
                "Random game",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void hltbSearchButton_Click(object? sender, EventArgs e)
        {
            if (gamesGrid.CurrentRow?.DataBoundItem is not SteamGame selectedGame)
            {
                MessageBox.Show(this, "Select a game from your library first.", "No game selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                IReadOnlyList<HowLongToBeatMatch> matches;
                if (howLongToBeatMatches.TryGetValue(selectedGame.AppId, out var cachedEntry))
                {
                    matches = cachedEntry.SearchResults;
                    if (matches.Count == 0)
                    {
                        MessageBox.Show(this,
                            $"This game was already searched on {cachedEntry.SearchedAtUtc.ToLocalTime():dd/MM/yyyy HH:mm}, but HowLongToBeat returned no results. It will not be searched again automatically.",
                            "Search already cached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    hltbSearchButton.Enabled = false;
                    hltbSearchButton.Text = "Searching…";
                    statusLabel.Text = $"Searching HowLongToBeat for {selectedGame.Name}…";
                    matches = await howLongToBeatClient.SearchAsync(selectedGame.Name);
                    cachedEntry = new HowLongToBeatCacheEntry { SearchResults = matches.ToList() };
                    howLongToBeatMatches[selectedGame.AppId] = cachedEntry;
                    howLongToBeatStore.Save(howLongToBeatMatches);
                }

                using var dialog = new HltbMatchForm(selectedGame.Name, matches);
                if (dialog.ShowDialog(this) == DialogResult.OK && dialog.SelectedMatch is { } match)
                {
                    var entry = howLongToBeatMatches[selectedGame.AppId];
                    entry.Match = match;
                    entry.SearchedAtUtc = DateTime.UtcNow;
                    howLongToBeatStore.Save(howLongToBeatMatches);
                    ApplyHltbMatch(selectedGame, match);
                    ApplyLibraryFilters();
                    statusLabel.Text = $"HowLongToBeat data linked to {selectedGame.Name}: {match.Name}.";
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(this,
                    $"Could not query HowLongToBeat. The site may have changed its search or may be temporarily unavailable.\n\nDetails: {ex.Message}",
                    "HowLongToBeat search failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusLabel.Text = "HowLongToBeat search failed.";
            }
            catch (Exception ex) when (ex is InvalidOperationException or System.Text.Json.JsonException or TaskCanceledException or IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this,
                    $"Could not process the HowLongToBeat response.\n\nDetails: {ex.Message}",
                    "HowLongToBeat search failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusLabel.Text = "The HowLongToBeat response could not be processed.";
            }
            finally
            {
                hltbSearchButton.Enabled = true;
                hltbSearchButton.Text = "Search HowLongToBeat";
            }
        }

        private async void bulkHltbSearchButton_Click(object? sender, EventArgs e)
        {
            if (bulkHltbSearchCts is not null)
            {
                bulkHltbSearchCts.Cancel();
                bulkHltbSearchButton.Text = "Cancelling…";
                return;
            }

            if (libraryGames.Count == 0)
            {
                MessageBox.Show(this, "Sync your Steam library before searching for playtimes.", "Library is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var gamesToSearch = libraryGames.Where(game => !howLongToBeatMatches.ContainsKey(game.AppId)).ToList();
            if (gamesToSearch.Count == 0)
            {
                statusLabel.Text = "All games in this library have already been searched and are in the local cache.";
                return;
            }

            var estimated = TimeSpan.FromMilliseconds(gamesToSearch.Count * 1100L);
            var estimatedText = estimated.TotalHours >= 1
                ? $"about {estimated.Hours + estimated.Days * 24}h{estimated.Minutes:00}"
                : $"about {Math.Max(1, (int)Math.Ceiling(estimated.TotalMinutes))} min";
            var answer = MessageBox.Show(this,
                $"{gamesToSearch.Count:N0} games that have not been searched yet will be queried. The estimate is {estimatedText}, with a delay between requests. Results, including searches without an exact match, will be saved. If you cancel, the next run will continue with pending games.\n\nStart now?",
                "Search library on HowLongToBeat", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (answer != DialogResult.Yes) return;

            var total = gamesToSearch.Count;
            var foundCount = 0;
            var noExactMatchCount = 0;
            var completed = 0;
            string? failureMessage = null;
            bulkHltbSearchCts = new CancellationTokenSource();
            var cancellationToken = bulkHltbSearchCts.Token;
            bulkHltbSearchButton.Text = "Cancel search";
            hltbSearchButton.Enabled = false;
            syncButton.Enabled = false;
            try
            {
                howLongToBeatStore.MarkBulkSearchStarted();
                howLongToBeatStore.Save(howLongToBeatMatches);
                foreach (var game in gamesToSearch)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    try
                    {
                        var results = await howLongToBeatClient.SearchAsync(game.Name, cancellationToken);
                        var exactMatch = results.FirstOrDefault(result => NormalizeGameName(result.Name) == NormalizeGameName(game.Name));
                        var entry = new HowLongToBeatCacheEntry
                        {
                            SearchedAtUtc = DateTime.UtcNow,
                            Match = exactMatch,
                            SearchResults = results.ToList()
                        };
                        howLongToBeatMatches[game.AppId] = entry;
                        howLongToBeatStore.Save(howLongToBeatMatches);
                        if (exactMatch is null)
                            noExactMatchCount++;
                        else
                        {
                            ApplyHltbMatch(game, exactMatch);
                            foundCount++;
                        }
                        completed++;
                        statusLabel.Text = $"HowLongToBeat: {completed:N0}/{total:N0} queried · {foundCount:N0} matched · {noExactMatchCount:N0} without an exact name match.";
                        bulkHltbSearchButton.Text = $"Cancel ({completed * 100 / total}%)";
                        if (completed % 20 == 0)
                            ApplyLibraryFilters();
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (HttpRequestException ex)
                    {
                        failureMessage = ex.Message;
                        break;
                    }
                    catch (Exception ex) when (ex is InvalidOperationException or System.Text.Json.JsonException or TaskCanceledException or IOException or UnauthorizedAccessException)
                    {
                        failureMessage = ex.Message;
                        break;
                    }
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                // Keep completed results; uncached games remain pending for the next run.
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                failureMessage = ex.Message;
            }
            finally
            {
                bulkHltbSearchCts.Dispose();
                bulkHltbSearchCts = null;
                bulkHltbSearchButton.Text = "Search all games on HLTB";
                hltbSearchButton.Enabled = true;
                syncButton.Enabled = true;
                ApplyLibraryFilters();
            }

            var pending = libraryGames.Count(game => !howLongToBeatMatches.ContainsKey(game.AppId));
            statusLabel.Text = $"Batch search: {completed:N0}/{total:N0} queried, {foundCount:N0} matched, {noExactMatchCount:N0} without an exact match; {pending:N0} pending.";
            if (failureMessage is not null)
            {
                MessageBox.Show(this,
                    $"The search was paused to preserve access to the website. Previous results are saved and will not be repeated.\n\nDetails: {failureMessage}",
                    "HowLongToBeat search paused", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pending == 0 && !cancellationToken.IsCancellationRequested)
            {
                MessageBox.Show(this,
                    $"Library search complete. {foundCount:N0} games were matched automatically by exact name, and {noExactMatchCount:N0} searches were saved without an automatic match. Use the game's search button to review those results and select a match manually.",
                    "HowLongToBeat search complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void settingsButton_Click(object? sender, EventArgs e)
        {
            using var dialog = new SettingsForm(settingsStore.Load());
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                settingsStore.Save(dialog.Settings);
                ShowPage("Library");
            }
        }

        private async void syncButton_Click(object? sender, EventArgs e)
        {
            var settings = settingsStore.Load();
            if (!settings.HasSteamConfiguration)
            {
                MessageBox.Show(this, "Enter your Steam Web API key and SteamID64 in Settings.", "Configuration required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                settingsButton_Click(sender, e);
                return;
            }

            syncButton.Enabled = false;
            syncButton.Text = "Syncing…";
            statusLabel.Text = "Loading games from Steam…";
            try
            {
                var previouslyCachedFamilyGames = libraryGames.Where(game => game.IsFamilyShared).ToList();
                var games = await steamApiClient.GetOwnedGamesAsync(settings.SteamApiKey, settings.SteamId64);
                ApplyCachedHowLongToBeatData(games);
                syncNotice = string.Empty;
                if (string.IsNullOrWhiteSpace(settings.SteamSessionToken))
                {
                    syncNotice = "Add a temporary session token in Settings to include Steam Families games.";
                    var currentIds = games.Select(game => game.AppId).ToHashSet();
                    foreach (var cachedFamilyGame in previouslyCachedFamilyGames)
                    {
                        if (currentIds.Add(cachedFamilyGame.AppId))
                            games.Add(cachedFamilyGame);
                    }
                    ApplyCachedHowLongToBeatData(games);
                }
                else
                {
                    try
                    {
                        var familyGames = await steamApiClient.GetFamilyLibraryAsync(settings.SteamSessionToken);
                        var ownedIds = games.Select(game => game.AppId).ToHashSet();
                        var addedFamilyCount = 0;
                        foreach (var familyGame in familyGames)
                        {
                            if (ownedIds.Contains(familyGame.AppId))
                                continue;
                            familyGame.IsFamilyShared = true;
                            games.Add(familyGame);
                            addedFamilyCount++;
                        }
                        ApplyCachedHowLongToBeatData(games);
                        syncNotice = familyGames.Count == 0
                            ? "Steam returned no Steam Families games for this session."
                            : $"Added {addedFamilyCount:N0} games from Steam Families.";
                    }
                    catch (FamilyApiException ex)
                    {
                        var currentIds = games.Select(game => game.AppId).ToHashSet();
                        foreach (var cachedFamilyGame in previouslyCachedFamilyGames)
                        {
                            if (currentIds.Add(cachedFamilyGame.AppId))
                                games.Add(cachedFamilyGame);
                        }
                        ApplyCachedHowLongToBeatData(games);
                        syncNotice = "Steam Families games were not loaded: the token expired or is unavailable. Update it in Settings.";
                        MessageBox.Show(this, ex.Message, "Steam Families games not loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                libraryGames = games;
                lastSyncTime = DateTime.Now;
                loadedLibraryFromCache = false;
                steamLibraryStore.Save(libraryGames, lastSyncTime.Value);
                ApplyLibraryFilters();
            }
            catch (SteamApiException ex)
            {
                MessageBox.Show(this, ex.Message, "Could not sync", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusLabel.Text = "Sync failed. Check your profile privacy and settings.";
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(this, "Could not connect to Steam. Check your internet connection and try again.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusLabel.Text = "No connection to Steam.";
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this, $"Could not save data locally.\n\nDetails: {ex.Message}", "Could not save library", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                syncButton.Enabled = true;
                syncButton.Text = "Sync Steam";
            }
        }

        private void ApplyCachedHowLongToBeatData(IEnumerable<SteamGame> games)
        {
            foreach (var game in games)
            {
                if (!howLongToBeatMatches.TryGetValue(game.AppId, out var entry) || entry.Match is null)
                    continue;
                ApplyHltbMatch(game, entry.Match);
            }
        }

        private static void ApplyHltbMatch(SteamGame game, HowLongToBeatMatch match)
        {
            game.HowLongToBeatId = match.GameId;
            game.HowLongToBeatName = match.Name;
            game.HltbMainHours = match.MainHours;
            game.HltbMainExtraHours = match.MainExtraHours;
            game.HltbCompletionistHours = match.CompletionistHours;
        }

        private static string NormalizeGameName(string name)
        {
            var decomposed = name.Normalize(NormalizationForm.FormD);
            return new string(decomposed
                .Where(character => CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark && char.IsLetterOrDigit(character))
                .Select(char.ToLowerInvariant)
                .ToArray());
        }
    }
}
