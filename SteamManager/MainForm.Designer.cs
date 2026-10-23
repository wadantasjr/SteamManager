namespace SteamManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button libraryButton;
        private System.Windows.Forms.Button collectionsButton;
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.Button pricesButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel workspacePanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label pageTitleLabel;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.Button columnOptionsButton;
        private System.Windows.Forms.ContextMenuStrip columnMenu;
        private System.Windows.Forms.ToolStripMenuItem gameNameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playtimeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastPlayedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hltbMainMenuItem;
        private System.Windows.Forms.Panel pagesPanel;
        private System.Windows.Forms.Panel libraryPage;
        private System.Windows.Forms.TableLayoutPanel libraryToolbar;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox sourceFilterComboBox;
        private System.Windows.Forms.ComboBox playedFilterComboBox;
        private System.Windows.Forms.ComboBox collectionFilterComboBox;
        private System.Windows.Forms.ComboBox sortComboBox;
        private System.Windows.Forms.Button randomGameButton;
        private System.Windows.Forms.Button hltbSearchButton;
        private System.Windows.Forms.Button bulkHltbSearchButton;
        private System.Windows.Forms.Label hltbHintLabel;
        private System.Windows.Forms.Panel collectionsPage;
        private System.Windows.Forms.Panel wishlistPage;
        private System.Windows.Forms.Panel pricesPage;
        private System.Windows.Forms.DataGridView gamesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playtimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPlayedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hltbMainColumn;
        private System.Windows.Forms.Label collectionsPlaceholderLabel;
        private System.Windows.Forms.Label wishlistPlaceholderLabel;
        private System.Windows.Forms.Label pricesPlaceholderLabel;
        private System.Windows.Forms.Label statusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            rootLayout = new TableLayoutPanel();
            sidebarPanel = new Panel();
            brandLabel = new Label();
            navigationPanel = new Panel();
            libraryButton = new Button();
            collectionsButton = new Button();
            wishlistButton = new Button();
            pricesButton = new Button();
            settingsButton = new Button();
            workspacePanel = new Panel();
            headerPanel = new Panel();
            pageTitleLabel = new Label();
            syncButton = new Button();
            columnOptionsButton = new Button();
            columnMenu = new ContextMenuStrip(components);
            gameNameMenuItem = new ToolStripMenuItem();
            sourceMenuItem = new ToolStripMenuItem();
            playtimeMenuItem = new ToolStripMenuItem();
            lastPlayedMenuItem = new ToolStripMenuItem();
            hltbMainMenuItem = new ToolStripMenuItem();
            pagesPanel = new Panel();
            libraryPage = new Panel();
            libraryToolbar = new TableLayoutPanel();
            searchTextBox = new TextBox();
            sourceFilterComboBox = new ComboBox();
            playedFilterComboBox = new ComboBox();
            collectionFilterComboBox = new ComboBox();
            sortComboBox = new ComboBox();
            randomGameButton = new Button();
            hltbSearchButton = new Button();
            bulkHltbSearchButton = new Button();
            hltbHintLabel = new Label();
            gamesGrid = new DataGridView();
            gameNameColumn = new DataGridViewTextBoxColumn();
            sourceColumn = new DataGridViewTextBoxColumn();
            playtimeColumn = new DataGridViewTextBoxColumn();
            lastPlayedColumn = new DataGridViewTextBoxColumn();
            hltbMainColumn = new DataGridViewTextBoxColumn();
            collectionsPage = new Panel();
            collectionsPlaceholderLabel = new Label();
            wishlistPage = new Panel();
            wishlistPlaceholderLabel = new Label();
            pricesPage = new Panel();
            pricesPlaceholderLabel = new Label();
            statusLabel = new Label();
            rootLayout.SuspendLayout();
            sidebarPanel.SuspendLayout();
            navigationPanel.SuspendLayout();
            workspacePanel.SuspendLayout();
            headerPanel.SuspendLayout();
            pagesPanel.SuspendLayout();
            libraryPage.SuspendLayout();
            libraryToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gamesGrid).BeginInit();
            collectionsPage.SuspendLayout();
            wishlistPage.SuspendLayout();
            pricesPage.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.BackColor = Color.FromArgb(15, 22, 32);
            rootLayout.ColumnCount = 2;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(sidebarPanel, 0, 0);
            rootLayout.Controls.Add(workspacePanel, 1, 0);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Margin = new Padding(0);
            rootLayout.RowCount = 1;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(20, 29, 41);
            sidebarPanel.Controls.Add(navigationPanel);
            sidebarPanel.Controls.Add(brandLabel);
            sidebarPanel.Controls.Add(settingsButton);
            sidebarPanel.Dock = DockStyle.Fill;
            sidebarPanel.Padding = new Padding(18, 20, 18, 18);
            // 
            // brandLabel
            // 
            brandLabel.Dock = DockStyle.Top;
            brandLabel.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            brandLabel.ForeColor = Color.FromArgb(102, 192, 244);
            brandLabel.Location = new Point(18, 20);
            brandLabel.Name = "brandLabel";
            brandLabel.Size = new Size(184, 72);
            brandLabel.TabIndex = 0;
            brandLabel.Text = "STEAM\nMANAGER";
            brandLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // navigationPanel
            // 
            navigationPanel.BackColor = Color.FromArgb(20, 29, 41);
            navigationPanel.Controls.Add(libraryButton);
            navigationPanel.Controls.Add(collectionsButton);
            navigationPanel.Controls.Add(wishlistButton);
            navigationPanel.Controls.Add(pricesButton);
            navigationPanel.Dock = DockStyle.Top;
            navigationPanel.Location = new Point(18, 92);
            navigationPanel.Name = "navigationPanel";
            navigationPanel.Size = new Size(184, 212);
            navigationPanel.TabIndex = 1;
            // 
            // libraryButton
            // 
            libraryButton.BackColor = Color.Transparent;
            libraryButton.FlatAppearance.BorderSize = 0;
            libraryButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 49, 65);
            libraryButton.FlatStyle = FlatStyle.Flat;
            libraryButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            libraryButton.ForeColor = Color.FromArgb(225, 234, 243);
            libraryButton.Location = new Point(0, 0);
            libraryButton.Name = "libraryButton";
            libraryButton.Size = new Size(184, 42);
            libraryButton.TabIndex = 0;
            libraryButton.Text = "   Library";
            libraryButton.TextAlign = ContentAlignment.MiddleLeft;
            libraryButton.UseVisualStyleBackColor = false;
            libraryButton.Click += libraryButton_Click;
            // 
            // collectionsButton
            // 
            collectionsButton.BackColor = Color.Transparent;
            collectionsButton.FlatAppearance.BorderSize = 0;
            collectionsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 49, 65);
            collectionsButton.FlatStyle = FlatStyle.Flat;
            collectionsButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            collectionsButton.ForeColor = Color.FromArgb(225, 234, 243);
            collectionsButton.Location = new Point(0, 48);
            collectionsButton.Name = "collectionsButton";
            collectionsButton.Size = new Size(184, 42);
            collectionsButton.TabIndex = 1;
            collectionsButton.Text = "   Collections";
            collectionsButton.TextAlign = ContentAlignment.MiddleLeft;
            collectionsButton.UseVisualStyleBackColor = false;
            collectionsButton.Click += collectionsButton_Click;
            // 
            // wishlistButton
            // 
            wishlistButton.BackColor = Color.Transparent;
            wishlistButton.FlatAppearance.BorderSize = 0;
            wishlistButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 49, 65);
            wishlistButton.FlatStyle = FlatStyle.Flat;
            wishlistButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            wishlistButton.ForeColor = Color.FromArgb(225, 234, 243);
            wishlistButton.Location = new Point(0, 96);
            wishlistButton.Name = "wishlistButton";
            wishlistButton.Size = new Size(184, 42);
            wishlistButton.TabIndex = 2;
            wishlistButton.Text = "   Wishlist";
            wishlistButton.TextAlign = ContentAlignment.MiddleLeft;
            wishlistButton.UseVisualStyleBackColor = false;
            wishlistButton.Click += wishlistButton_Click;
            // 
            // pricesButton
            // 
            pricesButton.BackColor = Color.Transparent;
            pricesButton.FlatAppearance.BorderSize = 0;
            pricesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 49, 65);
            pricesButton.FlatStyle = FlatStyle.Flat;
            pricesButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            pricesButton.ForeColor = Color.FromArgb(225, 234, 243);
            pricesButton.Location = new Point(0, 144);
            pricesButton.Name = "pricesButton";
            pricesButton.Size = new Size(184, 42);
            pricesButton.TabIndex = 3;
            pricesButton.Text = "   Prices";
            pricesButton.TextAlign = ContentAlignment.MiddleLeft;
            pricesButton.UseVisualStyleBackColor = false;
            pricesButton.Click += pricesButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Transparent;
            settingsButton.Dock = DockStyle.Bottom;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 49, 65);
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            settingsButton.ForeColor = Color.FromArgb(225, 234, 243);
            settingsButton.Location = new Point(18, 604);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(184, 42);
            settingsButton.TabIndex = 2;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // workspacePanel
            // 
            workspacePanel.BackColor = Color.FromArgb(15, 22, 32);
            workspacePanel.Controls.Add(pagesPanel);
            workspacePanel.Controls.Add(statusLabel);
            workspacePanel.Controls.Add(headerPanel);
            workspacePanel.Dock = DockStyle.Fill;
            workspacePanel.Padding = new Padding(30, 22, 30, 18);
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(15, 22, 32);
            headerPanel.Controls.Add(pageTitleLabel);
            headerPanel.Controls.Add(columnOptionsButton);
            headerPanel.Controls.Add(syncButton);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(30, 22);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(874, 76);
            headerPanel.TabIndex = 0;
            // 
            // pageTitleLabel
            // 
            pageTitleLabel.AutoSize = true;
            pageTitleLabel.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            pageTitleLabel.ForeColor = Color.FromArgb(232, 238, 245);
            pageTitleLabel.Location = new Point(0, 7);
            pageTitleLabel.Name = "pageTitleLabel";
            pageTitleLabel.Size = new Size(174, 42);
            pageTitleLabel.TabIndex = 0;
            pageTitleLabel.Text = "Library";
            // 
            // syncButton
            // 
            syncButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            syncButton.BackColor = Color.FromArgb(42, 111, 153);
            syncButton.FlatAppearance.BorderSize = 0;
            syncButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(54, 132, 177);
            syncButton.FlatStyle = FlatStyle.Flat;
            syncButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            syncButton.ForeColor = Color.White;
            syncButton.Location = new Point(714, 8);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(160, 40);
            syncButton.TabIndex = 1;
            syncButton.Text = "Sync Steam";
            syncButton.UseVisualStyleBackColor = false;
            syncButton.Click += syncButton_Click;
            // columnOptionsButton
            columnOptionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            columnOptionsButton.BackColor = Color.FromArgb(29, 42, 57);
            columnOptionsButton.FlatAppearance.BorderColor = Color.FromArgb(67, 90, 112);
            columnOptionsButton.FlatStyle = FlatStyle.Flat;
            columnOptionsButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            columnOptionsButton.ForeColor = Color.FromArgb(232, 238, 245);
            columnOptionsButton.Location = new Point(590, 8);
            columnOptionsButton.Name = "columnOptionsButton";
            columnOptionsButton.Size = new Size(108, 40);
            columnOptionsButton.TabIndex = 2;
            columnOptionsButton.Text = "Columns ▾";
            columnOptionsButton.UseVisualStyleBackColor = false;
            columnOptionsButton.Click += columnOptionsButton_Click;
            // columnMenu
            columnMenu.Items.AddRange(new ToolStripItem[] { gameNameMenuItem, sourceMenuItem, playtimeMenuItem, lastPlayedMenuItem, hltbMainMenuItem });
            columnMenu.Name = "columnMenu";
            columnMenu.Size = new Size(181, 114);
            gameNameMenuItem.CheckOnClick = true;
            gameNameMenuItem.Checked = true;
            gameNameMenuItem.Name = "gameNameColumnMenuItem";
            gameNameMenuItem.Tag = "gameNameColumn";
            gameNameMenuItem.Text = "Game";
            gameNameMenuItem.Click += gridColumnMenuItem_Click;
            sourceMenuItem.CheckOnClick = true;
            sourceMenuItem.Checked = true;
            sourceMenuItem.Name = "sourceColumnMenuItem";
            sourceMenuItem.Tag = "sourceColumn";
            sourceMenuItem.Text = "Source";
            sourceMenuItem.Click += gridColumnMenuItem_Click;
            playtimeMenuItem.CheckOnClick = true;
            playtimeMenuItem.Checked = true;
            playtimeMenuItem.Name = "playtimeColumnMenuItem";
            playtimeMenuItem.Tag = "playtimeColumn";
            playtimeMenuItem.Text = "Playtime";
            playtimeMenuItem.Click += gridColumnMenuItem_Click;
            lastPlayedMenuItem.CheckOnClick = true;
            lastPlayedMenuItem.Checked = true;
            lastPlayedMenuItem.Name = "lastPlayedColumnMenuItem";
            lastPlayedMenuItem.Tag = "lastPlayedColumn";
            lastPlayedMenuItem.Text = "Last played";
            lastPlayedMenuItem.Click += gridColumnMenuItem_Click;
            hltbMainMenuItem.CheckOnClick = true;
            hltbMainMenuItem.Checked = true;
            hltbMainMenuItem.Name = "hltbMainColumnMenuItem";
            hltbMainMenuItem.Tag = "hltbMainColumn";
            hltbMainMenuItem.Text = "HLTB main story";
            hltbMainMenuItem.Click += gridColumnMenuItem_Click;
            // 
            // pagesPanel
            // 
            pagesPanel.BackColor = Color.FromArgb(15, 22, 32);
            pagesPanel.Controls.Add(libraryPage);
            pagesPanel.Controls.Add(collectionsPage);
            pagesPanel.Controls.Add(wishlistPage);
            pagesPanel.Controls.Add(pricesPage);
            pagesPanel.Dock = DockStyle.Fill;
            pagesPanel.Location = new Point(30, 98);
            pagesPanel.Name = "pagesPanel";
            pagesPanel.Size = new Size(874, 578);
            pagesPanel.TabIndex = 1;
            // 
            // libraryPage
            // 
            libraryPage.BackColor = Color.FromArgb(15, 22, 32);
            libraryPage.Controls.Add(gamesGrid);
            libraryPage.Controls.Add(libraryToolbar);
            libraryPage.Dock = DockStyle.Fill;
            libraryPage.Location = new Point(0, 0);
            libraryPage.Name = "libraryPage";
            libraryPage.Size = new Size(874, 578);
            libraryPage.TabIndex = 0;
            // 
            // libraryToolbar
            // 
            libraryToolbar.BackColor = Color.FromArgb(15, 22, 32);
            libraryToolbar.ColumnCount = 5;
            libraryToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            libraryToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            libraryToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            libraryToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5F));
            libraryToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5F));
            libraryToolbar.Controls.Add(searchTextBox, 0, 0);
            libraryToolbar.SetColumnSpan(searchTextBox, 4);
            libraryToolbar.Controls.Add(sourceFilterComboBox, 0, 1);
            libraryToolbar.Controls.Add(playedFilterComboBox, 1, 1);
            libraryToolbar.Controls.Add(collectionFilterComboBox, 2, 1);
            libraryToolbar.Controls.Add(sortComboBox, 3, 1);
            libraryToolbar.SetColumnSpan(sortComboBox, 2);
            libraryToolbar.Controls.Add(randomGameButton, 4, 0);
            libraryToolbar.Dock = DockStyle.Top;
            libraryToolbar.Location = new Point(0, 0);
            libraryToolbar.Name = "libraryToolbar";
            libraryToolbar.Padding = new Padding(0, 0, 0, 8);
            libraryToolbar.RowCount = 3;
            libraryToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            libraryToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            libraryToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            libraryToolbar.Size = new Size(874, 128);
            libraryToolbar.TabIndex = 1;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.BackColor = Color.FromArgb(29, 42, 57);
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            searchTextBox.Location = new Point(3, 9);
            searchTextBox.Margin = new Padding(3, 2, 8, 2);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search games by name";
            searchTextBox.Size = new Size(270, 23);
            searchTextBox.TabIndex = 0;
            searchTextBox.TextChanged += libraryFilters_Changed;
            // 
            // playedFilterComboBox
            // 
            playedFilterComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            playedFilterComboBox.BackColor = Color.FromArgb(29, 42, 57);
            playedFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            playedFilterComboBox.ForeColor = Color.FromArgb(232, 238, 245);
            playedFilterComboBox.FormattingEnabled = true;
            playedFilterComboBox.Items.AddRange(new object[] { "Playtime: any", "Not played", "Started", "Playtime unavailable" });
            sourceFilterComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sourceFilterComboBox.BackColor = Color.FromArgb(29, 42, 57);
            sourceFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sourceFilterComboBox.ForeColor = Color.FromArgb(232, 238, 245);
            sourceFilterComboBox.FormattingEnabled = true;
            sourceFilterComboBox.Items.AddRange(new object[] { "All sources", "My account", "Steam Families" });
            sourceFilterComboBox.Location = new Point(3, 57);
            sourceFilterComboBox.Margin = new Padding(3, 2, 8, 2);
            sourceFilterComboBox.Name = "sourceFilterComboBox";
            sourceFilterComboBox.Size = new Size(270, 23);
            sourceFilterComboBox.TabIndex = 1;
            sourceFilterComboBox.SelectedIndex = 0;
            sourceFilterComboBox.SelectedIndexChanged += libraryFilters_Changed;
            // 
            // playedFilterComboBox
            // 
            playedFilterComboBox.Location = new Point(289, 57);
            playedFilterComboBox.Margin = new Padding(8, 2, 8, 2);
            playedFilterComboBox.Name = "playedFilterComboBox";
            playedFilterComboBox.Size = new Size(185, 23);
            playedFilterComboBox.TabIndex = 1;
            playedFilterComboBox.SelectedIndex = 0;
            playedFilterComboBox.SelectedIndexChanged += libraryFilters_Changed;
            //
            // collectionFilterComboBox
            //
            collectionFilterComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            collectionFilterComboBox.BackColor = Color.FromArgb(29, 42, 57);
            collectionFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            collectionFilterComboBox.ForeColor = Color.FromArgb(232, 238, 245);
            collectionFilterComboBox.FormattingEnabled = true;
            collectionFilterComboBox.Location = new Point(495, 57);
            collectionFilterComboBox.Margin = new Padding(8, 2, 8, 2);
            collectionFilterComboBox.Name = "collectionFilterComboBox";
            collectionFilterComboBox.Size = new Size(185, 23);
            collectionFilterComboBox.TabIndex = 2;
            collectionFilterComboBox.SelectedIndexChanged += libraryFilters_Changed;
            // 
            // sortComboBox
            // 
            sortComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sortComboBox.BackColor = Color.FromArgb(29, 42, 57);
            sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortComboBox.ForeColor = Color.FromArgb(232, 238, 245);
            sortComboBox.FormattingEnabled = true;
            sortComboBox.Items.AddRange(new object[] { "Name (A–Z)", "Most played", "Least played", "Recently played", "Longest time since played", "HLTB: shortest", "HLTB: longest" });
            sortComboBox.Location = new Point(495, 57);
            sortComboBox.Margin = new Padding(8, 2, 8, 2);
            sortComboBox.Name = "sortComboBox";
            sortComboBox.Size = new Size(217, 23);
            sortComboBox.TabIndex = 2;
            sortComboBox.SelectedIndex = 0;
            sortComboBox.SelectedIndexChanged += libraryFilters_Changed;
            // 
            // randomGameButton
            // 
            randomGameButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            randomGameButton.BackColor = Color.FromArgb(42, 111, 153);
            randomGameButton.FlatAppearance.BorderSize = 0;
            randomGameButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(54, 132, 177);
            randomGameButton.FlatStyle = FlatStyle.Flat;
            randomGameButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            randomGameButton.ForeColor = Color.White;
            randomGameButton.Location = new Point(727, 6);
            randomGameButton.Margin = new Padding(8, 2, 0, 2);
            randomGameButton.Name = "randomGameButton";
            randomGameButton.Size = new Size(144, 32);
            randomGameButton.TabIndex = 3;
            randomGameButton.Text = "Pick a random game";
            randomGameButton.UseVisualStyleBackColor = false;
            randomGameButton.Click += randomGameButton_Click;
            // hltbSearchButton
            hltbSearchButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hltbSearchButton.BackColor = Color.FromArgb(29, 42, 57);
            hltbSearchButton.FlatAppearance.BorderColor = Color.FromArgb(67, 90, 112);
            hltbSearchButton.FlatStyle = FlatStyle.Flat;
            hltbSearchButton.ForeColor = Color.FromArgb(232, 238, 245);
            hltbSearchButton.Location = new Point(3, 86);
            hltbSearchButton.Name = "hltbSearchButton";
            hltbSearchButton.Size = new Size(270, 30);
            hltbSearchButton.TabIndex = 4;
            hltbSearchButton.Text = "Search HowLongToBeat";
            hltbSearchButton.UseVisualStyleBackColor = false;
            hltbSearchButton.Click += hltbSearchButton_Click;
            libraryToolbar.Controls.Add(hltbSearchButton, 0, 2);
            // bulkHltbSearchButton
            bulkHltbSearchButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bulkHltbSearchButton.BackColor = Color.FromArgb(42, 111, 153);
            bulkHltbSearchButton.FlatAppearance.BorderSize = 0;
            bulkHltbSearchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(54, 132, 177);
            bulkHltbSearchButton.FlatStyle = FlatStyle.Flat;
            bulkHltbSearchButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bulkHltbSearchButton.ForeColor = Color.White;
            bulkHltbSearchButton.Location = new Point(289, 86);
            bulkHltbSearchButton.Name = "bulkHltbSearchButton";
            bulkHltbSearchButton.Size = new Size(185, 30);
            bulkHltbSearchButton.TabIndex = 5;
            bulkHltbSearchButton.Text = "Search all games on HLTB";
            bulkHltbSearchButton.UseVisualStyleBackColor = false;
            bulkHltbSearchButton.Click += bulkHltbSearchButton_Click;
            libraryToolbar.Controls.Add(bulkHltbSearchButton, 1, 2);
            // hltbHintLabel
            hltbHintLabel.Anchor = AnchorStyles.Left;
            hltbHintLabel.AutoSize = true;
            hltbHintLabel.ForeColor = Color.FromArgb(160, 177, 194);
            hltbHintLabel.Location = new Point(495, 94);
            hltbHintLabel.Name = "hltbHintLabel";
            hltbHintLabel.Size = new Size(375, 15);
            hltbHintLabel.TabIndex = 5;
            hltbHintLabel.Text = "Results are cached; previously searched games are not queried again.";
            libraryToolbar.Controls.Add(hltbHintLabel, 2, 2);
            libraryToolbar.SetColumnSpan(hltbHintLabel, 3);
            // 
            // gamesGrid
            // 
            gamesGrid.AllowUserToAddRows = false;
            gamesGrid.AllowUserToDeleteRows = false;
            gamesGrid.AllowUserToResizeRows = false;
            gamesGrid.AutoGenerateColumns = false;
            gamesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gamesGrid.BackgroundColor = Color.FromArgb(20, 29, 41);
            gamesGrid.BorderStyle = BorderStyle.None;
            gamesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gamesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gamesGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 42, 57);
            gamesGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            gamesGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(192, 208, 222);
            gamesGrid.ColumnHeadersHeight = 40;
            gamesGrid.Columns.AddRange(new DataGridViewColumn[] { gameNameColumn, sourceColumn, playtimeColumn, lastPlayedColumn, hltbMainColumn });
            gamesGrid.DefaultCellStyle.BackColor = Color.FromArgb(20, 29, 41);
            gamesGrid.DefaultCellStyle.ForeColor = Color.FromArgb(232, 238, 245);
            gamesGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 72, 98);
            gamesGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            gamesGrid.Dock = DockStyle.Fill;
            gamesGrid.EnableHeadersVisualStyles = false;
            gamesGrid.GridColor = Color.FromArgb(38, 52, 67);
            gamesGrid.Location = new Point(0, 0);
            gamesGrid.MultiSelect = false;
            gamesGrid.Name = "gamesGrid";
            gamesGrid.ReadOnly = true;
            gamesGrid.RowHeadersVisible = false;
            gamesGrid.RowTemplate.Height = 38;
            gamesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesGrid.Size = new Size(874, 578);
            gamesGrid.TabIndex = 0;
            // 
            // gameNameColumn
            // 
            gameNameColumn.DataPropertyName = "Name";
            gameNameColumn.FillWeight = 50F;
            gameNameColumn.HeaderText = "Game";
            gameNameColumn.Name = "gameNameColumn";
            gameNameColumn.ReadOnly = true;
            // 
            // sourceColumn
            // 
            sourceColumn.DataPropertyName = "SourceDisplay";
            sourceColumn.FillWeight = 18F;
            sourceColumn.HeaderText = "Source";
            sourceColumn.Name = "sourceColumn";
            sourceColumn.ReadOnly = true;
            // 
            // playtimeColumn
            // 
            playtimeColumn.DataPropertyName = "PlaytimeDisplay";
            playtimeColumn.FillWeight = 16F;
            playtimeColumn.HeaderText = "Playtime";
            playtimeColumn.Name = "playtimeColumn";
            playtimeColumn.ReadOnly = true;
            // 
            // lastPlayedColumn
            // 
            lastPlayedColumn.DataPropertyName = "LastPlayedDisplay";
            lastPlayedColumn.FillWeight = 16F;
            lastPlayedColumn.HeaderText = "Last played";
            lastPlayedColumn.Name = "lastPlayedColumn";
            lastPlayedColumn.ReadOnly = true;
            // hltbMainColumn
            hltbMainColumn.DataPropertyName = "HltbMainDisplay";
            hltbMainColumn.FillWeight = 15F;
            hltbMainColumn.HeaderText = "HLTB main story";
            hltbMainColumn.Name = "hltbMainColumn";
            hltbMainColumn.ReadOnly = true;
            // 
            // collectionsPage
            // 
            collectionsPage.BackColor = Color.FromArgb(15, 22, 32);
            collectionsPage.Controls.Add(collectionsPlaceholderLabel);
            collectionsPage.Dock = DockStyle.Fill;
            collectionsPage.Location = new Point(0, 0);
            collectionsPage.Name = "collectionsPage";
            collectionsPage.Size = new Size(874, 578);
            collectionsPage.TabIndex = 1;
            collectionsPage.Visible = false;
            // 
            // collectionsPlaceholderLabel
            // 
            collectionsPlaceholderLabel.Dock = DockStyle.Fill;
            collectionsPlaceholderLabel.Font = new Font("Segoe UI", 11F);
            collectionsPlaceholderLabel.ForeColor = Color.FromArgb(160, 177, 194);
            collectionsPlaceholderLabel.Location = new Point(0, 0);
            collectionsPlaceholderLabel.Name = "collectionsPlaceholderLabel";
            collectionsPlaceholderLabel.Size = new Size(874, 578);
            collectionsPlaceholderLabel.TabIndex = 0;
            collectionsPlaceholderLabel.Text = "Steam collection support is available from the Collections page.";
            collectionsPlaceholderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // wishlistPage
            // 
            wishlistPage.BackColor = Color.FromArgb(15, 22, 32);
            wishlistPage.Controls.Add(wishlistPlaceholderLabel);
            wishlistPage.Dock = DockStyle.Fill;
            wishlistPage.Location = new Point(0, 0);
            wishlistPage.Name = "wishlistPage";
            wishlistPage.Size = new Size(874, 578);
            wishlistPage.TabIndex = 2;
            wishlistPage.Visible = false;
            // 
            // wishlistPlaceholderLabel
            // 
            wishlistPlaceholderLabel.Dock = DockStyle.Fill;
            wishlistPlaceholderLabel.Font = new Font("Segoe UI", 11F);
            wishlistPlaceholderLabel.ForeColor = Color.FromArgb(160, 177, 194);
            wishlistPlaceholderLabel.Location = new Point(0, 0);
            wishlistPlaceholderLabel.Name = "wishlistPlaceholderLabel";
            wishlistPlaceholderLabel.Size = new Size(874, 578);
            wishlistPlaceholderLabel.TabIndex = 0;
            wishlistPlaceholderLabel.Text = "Wishlist import is not implemented yet.";
            wishlistPlaceholderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pricesPage
            // 
            pricesPage.BackColor = Color.FromArgb(15, 22, 32);
            pricesPage.Controls.Add(pricesPlaceholderLabel);
            pricesPage.Dock = DockStyle.Fill;
            pricesPage.Location = new Point(0, 0);
            pricesPage.Name = "pricesPage";
            pricesPage.Size = new Size(874, 578);
            pricesPage.TabIndex = 3;
            pricesPage.Visible = false;
            // 
            // pricesPlaceholderLabel
            // 
            pricesPlaceholderLabel.Dock = DockStyle.Fill;
            pricesPlaceholderLabel.Font = new Font("Segoe UI", 11F);
            pricesPlaceholderLabel.ForeColor = Color.FromArgb(160, 177, 194);
            pricesPlaceholderLabel.Location = new Point(0, 0);
            pricesPlaceholderLabel.Name = "pricesPlaceholderLabel";
            pricesPlaceholderLabel.Size = new Size(874, 578);
            pricesPlaceholderLabel.TabIndex = 0;
            pricesPlaceholderLabel.Text = "Price tracking through the IsThereAnyDeal API is not implemented yet.";
            pricesPlaceholderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            statusLabel.Dock = DockStyle.Bottom;
            statusLabel.ForeColor = Color.FromArgb(160, 177, 194);
            statusLabel.Location = new Point(30, 676);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(874, 30);
            statusLabel.TabIndex = 2;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 22, 32);
            ClientSize = new Size(1124, 724);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(232, 238, 245);
            MinimumSize = new Size(960, 620);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SteamManager";
            rootLayout.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            navigationPanel.ResumeLayout(false);
            workspacePanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            pagesPanel.ResumeLayout(false);
            libraryPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gamesGrid).EndInit();
            libraryToolbar.ResumeLayout(false);
            libraryToolbar.PerformLayout();
            collectionsPage.ResumeLayout(false);
            wishlistPage.ResumeLayout(false);
            pricesPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
