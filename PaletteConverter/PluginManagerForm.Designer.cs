namespace PaletteConverter
{
    partial class PluginManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkedListBoxPlugins = new CheckedListBox();
            ApplyButton = new Button();
            CancelButton = new Button();
            Label2 = new Label();
            Label1 = new Label();
            AuthorLabel = new Label();
            Label3 = new Label();
            VersionLabel = new Label();
            label4 = new Label();
            GuidLabel = new Label();
            label5 = new Label();
            CreatedLabel = new Label();
            label6 = new Label();
            UpdatedLabel = new Label();
            DescBox = new TextBox();
            SuspendLayout();
            // 
            // checkedListBoxPlugins
            // 
            checkedListBoxPlugins.Dock = DockStyle.Left;
            checkedListBoxPlugins.FormattingEnabled = true;
            checkedListBoxPlugins.Location = new Point(0, 0);
            checkedListBoxPlugins.Name = "checkedListBoxPlugins";
            checkedListBoxPlugins.Size = new Size(294, 473);
            checkedListBoxPlugins.TabIndex = 0;
            checkedListBoxPlugins.SelectedIndexChanged += checkedListBoxPlugins_SelectedIndexChanged;
            // 
            // ApplyButton
            // 
            ApplyButton.Anchor = AnchorStyles.Right;
            ApplyButton.Location = new Point(586, 438);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(85, 23);
            ApplyButton.TabIndex = 1;
            ApplyButton.Text = "Применить";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Right;
            CancelButton.Location = new Point(677, 438);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(85, 23);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(300, 97);
            Label2.Name = "Label2";
            Label2.Size = new Size(62, 15);
            Label2.TabIndex = 3;
            Label2.Text = "Описание";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(300, 38);
            Label1.Name = "Label1";
            Label1.Size = new Size(40, 15);
            Label1.TabIndex = 4;
            Label1.Text = "Автор";
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Location = new Point(300, 53);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(23, 15);
            AuthorLabel.TabIndex = 5;
            AuthorLabel.Text = "<>";
            // 
            // Label3
            // 
            Label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label3.AutoSize = true;
            Label3.Location = new Point(479, 38);
            Label3.Name = "Label3";
            Label3.Size = new Size(46, 15);
            Label3.TabIndex = 7;
            Label3.Text = "Версия";
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(479, 53);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(23, 15);
            VersionLabel.TabIndex = 8;
            VersionLabel.Text = "<>";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(543, 38);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 9;
            label4.Text = "GUID";
            // 
            // GuidLabel
            // 
            GuidLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GuidLabel.AutoSize = true;
            GuidLabel.Location = new Point(543, 53);
            GuidLabel.Name = "GuidLabel";
            GuidLabel.Size = new Size(23, 15);
            GuidLabel.TabIndex = 10;
            GuidLabel.Text = "<>";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(306, 372);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 11;
            label5.Text = "Создан";
            // 
            // CreatedLabel
            // 
            CreatedLabel.AutoSize = true;
            CreatedLabel.Location = new Point(306, 387);
            CreatedLabel.Name = "CreatedLabel";
            CreatedLabel.Size = new Size(23, 15);
            CreatedLabel.TabIndex = 12;
            CreatedLabel.Text = "<>";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(306, 402);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 13;
            label6.Text = "Обновлен";
            // 
            // UpdatedLabel
            // 
            UpdatedLabel.AutoSize = true;
            UpdatedLabel.Location = new Point(306, 417);
            UpdatedLabel.Name = "UpdatedLabel";
            UpdatedLabel.Size = new Size(23, 15);
            UpdatedLabel.TabIndex = 14;
            UpdatedLabel.Text = "<>";
            // 
            // DescBox
            // 
            DescBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DescBox.Location = new Point(300, 115);
            DescBox.Multiline = true;
            DescBox.Name = "DescBox";
            DescBox.ReadOnly = true;
            DescBox.Size = new Size(454, 146);
            DescBox.TabIndex = 15;
            // 
            // PluginManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 473);
            Controls.Add(DescBox);
            Controls.Add(UpdatedLabel);
            Controls.Add(label6);
            Controls.Add(CreatedLabel);
            Controls.Add(label5);
            Controls.Add(GuidLabel);
            Controls.Add(label4);
            Controls.Add(VersionLabel);
            Controls.Add(Label3);
            Controls.Add(AuthorLabel);
            Controls.Add(Label1);
            Controls.Add(Label2);
            Controls.Add(CancelButton);
            Controls.Add(ApplyButton);
            Controls.Add(checkedListBoxPlugins);
            Name = "PluginManagerForm";
            Text = "PluginManagerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxPlugins;
        private Button ApplyButton;
        private Button CancelButton;
        private Label Label2;
        private Label Label1;
        private Label AuthorLabel;
        private Label Label3;
        private Label VersionLabel;
        private Label label4;
        private Label GuidLabel;
        private Label label5;
        private Label CreatedLabel;
        private Label label6;
        private Label UpdatedLabel;
        private TextBox DescBox;
    }
}