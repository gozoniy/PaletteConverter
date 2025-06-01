using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace PaletteConverter
{
    public partial class ThreadsViewForm : Form
    {
        private string dbPath = Path.Combine(Application.StartupPath, "log.db");
        private string connectionString;

        public ThreadsViewForm()
        {
            InitializeComponent();
            connectionString = $"Data Source={dbPath}";
            LoadLogData();
        }

        private void LoadLogData()
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT * FROM ParseLog ORDER BY Id DESC", conn);
                    var adapter = new SQLiteDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;

                    // Авторастяжение колонок
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Локализация заголовков
                    if (dataGridView1.Columns.Contains("Id"))
                        dataGridView1.Columns["Id"].HeaderText = "ID";
                    if (dataGridView1.Columns.Contains("ThreadId"))
                        dataGridView1.Columns["ThreadId"].HeaderText = "Поток";
                    if (dataGridView1.Columns.Contains("PaintName"))
                        dataGridView1.Columns["PaintName"].HeaderText = "Краска";
                    if (dataGridView1.Columns.Contains("DurationMs"))
                        dataGridView1.Columns["DurationMs"].HeaderText = "Время (мс)";
                    if (dataGridView1.Columns.Contains("Timestamp"))
                        dataGridView1.Columns["Timestamp"].HeaderText = "Время";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки логов: " + ex.Message);
            }
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection("Data Source=log.db"))
            {
                conn.Open();

                var query = @"
                    SELECT 
                        ThreadId AS 'Поток',
                        COUNT(*) AS 'Количество задач',
                        MIN(DurationMs) AS 'Минимум (мс)',
                        ROUND(AVG(DurationMs), 2) AS 'Среднее (мс)',
                        MAX(DurationMs) AS 'Максимум (мс)'
                    FROM ParseLog
                    GROUP BY ThreadId
                    ORDER BY ThreadId;
                ";

                var cmd = new SQLiteCommand(query, conn);
                var adapter = new SQLiteDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ClearBaseButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить все логи?",
                "Подтверждение очистки",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("DELETE FROM ParseLog", conn);
                        cmd.ExecuteNonQuery();
                    }
                    LoadLogData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при очистке логов: " + ex.Message);
                }
            }
        }
    }
}
