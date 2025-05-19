using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using PalettePluginContracts;

using System.Runtime.InteropServices;
using System.Drawing.Imaging;

using System;

using HtmlAgilityPack;
using System.Text.RegularExpressions;
using AngleSharp.Text;
using ParserContracts;





namespace PaletteConverter
{

    public partial class Form1 : Form
    {
        public class PaletteColor
        {
            public string code { get; set; }
            public string rgb_approx { get; set; }
            public string rgb_hex { get; set; }
            public string name { get; set; }
        }
        /*
        public interface IProductParserPlugin
        {
            string PluginName { get; }
            List<string> SupportedBrands { get; }
            Task<string> LoadPageSourceAsync(string brand);
            List<ProductInfo> ParseProducts(string html);
            public string name { get; set; }
        }*/



        private string enabledPluginsFile = "enabled_plugins.txt";
        private Dictionary<string, PaletteColor> ralColors = new();


        public Form1()
        {
            InitializeComponent();
            comboBox3.SelectedIndex = 0;


            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;  // �������� ��������� ���������
            comboBox2.DrawItem += comboBox2_DrawItem;     // ������������� �� ������� DrawItem

            var pluginManagerForm = new PluginManagerForm();

            // ������������� �� ������� �������� ��������
            //pluginManagerForm.PluginsLoaded += OnPluginsLoaded;

            // ���������� ����� ��������� ��������
            //pluginManagerForm.Show();
            refreshPlugins();
            LoadEnabledPluginNames();



            comboBox6.SelectedIndex = 0;
        }


