using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaletteConverter
{
    public partial class PipetteForm : Form
    {
        public event Action<Color> ColorPicked;
        private Color lastColor = Color.White;
        private Point lastMousePosition = Point.Empty;

        private void UpdateColorPreview(Color color, Point location)
        {
            lastColor = color;
            lastMousePosition = location;

            // Обновляем информацию о цвете (если нужно)
            //lblColorInfo.Text = $"RGB: {color.R}, {color.G}, {color.B}";
            //colorPreviewPanel.BackColor = color;
        }
        public PipetteForm()
        {
            InitializeComponent();
            // Подключаем обработчики
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseClick += pictureBox1_MouseClick;

            pictureBox1.Paint -= pictureBox1_Paint; // Если был подписан
            pictureBox1.Paint += pictureBox1_Paint;

            this.DoubleBuffered = true;
            //pictureBox1.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public Color SelectedColor { get; private set; }

        private Color[,] colorBuffer;

        private void PreloadColors(Bitmap bmp)
        {
            colorBuffer = new Color[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    colorBuffer[x, y] = bmp.GetPixel(x, y);
                }
            }
        }
        private Color GetBufferedColor(int x, int y)
        {
            // Проверяем границы массива, чтобы избежать ошибок
            x = Math.Clamp(x, 0, colorBuffer.GetLength(0) - 1);
            y = Math.Clamp(y, 0, colorBuffer.GetLength(1) - 1);
            return colorBuffer[x, y];
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Настраиваем диалог выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image File"
            };

            // Показываем диалог и проверяем выбор файла
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Загружаем изображение в PictureBox
                    Bitmap loadedBitmap = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = loadedBitmap;

                    // Передаём Bitmap в PreloadColors
                    PreloadColors(loadedBitmap);

                    // Настраиваем отображение
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Cursor = Cursors.Cross; // Меняем курсор на крестик
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            pictureBox1.Invalidate(); // Принудительная перерисовка
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image == null || lastMousePosition == Point.Empty)
                return;

            // Настройки круга
            int circleRadius = 25; // Радиус обруча
            int thickness = 5;     // Толщина линии

            // Рисуем ТОЛЬКО внешний круг в цвете пикселя
            using (Pen colorPen = new Pen(lastColor, thickness))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(
                    colorPen,
                    lastMousePosition.X - circleRadius,
                    lastMousePosition.Y - circleRadius,
                    circleRadius * 2,
                    circleRadius * 2
                );
            }
        }
        /*
        private Color GetContrastColor(Color color)
        {
            // Вычисляем яркость цвета
            double brightness = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B;
            return brightness > 128 ? Color.Black : Color.White;
        }
        */



        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private Color GetPixelSafe(Bitmap bmp, int x, int y)
        {
            x = Math.Clamp(x, 0, bmp.Width - 1);
            y = Math.Clamp(y, 0, bmp.Height - 1);
            return bmp.GetPixel(x, y);
        }
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null || colorBuffer == null) return; // Проверяем, что буфер цветов загружен

            var bmp = (Bitmap)pictureBox1.Image;
            RectangleF imageRect = GetImageRectangle(pictureBox1);

            if (!imageRect.Contains(e.Location))
            {
                pictureBox1.Cursor = Cursors.Default;
                return;
            }

            // Получаем координаты на изображении
            int x = (int)((e.X - imageRect.X) * bmp.Width / imageRect.Width);
            int y = (int)((e.Y - imageRect.Y) * bmp.Height / imageRect.Height);

            // Используем GetBufferedColor для получения цвета из буфера
            Color pixelColor = GetBufferedColor(x, y);

            // Обновляем предпросмотр цвета
            UpdateColorPreview(pixelColor, e.Location);

            // Вызываем событие для обновления главной формы
            ColorPicked?.Invoke(pixelColor);

            // Принудительная перерисовка
            pictureBox1.Invalidate();
        }
        private RectangleF GetImageRectangle(PictureBox pb)
        {
            if (pb.Image == null) return RectangleF.Empty;

            float imageAspect = (float)pb.Image.Width / pb.Image.Height;
            float controlAspect = (float)pb.Width / pb.Height;

            float width, height, x, y;

            if (imageAspect > controlAspect)
            {
                // Изображение шире контрола (пустые области сверху и снизу)
                width = pb.Width;
                height = width / imageAspect;
                x = 0;
                y = (pb.Height - height) / 2;
            }
            else
            {
                // Изображение уже контрола (пустые области по бокам)
                height = pb.Height;
                width = height * imageAspect;
                y = 0;
                x = (pb.Width - width) / 2;
            }

            return new RectangleF(x, y, width, height);
        }
        

        private double GetColorDistance(Color c1, Color c2)
        {
            // Вычисляем евклидово расстояние между двумя цветами
            int rDiff = c1.R - c2.R;
            int gDiff = c1.G - c2.G;
            int bDiff = c1.B - c2.B;

            return Math.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
        }
    }
}
