namespace PaletteConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ColorMaker = new TabControl();
            Converter = new TabPage();
            label30 = new Label();
            HistoryPanel = new FlowLayoutPanel();
            ColorCount = new Label();
            AvgTimeLabel = new Label();
            PreviewButton = new Button();
            ScreenColorButton = new Button();
            label10 = new Label();
            comboBox3 = new ComboBox();
            similarityBox = new TextBox();
            label9 = new Label();
            label5 = new Label();
            AnColB = new TextBox();
            label6 = new Label();
            AnColG = new TextBox();
            label7 = new Label();
            AnColR = new TextBox();
            AnalogColorHEX = new TextBox();
            label8 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            label3 = new Label();
            ColB = new TextBox();
            label2 = new Label();
            ColG = new TextBox();
            label1 = new Label();
            ColR = new TextBox();
            CurrentColorHEX = new TextBox();
            CurrentColorText = new Label();
            panel1 = new Panel();
            pipette = new Button();
            ColorPic = new Button();
            Calc = new TabPage();
            label28 = new Label();
            numericUpDown1 = new NumericUpDown();
            button3 = new Button();
            button2 = new Button();
            label27 = new Label();
            numericUpDownThreads = new NumericUpDown();
            ParseAllButton = new Button();
            label26 = new Label();
            BrandBox = new ComboBox();
            label25 = new Label();
            LayersLabel = new TextBox();
            label24 = new Label();
            panel4 = new Panel();
            primerCheck = new CheckBox();
            label23 = new Label();
            comboBox6 = new ComboBox();
            label11 = new Label();
            WidthBox = new TextBox();
            label12 = new Label();
            HeightBox = new TextBox();
            label13 = new Label();
            DepthBox = new TextBox();
            SquareBox = new TextBox();
            label14 = new Label();
            RubTLabel = new Label();
            label22 = new Label();
            Label424 = new Label();
            ConsumptionBox = new TextBox();
            CansLabel = new Label();
            label21 = new Label();
            LitreLabel = new Label();
            label20 = new Label();
            RubLabel = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            VolumeBox = new TextBox();
            PriceBox = new TextBox();
            pictureBox1 = new PictureBox();
            comboBox5 = new ComboBox();
            ParseButton = new Button();
            PaintsBox = new TextBox();
            label16 = new Label();
            comboBox4 = new ComboBox();
            HexBox = new TextBox();
            label15 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            coler = new TabPage();
            resultBox = new RichTextBox();
            label35 = new Label();
            label29 = new Label();
            colerAnswLabel = new Label();
            Vbox = new TextBox();
            colorDialog1 = new ColorDialog();
            menuStrip1 = new MenuStrip();
            выходToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            менеджерПлагиновToolStripMenuItem = new ToolStripMenuItem();
            директорияToolStripMenuItem = new ToolStripMenuItem();
            лицензияToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ColorMaker.SuspendLayout();
            Converter.SuspendLayout();
            Calc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreads).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            coler.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ColorMaker
            // 
            ColorMaker.Controls.Add(Converter);
            ColorMaker.Controls.Add(Calc);
            ColorMaker.Controls.Add(coler);
            ColorMaker.Dock = DockStyle.Fill;
            ColorMaker.Location = new Point(0, 24);
            ColorMaker.Name = "ColorMaker";
            ColorMaker.SelectedIndex = 0;
            ColorMaker.Size = new Size(871, 528);
            ColorMaker.TabIndex = 0;
            ColorMaker.SelectedIndexChanged += ColorMaker_SelectedIndexChanged;
            // 
            // Converter
            // 
            Converter.Controls.Add(label30);
            Converter.Controls.Add(HistoryPanel);
            Converter.Controls.Add(ColorCount);
            Converter.Controls.Add(AvgTimeLabel);
            Converter.Controls.Add(PreviewButton);
            Converter.Controls.Add(ScreenColorButton);
            Converter.Controls.Add(label10);
            Converter.Controls.Add(comboBox3);
            Converter.Controls.Add(similarityBox);
            Converter.Controls.Add(label9);
            Converter.Controls.Add(label5);
            Converter.Controls.Add(AnColB);
            Converter.Controls.Add(label6);
            Converter.Controls.Add(AnColG);
            Converter.Controls.Add(label7);
            Converter.Controls.Add(AnColR);
            Converter.Controls.Add(AnalogColorHEX);
            Converter.Controls.Add(label8);
            Converter.Controls.Add(comboBox2);
            Converter.Controls.Add(label4);
            Converter.Controls.Add(comboBox1);
            Converter.Controls.Add(panel2);
            Converter.Controls.Add(label3);
            Converter.Controls.Add(ColB);
            Converter.Controls.Add(label2);
            Converter.Controls.Add(ColG);
            Converter.Controls.Add(label1);
            Converter.Controls.Add(ColR);
            Converter.Controls.Add(CurrentColorHEX);
            Converter.Controls.Add(CurrentColorText);
            Converter.Controls.Add(panel1);
            Converter.Controls.Add(pipette);
            Converter.Controls.Add(ColorPic);
            Converter.Location = new Point(4, 24);
            Converter.Name = "Converter";
            Converter.Padding = new Padding(3);
            Converter.Size = new Size(863, 500);
            Converter.TabIndex = 0;
            Converter.Text = "Конвертер цветов";
            Converter.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            label30.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label30.AutoSize = true;
            label30.Location = new Point(8, 346);
            label30.Name = "label30";
            label30.Size = new Size(60, 15);
            label30.TabIndex = 32;
            label30.Text = "Недавние";
            // 
            // HistoryPanel
            // 
            HistoryPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HistoryPanel.BorderStyle = BorderStyle.FixedSingle;
            HistoryPanel.Location = new Point(8, 367);
            HistoryPanel.Name = "HistoryPanel";
            HistoryPanel.Size = new Size(847, 125);
            HistoryPanel.TabIndex = 31;
            // 
            // ColorCount
            // 
            ColorCount.AutoSize = true;
            ColorCount.Location = new Point(322, 61);
            ColorCount.Name = "ColorCount";
            ColorCount.Size = new Size(12, 15);
            ColorCount.TabIndex = 30;
            ColorCount.Text = "-";
            // 
            // AvgTimeLabel
            // 
            AvgTimeLabel.AutoSize = true;
            AvgTimeLabel.Location = new Point(322, 121);
            AvgTimeLabel.Name = "AvgTimeLabel";
            AvgTimeLabel.Size = new Size(12, 15);
            AvgTimeLabel.TabIndex = 29;
            AvgTimeLabel.Text = "-";
            // 
            // PreviewButton
            // 
            PreviewButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PreviewButton.Location = new Point(654, 323);
            PreviewButton.Name = "PreviewButton";
            PreviewButton.Size = new Size(204, 38);
            PreviewButton.TabIndex = 28;
            PreviewButton.Text = "Предпросмотр цвета";
            PreviewButton.UseVisualStyleBackColor = true;
            PreviewButton.Click += PreviewButton_Click;
            // 
            // ScreenColorButton
            // 
            ScreenColorButton.Location = new Point(8, 64);
            ScreenColorButton.Name = "ScreenColorButton";
            ScreenColorButton.Size = new Size(104, 23);
            ScreenColorButton.TabIndex = 27;
            ScreenColorButton.Text = "Цвет с экрана";
            ScreenColorButton.UseVisualStyleBackColor = true;
            ScreenColorButton.Click += ScreenColorButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(322, 77);
            label10.Name = "label10";
            label10.Size = new Size(103, 15);
            label10.TabIndex = 26;
            label10.Text = "Метод сравнения";
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "HSV", "RGB", "LCH", "LAB" });
            comboBox3.Location = new Point(322, 95);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(327, 23);
            comboBox3.TabIndex = 25;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // similarityBox
            // 
            similarityBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            similarityBox.Location = new Point(810, 297);
            similarityBox.Name = "similarityBox";
            similarityBox.ReadOnly = true;
            similarityBox.Size = new Size(45, 23);
            similarityBox.TabIndex = 24;
            similarityBox.TextChanged += similarityBox_TextChanged;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(655, 305);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 23;
            label9.Text = "Совпадение";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(798, 278);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 22;
            label5.Text = "B";
            // 
            // AnColB
            // 
            AnColB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnColB.Location = new Point(818, 270);
            AnColB.Name = "AnColB";
            AnColB.Size = new Size(37, 23);
            AnColB.TabIndex = 21;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(724, 278);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 20;
            label6.Text = "G";
            // 
            // AnColG
            // 
            AnColG.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnColG.Location = new Point(744, 270);
            AnColG.Name = "AnColG";
            AnColG.Size = new Size(37, 23);
            AnColG.TabIndex = 19;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(655, 278);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 18;
            label7.Text = "R";
            // 
            // AnColR
            // 
            AnColR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnColR.Location = new Point(675, 270);
            AnColR.Name = "AnColR";
            AnColR.Size = new Size(37, 23);
            AnColR.TabIndex = 17;
            // 
            // AnalogColorHEX
            // 
            AnalogColorHEX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnalogColorHEX.Location = new Point(755, 241);
            AnalogColorHEX.Name = "AnalogColorHEX";
            AnalogColorHEX.Size = new Size(100, 23);
            AnalogColorHEX.TabIndex = 16;
            AnalogColorHEX.TextChanged += AnalogColorHEX_TextChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(655, 249);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 15;
            label8.Text = "HEX";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(655, 212);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(200, 23);
            comboBox2.TabIndex = 13;
            comboBox2.SelectedIndexChanged += ColorNameBox_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 17);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "Палитра";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(322, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(327, 23);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Location = new Point(655, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 200);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(259, 249);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 10;
            label3.Text = "B";
            // 
            // ColB
            // 
            ColB.Location = new Point(279, 241);
            ColB.Name = "ColB";
            ColB.Size = new Size(37, 23);
            ColB.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(185, 249);
            label2.Name = "label2";
            label2.Size = new Size(15, 15);
            label2.TabIndex = 8;
            label2.Text = "G";
            // 
            // ColG
            // 
            ColG.Location = new Point(205, 241);
            ColG.Name = "ColG";
            ColG.Size = new Size(37, 23);
            ColG.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 249);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 6;
            label1.Text = "R";
            // 
            // ColR
            // 
            ColR.Location = new Point(136, 241);
            ColR.Name = "ColR";
            ColR.Size = new Size(37, 23);
            ColR.TabIndex = 5;
            // 
            // CurrentColorHEX
            // 
            CurrentColorHEX.Location = new Point(216, 212);
            CurrentColorHEX.Name = "CurrentColorHEX";
            CurrentColorHEX.Size = new Size(100, 23);
            CurrentColorHEX.TabIndex = 4;
            CurrentColorHEX.Text = "#FFFFFF";
            CurrentColorHEX.TextChanged += CurrentColorHEX_TextChanged;
            // 
            // CurrentColorText
            // 
            CurrentColorText.AutoSize = true;
            CurrentColorText.Location = new Point(116, 220);
            CurrentColorText.Name = "CurrentColorText";
            CurrentColorText.Size = new Size(29, 15);
            CurrentColorText.TabIndex = 3;
            CurrentColorText.Text = "HEX";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Location = new Point(116, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 200);
            panel1.TabIndex = 2;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // pipette
            // 
            pipette.Location = new Point(8, 35);
            pipette.Name = "pipette";
            pipette.Size = new Size(102, 23);
            pipette.TabIndex = 1;
            pipette.Text = "Фото пипетка";
            pipette.UseVisualStyleBackColor = true;
            pipette.Click += pipette_Click;
            // 
            // ColorPic
            // 
            ColorPic.Location = new Point(8, 6);
            ColorPic.Name = "ColorPic";
            ColorPic.Size = new Size(102, 23);
            ColorPic.TabIndex = 0;
            ColorPic.Text = "Выбрать RGB";
            ColorPic.UseVisualStyleBackColor = true;
            ColorPic.Click += ColorPic_Click;
            // 
            // Calc
            // 
            Calc.Controls.Add(label28);
            Calc.Controls.Add(numericUpDown1);
            Calc.Controls.Add(button3);
            Calc.Controls.Add(button2);
            Calc.Controls.Add(label27);
            Calc.Controls.Add(numericUpDownThreads);
            Calc.Controls.Add(ParseAllButton);
            Calc.Controls.Add(label26);
            Calc.Controls.Add(BrandBox);
            Calc.Controls.Add(label25);
            Calc.Controls.Add(LayersLabel);
            Calc.Controls.Add(label24);
            Calc.Controls.Add(panel4);
            Calc.Controls.Add(RubTLabel);
            Calc.Controls.Add(label22);
            Calc.Controls.Add(Label424);
            Calc.Controls.Add(ConsumptionBox);
            Calc.Controls.Add(CansLabel);
            Calc.Controls.Add(label21);
            Calc.Controls.Add(LitreLabel);
            Calc.Controls.Add(label20);
            Calc.Controls.Add(RubLabel);
            Calc.Controls.Add(label19);
            Calc.Controls.Add(label18);
            Calc.Controls.Add(label17);
            Calc.Controls.Add(VolumeBox);
            Calc.Controls.Add(PriceBox);
            Calc.Controls.Add(pictureBox1);
            Calc.Controls.Add(comboBox5);
            Calc.Controls.Add(ParseButton);
            Calc.Controls.Add(PaintsBox);
            Calc.Controls.Add(label16);
            Calc.Controls.Add(comboBox4);
            Calc.Controls.Add(HexBox);
            Calc.Controls.Add(label15);
            Calc.Controls.Add(panel3);
            Calc.Controls.Add(button1);
            Calc.Location = new Point(4, 24);
            Calc.Name = "Calc";
            Calc.Padding = new Padding(3);
            Calc.Size = new Size(863, 479);
            Calc.TabIndex = 1;
            Calc.Text = "Калькулятор краски";
            Calc.UseVisualStyleBackColor = true;
            Calc.Click += Calc_Click;
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label28.AutoSize = true;
            label28.Location = new Point(742, 3);
            label28.Name = "label28";
            label28.Size = new Size(51, 15);
            label28.TabIndex = 47;
            label28.Text = "Сон, ms";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.Location = new Point(742, 18);
            numericUpDown1.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(55, 23);
            numericUpDown1.TabIndex = 46;
            numericUpDown1.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(779, 46);
            button3.Name = "button3";
            button3.Size = new Size(23, 23);
            button3.TabIndex = 45;
            button3.Text = "❌";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(572, 18);
            button2.Name = "button2";
            button2.Size = new Size(24, 23);
            button2.TabIndex = 44;
            button2.Text = "?";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label27.AutoSize = true;
            label27.Location = new Point(682, 3);
            label27.Name = "label27";
            label27.Size = new Size(54, 15);
            label27.TabIndex = 43;
            label27.Text = "Потоков";
            // 
            // numericUpDownThreads
            // 
            numericUpDownThreads.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownThreads.Location = new Point(682, 18);
            numericUpDownThreads.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownThreads.Name = "numericUpDownThreads";
            numericUpDownThreads.Size = new Size(55, 23);
            numericUpDownThreads.TabIndex = 42;
            numericUpDownThreads.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // ParseAllButton
            // 
            ParseAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ParseAllButton.Location = new Point(601, 18);
            ParseAllButton.Name = "ParseAllButton";
            ParseAllButton.Size = new Size(76, 23);
            ParseAllButton.TabIndex = 41;
            ParseAllButton.Text = "Найти все";
            ParseAllButton.UseVisualStyleBackColor = true;
            ParseAllButton.Click += ParseAllButton_Click;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label26.AutoSize = true;
            label26.Location = new Point(6, 85);
            label26.Name = "label26";
            label26.Size = new Size(134, 15);
            label26.TabIndex = 40;
            label26.Text = "Цвет стен до покраски:";
            // 
            // BrandBox
            // 
            BrandBox.DropDownStyle = ComboBoxStyle.DropDownList;
            BrandBox.FormattingEnabled = true;
            BrandBox.Location = new Point(356, 18);
            BrandBox.Name = "BrandBox";
            BrandBox.Size = new Size(121, 23);
            BrandBox.TabIndex = 39;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(356, 3);
            label25.Name = "label25";
            label25.Size = new Size(92, 15);
            label25.TabIndex = 38;
            label25.Text = "Производитель";
            // 
            // LayersLabel
            // 
            LayersLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LayersLabel.Location = new Point(130, 338);
            LayersLabel.Name = "LayersLabel";
            LayersLabel.Size = new Size(76, 23);
            LayersLabel.TabIndex = 37;
            LayersLabel.TextChanged += LayersLabel_TextChanged;
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label24.AutoSize = true;
            label24.Location = new Point(8, 346);
            label24.Name = "label24";
            label24.Size = new Size(44, 15);
            label24.TabIndex = 35;
            label24.Text = "Слоев:";
            label24.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(primerCheck);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(comboBox6);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(WidthBox);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(HeightBox);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(DepthBox);
            panel4.Controls.Add(SquareBox);
            panel4.Controls.Add(label14);
            panel4.Location = new Point(6, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 129);
            panel4.TabIndex = 34;
            // 
            // primerCheck
            // 
            primerCheck.AutoSize = true;
            primerCheck.Checked = true;
            primerCheck.CheckState = CheckState.Checked;
            primerCheck.Location = new Point(3, 103);
            primerCheck.Name = "primerCheck";
            primerCheck.Size = new Size(82, 19);
            primerCheck.TabIndex = 37;
            primerCheck.Text = "Грунтовка";
            primerCheck.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(3, 85);
            label23.Name = "label23";
            label23.Size = new Size(62, 15);
            label23.TabIndex = 36;
            label23.Text = "Материал";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Items.AddRange(new object[] { "Гипс", "Краска", "Обои под покраску" });
            comboBox6.Location = new Point(68, 77);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(121, 23);
            comboBox6.TabIndex = 35;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 3);
            label11.Name = "label11";
            label11.Size = new Size(169, 15);
            label11.TabIndex = 0;
            label11.Text = "Размеры помещения ШВС, м";
            // 
            // WidthBox
            // 
            WidthBox.Location = new Point(3, 21);
            WidthBox.Name = "WidthBox";
            WidthBox.Size = new Size(46, 23);
            WidthBox.TabIndex = 1;
            WidthBox.Text = "0";
            WidthBox.TextChanged += WidthBox_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(55, 29);
            label12.Name = "label12";
            label12.Size = new Size(12, 15);
            label12.TabIndex = 2;
            label12.Text = "x";
            // 
            // HeightBox
            // 
            HeightBox.Location = new Point(73, 21);
            HeightBox.Name = "HeightBox";
            HeightBox.Size = new Size(46, 23);
            HeightBox.TabIndex = 3;
            HeightBox.Text = "0";
            HeightBox.TextChanged += HeightBox_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(125, 29);
            label13.Name = "label13";
            label13.Size = new Size(12, 15);
            label13.TabIndex = 4;
            label13.Text = "x";
            // 
            // DepthBox
            // 
            DepthBox.Location = new Point(143, 21);
            DepthBox.Name = "DepthBox";
            DepthBox.Size = new Size(46, 23);
            DepthBox.TabIndex = 5;
            DepthBox.Text = "0";
            DepthBox.TextChanged += DepthBox_TextChanged;
            // 
            // SquareBox
            // 
            SquareBox.Location = new Point(143, 47);
            SquareBox.Name = "SquareBox";
            SquareBox.Size = new Size(46, 23);
            SquareBox.TabIndex = 6;
            SquareBox.TextChanged += SquareBox_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1, 55);
            label14.Name = "label14";
            label14.Size = new Size(107, 15);
            label14.TabIndex = 7;
            label14.Text = "Площадь стен, м2";
            label14.Click += label14_Click;
            // 
            // RubTLabel
            // 
            RubTLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RubTLabel.AutoSize = true;
            RubTLabel.Location = new Point(373, 292);
            RubTLabel.Name = "RubTLabel";
            RubTLabel.Size = new Size(12, 15);
            RubTLabel.TabIndex = 33;
            RubTLabel.Text = "*";
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label22.AutoSize = true;
            label22.Location = new Point(229, 292);
            label22.Name = "label22";
            label22.Size = new Size(121, 15);
            label22.TabIndex = 32;
            label22.Text = "Теоретическая цена:";
            // 
            // Label424
            // 
            Label424.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label424.AutoSize = true;
            Label424.Location = new Point(229, 220);
            Label424.Name = "Label424";
            Label424.Size = new Size(74, 15);
            Label424.TabIndex = 31;
            Label424.Text = "Расход л/м2";
            // 
            // ConsumptionBox
            // 
            ConsumptionBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ConsumptionBox.Location = new Point(310, 212);
            ConsumptionBox.Name = "ConsumptionBox";
            ConsumptionBox.Size = new Size(46, 23);
            ConsumptionBox.TabIndex = 30;
            ConsumptionBox.Text = "0.08";
            // 
            // CansLabel
            // 
            CansLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CansLabel.AutoSize = true;
            CansLabel.Location = new Point(292, 268);
            CansLabel.Name = "CansLabel";
            CansLabel.Size = new Size(12, 15);
            CansLabel.TabIndex = 29;
            CansLabel.Text = "*";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label21.AutoSize = true;
            label21.Location = new Point(229, 268);
            label21.Name = "label21";
            label21.Size = new Size(43, 15);
            label21.TabIndex = 28;
            label21.Text = "Банок:";
            // 
            // LitreLabel
            // 
            LitreLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LitreLabel.AutoSize = true;
            LitreLabel.Location = new Point(292, 244);
            LitreLabel.Name = "LitreLabel";
            LitreLabel.Size = new Size(12, 15);
            LitreLabel.TabIndex = 27;
            LitreLabel.Text = "*";
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label20.AutoSize = true;
            label20.Location = new Point(229, 244);
            label20.Name = "label20";
            label20.Size = new Size(50, 15);
            label20.TabIndex = 26;
            label20.Text = "Литров:";
            // 
            // RubLabel
            // 
            RubLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RubLabel.AutoSize = true;
            RubLabel.Location = new Point(373, 317);
            RubLabel.Name = "RubLabel";
            RubLabel.Size = new Size(12, 15);
            RubLabel.TabIndex = 25;
            RubLabel.Text = "*";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label19.AutoSize = true;
            label19.Location = new Point(229, 317);
            label19.Name = "label19";
            label19.Size = new Size(109, 15);
            label19.TabIndex = 24;
            label19.Text = "Фактическая цена:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(322, 79);
            label18.Name = "label18";
            label18.Size = new Size(45, 15);
            label18.TabIndex = 23;
            label18.Text = "Объем";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(229, 79);
            label17.Name = "label17";
            label17.Size = new Size(35, 15);
            label17.TabIndex = 22;
            label17.Text = "Цена";
            // 
            // VolumeBox
            // 
            VolumeBox.Location = new Point(373, 71);
            VolumeBox.Name = "VolumeBox";
            VolumeBox.Size = new Size(46, 23);
            VolumeBox.TabIndex = 21;
            VolumeBox.Text = "0";
            // 
            // PriceBox
            // 
            PriceBox.Location = new Point(270, 71);
            PriceBox.Name = "PriceBox";
            PriceBox.Size = new Size(46, 23);
            PriceBox.TabIndex = 20;
            PriceBox.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Location = new Point(649, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // comboBox5
            // 
            comboBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(229, 47);
            comboBox5.MaxDropDownItems = 16;
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(544, 23);
            comboBox5.TabIndex = 18;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // ParseButton
            // 
            ParseButton.Location = new Point(483, 18);
            ParseButton.Name = "ParseButton";
            ParseButton.Size = new Size(75, 23);
            ParseButton.TabIndex = 17;
            ParseButton.Text = "Найти";
            ParseButton.UseVisualStyleBackColor = true;
            ParseButton.Click += ParseButton_Click;
            // 
            // PaintsBox
            // 
            PaintsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PaintsBox.Location = new Point(229, 103);
            PaintsBox.Multiline = true;
            PaintsBox.Name = "PaintsBox";
            PaintsBox.ReadOnly = true;
            PaintsBox.Size = new Size(370, 103);
            PaintsBox.TabIndex = 16;
            PaintsBox.TextChanged += PaintsBox_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(229, 3);
            label16.Name = "label16";
            label16.Size = new Size(96, 15);
            label16.TabIndex = 13;
            label16.Text = "Магазин поиска";
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(229, 18);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 12;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // HexBox
            // 
            HexBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            HexBox.Location = new Point(130, 309);
            HexBox.Name = "HexBox";
            HexBox.Size = new Size(76, 23);
            HexBox.TabIndex = 11;
            HexBox.Text = "#FFFFFF";
            HexBox.TextChanged += HexBox_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 79);
            label15.Name = "label15";
            label15.Size = new Size(131, 15);
            label15.TabIndex = 10;
            label15.Text = "Цвет стен до покраски";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Location = new Point(6, 103);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 200);
            panel3.TabIndex = 9;
            panel3.Click += panel3_Click;
            panel3.Paint += panel3_Paint;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(6, 308);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 8;
            button1.Text = "Выбрать RGB";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // coler
            // 
            coler.Controls.Add(resultBox);
            coler.Controls.Add(label35);
            coler.Controls.Add(label29);
            coler.Controls.Add(colerAnswLabel);
            coler.Controls.Add(Vbox);
            coler.Location = new Point(4, 24);
            coler.Name = "coler";
            coler.Padding = new Padding(3);
            coler.Size = new Size(863, 479);
            coler.TabIndex = 2;
            coler.Text = "Колеровка";
            coler.UseVisualStyleBackColor = true;
            // 
            // resultBox
            // 
            resultBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            resultBox.BorderStyle = BorderStyle.None;
            resultBox.Location = new Point(469, 29);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(330, 204);
            resultBox.TabIndex = 16;
            resultBox.Text = "";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(109, 11);
            label35.Name = "label35";
            label35.Size = new Size(12, 15);
            label35.TabIndex = 15;
            label35.Text = "г";
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label29.AutoSize = true;
            label29.Location = new Point(739, 11);
            label29.Name = "label29";
            label29.Size = new Size(60, 15);
            label29.TabIndex = 3;
            label29.Text = "Результат";
            // 
            // colerAnswLabel
            // 
            colerAnswLabel.AutoSize = true;
            colerAnswLabel.Location = new Point(8, 32);
            colerAnswLabel.Name = "colerAnswLabel";
            colerAnswLabel.Size = new Size(12, 15);
            colerAnswLabel.TabIndex = 2;
            colerAnswLabel.Text = "-";
            // 
            // Vbox
            // 
            Vbox.Location = new Point(8, 6);
            Vbox.Name = "Vbox";
            Vbox.Size = new Size(100, 23);
            Vbox.TabIndex = 0;
            Vbox.Text = "100";
            Vbox.TextChanged += Vbox_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem, оПрограммеToolStripMenuItem, менеджерПлагиновToolStripMenuItem, директорияToolStripMenuItem, лицензияToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(871, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(53, 20);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(94, 20);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // менеджерПлагиновToolStripMenuItem
            // 
            менеджерПлагиновToolStripMenuItem.Name = "менеджерПлагиновToolStripMenuItem";
            менеджерПлагиновToolStripMenuItem.Size = new Size(132, 20);
            менеджерПлагиновToolStripMenuItem.Text = "Менеджер плагинов";
            менеджерПлагиновToolStripMenuItem.Click += менеджерПлагиновToolStripMenuItem_Click;
            // 
            // директорияToolStripMenuItem
            // 
            директорияToolStripMenuItem.Name = "директорияToolStripMenuItem";
            директорияToolStripMenuItem.Size = new Size(85, 20);
            директорияToolStripMenuItem.Text = "Директория";
            директорияToolStripMenuItem.Click += директорияToolStripMenuItem_Click;
            // 
            // лицензияToolStripMenuItem
            // 
            лицензияToolStripMenuItem.Name = "лицензияToolStripMenuItem";
            лицензияToolStripMenuItem.Size = new Size(72, 20);
            лицензияToolStripMenuItem.Text = "Лицензия";
            лицензияToolStripMenuItem.Click += лицензияToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 552);
            Controls.Add(ColorMaker);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Конвертер палитр";
            ColorMaker.ResumeLayout(false);
            Converter.ResumeLayout(false);
            Converter.PerformLayout();
            Calc.ResumeLayout(false);
            Calc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreads).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            coler.ResumeLayout(false);
            coler.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl ColorMaker;
        private TabPage Converter;
        private TabPage Calc;
        private TabPage coler;
        private Button pipette;
        private Button ColorPic;
        private ColorDialog colorDialog1;
        private Panel panel1;
        private TextBox CurrentColorHEX;
        private Label CurrentColorText;
        private TextBox ColR;
        private Label label1;
        private Label label3;
        private TextBox ColB;
        private Label label2;
        private TextBox ColG;
        private Panel panel2;
        private Label label4;
        private ComboBox comboBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem менеджерПлагиновToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ComboBox comboBox2;
        private Label label5;
        private TextBox AnColB;
        private Label label6;
        private TextBox AnColG;
        private Label label7;
        private TextBox AnColR;
        private TextBox AnalogColorHEX;
        private Label label8;
        private Label label9;
        private TextBox similarityBox;
        private Label label10;
        private ComboBox comboBox3;
        private Button ScreenColorButton;
        private Label label11;
        private Label label14;
        private TextBox SquareBox;
        private TextBox DepthBox;
        private Label label13;
        private TextBox HeightBox;
        private Label label12;
        private TextBox WidthBox;
        private Label label15;
        private Panel panel3;
        private Button button1;
        private TextBox HexBox;
        private Label label16;
        private ComboBox comboBox4;
        private Button ParseButton;
        private TextBox PaintsBox;
        private ComboBox comboBox5;
        private PictureBox pictureBox1;
        private TextBox PriceBox;
        private TextBox VolumeBox;
        private Label label18;
        private Label label17;
        private Label RubLabel;
        private Label label19;
        private Label LitreLabel;
        private Label label20;
        private Label CansLabel;
        private Label label21;
        private Label Label424;
        private TextBox ConsumptionBox;
        private Label RubTLabel;
        private Label label22;
        private Panel panel4;
        private CheckBox primerCheck;
        private Label label23;
        private ComboBox comboBox6;
        private Label label24;
        private TextBox LayersLabel;
        private Label label25;
        private ComboBox BrandBox;
        private Label label26;
        private Button PreviewButton;
        private ContextMenuStrip contextMenuStrip1;
        private Label AvgTimeLabel;
        private Button ParseAllButton;
        private Label label27;
        private NumericUpDown numericUpDownThreads;
        private Button button2;
        private Button button3;
        private ToolStripMenuItem директорияToolStripMenuItem;
        private Label label28;
        private NumericUpDown numericUpDown1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem лицензияToolStripMenuItem;
        private TextBox Vbox;
        private Label label29;
        private Label colerAnswLabel;
        private Label BaseTypeLabel;
        private Label label35;
        private RichTextBox resultBox;
        private Label ColorCount;
        private FlowLayoutPanel HistoryPanel;
        private Label label30;
    }
}