        private void LoadEnabledPluginNames()
        {
            if (!File.Exists(enabledPluginsFile))
            {
                MessageBox.Show("���� � ��������� ��������� �� ������.");
                return;
            }

            var lines = File.ReadAllLines(enabledPluginsFile);
            var pluginNames = new List<string>();

            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                    pluginNames.Add(trimmed);
            }
            /*
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(pluginNames.ToArray());
            */
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }
        private void ColorPic1()
        {
            {
                // ������� ������ ������ �����
                ColorDialog colorDialog = new ColorDialog();

                // �����������: ������������� ��������� ���� (��������, ������� ���� panel1)
                colorDialog.Color = panel1.BackColor;

                // ���������� ������ � ���������, ��� ������������ ����� OK
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // ������������� ��������� ���� ��� panel1
                    panel1.BackColor = colorDialog.Color;

                    // �����������: ������� HEX-��� ����� (���� �����)
                    string hexColor = "#" + colorDialog.Color.R.ToString("X2")
                                            + colorDialog.Color.G.ToString("X2")
                                            + colorDialog.Color.B.ToString("X2");
                    //MessageBox.Show("������ ����: " + hexColor);
                    CurrentColorHEX.Text = hexColor;
                    ColR.Text = colorDialog.Color.R.ToString();
                    ColG.Text = colorDialog.Color.G.ToString();
                    ColB.Text = colorDialog.Color.B.ToString();
                    FindClosestColor();
                }
            }
        }
        private void ColorPic_Click(object sender, EventArgs e)
        {
            ColorPic1();
        }


        private void pipette_Click(object sender, EventArgs e)
        {
            var pipetteForm = new PipetteForm();

            // ������������� �� ������� ������ �����
            pipetteForm.ColorPicked += color =>
            {
                // ��������� ��������� � �������� �������
                panel1.BackColor = color;
                CurrentColorHEX.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
                ColR.Text = color.R.ToString();
                ColG.Text = color.G.ToString();
                ColB.Text = color.B.ToString();
                FindClosestColor();
            };

            // ���������� ����� ��� ����������� ����
            pipetteForm.Show();

            // �����������: �������� ��� �������� �����-�������
            pipetteForm.FormClosed += (s, args) => pipetteForm.Dispose();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            var plugin = loadedPlugins.FirstOrDefault(p => p.Name == selected);
            if (plugin != null)
            {
                var colors = plugin.LoadColors();
                comboBox2.Items.Clear();
                foreach (var kvp in colors)
                    comboBox2.Items.Add($"{kvp.Key} - {kvp.Value.name} - {kvp.Value.rgb_hex}");
            }
            //comboBox2.DroppedDown = true;
            FindClosestColor();
            //System.Threading.Thread.Sleep(1000); // Replace "sleep()" with the correct method and add a semicolon
            //comboBox2.DroppedDown = false;
        }
        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;  // ��������� �� ���������� ������

            var comboBox = sender as ComboBox;
            string itemText = comboBox.Items[e.Index].ToString();

            // ��������� HEX ��� ����� (�� ������ ���� � ����� ������)
            string hexColor = itemText.Substring(itemText.LastIndexOf(" - ") + 3);

            // ���������, ��� ��� �������� HEX ���
            if (hexColor.Length == 6 || hexColor.Length == 7) // 6 �������� ��� `#` ��� 7 � `#`
            {
                try
                {
                    // ���� HEX ��� �� ���������� � '#', ��������� ���
                    if (hexColor[0] != '#')
                    {
                        hexColor = "#" + hexColor;
                    }

                    // ����������� � ���� � ������ ����������� �������
                    Color color = ColorTranslator.FromHtml(hexColor);
                    e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);  // ����������� ��� ������

                    // ���������� ������� ����
                    int brightness = (int)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);

                    // ���� ������� ������ (������ ����), ���������� ����� �����
                    Brush textBrush = brightness < 128 ? Brushes.White : Brushes.Black;

                    // ������ ����� �� ����
                    e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds.Left, e.Bounds.Top);
                }
                catch
                {
                    // ���� ��������� ������, ��������� ����������� ���
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }
            else
            {
                // ���� HEX ��� ������������, ���������� ����������� ���
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);
            }

            e.DrawFocusRectangle();  // ������������ ����� ��� ��������� ��������
        }




        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private static List<IColorPalettePlugin> loadedPlugins = new();
        private static List<IProductParserPlugin> loadedParsers = new();
        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manager = new PluginManagerForm();
            manager.ShowDialog();

            loadedPlugins = PluginManagerForm.GetEnabledPalettes();

            comboBox1.Items.Clear();
            foreach (var plugin in loadedPlugins)
                comboBox1.Items.Add(plugin.Name);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }
        private void refreshPlugins()
        {
            //var manager = new PluginManagerForm();

            //MessageBox.Show("������� ���������");
            //manager.LoadPlugins();
            //manager.LoadEnabledPlugins();
            loadedPlugins = PluginManagerForm.GetEnabledPalettes();
            loadedParsers = PluginManagerForm.GetEnabledParsers();
            comboBox1.Items.Clear();
            foreach (var plugin in loadedPlugins)
                comboBox1.Items.Add(plugin.Name);
            foreach (var parser in loadedParsers)
                comboBox4.Items.Add(parser.Name);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            if (comboBox4.Items.Count > 0)
                comboBox4.SelectedIndex = 0;
        }

        private void ColorNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                return;

            // �������� ��� ���������� �������
            string selectedPluginName = comboBox1.SelectedItem.ToString();

            // ������� ��������������� ������
            var plugin = loadedPlugins.FirstOrDefault(p => p.Name == selectedPluginName);
            if (plugin == null)
                return;

            // ��������� ����� �� �������
            var colors = plugin.LoadColors();

            // ��������� ��� ����� (�� ������)
            var selected = comboBox2.SelectedItem.ToString();
            var code = selected.Split('-')[0].Trim();

            if (colors.TryGetValue(code, out var color))
            {
                // ������������� ���� ������
                try
                {
                    panel2.BackColor = ColorTranslator.FromHtml(color.rgb_hex);
                }
                catch
                {
                    MessageBox.Show($"������ �������������� HEX: {color.rgb_hex}");
                }

                // ��������� ����
                AnalogColorHEX.Text = color.rgb_hex;

                var rgbParts = color.rgb_approx.Split('-');
                if (rgbParts.Length == 3)
                {
                    AnColR.Text = rgbParts[0];
                    AnColG.Text = rgbParts[1];
                    AnColB.Text = rgbParts[2];
                }
            }
            string comparisonMethod = comboBox3.SelectedItem?.ToString() ?? "RGB";
            int minDistance = int.MaxValue;

            //updateSimilarity(minDistance, comparisonMethod);
            FindClosestColor(1);
        }

        public void FindClosestColor(int flag = 0)
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            string selectedPluginName = comboBox1.SelectedItem.ToString();
            var plugin = loadedPlugins.FirstOrDefault(p => p.Name == selectedPluginName);
            if (plugin == null)
                return;

            var colors = plugin.LoadColors();

            // ����������� HEX � Color
            Color targetColor;
            try
            {
                targetColor = ColorTranslator.FromHtml(CurrentColorHEX.Text);
            }
            catch
            {
                MessageBox.Show("�������� HEX-��� �����.");
                return;
            }

            int minDistance = int.MaxValue;
            string closestCode = null;
            PalettePluginContracts.PaletteColor closestColor = null;

            // �������� ��������� ����� ��������� �� comboBox3
            string comparisonMethod = comboBox3.SelectedItem?.ToString() ?? "RGB";
            if (flag == 0)
            {
                foreach (var kv in colors)
                {
                    string code = kv.Key;
                    PalettePluginContracts.PaletteColor col = kv.Value;

                    Color colorInPalette;
                    try
                    {
                        colorInPalette = ColorTranslator.FromHtml(col.rgb_hex);
                    }
                    catch
                    {
                        continue; // ���������� ������������ ����
                    }

                    int dist;
                    switch (comparisonMethod)
                    {
                        case "HSV":
                            dist = ColorDistanceHSV(targetColor, colorInPalette);
                            break;
                        case "LAB":
                            dist = ColorDistanceLab(targetColor, colorInPalette);
                            break;
                        case "HLC":
                        case "LCH": // �������� �������
                            dist = ColorDistanceLch(targetColor, colorInPalette);
                            break;
                        default:
                            dist = ColorDistanceSquared(targetColor, colorInPalette);
                            break;
                    }


                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        closestCode = code;
                        closestColor = col;
                    }
                }
            }
            else
            {
                int dist;
                Color colorInPalette = ColorTranslator.FromHtml(AnalogColorHEX.Text);

                switch (comparisonMethod)
                {
                    case "HSV":
                        dist = ColorDistanceHSV(targetColor, colorInPalette);
                        break;
                    case "LAB":
                        dist = ColorDistanceLab(targetColor, colorInPalette);
                        break;
                    case "HLC":
                    case "LCH": // �������� �������
                        dist = ColorDistanceLch(targetColor, colorInPalette);
                        break;
                    default:
                        dist = ColorDistanceSquared(targetColor, colorInPalette);
                        break;
                }

                minDistance = dist;

            }
            if (flag == 1)
            {
                updateSimilarity(minDistance, comparisonMethod);
            }
            else
            {


                if (closestCode != null && closestColor != null)
                {
                    // ���������� ���������
                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        var item = comboBox2.Items[i].ToString();
                        if (item.StartsWith(closestCode))
                        {
                            comboBox2.SelectedIndex = i;
                            break;
                        }
                    }
                    updateSimilarity(minDistance, comparisonMethod);


                }
                else
                {
                    MessageBox.Show("�� ������� ����� ���������� ����.");
                    similarityBox.Text = "";
                }
            }

        }
        private void updateSimilarity(int minDistance, string comparisonMethod)
        {
            double similarity;
            double maxDistance = GetMaxDistance(comparisonMethod);
            similarity = 100.0 - (minDistance * 100.0 / maxDistance);
            similarity = Math.Clamp(similarity, 0, 100); // ����� �� ������� �� �������

            //MessageBox.Show(similarity.ToString());
            // ��������� � ���������� ������� ����������
            //double similarity = 100.0 - (minDistance * 100.0 / 195075.0);
            similarity = Math.Max(0, Math.Min(100, similarity)); // �� ������ ������ �� �������

            similarityBox.Text = $"{similarity:F2}%";
        }

        private double GetMaxDistance(string method)
        {
            return method switch
            {
                "RGB" => 195075.0,
                "HSV" => 360.0,
                "LAB" => 10000.0,
                "LCH" or "HLC" => 15000.0,
                _ => 1.0
            };
        }

        private static int ColorDistanceSquared(Color c1, Color c2)
        {
            int dr = c1.R - c2.R;
            int dg = c1.G - c2.G;
            int db = c1.B - c2.B;
            return dr * dr + dg * dg + db * db;
        }





        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CurrentColorHEX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(CurrentColorHEX.Text);
                panel1.BackColor = color;

                ColR.Text = color.R.ToString();
                ColG.Text = color.G.ToString();
                ColB.Text = color.B.ToString();
            }
            catch
            {
                panel1.BackColor = SystemColors.Control;
                MessageBox.Show("�������� HEX-��� �����.");
                // ������� ���� ��� ������
                ColR.Text = "";
                ColG.Text = "";
                ColB.Text = "";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindClosestColor();
        }
        private int ColorDistanceHSV(Color c1, Color c2)
        {
            var (h1, s1, v1) = RgbToHsv(c1);
            var (h2, s2, v2) = RgbToHsv(c2);

            // ��������� ����������� hue
            double dh = Math.Min(Math.Abs(h1 - h2), 360 - Math.Abs(h1 - h2)) / 180.0; // ����������� �� [0, 1]
            double ds = s1 - s2;
            double dv = v1 - v2;

            // ������� ��������� �������
            double distance = dh * dh + ds * ds + dv * dv;
            return (int)(distance * 1000); // ������������ ��� �������������� ���������
        }






        private (double H, double S, double V) RgbToHsv(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double h = 0;
            if (delta > 0)
            {
                if (max == r)
                {
                    h = (g - b) / delta;
                }
                else if (max == g)
                {
                    h = 2 + (b - r) / delta;
                }
                else
                {
                    h = 4 + (r - g) / delta;
                }
                h *= 60;
                if (h < 0) h += 360;
            }

            double s = max == 0 ? 0 : delta / max;
            double v = max;

            return (h, s, v);
        }
        private static double[] RgbToXyz(Color color)
        {
            double r = PivotRgb(color.R / 255.0);
            double g = PivotRgb(color.G / 255.0);
            double b = PivotRgb(color.B / 255.0);

            // ����������� � XYZ (sRGB, D65)
            double x = r * 0.4124 + g * 0.3576 + b * 0.1805;
            double y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            double z = r * 0.0193 + g * 0.1192 + b * 0.9505;

            return new double[] { x, y, z };
        }

        private static double PivotRgb(double n)
        {
            return (n > 0.04045) ? Math.Pow((n + 0.055) / 1.055, 2.4) : n / 12.92;
        }

        private static (double L, double A, double B) RgbToLab(Color color)
        {
            var xyz = RgbToXyz(color);
            double x = xyz[0] / 0.95047;
            double y = xyz[1] / 1.00000;
            double z = xyz[2] / 1.08883;

            x = PivotLab(x);
            y = PivotLab(y);
            z = PivotLab(z);

            double l = 116 * y - 16;
            double a = 500 * (x - y);
            double b = 200 * (y - z);

            return (l, a, b);
        }

        private static double PivotLab(double n)
        {
            return n > 0.008856 ? Math.Pow(n, 1.0 / 3.0) : (7.787 * n) + (16.0 / 116.0);
        }

        private static (double L, double C, double H) RgbToLch(Color color)
        {
            var (l, a, b) = RgbToLab(color);
            double c = Math.Sqrt(a * a + b * b);
            double h = Math.Atan2(b, a) * (180.0 / Math.PI);
            if (h < 0) h += 360;
            return (l, c, h);
        }

        private static int ColorDistanceLab(Color c1, Color c2)
        {
            var (l1, a1, b1) = RgbToLab(c1);
            var (l2, a2, b2) = RgbToLab(c2);
            double dl = l1 - l2;
            double da = a1 - a2;
            double db = b1 - b2;
            return (int)(dl * dl + da * da + db * db);
        }

        private static int ColorDistanceLch(Color c1, Color c2)
        {
            var (l1, c1c, h1) = RgbToLch(c1);
            var (l2, c2c, h2) = RgbToLch(c2);

            double dh = Math.Min(Math.Abs(h1 - h2), 360 - Math.Abs(h1 - h2));
            double dl = l1 - l2;
            double dc = c1c - c2c;
            return (int)(dl * dl + dc * dc + dh * dh);
        }

        private void similarityBox_TextChanged(object sender, EventArgs e)
        {

        }













        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private System.Windows.Forms.Timer pipetteTimer;
        private bool isPicking = false;


        private MouseHook mouseHook;



        private void ScreenColorButton_Click(object sender, EventArgs e)
        {
            if (isPicking) return; // ���� ������� ��� ��������

            isPicking = true;

            // ��������� ������ ��� ������� �����
            pipetteTimer = new System.Windows.Forms.Timer();
            pipetteTimer.Interval = 50; // ������ 50 ��
            pipetteTimer.Tick += PipetteTimer_Tick;
            pipetteTimer.Start();

            // �������������� ���������� ��� ��� ��������� ������ ����
            mouseHook = new MouseHook();
            mouseHook.MouseClickDetected += () =>
            {
                pipetteTimer.Stop();
                pipetteTimer.Dispose();
                isPicking = false;

                // ������������� ��� ����� �����
                mouseHook.Unhook();
                mouseHook = null;
            };

        }


        private void PipetteTimer_Tick(object sender, EventArgs e)
        {
            GetCursorPos(out Point cursorPos);
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, cursorPos.X, cursorPos.Y);
            ReleaseDC(IntPtr.Zero, hdc);

            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                                         (int)(pixel & 0x0000FF00) >> 8,
                                         (int)(pixel & 0x00FF0000) >> 16);

            panel1.BackColor = color;

            string hexColor = "#" + color.R.ToString("X2")
                                    + color.G.ToString("X2")
                                    + color.B.ToString("X2");
            CurrentColorHEX.Text = hexColor;
            ColR.Text = color.R.ToString();
            ColG.Text = color.G.ToString();
            ColB.Text = color.B.ToString();
            FindClosestColor();
            
        }
        public class MouseClickFilter : IMessageFilter
        {
            public static MouseClickFilter Instance { get; private set; }
            private readonly Action onClick;

            public MouseClickFilter(Action onClick)
            {
                this.onClick = onClick;
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x201) // MSG: Left mouse button down
                {
                    onClick.Invoke();
                    return true; // ���������� ���������� ���������
                }
                return false;
            }
        }



        public class MouseHook
        {
            // ���������� ������� WinAPI
            private const int WH_MOUSE_LL = 14;
            private const int WM_LBUTTONDOWN = 0x201;

            private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
            private HookProc _hookProc;
            private IntPtr _hookID = IntPtr.Zero;

            public event Action MouseClickDetected;

            public MouseHook()
            {
                _hookProc = HookCallback;
                _hookID = SetHook(_hookProc);
            }

            // ��������� ����
            private IntPtr SetHook(HookProc proc)
            {
                IntPtr hInstance = Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]);
                return SetWindowsHookEx(WH_MOUSE_LL, proc, hInstance, 0);
            }

            // Callback ������� ����
            private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    MouseClickDetected?.Invoke();
                }

                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            // ������������ ����
            public void Unhook()
            {
                UnhookWindowsHookEx(_hookID);
            }

            // ��������������� ������� �� user32.dll
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll")]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
















        //������ ������� ����
        private void DepthBox_TextChanged(object sender, EventArgs e)
        {
            squareCalc();
        }


        private void squareCalc()
        {
            double square = 0;


            if (double.TryParse(WidthBox.Text, out double Width) &&
                double.TryParse(HeightBox.Text, out double Height) &&
                double.TryParse(DepthBox.Text, out double Depth))
            {
                square = 2 * (Width * Height + Height * Depth);
            }
            else
            {
                MessageBox.Show("����������, ������� ���������� �������� �������� ��� ������, ������ � �������.");
                SquareBox.Text = "";
                return;
            }

            SquareBox.Text = square.ToString("F2");
            calculate();

        }
        private void calculate()
        {
            double litersNeeded = 0;
            double cansNeeded = 0;
            double cans = 0;
            double totalPrice = 0;
            double TeoryPrice = 0; //
            double consumption = 0; // ������ �� 1 �2 � ������

            double layers = LayersLabel.Text == "" ? 1 : double.Parse(LayersLabel.Text);

            // ��������� ������ ������ �� ���������� ����
            double.TryParse(ConsumptionBox.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out consumption);

            double squareValue = 0;
            double.TryParse(SquareBox.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out squareValue);
            litersNeeded = squareValue * consumption * layers;

            double volume = 0;
            double price = 0;

            double.TryParse(VolumeBox.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out volume);
            double.TryParse(PriceBox.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price);

            if (volume > 0 && (price > 0 && price < 30000))
            {
                cansNeeded = litersNeeded / volume;
                // �����: Math.Ceiling(1.02) ������ ���� 2, ���� ��� double!
                cans = Math.Ceiling(cansNeeded);
                TeoryPrice = cans * price;
                totalPrice = cansNeeded * price;
                RubTLabel.Text = totalPrice.ToString("F2");
                RubLabel.Text = TeoryPrice.ToString("F2");
                LitreLabel.Text = litersNeeded.ToString("F2");
                CansLabel.Text = cansNeeded.ToString("F2");
                // ��� �������:
                //MessageBox.Show($"litersNeeded={litersNeeded:F4}, volume={volume:F4}, cansNeeded={cansNeeded:F4}, cans={cans}");
            }
        }
        private void HeightBox_TextChanged(object sender, EventArgs e)
        {
            squareCalc();
        }

        private void WidthBox_TextChanged(object sender, EventArgs e)
        {
            squareCalc();
        }

        private void ColorDiag2()
        {
            // ������� ������ ������ �����
            ColorDialog colorDialog = new ColorDialog();

            // �����������: ������������� ��������� ���� (��������, ������� ���� panel1)
            colorDialog.Color = panel3.BackColor;

            // ���������� ������ � ���������, ��� ������������ ����� OK
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // ������������� ��������� ���� ��� panel1
                panel3.BackColor = colorDialog.Color;

                // �����������: ������� HEX-��� ����� (���� �����)
                string hexColor = "#" + colorDialog.Color.R.ToString("X2")
                                        + colorDialog.Color.G.ToString("X2")
                                        + colorDialog.Color.B.ToString("X2");
                //MessageBox.Show("������ ����: " + hexColor);
                HexBox.Text = hexColor;
                /*ColR.Text = colorDialog.Color.R.ToString();
                ColG.Text = colorDialog.Color.G.ToString();
                ColB.Text = colorDialog.Color.B.ToString();
                FindClosestColor();
                */
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorDiag2();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ColorDiag2();

            CalculateRequiredLayers();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ColorPic1();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var plugin = loadedParsers.First(p => p.Name == comboBox4.SelectedItem.ToString());

            BrandBox.Items.Clear();
            BrandBox.Items.AddRange(plugin.SupportedBrands.ToArray());

            // ���� comboBox1 �������� �����, �������� ��� �������
            string selectedBrand = comboBox1.Text;
            int existingIndex = BrandBox.Items.IndexOf(selectedBrand);

            if (existingIndex >= 0)
            {
                BrandBox.SelectedIndex = existingIndex;
            }
            else if (BrandBox.Items.Count > 0)
            {
                BrandBox.SelectedIndex = 0; // ���� ���������� ��� � �������� ������
            }
        }










        //������ �����

        private bool IsValidHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) return false;

            hex = hex.Trim();
            if (!hex.StartsWith("#")) hex = "#" + hex;

            return System.Text.RegularExpressions.Regex.IsMatch(hex, @"^#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{3})$");
        }

        double GetBrightness(Color c) => 0.2126 * c.R + 0.7152 * c.G + 0.0722 * c.B;
        private int CalculateRequiredLayers()
        {
            // �������� HEX �����
            string hexOld = HexBox.Text.Trim();
            string hexNew = AnalogColorHEX.Text.Trim();

            if (!IsValidHex(hexOld) || !IsValidHex(hexNew))
            {
                MessageBox.Show("������� ���������� HEX-�������� �����!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1;
            }

            // ��������� � Color
            Color oldColor = ColorTranslator.FromHtml(hexOld);
            Color newColor = ColorTranslator.FromHtml(hexNew);

            // ��������� � Lab
            var (l1, a1, b1) = RgbToLab(oldColor);
            var (l2, a2, b2) = RgbToLab(newColor);

            // ��������� ������ E �� ���������� �������
            double deltaE = Math.Sqrt(Math.Pow(l1 - l2, 2) + Math.Pow(a1 - a2, 2) + Math.Pow(b1 - b2, 2));

            // ��������, ������� �� ����� ����
            bool newIsLighter = GetBrightness(newColor) > GetBrightness(oldColor);

            // ����������� �� ���������
            string material = comboBox6.SelectedItem?.ToString()?.ToLower() ?? "������";
            double materialFactor = material switch
            {
                string m when m.Contains("����") => 1.3,
                string m when m.Contains("����") => 1.5,
                _ => 1.0 // ������
            };

            // ���� ���������
            bool hasPrimer = primerCheck.Checked;
            double primerFactor = hasPrimer ? 0.8 : 1.0;

            // ������� ����� �����
            double baseLayers = deltaE / 20.0;

            if (newIsLighter)
                baseLayers *= 1.5;

            baseLayers *= materialFactor * primerFactor;
            LayersLabel.Text = Math.Clamp((int)Math.Ceiling(baseLayers), 2, 7).ToString();
            return Math.Clamp((int)Math.Ceiling(baseLayers), 2, 7);
        }
















        //������ ��������������





        private List<ProductInfo> products = new List<ProductInfo>();



        private async void ParseButton_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null || BrandBox.SelectedItem == null)
            {
                MessageBox.Show("�������� ������ � �����.");
                return;
            }

            var plugin = loadedParsers.First(p => p.Name == comboBox4.SelectedItem.ToString());
            var brand = BrandBox.SelectedItem?.ToString() ?? string.Empty;

            try
            {
                //MessageBox.Show("������� �����. ����������, ���������...");
                var list = await plugin.GetProductsAsync(brand);
                products.Clear();
                comboBox5.Items.Clear();

                foreach (var product in list)
                {
                    products.Add(product);
                    comboBox5.Items.Add(product);
                }
                if (comboBox5.Items.Count > 0)
                {
                    comboBox5.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }


        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex >= 0)
            {
                var selectedProduct = products[comboBox5.SelectedIndex];
                string imageUrl = selectedProduct.ImageUrl;

                // ��������� PriceBox
                PriceBox.Text = selectedProduct.Price.ToString();

                // ��������� ����� �� �������� (��������, "������ Dulux 2.5 �")
                string name = selectedProduct.Name;
                string volume = "";

                // �������� ����� ����� � ������
                var match = Regex.Match(name, @"(\d+(?:[.,]\d+)?)\s*�\b", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    volume = match.Groups[1].Value.Replace(',', '.'); // �����������
                }
                else
                {
                    // ���� �� ����� ����� � ���� ����������
                    var matchKg = Regex.Match(name, @"(\d+(?:[.,]\d+)?)\s*��\b", RegexOptions.IgnoreCase);
                    if (matchKg.Success)
                    {
                        string kgStr = matchKg.Groups[1].Value.Replace(',', '.');
                        if (double.TryParse(kgStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double weightKg))
                        {
                            double density = 1.3; // ��������� � ��/� � ����� ������� � ���������/���������
                            double liters = weightKg / density;
                            volume = liters.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture); // ��������� �� 2 ������
                        }
                    }
                }

                VolumeBox.Text = volume;

                // �������� �����������
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    using var client = new HttpClient();
                    try
                    {
                        var data = client.GetByteArrayAsync(imageUrl).Result;
                        using var ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    catch
                    {
                        pictureBox1.Image = null; // ��� ��������
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }

                calculate();
            }

        }

        private void SquareBox_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateRequiredLayers();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HexBox_TextChanged(object sender, EventArgs e)
        {
            panel3.BackColor = ColorTranslator.FromHtml(HexBox.Text);
            CalculateRequiredLayers();
        }

        private void LayersLabel_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void AnalogColorHEX_TextChanged(object sender, EventArgs e)
        {
            CalculateRequiredLayers();
            calculate();
            var colorPreviewPlugin = PluginManagerForm.FormPlugins
                .FirstOrDefault(p => p.Name == "Color Preview");
            try
            {
                dynamic plugin = colorPreviewPlugin;
                plugin.SetColor(panel2.BackColor);
            }
            catch
            {

            }
        }

        private void PaintsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            var colorPreviewPlugin = PluginManagerForm.FormPlugins
                .FirstOrDefault(p => p.Name == "Color Preview");

            if (colorPreviewPlugin == null)
            {
                MessageBox.Show("������ 'Color Preview' �� ��������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // �������� ���� �� ������� �����
            Color selectedColor = panel2.BackColor;

            // ������������� ���� � ������ (���� ���������� ����� SetColor)
            try
            {
                dynamic plugin = colorPreviewPlugin;
                plugin.SetColor(panel2.BackColor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��������� ����� � �������: " + ex.Message);
            }

            // ���������� ����� �������������
            var previewForm = colorPreviewPlugin.GetMainForm();

            previewForm.FormClosed += (s, ev) =>
            {
                previewForm.Dispose();
            };

            previewForm.Show(this);
        }

    }
}
