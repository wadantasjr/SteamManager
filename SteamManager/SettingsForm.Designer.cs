namespace SteamManager
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label steamKeyLabel;
        private System.Windows.Forms.TextBox steamKeyTextBox;
        private System.Windows.Forms.Label steamIdLabel;
        private System.Windows.Forms.TextBox steamIdTextBox;
        private System.Windows.Forms.Label steamSessionTokenLabel;
        private System.Windows.Forms.TextBox steamSessionTokenTextBox;
        private System.Windows.Forms.Label sessionTokenHelpLabel;
        private System.Windows.Forms.Label itadKeyLabel;
        private System.Windows.Forms.TextBox itadKeyTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Label protectedNoticeLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

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
            titleLabel = new Label();
            steamKeyLabel = new Label();
            steamKeyTextBox = new TextBox();
            steamIdLabel = new Label();
            steamIdTextBox = new TextBox();
            steamSessionTokenLabel = new Label();
            steamSessionTokenTextBox = new TextBox();
            sessionTokenHelpLabel = new Label();
            itadKeyLabel = new Label();
            itadKeyTextBox = new TextBox();
            countryLabel = new Label();
            countryComboBox = new ComboBox();
            protectedNoticeLabel = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(102, 192, 244);
            titleLabel.Location = new Point(24, 18);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(141, 36);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Connections";
            // 
            // steamKeyLabel
            // 
            steamKeyLabel.AutoSize = true;
            steamKeyLabel.ForeColor = Color.FromArgb(192, 208, 222);
            steamKeyLabel.Location = new Point(24, 72);
            steamKeyLabel.Name = "steamKeyLabel";
            steamKeyLabel.Size = new Size(161, 15);
            steamKeyLabel.TabIndex = 1;
            steamKeyLabel.Text = "Steam Web API key";
            // 
            // steamKeyTextBox
            // 
            steamKeyTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            steamKeyTextBox.BackColor = Color.FromArgb(29, 42, 57);
            steamKeyTextBox.BorderStyle = BorderStyle.FixedSingle;
            steamKeyTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            steamKeyTextBox.Location = new Point(24, 95);
            steamKeyTextBox.Name = "steamKeyTextBox";
            steamKeyTextBox.Size = new Size(492, 23);
            steamKeyTextBox.TabIndex = 2;
            steamKeyTextBox.UseSystemPasswordChar = true;
            // 
            // steamIdLabel
            // 
            steamIdLabel.AutoSize = true;
            steamIdLabel.ForeColor = Color.FromArgb(192, 208, 222);
            steamIdLabel.Location = new Point(24, 142);
            steamIdLabel.Name = "steamIdLabel";
            steamIdLabel.Size = new Size(65, 15);
            steamIdLabel.TabIndex = 3;
            steamIdLabel.Text = "SteamID64";
            // 
            // steamIdTextBox
            // 
            steamIdTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            steamIdTextBox.BackColor = Color.FromArgb(29, 42, 57);
            steamIdTextBox.BorderStyle = BorderStyle.FixedSingle;
            steamIdTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            steamIdTextBox.Location = new Point(24, 165);
            steamIdTextBox.Name = "steamIdTextBox";
            steamIdTextBox.Size = new Size(492, 23);
            steamIdTextBox.TabIndex = 4;
            // 
            // steamSessionTokenLabel
            // 
            steamSessionTokenLabel.AutoSize = true;
            steamSessionTokenLabel.ForeColor = Color.FromArgb(192, 208, 222);
            steamSessionTokenLabel.Location = new Point(24, 212);
            steamSessionTokenLabel.Name = "steamSessionTokenLabel";
            steamSessionTokenLabel.Size = new Size(272, 15);
            steamSessionTokenLabel.TabIndex = 5;
            steamSessionTokenLabel.Text = "Temporary Steam session token (for Steam Families)";
            // 
            // steamSessionTokenTextBox
            // 
            steamSessionTokenTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            steamSessionTokenTextBox.BackColor = Color.FromArgb(29, 42, 57);
            steamSessionTokenTextBox.BorderStyle = BorderStyle.FixedSingle;
            steamSessionTokenTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            steamSessionTokenTextBox.Location = new Point(24, 235);
            steamSessionTokenTextBox.Name = "steamSessionTokenTextBox";
            steamSessionTokenTextBox.Size = new Size(492, 23);
            steamSessionTokenTextBox.TabIndex = 6;
            steamSessionTokenTextBox.UseSystemPasswordChar = true;
            // 
            // sessionTokenHelpLabel
            // 
            sessionTokenHelpLabel.ForeColor = Color.FromArgb(160, 177, 194);
            sessionTokenHelpLabel.Location = new Point(24, 265);
            sessionTokenHelpLabel.Name = "sessionTokenHelpLabel";
            sessionTokenHelpLabel.Size = new Size(492, 36);
            sessionTokenHelpLabel.TabIndex = 7;
            sessionTokenHelpLabel.Text = "While signed in to Steam in your browser, open store.steampowered.com/pointssummary/ajaxgetasyncconfig and copy only the webapi_token value. This token expires and must be renewed.";
            // 
            // itadKeyLabel
            // 
            itadKeyLabel.AutoSize = true;
            itadKeyLabel.ForeColor = Color.FromArgb(192, 208, 222);
            itadKeyLabel.Location = new Point(24, 310);
            itadKeyLabel.Name = "itadKeyLabel";
            itadKeyLabel.Size = new Size(223, 15);
            itadKeyLabel.TabIndex = 8;
            itadKeyLabel.Text = "IsThereAnyDeal API key (optional; not used yet)";
            // 
            // itadKeyTextBox
            // 
            itadKeyTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            itadKeyTextBox.BackColor = Color.FromArgb(29, 42, 57);
            itadKeyTextBox.BorderStyle = BorderStyle.FixedSingle;
            itadKeyTextBox.ForeColor = Color.FromArgb(232, 238, 245);
            itadKeyTextBox.Location = new Point(24, 333);
            itadKeyTextBox.Name = "itadKeyTextBox";
            itadKeyTextBox.Size = new Size(492, 23);
            itadKeyTextBox.TabIndex = 9;
            itadKeyTextBox.UseSystemPasswordChar = true;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.ForeColor = Color.FromArgb(192, 208, 222);
            countryLabel.Location = new Point(24, 380);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(161, 15);
            countryLabel.TabIndex = 10;
            countryLabel.Text = "Country for price lookups";
            // 
            // countryComboBox
            // 
            countryComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            countryComboBox.BackColor = Color.FromArgb(29, 42, 57);
            countryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            countryComboBox.ForeColor = Color.FromArgb(232, 238, 245);
            countryComboBox.FormattingEnabled = true;
            countryComboBox.Items.AddRange(new object[] { "Brazil (BR)", "United States (US)", "Portugal (PT)" });
            countryComboBox.Location = new Point(24, 403);
            countryComboBox.Name = "countryComboBox";
            countryComboBox.Size = new Size(492, 23);
            countryComboBox.TabIndex = 11;
            // 
            // protectedNoticeLabel
            // 
            protectedNoticeLabel.AutoSize = true;
            protectedNoticeLabel.ForeColor = Color.FromArgb(160, 177, 194);
            protectedNoticeLabel.Location = new Point(24, 442);
            protectedNoticeLabel.Name = "protectedNoticeLabel";
            protectedNoticeLabel.Size = new Size(360, 15);
            protectedNoticeLabel.TabIndex = 12;
            protectedNoticeLabel.Text = "Keys are protected by Windows for your user account.";
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(42, 111, 153);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(304, 470);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 36);
            saveButton.TabIndex = 13;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(35, 49, 65);
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(414, 470);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 36);
            cancelButton.TabIndex = 14;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 29, 41);
            CancelButton = cancelButton;
            ClientSize = new Size(540, 520);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(protectedNoticeLabel);
            Controls.Add(countryComboBox);
            Controls.Add(countryLabel);
            Controls.Add(itadKeyTextBox);
            Controls.Add(itadKeyLabel);
            Controls.Add(sessionTokenHelpLabel);
            Controls.Add(steamSessionTokenTextBox);
            Controls.Add(steamSessionTokenLabel);
            Controls.Add(steamIdTextBox);
            Controls.Add(steamIdLabel);
            Controls.Add(steamKeyTextBox);
            Controls.Add(steamKeyLabel);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(232, 238, 245);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
