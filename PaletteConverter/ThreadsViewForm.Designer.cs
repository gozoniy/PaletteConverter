namespace PaletteConverter
{
    partial class ThreadsViewForm
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
            dataGridView1 = new DataGridView();
            GroupButton = new Button();
            ClearBaseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(449, 409);
            dataGridView1.TabIndex = 0;
            // 
            // GroupButton
            // 
            GroupButton.Location = new Point(12, 12);
            GroupButton.Name = "GroupButton";
            GroupButton.Size = new Size(94, 23);
            GroupButton.TabIndex = 1;
            GroupButton.Text = "Группировать";
            GroupButton.UseVisualStyleBackColor = true;
            GroupButton.Click += GroupButton_Click;
            // 
            // ClearBaseButton
            // 
            ClearBaseButton.Location = new Point(112, 12);
            ClearBaseButton.Name = "ClearBaseButton";
            ClearBaseButton.Size = new Size(94, 23);
            ClearBaseButton.TabIndex = 2;
            ClearBaseButton.Text = "Очистить";
            ClearBaseButton.UseVisualStyleBackColor = true;
            ClearBaseButton.Click += ClearBaseButton_Click;
            // 
            // ThreadsViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 450);
            Controls.Add(ClearBaseButton);
            Controls.Add(GroupButton);
            Controls.Add(dataGridView1);
            Name = "ThreadsViewForm";
            Text = "Просмотр задач";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button GroupButton;
        private Button ClearBaseButton;
    }
}