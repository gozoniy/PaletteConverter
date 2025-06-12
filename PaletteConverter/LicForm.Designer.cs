namespace PaletteConverter
{
    partial class LicForm
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
            label1 = new Label();
            NameLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            OrgLabel = new Label();
            DateLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            label1.Location = new Point(15, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 0;
            label1.Text = "Владелец лицензии";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Google Sans", 12F);
            NameLabel.Location = new Point(15, 32);
            NameLabel.Margin = new Padding(4, 0, 4, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(16, 20);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            label2.Location = new Point(15, 52);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 2;
            label2.Text = "Организация";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Google Sans", 12F, FontStyle.Bold);
            label3.Location = new Point(15, 92);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(157, 20);
            label3.TabIndex = 3;
            label3.Text = "Действительна до";
            label3.Click += label3_Click;
            // 
            // OrgLabel
            // 
            OrgLabel.AutoSize = true;
            OrgLabel.Font = new Font("Google Sans", 12F);
            OrgLabel.Location = new Point(15, 72);
            OrgLabel.Margin = new Padding(4, 0, 4, 0);
            OrgLabel.Name = "OrgLabel";
            OrgLabel.Size = new Size(16, 20);
            OrgLabel.TabIndex = 4;
            OrgLabel.Text = "-";
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Font = new Font("Google Sans", 12F);
            DateLabel.Location = new Point(15, 112);
            DateLabel.Margin = new Padding(4, 0, 4, 0);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(16, 20);
            DateLabel.TabIndex = 5;
            DateLabel.Text = "-";
            // 
            // LicForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 176);
            Controls.Add(DateLabel);
            Controls.Add(OrgLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NameLabel);
            Controls.Add(label1);
            Font = new Font("Google Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "LicForm";
            Text = "Информация о лицензии";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label NameLabel;
        private Label label2;
        private Label label3;
        private Label OrgLabel;
        private Label DateLabel;
    }
}