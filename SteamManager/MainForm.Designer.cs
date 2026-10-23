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
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.Button columnOptionsButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ContextMenuStrip columnMenu;
        private System.Windows.Forms.ToolStripMenuItem gameNameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playtimeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastPlayedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hltbMainMenuItem;
        private System.Windows.Forms.Panel pagesPanel;
        private System.Windows.Forms.Panel libraryPage;
        private System.Windows.Forms.TableLayoutPanel libraryLayout;
        private System.Windows.Forms.TableLayoutPanel libraryMetricsPanel;
        private System.Windows.Forms.Panel totalGamesCard;
        private System.Windows.Forms.Panel playedGamesCard;
        private System.Windows.Forms.Panel familyGamesCard;
        private System.Windows.Forms.Panel totalPlaytimeCard;
        private System.Windows.Forms.Label totalGamesTitleLabel;
        private System.Windows.Forms.Label totalGamesValueLabel;
        private System.Windows.Forms.Label totalGamesDetailLabel;
        private System.Windows.Forms.Label playedGamesTitleLabel;
        private System.Windows.Forms.Label playedGamesValueLabel;
        private System.Windows.Forms.Label playedGamesDetailLabel;
        private System.Windows.Forms.Label familyGamesTitleLabel;
        private System.Windows.Forms.Label familyGamesValueLabel;
        private System.Windows.Forms.Label familyGamesDetailLabel;
        private System.Windows.Forms.Label totalPlaytimeTitleLabel;
        private System.Windows.Forms.Label totalPlaytimeValueLabel;
        private System.Windows.Forms.Label totalPlaytimeDetailLabel;
        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.TableLayoutPanel filterGrid;
        private System.Windows.Forms.TableLayoutPanel hltbActionsLayout;
        private System.Windows.Forms.Panel gamesGridPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox sourceFilterComboBox;
        private System.Windows.Forms.ComboBox playedFilterComboBox;
        private System.Windows.Forms.ComboBox collectionFilterComboBox;
        private System.Windows.Forms.ComboBox sortComboBox;
        private System.Windows.Forms.TextBox hltbMinHoursTextBox;
        private System.Windows.Forms.TextBox hltbMaxHoursTextBox;
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
            headerSubtitleLabel = new Label();
            syncButton = new Button();
            columnOptionsButton = new Button();
            exportButton = new Button();
            columnMenu = new ContextMenuStrip(components);
            gameNameMenuItem = new ToolStripMenuItem();
            sourceMenuItem = new ToolStripMenuItem();
            playtimeMenuItem = new ToolStripMenuItem();
            lastPlayedMenuItem = new ToolStripMenuItem();
            hltbMainMenuItem = new ToolStripMenuItem();
            pagesPanel = new Panel();
            libraryPage = new Panel();
            libraryLayout = new TableLayoutPanel();
            libraryMetricsPanel = new TableLayoutPanel();
            totalGamesCard = new Panel();
            playedGamesCard = new Panel();
            familyGamesCard = new Panel();
            totalPlaytimeCard = new Panel();
            totalGamesTitleLabel = new Label();
            totalGamesValueLabel = new Label();
            totalGamesDetailLabel = new Label();
            playedGamesTitleLabel = new Label();
            playedGamesValueLabel = new Label();
            playedGamesDetailLabel = new Label();
            familyGamesTitleLabel = new Label();
            familyGamesValueLabel = new Label();
            familyGamesDetailLabel = new Label();
            totalPlaytimeTitleLabel = new Label();
            totalPlaytimeValueLabel = new Label();
            totalPlaytimeDetailLabel = new Label();
            filtersPanel = new Panel();
            filterGrid = new TableLayoutPanel();
            hltbActionsLayout = new TableLayoutPanel();
            gamesGridPanel = new Panel();
            searchTextBox = new TextBox();
            sourceFilterComboBox = new ComboBox();
            playedFilterComboBox = new ComboBox();
            collectionFilterComboBox = new ComboBox();
            sortComboBox = new ComboBox();
            hltbMinHoursTextBox = new TextBox();
            hltbMaxHoursTextBox = new TextBox();
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
            libraryLayout.SuspendLayout();
            libraryMetricsPanel.SuspendLayout();
            filtersPanel.SuspendLayout();
            filterGrid.SuspendLayout();
            hltbActionsLayout.SuspendLayout();
            gamesGridPanel.SuspendLayout();
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
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 228F));
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
            headerPanel.Controls.Add(headerSubtitleLabel);
            headerPanel.Controls.Add(columnOptionsButton);
            headerPanel.Controls.Add(exportButton);
            headerPanel.Controls.Add(syncButton);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(30, 22);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(874, 92);
            headerPanel.TabIndex = 0;
            // 
            // pageTitleLabel
            // 
            pageTitleLabel.AutoSize = true;
            pageTitleLabel.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            pageTitleLabel.ForeColor = Color.FromArgb(232, 238, 245);
            pageTitleLabel.Location = new Point(0, 2);
            pageTitleLabel.Name = "pageTitleLabel";
            pageTitleLabel.Size = new Size(174, 42);
            pageTitleLabel.TabIndex = 0;
            pageTitleLabel.Text = "Library";
            // 
            // headerSubtitleLabel
            //
            headerSubtitleLabel.AutoSize = true;
            headerSubtitleLabel.Font = new Font("Segoe UI", 9F);
            headerSubtitleLabel.ForeColor = Color.FromArgb(160, 177, 194);
            headerSubtitleLabel.Location = new Point(2, 52);
            headerSubtitleLabel.Name = "headerSubtitleLabel";
            headerSubtitleLabel.Size = new Size(278, 15);
            headerSubtitleLabel.TabIndex = 4;
            headerSubtitleLabel.Text = "Games, collections and playtime in one place.";
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
            // exportButton
            exportButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportButton.BackColor = Color.FromArgb(29, 42, 57);
            exportButton.FlatAppearance.BorderColor = Color.FromArgb(67, 90, 112);
            exportButton.FlatStyle = FlatStyle.Flat;
            exportButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            exportButton.ForeColor = Color.FromArgb(232, 238, 245);
            exportButton.Location = new Point(438, 8);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(136, 40);
            exportButton.TabIndex = 3;
            exportButton.Text = "Export to Excel";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
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
            libraryPage.Controls.Add(libraryLayout);
            libraryPage.Dock = DockStyle.Fill;
            libraryPage.Location = new Point(0, 0);
            libraryPage.Name = "libraryPage";
            libraryPage.Size = new Size(874, 578);
            libraryPage.TabIndex = 0;
            // 
            // libraryLayout
            //
            libraryLayout.BackColor = Color.FromArgb(15, 22, 32);
            libraryLayout.ColumnCount = 1;
            libraryLayout.RowCount = 4;
            libraryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            libraryLayout.Controls.Add(libraryMetricsPanel, 0, 0);
            libraryLayout.Controls.Add(filtersPanel, 0, 1);
            libraryLayout.Controls.Add(hltbActionsLayout, 0, 2);
            libraryLayout.Controls.Add(gamesGridPanel, 0, 3);
            libraryLayout.Dock = DockStyle.Fill;
            libraryLayout.Margin = Padding.Empty;
            libraryLayout.Name = "libraryLayout";
            libraryLayout.Padding = new Padding(0, 2, 0, 0);
            libraryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            libraryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            libraryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            libraryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            libraryLayout.TabIndex = 1;
            //
            // libraryMetricsPanel
            //
            libraryMetricsPanel.BackColor = Color.FromArgb(15, 22, 32);
            libraryMetricsPanel.ColumnCount = 4;
            libraryMetricsPanel.RowCount = 1;
            libraryMetricsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            libraryMetricsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            libraryMetricsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            libraryMetricsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            libraryMetricsPanel.Controls.Add(totalGamesCard, 0, 0);
            libraryMetricsPanel.Controls.Add(playedGamesCard, 1, 0);
            libraryMetricsPanel.Controls.Add(familyGamesCard, 2, 0);
            libraryMetricsPanel.Controls.Add(totalPlaytimeCard, 3, 0);
            libraryMetricsPanel.Dock = DockStyle.Fill;
            libraryMetricsPanel.Margin = Padding.Empty;
            libraryMetricsPanel.Name = "libraryMetricsPanel";
            libraryMetricsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            libraryMetricsPanel.TabIndex = 0;
            //
            // totalGamesCard
            //
            totalGamesCard.BackColor = Color.FromArgb(20, 29, 41);
            totalGamesCard.Controls.Add(totalGamesTitleLabel);
            totalGamesCard.Controls.Add(totalGamesValueLabel);
            totalGamesCard.Controls.Add(totalGamesDetailLabel);
            totalGamesCard.Dock = DockStyle.Fill;
            totalGamesCard.Margin = new Padding(0, 0, 8, 0);
            totalGamesCard.Name = "totalGamesCard";
            totalGamesCard.Padding = new Padding(13, 9, 10, 7);
            totalGamesCard.TabIndex = 0;
            totalGamesTitleLabel.AutoSize = true;
            totalGamesTitleLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            totalGamesTitleLabel.ForeColor = Color.FromArgb(160, 177, 194);
            totalGamesTitleLabel.Location = new Point(13, 8);
            totalGamesTitleLabel.Name = "totalGamesTitleLabel";
            totalGamesTitleLabel.Size = new Size(107, 13);
            totalGamesTitleLabel.TabIndex = 0;
            totalGamesTitleLabel.Text = "GAMES IN LIBRARY";
            totalGamesValueLabel.AutoEllipsis = true;
            totalGamesValueLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            totalGamesValueLabel.ForeColor = Color.FromArgb(225, 234, 243);
            totalGamesValueLabel.Location = new Point(11, 25);
            totalGamesValueLabel.Name = "totalGamesValueLabel";
            totalGamesValueLabel.Size = new Size(180, 33);
            totalGamesValueLabel.TabIndex = 1;
            totalGamesValueLabel.Text = "0";
            totalGamesDetailLabel.AutoEllipsis = true;
            totalGamesDetailLabel.Font = new Font("Segoe UI", 8F);
            totalGamesDetailLabel.ForeColor = Color.FromArgb(102, 192, 244);
            totalGamesDetailLabel.Location = new Point(13, 63);
            totalGamesDetailLabel.Name = "totalGamesDetailLabel";
            totalGamesDetailLabel.Size = new Size(170, 18);
            totalGamesDetailLabel.TabIndex = 2;
            totalGamesDetailLabel.Text = "Across your Steam account";
            //
            // playedGamesCard
            //
            playedGamesCard.BackColor = Color.FromArgb(20, 29, 41);
            playedGamesCard.Controls.Add(playedGamesTitleLabel);
            playedGamesCard.Controls.Add(playedGamesValueLabel);
            playedGamesCard.Controls.Add(playedGamesDetailLabel);
            playedGamesCard.Dock = DockStyle.Fill;
            playedGamesCard.Margin = new Padding(0, 0, 8, 0);
            playedGamesCard.Name = "playedGamesCard";
            playedGamesCard.Padding = new Padding(13, 9, 10, 7);
            playedGamesCard.TabIndex = 1;
            playedGamesTitleLabel.AutoSize = true;
            playedGamesTitleLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            playedGamesTitleLabel.ForeColor = Color.FromArgb(160, 177, 194);
            playedGamesTitleLabel.Location = new Point(13, 8);
            playedGamesTitleLabel.Name = "playedGamesTitleLabel";
            playedGamesTitleLabel.Size = new Size(47, 13);
            playedGamesTitleLabel.TabIndex = 0;
            playedGamesTitleLabel.Text = "PLAYED";
            playedGamesValueLabel.AutoEllipsis = true;
            playedGamesValueLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            playedGamesValueLabel.ForeColor = Color.FromArgb(225, 234, 243);
            playedGamesValueLabel.Location = new Point(11, 25);
            playedGamesValueLabel.Name = "playedGamesValueLabel";
            playedGamesValueLabel.Size = new Size(180, 33);
            playedGamesValueLabel.TabIndex = 1;
            playedGamesValueLabel.Text = "0";
            playedGamesDetailLabel.AutoEllipsis = true;
            playedGamesDetailLabel.Font = new Font("Segoe UI", 8F);
            playedGamesDetailLabel.ForeColor = Color.FromArgb(126, 211, 170);
            playedGamesDetailLabel.Location = new Point(13, 63);
            playedGamesDetailLabel.Name = "playedGamesDetailLabel";
            playedGamesDetailLabel.Size = new Size(170, 18);
            playedGamesDetailLabel.TabIndex = 2;
            playedGamesDetailLabel.Text = "Games with recorded playtime";
            //
            // familyGamesCard
            //
            familyGamesCard.BackColor = Color.FromArgb(20, 29, 41);
            familyGamesCard.Controls.Add(familyGamesTitleLabel);
            familyGamesCard.Controls.Add(familyGamesValueLabel);
            familyGamesCard.Controls.Add(familyGamesDetailLabel);
            familyGamesCard.Dock = DockStyle.Fill;
            familyGamesCard.Margin = new Padding(0, 0, 8, 0);
            familyGamesCard.Name = "familyGamesCard";
            familyGamesCard.Padding = new Padding(13, 9, 10, 7);
            familyGamesCard.TabIndex = 2;
            familyGamesTitleLabel.AutoSize = true;
            familyGamesTitleLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            familyGamesTitleLabel.ForeColor = Color.FromArgb(160, 177, 194);
            familyGamesTitleLabel.Location = new Point(13, 8);
            familyGamesTitleLabel.Name = "familyGamesTitleLabel";
            familyGamesTitleLabel.Size = new Size(90, 13);
            familyGamesTitleLabel.TabIndex = 0;
            familyGamesTitleLabel.Text = "FAMILY SHARED";
            familyGamesValueLabel.AutoEllipsis = true;
            familyGamesValueLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            familyGamesValueLabel.ForeColor = Color.FromArgb(225, 234, 243);
            familyGamesValueLabel.Location = new Point(11, 25);
            familyGamesValueLabel.Name = "familyGamesValueLabel";
            familyGamesValueLabel.Size = new Size(180, 33);
            familyGamesValueLabel.TabIndex = 1;
            familyGamesValueLabel.Text = "0";
            familyGamesDetailLabel.AutoEllipsis = true;
            familyGamesDetailLabel.Font = new Font("Segoe UI", 8F);
            familyGamesDetailLabel.ForeColor = Color.FromArgb(190, 156, 255);
            familyGamesDetailLabel.Location = new Point(13, 63);
            familyGamesDetailLabel.Name = "familyGamesDetailLabel";
            familyGamesDetailLabel.Size = new Size(170, 18);
            familyGamesDetailLabel.TabIndex = 2;
            familyGamesDetailLabel.Text = "Shared through Steam Families";
            //
            // totalPlaytimeCard
            //
            totalPlaytimeCard.BackColor = Color.FromArgb(20, 29, 41);
            totalPlaytimeCard.Controls.Add(totalPlaytimeTitleLabel);
            totalPlaytimeCard.Controls.Add(totalPlaytimeValueLabel);
            totalPlaytimeCard.Controls.Add(totalPlaytimeDetailLabel);
            totalPlaytimeCard.Dock = DockStyle.Fill;
            totalPlaytimeCard.Margin = new Padding(0, 0, 0, 0);
            totalPlaytimeCard.Name = "totalPlaytimeCard";
            totalPlaytimeCard.Padding = new Padding(13, 9, 10, 7);
            totalPlaytimeCard.TabIndex = 3;
            totalPlaytimeTitleLabel.AutoSize = true;
            totalPlaytimeTitleLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            totalPlaytimeTitleLabel.ForeColor = Color.FromArgb(160, 177, 194);
            totalPlaytimeTitleLabel.Location = new Point(13, 8);
            totalPlaytimeTitleLabel.Name = "totalPlaytimeTitleLabel";
            totalPlaytimeTitleLabel.Size = new Size(94, 13);
            totalPlaytimeTitleLabel.TabIndex = 0;
            totalPlaytimeTitleLabel.Text = "TOTAL PLAYTIME";
            totalPlaytimeValueLabel.AutoEllipsis = true;
            totalPlaytimeValueLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            totalPlaytimeValueLabel.ForeColor = Color.FromArgb(225, 234, 243);
            totalPlaytimeValueLabel.Location = new Point(11, 25);
            totalPlaytimeValueLabel.Name = "totalPlaytimeValueLabel";
            totalPlaytimeValueLabel.Size = new Size(180, 33);
            totalPlaytimeValueLabel.TabIndex = 1;
            totalPlaytimeValueLabel.Text = "0 h";
            totalPlaytimeDetailLabel.AutoEllipsis = true;
            totalPlaytimeDetailLabel.Font = new Font("Segoe UI", 8F);
            totalPlaytimeDetailLabel.ForeColor = Color.FromArgb(255, 190, 105);
            totalPlaytimeDetailLabel.Location = new Point(13, 63);
            totalPlaytimeDetailLabel.Name = "totalPlaytimeDetailLabel";
            totalPlaytimeDetailLabel.Size = new Size(170, 18);
            totalPlaytimeDetailLabel.TabIndex = 2;
            totalPlaytimeDetailLabel.Text = "Recorded across your library";
            //
            // filtersPanel
            //
            filtersPanel.BackColor = Color.FromArgb(20, 29, 41);
            filtersPanel.Controls.Add(filterGrid);
            filtersPanel.Dock = DockStyle.Fill;
            filtersPanel.Margin = new Padding(0, 6, 0, 5);
            filtersPanel.Name = "filtersPanel";
            filtersPanel.Padding = new Padding(12, 10, 12, 9);
            filtersPanel.TabIndex = 1;
            //
            // filterGrid
            //
            filterGrid.BackColor = Color.FromArgb(20, 29, 41);
            filterGrid.ColumnCount = 5;
            filterGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            filterGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            filterGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            filterGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            filterGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            filterGrid.Dock = DockStyle.Fill;
            filterGrid.Margin = Padding.Empty;
            filterGrid.Name = "filterGrid";
            filterGrid.RowCount = 2;
            filterGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            filterGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            filterGrid.TabIndex = 0;
            //
            // hltbActionsLayout
            //
            hltbActionsLayout.BackColor = Color.FromArgb(15, 22, 32);
            hltbActionsLayout.ColumnCount = 3;
            hltbActionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 205F));
            hltbActionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 218F));
            hltbActionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            hltbActionsLayout.Dock = DockStyle.Fill;
            hltbActionsLayout.Margin = Padding.Empty;
            hltbActionsLayout.Name = "hltbActionsLayout";
            hltbActionsLayout.Padding = new Padding(0, 2, 0, 2);
            hltbActionsLayout.RowCount = 1;
            hltbActionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            hltbActionsLayout.TabIndex = 2;
            //
            // gamesGridPanel
            //
            gamesGridPanel.BackColor = Color.FromArgb(20, 29, 41);
            gamesGridPanel.Dock = DockStyle.Fill;
            gamesGridPanel.Margin = new Padding(0, 2, 0, 0);
            gamesGridPanel.Name = "gamesGridPanel";
            gamesGridPanel.Padding = Padding.Empty;
            gamesGridPanel.TabIndex = 3;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.BackColor = Color.FromArgb(29, 42, 57);
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            searchTextBox.Location = new Point(3, 9);
            searchTextBox.Margin = new Padding(3, 4, 6, 3);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search your games";
            searchTextBox.Size = new Size(270, 23);
            searchTextBox.TabIndex = 0;
            searchTextBox.TextChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(searchTextBox, 0, 0);
            filterGrid.SetColumnSpan(searchTextBox, 2);
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
            sourceFilterComboBox.Margin = new Padding(3, 3, 6, 3);
            sourceFilterComboBox.Name = "sourceFilterComboBox";
            sourceFilterComboBox.Size = new Size(270, 23);
            sourceFilterComboBox.TabIndex = 1;
            sourceFilterComboBox.SelectedIndex = 0;
            sourceFilterComboBox.SelectedIndexChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(sourceFilterComboBox, 0, 1);
            // 
            // playedFilterComboBox
            // 
            playedFilterComboBox.Location = new Point(289, 57);
            playedFilterComboBox.Margin = new Padding(3, 3, 6, 3);
            playedFilterComboBox.Name = "playedFilterComboBox";
            playedFilterComboBox.Size = new Size(185, 23);
            playedFilterComboBox.TabIndex = 1;
            playedFilterComboBox.SelectedIndex = 0;
            playedFilterComboBox.SelectedIndexChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(playedFilterComboBox, 1, 1);
            //
            // collectionFilterComboBox
            //
            collectionFilterComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            collectionFilterComboBox.BackColor = Color.FromArgb(29, 42, 57);
            collectionFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            collectionFilterComboBox.ForeColor = Color.FromArgb(232, 238, 245);
            collectionFilterComboBox.FormattingEnabled = true;
            collectionFilterComboBox.Location = new Point(495, 57);
            collectionFilterComboBox.Margin = new Padding(3, 3, 6, 3);
            collectionFilterComboBox.Name = "collectionFilterComboBox";
            collectionFilterComboBox.Size = new Size(185, 23);
            collectionFilterComboBox.TabIndex = 2;
            collectionFilterComboBox.SelectedIndexChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(collectionFilterComboBox, 2, 1);
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
            sortComboBox.Margin = new Padding(3, 3, 6, 3);
            sortComboBox.Name = "sortComboBox";
            sortComboBox.Size = new Size(217, 23);
            sortComboBox.TabIndex = 2;
            sortComboBox.SelectedIndex = 0;
            sortComboBox.SelectedIndexChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(sortComboBox, 2, 0);
            filterGrid.SetColumnSpan(sortComboBox, 2);
            //
            // hltbMinHoursTextBox
            //
            hltbMinHoursTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hltbMinHoursTextBox.BackColor = Color.FromArgb(29, 42, 57);
            hltbMinHoursTextBox.BorderStyle = BorderStyle.FixedSingle;
            hltbMinHoursTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            hltbMinHoursTextBox.Location = new Point(3, 89);
            hltbMinHoursTextBox.Margin = new Padding(3, 4, 6, 3);
            hltbMinHoursTextBox.Name = "hltbMinHoursTextBox";
            hltbMinHoursTextBox.PlaceholderText = "HLTB min hours";
            hltbMinHoursTextBox.Size = new Size(190, 23);
            hltbMinHoursTextBox.TabIndex = 3;
            hltbMinHoursTextBox.TextChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(hltbMinHoursTextBox, 3, 1);
            //
            // hltbMaxHoursTextBox
            //
            hltbMaxHoursTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hltbMaxHoursTextBox.BackColor = Color.FromArgb(29, 42, 57);
            hltbMaxHoursTextBox.BorderStyle = BorderStyle.FixedSingle;
            hltbMaxHoursTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            hltbMaxHoursTextBox.Location = new Point(204, 89);
            hltbMaxHoursTextBox.Margin = new Padding(3, 4, 3, 3);
            hltbMaxHoursTextBox.Name = "hltbMaxHoursTextBox";
            hltbMaxHoursTextBox.PlaceholderText = "HLTB max hours";
            hltbMaxHoursTextBox.Size = new Size(131, 23);
            hltbMaxHoursTextBox.TabIndex = 4;
            hltbMaxHoursTextBox.TextChanged += libraryFilters_Changed;
            filterGrid.Controls.Add(hltbMaxHoursTextBox, 4, 1);
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
            randomGameButton.Margin = new Padding(3, 3, 0, 3);
            randomGameButton.Name = "randomGameButton";
            randomGameButton.Size = new Size(144, 32);
            randomGameButton.TabIndex = 3;
            randomGameButton.Text = "Pick for me";
            randomGameButton.UseVisualStyleBackColor = false;
            randomGameButton.Click += randomGameButton_Click;
            filterGrid.Controls.Add(randomGameButton, 4, 0);
            // hltbSearchButton
            hltbSearchButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hltbSearchButton.Dock = DockStyle.Fill;
            hltbSearchButton.BackColor = Color.FromArgb(29, 42, 57);
            hltbSearchButton.FlatAppearance.BorderColor = Color.FromArgb(67, 90, 112);
            hltbSearchButton.FlatStyle = FlatStyle.Flat;
            hltbSearchButton.ForeColor = Color.FromArgb(232, 238, 245);
            hltbSearchButton.Margin = new Padding(0, 2, 8, 2);
            hltbSearchButton.Name = "hltbSearchButton";
            hltbSearchButton.Size = new Size(205, 36);
            hltbSearchButton.TabIndex = 4;
            hltbSearchButton.Text = "Search selected on HLTB";
            hltbSearchButton.UseVisualStyleBackColor = false;
            hltbSearchButton.Click += hltbSearchButton_Click;
            hltbActionsLayout.Controls.Add(hltbSearchButton, 0, 0);
            // bulkHltbSearchButton
            bulkHltbSearchButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bulkHltbSearchButton.Dock = DockStyle.Fill;
            bulkHltbSearchButton.BackColor = Color.FromArgb(42, 111, 153);
            bulkHltbSearchButton.FlatAppearance.BorderSize = 0;
            bulkHltbSearchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(54, 132, 177);
            bulkHltbSearchButton.FlatStyle = FlatStyle.Flat;
            bulkHltbSearchButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bulkHltbSearchButton.ForeColor = Color.White;
            bulkHltbSearchButton.Margin = new Padding(0, 2, 13, 2);
            bulkHltbSearchButton.Name = "bulkHltbSearchButton";
            bulkHltbSearchButton.Size = new Size(205, 36);
            bulkHltbSearchButton.TabIndex = 5;
            bulkHltbSearchButton.Text = "Search library on HLTB";
            bulkHltbSearchButton.UseVisualStyleBackColor = false;
            bulkHltbSearchButton.Click += bulkHltbSearchButton_Click;
            hltbActionsLayout.Controls.Add(bulkHltbSearchButton, 1, 0);
            // hltbHintLabel
            hltbHintLabel.AutoSize = false;
            hltbHintLabel.Dock = DockStyle.Fill;
            hltbHintLabel.ForeColor = Color.FromArgb(160, 177, 194);
            hltbHintLabel.TextAlign = ContentAlignment.MiddleLeft;
            hltbHintLabel.Name = "hltbHintLabel";
            hltbHintLabel.Size = new Size(375, 36);
            hltbHintLabel.TabIndex = 5;
            hltbHintLabel.Text = "Results are cached; previously searched games are not queried again.";
            hltbActionsLayout.Controls.Add(hltbHintLabel, 2, 0);
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
            gamesGrid.ColumnHeadersHeight = 44;
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
            gamesGrid.RowTemplate.Height = 42;
            gamesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesGrid.Size = new Size(874, 578);
            gamesGrid.TabIndex = 0;
            gamesGrid.ColumnHeaderMouseClick += gamesGrid_ColumnHeaderMouseClick;
            gamesGridPanel.Controls.Add(gamesGrid);
            // 
            // gameNameColumn
            // 
            gameNameColumn.DataPropertyName = "Name";
            gameNameColumn.FillWeight = 50F;
            gameNameColumn.HeaderText = "Game";
            gameNameColumn.Name = "gameNameColumn";
            gameNameColumn.ReadOnly = true;
            gameNameColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // sourceColumn
            // 
            sourceColumn.DataPropertyName = "SourceDisplay";
            sourceColumn.FillWeight = 18F;
            sourceColumn.HeaderText = "Source";
            sourceColumn.Name = "sourceColumn";
            sourceColumn.ReadOnly = true;
            sourceColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // playtimeColumn
            // 
            playtimeColumn.DataPropertyName = "PlaytimeDisplay";
            playtimeColumn.FillWeight = 16F;
            playtimeColumn.HeaderText = "Playtime";
            playtimeColumn.Name = "playtimeColumn";
            playtimeColumn.ReadOnly = true;
            playtimeColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // lastPlayedColumn
            // 
            lastPlayedColumn.DataPropertyName = "LastPlayedDisplay";
            lastPlayedColumn.FillWeight = 16F;
            lastPlayedColumn.HeaderText = "Last played";
            lastPlayedColumn.Name = "lastPlayedColumn";
            lastPlayedColumn.ReadOnly = true;
            lastPlayedColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // hltbMainColumn
            hltbMainColumn.DataPropertyName = "HltbMainDisplay";
            hltbMainColumn.FillWeight = 15F;
            hltbMainColumn.HeaderText = "HLTB main story";
            hltbMainColumn.Name = "hltbMainColumn";
            hltbMainColumn.ReadOnly = true;
            hltbMainColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
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
            MinimumSize = new Size(1060, 720);
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
            libraryLayout.ResumeLayout(false);
            libraryMetricsPanel.ResumeLayout(false);
            filtersPanel.ResumeLayout(false);
            filterGrid.ResumeLayout(false);
            hltbActionsLayout.ResumeLayout(false);
            gamesGridPanel.ResumeLayout(false);
            collectionsPage.ResumeLayout(false);
            wishlistPage.ResumeLayout(false);
            pricesPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
