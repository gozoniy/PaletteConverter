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
            Settings_button = new Button();
            label7 = new Label();
            TypeLabel = new Label();
            LastOperations = new TextBox();
            SuspendLayout();
            // 
            // checkedListBoxPlugins
            // 
            checkedListBoxPlugins.Dock = DockStyle.Left;
            checkedListBoxPlugins.FormattingEnabled = true;
            checkedListBoxPlugins.Location = new Point(0, 0);
            checkedListBoxPlugins.Margin = new Padding(4);
            checkedListBoxPlugins.Name = "checkedListBoxPlugins";
            checkedListBoxPlugins.Size = new Size(377, 631);
            checkedListBoxPlugins.TabIndex = 0;
            checkedListBoxPlugins.SelectedIndexChanged += checkedListBoxPlugins_SelectedIndexChanged;
            // 
            // ApplyButton
            // 
            ApplyButton.Anchor = AnchorStyles.Right;
            ApplyButton.Font = new Font("Google Sans", 12F);
            ApplyButton.Location = new Point(753, 584);
            ApplyButton.Margin = new Padding(4);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(109, 31);
            ApplyButton.TabIndex = 1;
            ApplyButton.Text = "Применить";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Right;
            CancelButton.Font = new Font("Google Sans", 12F);
            CancelButton.Location = new Point(870, 584);
            CancelButton.Margin = new Padding(4);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(109, 31);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Google Sans", 12F);
            Label2.Location = new Point(386, 147);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(84, 20);
            Label2.TabIndex = 3;
            Label2.Text = "Описание";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            Label1.Location = new Point(386, 51);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(58, 20);
            Label1.TabIndex = 4;
            Label1.Text = "Автор";
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Font = new Font("Google Sans", 12F);
            AuthorLabel.Location = new Point(386, 71);
            AuthorLabel.Margin = new Padding(4, 0, 4, 0);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(25, 20);
            AuthorLabel.TabIndex = 5;
            AuthorLabel.Text = "<>";
            // 
            // Label3
            // 
            Label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label3.AutoSize = true;
            Label3.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            Label3.Location = new Point(616, 51);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(65, 20);
            Label3.TabIndex = 7;
            Label3.Text = "Версия";
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            VersionLabel.AutoSize = true;
            VersionLabel.Font = new Font("Google Sans", 12F);
            VersionLabel.Location = new Point(616, 71);
            VersionLabel.Margin = new Padding(4, 0, 4, 0);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(25, 20);
            VersionLabel.TabIndex = 8;
            VersionLabel.Text = "<>";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            label4.Location = new Point(698, 51);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 9;
            label4.Text = "GUID";
            // 
            // GuidLabel
            // 
            GuidLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GuidLabel.AutoSize = true;
            GuidLabel.Font = new Font("Google Sans", 12F);
            GuidLabel.Location = new Point(698, 71);
            GuidLabel.Margin = new Padding(4, 0, 4, 0);
            GuidLabel.Name = "GuidLabel";
            GuidLabel.Size = new Size(25, 20);
            GuidLabel.TabIndex = 10;
            GuidLabel.Text = "<>";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Google Sans", 12F);
            label5.Location = new Point(393, 496);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 11;
            label5.Text = "Создан";
            // 
            // CreatedLabel
            // 
            CreatedLabel.AutoSize = true;
            CreatedLabel.Font = new Font("Google Sans", 12F);
            CreatedLabel.Location = new Point(393, 516);
            CreatedLabel.Margin = new Padding(4, 0, 4, 0);
            CreatedLabel.Name = "CreatedLabel";
            CreatedLabel.Size = new Size(25, 20);
            CreatedLabel.TabIndex = 12;
            CreatedLabel.Text = "<>";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Google Sans", 12F);
            label6.Location = new Point(393, 536);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 13;
            label6.Text = "Обновлен";
            // 
            // UpdatedLabel
            // 
            UpdatedLabel.AutoSize = true;
            UpdatedLabel.Font = new Font("Google Sans", 12F);
            UpdatedLabel.Location = new Point(393, 556);
            UpdatedLabel.Margin = new Padding(4, 0, 4, 0);
            UpdatedLabel.Name = "UpdatedLabel";
            UpdatedLabel.Size = new Size(25, 20);
            UpdatedLabel.TabIndex = 14;
            UpdatedLabel.Text = "<>";
            // 
            // DescBox
            // 
            DescBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DescBox.Font = new Font("Google Sans", 12F);
            DescBox.Location = new Point(386, 171);
            DescBox.Margin = new Padding(4);
            DescBox.Multiline = true;
            DescBox.Name = "DescBox";
            DescBox.ReadOnly = true;
            DescBox.Size = new Size(583, 193);
            DescBox.TabIndex = 15;
            // 
            // Settings_button
            // 
            Settings_button.Anchor = AnchorStyles.Right;
            Settings_button.Enabled = false;
            Settings_button.Font = new Font("Google Sans", 12F);
            Settings_button.Location = new Point(393, 584);
            Settings_button.Margin = new Padding(4);
            Settings_button.Name = "Settings_button";
            Settings_button.Size = new Size(109, 31);
            Settings_button.TabIndex = 16;
            Settings_button.Text = "Настройки";
            Settings_button.UseVisualStyleBackColor = true;
            Settings_button.Click += Settings_button_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            label7.Location = new Point(386, 91);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(139, 20);
            label7.TabIndex = 17;
            label7.Text = "Тип расширения";
            label7.Click += label7_Click;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Font = new Font("Google Sans", 12F);
            TypeLabel.Location = new Point(386, 111);
            TypeLabel.Margin = new Padding(4, 0, 4, 0);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(25, 20);
            TypeLabel.TabIndex = 18;
            TypeLabel.Text = "<>";
            // 
            // LastOperations
            // 
            LastOperations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LastOperations.Font = new Font("Google Sans", 12F);
            LastOperations.Location = new Point(386, 381);
            LastOperations.Margin = new Padding(4);
            LastOperations.Multiline = true;
            LastOperations.Name = "LastOperations";
            LastOperations.ReadOnly = true;
            LastOperations.Size = new Size(583, 69);
            LastOperations.TabIndex = 19;
            // 
            // PluginManagerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 631);
            Controls.Add(LastOperations);
            Controls.Add(TypeLabel);
            Controls.Add(label7);
            Controls.Add(Settings_button);
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
            Font = new Font("Google Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "PluginManagerForm";
            Text = "Менеджер плагинов";
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
        private Button Settings_button;
        private Label label7;
        private Label TypeLabel;
        private TextBox LastOperations;
    }
}