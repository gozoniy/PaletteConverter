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
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Владелец лицензии";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 24);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(12, 15);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 2;
            label2.Text = "Организация";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 69);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 3;
            label3.Text = "Действительна до";
            label3.Click += label3_Click;
            // 
            // OrgLabel
            // 
            OrgLabel.AutoSize = true;
            OrgLabel.Location = new Point(12, 54);
            OrgLabel.Name = "OrgLabel";
            OrgLabel.Size = new Size(12, 15);
            OrgLabel.TabIndex = 4;
            OrgLabel.Text = "-";
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(12, 84);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(12, 15);
            DateLabel.TabIndex = 5;
            DateLabel.Text = "-";
            // 
            // LicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 132);
            Controls.Add(DateLabel);
            Controls.Add(OrgLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NameLabel);
            Controls.Add(label1);
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