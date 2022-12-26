namespace kursBd
{
    partial class employeePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employeePanel));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.lastUpdateLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.servLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.salLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.helloLabel = new System.Windows.Forms.Label();
            this.eventsTab = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.objDD = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.eventDel = new System.Windows.Forms.Button();
            this.addOrdDet = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.selectEvents = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label35 = new System.Windows.Forms.Label();
            this.eventName = new System.Windows.Forms.TextBox();
            this.eventUpd = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.eventsTab.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.infoTab);
            this.tabControl1.Controls.Add(this.eventsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1262, 593);
            this.tabControl1.TabIndex = 0;
            // 
            // infoTab
            // 
            this.infoTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.infoTab.Controls.Add(this.lastUpdateLabel);
            this.infoTab.Controls.Add(this.panel2);
            this.infoTab.Controls.Add(this.panel1);
            this.infoTab.Controls.Add(this.helloLabel);
            this.infoTab.Location = new System.Drawing.Point(4, 25);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(1254, 564);
            this.infoTab.TabIndex = 0;
            this.infoTab.Text = "Информация";
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.AutoSize = true;
            this.lastUpdateLabel.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastUpdateLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lastUpdateLabel.Location = new System.Drawing.Point(62, 103);
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.Size = new System.Drawing.Size(353, 26);
            this.lastUpdateLabel.TabIndex = 15;
            this.lastUpdateLabel.Text = "Время последней авторизации: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.servLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(676, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 200);
            this.panel2.TabIndex = 14;
            // 
            // servLabel
            // 
            this.servLabel.AutoSize = true;
            this.servLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.servLabel.Location = new System.Drawing.Point(192, 118);
            this.servLabel.Name = "servLabel";
            this.servLabel.Size = new System.Drawing.Size(121, 25);
            this.servLabel.TabIndex = 2;
            this.servLabel.Text = "Договоров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.label3.Location = new System.Drawing.Point(155, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Вы выполнияете";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.salLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(68, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 200);
            this.panel1.TabIndex = 13;
            // 
            // salLabel
            // 
            this.salLabel.AutoSize = true;
            this.salLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.salLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.salLabel.Location = new System.Drawing.Point(273, 118);
            this.salLabel.Name = "salLabel";
            this.salLabel.Size = new System.Drawing.Size(84, 25);
            this.salLabel.TabIndex = 2;
            this.salLabel.Text = "Рублей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.label2.Location = new System.Drawing.Point(113, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ваш оклад составляет";
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helloLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.helloLabel.Location = new System.Drawing.Point(62, 45);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(218, 35);
            this.helloLabel.TabIndex = 12;
            this.helloLabel.Text = "Здравствуйте";
            // 
            // eventsTab
            // 
            this.eventsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.eventsTab.Controls.Add(this.eventUpd);
            this.eventsTab.Controls.Add(this.panel6);
            this.eventsTab.Controls.Add(this.eventDel);
            this.eventsTab.Controls.Add(this.addOrdDet);
            this.eventsTab.Controls.Add(this.label33);
            this.eventsTab.Controls.Add(this.label34);
            this.eventsTab.Controls.Add(this.selectEvents);
            this.eventsTab.Controls.Add(this.dataGridView4);
            this.eventsTab.Controls.Add(this.label35);
            this.eventsTab.Location = new System.Drawing.Point(4, 25);
            this.eventsTab.Name = "eventsTab";
            this.eventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTab.Size = new System.Drawing.Size(1254, 564);
            this.eventsTab.TabIndex = 1;
            this.eventsTab.Text = "События";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.dateTimePicker1);
            this.panel6.Controls.Add(this.eventName);
            this.panel6.Controls.Add(this.label37);
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.numericUpDown4);
            this.panel6.Controls.Add(this.label31);
            this.panel6.Controls.Add(this.objDD);
            this.panel6.Controls.Add(this.label32);
            this.panel6.Location = new System.Drawing.Point(680, 148);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(549, 252);
            this.panel6.TabIndex = 82;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label37.Location = new System.Drawing.Point(14, 42);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(149, 20);
            this.label37.TabIndex = 76;
            this.label37.Text = "Номер договора";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(14, 182);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(128, 20);
            this.label30.TabIndex = 64;
            this.label30.Text = "Дата события";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(258, 42);
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(58, 22);
            this.numericUpDown4.TabIndex = 64;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(14, 91);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 20);
            this.label31.TabIndex = 11;
            this.label31.Text = "Объекты";
            // 
            // objDD
            // 
            this.objDD.FormattingEnabled = true;
            this.objDD.Location = new System.Drawing.Point(258, 87);
            this.objDD.Name = "objDD";
            this.objDD.Size = new System.Drawing.Size(286, 24);
            this.objDD.TabIndex = 61;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(14, 134);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(91, 20);
            this.label32.TabIndex = 9;
            this.label32.Text = "Название";
            // 
            // eventDel
            // 
            this.eventDel.Location = new System.Drawing.Point(533, 493);
            this.eventDel.Name = "eventDel";
            this.eventDel.Size = new System.Drawing.Size(100, 50);
            this.eventDel.TabIndex = 81;
            this.eventDel.Text = "Удалить";
            this.eventDel.UseVisualStyleBackColor = true;
            this.eventDel.Click += new System.EventHandler(this.eventDel_Click);
            // 
            // addOrdDet
            // 
            this.addOrdDet.Location = new System.Drawing.Point(321, 493);
            this.addOrdDet.Name = "addOrdDet";
            this.addOrdDet.Size = new System.Drawing.Size(100, 50);
            this.addOrdDet.TabIndex = 80;
            this.addOrdDet.Text = "Добавить";
            this.addOrdDet.UseVisualStyleBackColor = true;
            this.addOrdDet.Click += new System.EventHandler(this.addOrdDet_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(677, 79);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(529, 32);
            this.label33.TabIndex = 79;
            this.label33.Text = "Для добавления, удаления и изменения информации используйте форму ниже.\r\nНажмите " +
    "\"Справка\" для получения дополнительной информации.\r\n";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label34.Location = new System.Drawing.Point(674, 21);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(375, 35);
            this.label34.TabIndex = 78;
            this.label34.Text = "Изменение информации";
            // 
            // selectEvents
            // 
            this.selectEvents.Location = new System.Drawing.Point(215, 493);
            this.selectEvents.Name = "selectEvents";
            this.selectEvents.Size = new System.Drawing.Size(100, 50);
            this.selectEvents.TabIndex = 77;
            this.selectEvents.Text = "Выбрать данные";
            this.selectEvents.UseVisualStyleBackColor = true;
            this.selectEvents.Click += new System.EventHandler(this.selectEvents_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(32, 79);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(601, 408);
            this.dataGridView4.TabIndex = 76;
            this.dataGridView4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellClick);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label35.Location = new System.Drawing.Point(26, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(607, 35);
            this.label35.TabIndex = 75;
            this.label35.Text = "Просмотр информации из базы данных\r\n";
            // 
            // eventName
            // 
            this.eventName.Location = new System.Drawing.Point(258, 134);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(286, 22);
            this.eventName.TabIndex = 77;
            // 
            // eventUpd
            // 
            this.eventUpd.Location = new System.Drawing.Point(427, 493);
            this.eventUpd.Name = "eventUpd";
            this.eventUpd.Size = new System.Drawing.Size(100, 50);
            this.eventUpd.TabIndex = 83;
            this.eventUpd.Text = "Обновить";
            this.eventUpd.UseVisualStyleBackColor = true;
            this.eventUpd.Click += new System.EventHandler(this.eventUpd_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(258, 191);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(286, 22);
            this.dateTimePicker1.TabIndex = 78;
            // 
            // employeePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 593);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "employeePanel";
            this.Text = "employeePanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.employeePanel_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.infoTab.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.eventsTab.ResumeLayout(false);
            this.eventsTab.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.TabPage eventsTab;
        private System.Windows.Forms.Label lastUpdateLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label servLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label salLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label helloLabel;
        private System.Windows.Forms.Button eventUpd;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox eventName;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox objDD;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button eventDel;
        private System.Windows.Forms.Button addOrdDet;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button selectEvents;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label35;
    }
}