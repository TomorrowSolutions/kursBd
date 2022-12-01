namespace kursBd
{
    partial class directorPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(directorPanel));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.viewTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.profitLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.orderLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.emplLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.manTab = new System.Windows.Forms.TabPage();
            this.delManBtn = new System.Windows.Forms.Button();
            this.updateManBtn = new System.Windows.Forms.Button();
            this.addManBtn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.passTb = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.loginTb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.salTb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.eduTb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.patrTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.surnameTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.selectManBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.viewTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.manTab.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.viewTab);
            this.tabControl1.Controls.Add(this.manTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1262, 593);
            this.tabControl1.TabIndex = 0;
            // 
            // viewTab
            // 
            this.viewTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.viewTab.Controls.Add(this.label5);
            this.viewTab.Controls.Add(this.chart1);
            this.viewTab.Controls.Add(this.panel3);
            this.viewTab.Controls.Add(this.panel2);
            this.viewTab.Controls.Add(this.panel1);
            this.viewTab.Controls.Add(this.label1);
            this.viewTab.Location = new System.Drawing.Point(4, 25);
            this.viewTab.Name = "viewTab";
            this.viewTab.Padding = new System.Windows.Forms.Padding(3);
            this.viewTab.Size = new System.Drawing.Size(1254, 564);
            this.viewTab.TabIndex = 0;
            this.viewTab.Text = "Обзор";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Baskerville Old Face", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label5.Location = new System.Drawing.Point(39, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 34);
            this.label5.TabIndex = 5;
            this.label5.Text = "Охраняем ваше время";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(486, 6);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "clientsSeries";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(619, 300);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepPink;
            this.panel3.Controls.Add(this.profitLabel);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(887, 322);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 200);
            this.panel3.TabIndex = 3;
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.profitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.profitLabel.Location = new System.Drawing.Point(32, 118);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(102, 25);
            this.profitLabel.TabIndex = 2;
            this.profitLabel.Text = "Прибыль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.label4.Location = new System.Drawing.Point(32, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Прибыль";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.orderLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(486, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 200);
            this.panel2.TabIndex = 3;
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.orderLabel.Location = new System.Drawing.Point(34, 118);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(121, 25);
            this.orderLabel.TabIndex = 2;
            this.orderLabel.Text = "Договоров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.label3.Location = new System.Drawing.Point(34, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Договоров";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.emplLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(45, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 200);
            this.panel1.TabIndex = 2;
            // 
            // emplLabel
            // 
            this.emplLabel.AutoSize = true;
            this.emplLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emplLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.emplLabel.Location = new System.Drawing.Point(24, 118);
            this.emplLabel.Name = "emplLabel";
            this.emplLabel.Size = new System.Drawing.Size(144, 25);
            this.emplLabel.TabIndex = 2;
            this.emplLabel.Text = "Сотрудников";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сотрудников";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Охранная организация";
            // 
            // manTab
            // 
            this.manTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.manTab.Controls.Add(this.delManBtn);
            this.manTab.Controls.Add(this.updateManBtn);
            this.manTab.Controls.Add(this.addManBtn);
            this.manTab.Controls.Add(this.label17);
            this.manTab.Controls.Add(this.label16);
            this.manTab.Controls.Add(this.panel4);
            this.manTab.Controls.Add(this.selectManBtn);
            this.manTab.Controls.Add(this.dataGridView1);
            this.manTab.Controls.Add(this.label6);
            this.manTab.Location = new System.Drawing.Point(4, 25);
            this.manTab.Name = "manTab";
            this.manTab.Padding = new System.Windows.Forms.Padding(3);
            this.manTab.Size = new System.Drawing.Size(1254, 564);
            this.manTab.TabIndex = 1;
            this.manTab.Text = "Менеджеры";
            // 
            // delManBtn
            // 
            this.delManBtn.Location = new System.Drawing.Point(532, 494);
            this.delManBtn.Name = "delManBtn";
            this.delManBtn.Size = new System.Drawing.Size(100, 50);
            this.delManBtn.TabIndex = 29;
            this.delManBtn.Text = "Удалить";
            this.delManBtn.UseVisualStyleBackColor = true;
            // 
            // updateManBtn
            // 
            this.updateManBtn.Location = new System.Drawing.Point(426, 494);
            this.updateManBtn.Name = "updateManBtn";
            this.updateManBtn.Size = new System.Drawing.Size(100, 50);
            this.updateManBtn.TabIndex = 28;
            this.updateManBtn.Text = "Обновить";
            this.updateManBtn.UseVisualStyleBackColor = true;
            // 
            // addManBtn
            // 
            this.addManBtn.Location = new System.Drawing.Point(320, 494);
            this.addManBtn.Name = "addManBtn";
            this.addManBtn.Size = new System.Drawing.Size(100, 50);
            this.addManBtn.TabIndex = 27;
            this.addManBtn.Text = "Добавить";
            this.addManBtn.UseVisualStyleBackColor = true;
            this.addManBtn.Click += new System.EventHandler(this.addManBtn_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(676, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(529, 32);
            this.label17.TabIndex = 26;
            this.label17.Text = "Для добавления, удаления и изменения информации используйте форму ниже.\r\nПоля Фам" +
    "илия, Отчество, Дата начала работы необязательны для заполнения.\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label16.Location = new System.Drawing.Point(673, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(375, 35);
            this.label16.TabIndex = 5;
            this.label16.Text = "Изменение информации";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Controls.Add(this.passTb);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.loginTb);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.salTb);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.eduTb);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.numericUpDown1);
            this.panel4.Controls.Add(this.patrTb);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.surnameTb);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.nameTb);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(679, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 447);
            this.panel4.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(15, 385);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "Дата начала работы";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(344, 383);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // passTb
            // 
            this.passTb.Location = new System.Drawing.Point(258, 347);
            this.passTb.Name = "passTb";
            this.passTb.Size = new System.Drawing.Size(286, 22);
            this.passTb.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(15, 349);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "Пароль";
            // 
            // loginTb
            // 
            this.loginTb.Location = new System.Drawing.Point(258, 304);
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(286, 22);
            this.loginTb.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(15, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "Логин";
            // 
            // salTb
            // 
            this.salTb.Location = new System.Drawing.Point(258, 260);
            this.salTb.Name = "salTb";
            this.salTb.Size = new System.Drawing.Size(286, 22);
            this.salTb.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(15, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "Заработная плата";
            // 
            // eduTb
            // 
            this.eduTb.Location = new System.Drawing.Point(258, 212);
            this.eduTb.Name = "eduTb";
            this.eduTb.Size = new System.Drawing.Size(286, 22);
            this.eduTb.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(15, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Образование";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(15, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "ID Менеджера";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(150, 31);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 22);
            this.numericUpDown1.TabIndex = 14;
            // 
            // patrTb
            // 
            this.patrTb.Location = new System.Drawing.Point(258, 167);
            this.patrTb.Name = "patrTb";
            this.patrTb.Size = new System.Drawing.Size(286, 22);
            this.patrTb.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(15, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Отчество";
            // 
            // surnameTb
            // 
            this.surnameTb.Location = new System.Drawing.Point(258, 85);
            this.surnameTb.Name = "surnameTb";
            this.surnameTb.Size = new System.Drawing.Size(286, 22);
            this.surnameTb.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(15, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Фамилия";
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(258, 128);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(286, 22);
            this.nameTb.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(15, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Имя";
            // 
            // selectManBtn
            // 
            this.selectManBtn.Location = new System.Drawing.Point(214, 494);
            this.selectManBtn.Name = "selectManBtn";
            this.selectManBtn.Size = new System.Drawing.Size(100, 50);
            this.selectManBtn.TabIndex = 3;
            this.selectManBtn.Text = "Выбрать данные";
            this.selectManBtn.UseVisualStyleBackColor = true;
            this.selectManBtn.Click += new System.EventHandler(this.selectManBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(601, 408);
            this.dataGridView1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label6.Location = new System.Drawing.Point(25, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(607, 35);
            this.label6.TabIndex = 1;
            this.label6.Text = "Просмотр информации из базы данных\r\n";
            // 
            // directorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1262, 593);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "directorPanel";
            this.Text = "Панель Директора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.directorPanel_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.viewTab.ResumeLayout(false);
            this.viewTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.manTab.ResumeLayout(false);
            this.manTab.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage viewTab;
        private System.Windows.Forms.TabPage manTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label profitLabel;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.Label emplLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectManBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox surnameTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox passTb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox loginTb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox salTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox eduTb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox patrTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button delManBtn;
        private System.Windows.Forms.Button updateManBtn;
        private System.Windows.Forms.Button addManBtn;
    }
}