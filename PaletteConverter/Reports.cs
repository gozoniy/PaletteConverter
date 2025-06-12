using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaletteConverter
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        public void ShowPluginExecutionChartReport(string selectedPluginName)
        {
            /*
            // Получаем времена выполнения из Form1
            if (!Form1.pluginExecutionTimes.TryGetValue(selectedPluginName, out var execTimes) || execTimes.Count == 0)
            {
                MessageBox.Show("Нет данных для выбранного плагина.");
                return;
            }

            // Очищаем старый график
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Создаём область графика
            ChartArea chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Add(chartArea);

            // Создаём серию данных
            Series series = new Series("Execution Time")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = System.Drawing.Color.Blue,
                XValueType = ChartValueType.Int32
            };

            int index = 0;
            foreach (double time in execTimes)
            {
                series.Points.AddXY(index++, time);
            }

            chart1.Series.Add(series);

            // Создание отчёта
            Report report = new Report();

            // Вставляем chart1 в отчёт как объект
            var chartObject = new FastReport.DataVisualization.Charting.ChartObject();
            chartObject.Chart = chart1;
            chartObject.Bounds = new System.Drawing.RectangleF(0, 0, Units.Centimeters * 16, Units.Centimeters * 10);

            // Добавляем страницу и объект
            report.Pages.Clear();
            ReportPage page = new ReportPage();
            page.CreateUniqueName();
            report.Pages.Add(page);

            page.ReportTitle = new ReportTitleBand();
            page.ReportTitle.Height = Units.Centimeters * 10;
            page.ReportTitle.CreateUniqueName();
            page.ReportTitle.Objects.Add(chartObject);

            // Показать отчёт
            report.Show();
            */
        }

    }
}
