namespace SteamManager
{
    partial class HltbMatchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label noResultsLabel;
        private System.Windows.Forms.DataGridView matchesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mainColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeColumn;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button cancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            titleLabel = new Label();
            noResultsLabel = new Label();
            matchesGrid = new DataGridView();
            nameColumn = new DataGridViewTextBoxColumn();
            yearColumn = new DataGridViewTextBoxColumn();
            mainColumn = new DataGridViewTextBoxColumn();
            extraColumn = new DataGridViewTextBoxColumn();
            completeColumn = new DataGridViewTextBoxColumn();
            selectButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)matchesGrid).BeginInit();
            SuspendLayout();
            // titleLabel
            titleLabel.AutoEllipsis = true;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(16, 14);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(808, 34);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "HowLongToBeat results";
            // noResultsLabel
            noResultsLabel.Dock = DockStyle.None;
            noResultsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noResultsLabel.Location = new Point(16, 58);
            noResultsLabel.Size = new Size(808, 390);
            noResultsLabel.Font = new Font("Segoe UI", 11F);
            noResultsLabel.ForeColor = Color.DimGray;
            noResultsLabel.Location = new Point(16, 48);
            noResultsLabel.Name = "noResultsLabel";
            noResultsLabel.Size = new Size(808, 400);
            noResultsLabel.TabIndex = 2;
            noResultsLabel.Text = "No results found.";
            noResultsLabel.TextAlign = ContentAlignment.MiddleCenter;
            noResultsLabel.Visible = false;
            // matchesGrid
            matchesGrid.AllowUserToAddRows = false;
            matchesGrid.AllowUserToDeleteRows = false;
            matchesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            matchesGrid.BackgroundColor = SystemColors.Window;
            matchesGrid.Columns.AddRange(new DataGridViewColumn[] { nameColumn, yearColumn, mainColumn, extraColumn, completeColumn });
            matchesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            matchesGrid.Location = new Point(16, 58);
            matchesGrid.Size = new Size(808, 390);
            matchesGrid.MultiSelect = false;
            matchesGrid.Name = "matchesGrid";
            matchesGrid.ReadOnly = true;
            matchesGrid.RowHeadersVisible = false;
            matchesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            matchesGrid.CellDoubleClick += matchesGrid_CellDoubleClick;
            // columns
            nameColumn.DataPropertyName = "Name";
            nameColumn.FillWeight = 48F;
            nameColumn.HeaderText = "Game on HowLongToBeat";
            nameColumn.Name = "nameColumn";
            nameColumn.ReadOnly = true;
            yearColumn.DataPropertyName = "ReleaseDisplay";
            yearColumn.FillWeight = 10F;
            yearColumn.HeaderText = "Year";
            yearColumn.Name = "yearColumn";
            yearColumn.ReadOnly = true;
            mainColumn.DataPropertyName = "MainDisplay";
            mainColumn.FillWeight = 14F;
            mainColumn.HeaderText = "Main story";
            mainColumn.Name = "mainColumn";
            mainColumn.ReadOnly = true;
            extraColumn.DataPropertyName = "MainExtraDisplay";
            extraColumn.FillWeight = 14F;
            extraColumn.HeaderText = "Main + extras";
            extraColumn.Name = "extraColumn";
            extraColumn.ReadOnly = true;
            completeColumn.DataPropertyName = "CompletionistDisplay";
            completeColumn.FillWeight = 14F;
            completeColumn.HeaderText = "Completionist";
            completeColumn.Name = "completeColumn";
            completeColumn.ReadOnly = true;
            // buttons
            selectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            selectButton.Location = new Point(628, 462);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(108, 34);
            selectButton.TabIndex = 3;
            selectButton.Text = "Use this game";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(744, 462);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(80, 34);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // Form
            AcceptButton = selectButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(840, 510);
            Controls.Add(matchesGrid);
            Controls.Add(noResultsLabel);
            Controls.Add(selectButton);
            Controls.Add(cancelButton);
            Controls.Add(titleLabel);
            Padding = new Padding(16, 14, 16, 12);
            MinimumSize = new Size(700, 400);
            Name = "HltbMatchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select a HowLongToBeat game";
            ((System.ComponentModel.ISupportInitialize)matchesGrid).EndInit();
            ResumeLayout(false);
        }
    }
}
