namespace kursBd
{
    partial class managerPanel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.delServ = new System.Windows.Forms.Button();
            this.updServ = new System.Windows.Forms.Button();
            this.addService = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.servPeriod = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.servName = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.servPrice = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.selectServ = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label38 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1262, 593);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1254, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Информация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.label33);
            this.tabPage2.Controls.Add(this.delServ);
            this.tabPage2.Controls.Add(this.updServ);
            this.tabPage2.Controls.Add(this.addService);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.selectServ);
            this.tabPage2.Controls.Add(this.dataGridView4);
            this.tabPage2.Controls.Add(this.label38);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1254, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Услуги";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(685, 67);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(529, 16);
            this.label32.TabIndex = 65;
            this.label32.Text = "Для добавления, удаления и изменения информации используйте форму ниже.\r\n";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label33.Location = new System.Drawing.Point(682, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(375, 35);
            this.label33.TabIndex = 64;
            this.label33.Text = "Изменение информации";
            // 
            // delServ
            // 
            this.delServ.Location = new System.Drawing.Point(524, 493);
            this.delServ.Name = "delServ";
            this.delServ.Size = new System.Drawing.Size(100, 50);
            this.delServ.TabIndex = 63;
            this.delServ.Text = "Удалить";
            this.delServ.UseVisualStyleBackColor = true;
            // 
            // updServ
            // 
            this.updServ.Location = new System.Drawing.Point(418, 493);
            this.updServ.Name = "updServ";
            this.updServ.Size = new System.Drawing.Size(100, 50);
            this.updServ.TabIndex = 62;
            this.updServ.Text = "Обновить";
            this.updServ.UseVisualStyleBackColor = true;
            // 
            // addService
            // 
            this.addService.Location = new System.Drawing.Point(312, 493);
            this.addService.Name = "addService";
            this.addService.Size = new System.Drawing.Size(100, 50);
            this.addService.TabIndex = 61;
            this.addService.Text = "Добавить";
            this.addService.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label42);
            this.panel7.Controls.Add(this.servPeriod);
            this.panel7.Controls.Add(this.label34);
            this.panel7.Controls.Add(this.numericUpDown4);
            this.panel7.Controls.Add(this.servName);
            this.panel7.Controls.Add(this.label35);
            this.panel7.Controls.Add(this.servPrice);
            this.panel7.Controls.Add(this.label36);
            this.panel7.Location = new System.Drawing.Point(688, 116);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(549, 350);
            this.panel7.TabIndex = 60;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label42.Location = new System.Drawing.Point(15, 234);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(237, 20);
            this.label42.TabIndex = 17;
            this.label42.Text = "Время выполнения(в днях)";
            // 
            // servPeriod
            // 
            this.servPeriod.Location = new System.Drawing.Point(258, 232);
            this.servPeriod.Name = "servPeriod";
            this.servPeriod.Size = new System.Drawing.Size(286, 22);
            this.servPeriod.TabIndex = 16;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label34.Location = new System.Drawing.Point(15, 30);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(124, 20);
            this.label34.TabIndex = 15;
            this.label34.Text = "ID должности";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(150, 31);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(58, 22);
            this.numericUpDown4.TabIndex = 14;
            // 
            // servName
            // 
            this.servName.Location = new System.Drawing.Point(258, 148);
            this.servName.Name = "servName";
            this.servName.Size = new System.Drawing.Size(286, 22);
            this.servName.TabIndex = 10;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label35.Location = new System.Drawing.Point(15, 148);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(91, 20);
            this.label35.TabIndex = 11;
            this.label35.Text = "Название";
            // 
            // servPrice
            // 
            this.servPrice.Location = new System.Drawing.Point(258, 191);
            this.servPrice.Name = "servPrice";
            this.servPrice.Size = new System.Drawing.Size(286, 22);
            this.servPrice.TabIndex = 8;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label36.Location = new System.Drawing.Point(15, 191);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(52, 20);
            this.label36.TabIndex = 9;
            this.label36.Text = "Цена";
            // 
            // selectServ
            // 
            this.selectServ.Location = new System.Drawing.Point(206, 493);
            this.selectServ.Name = "selectServ";
            this.selectServ.Size = new System.Drawing.Size(100, 50);
            this.selectServ.TabIndex = 59;
            this.selectServ.Text = "Выбрать данные";
            this.selectServ.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(23, 79);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(601, 408);
            this.dataGridView4.TabIndex = 58;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.label38.Location = new System.Drawing.Point(17, 21);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(607, 35);
            this.label38.TabIndex = 57;
            this.label38.Text = "Просмотр информации из базы данных\r\n";
            // 
            // managerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 593);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "managerPanel";
            this.Text = "Панель менеджера";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.managerPanel_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button delServ;
        private System.Windows.Forms.Button updServ;
        private System.Windows.Forms.Button addService;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox servPeriod;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.TextBox servName;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox servPrice;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button selectServ;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label38;
    }
}