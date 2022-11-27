namespace kursBd
{
    partial class login
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.loginTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.managerRadio = new System.Windows.Forms.RadioButton();
            this.emplRadio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dirRadio = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTb
            // 
            this.loginTb.Location = new System.Drawing.Point(134, 223);
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(261, 22);
            this.loginTb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(170, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Авторизация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.Location = new System.Drawing.Point(131, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тип учетной записи";
            // 
            // managerRadio
            // 
            this.managerRadio.AutoSize = true;
            this.managerRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.managerRadio.Location = new System.Drawing.Point(72, 174);
            this.managerRadio.Name = "managerRadio";
            this.managerRadio.Size = new System.Drawing.Size(96, 20);
            this.managerRadio.TabIndex = 3;
            this.managerRadio.TabStop = true;
            this.managerRadio.Text = "Менеджер";
            this.managerRadio.UseVisualStyleBackColor = true;
            // 
            // emplRadio
            // 
            this.emplRadio.AutoSize = true;
            this.emplRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emplRadio.Location = new System.Drawing.Point(175, 174);
            this.emplRadio.Name = "emplRadio";
            this.emplRadio.Size = new System.Drawing.Size(99, 20);
            this.emplRadio.TabIndex = 4;
            this.emplRadio.TabStop = true;
            this.emplRadio.Text = "Сотрудник";
            this.emplRadio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label3.Location = new System.Drawing.Point(50, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label4.Location = new System.Drawing.Point(50, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(134, 259);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(261, 22);
            this.passwordTb.TabIndex = 6;
            this.passwordTb.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold);
            this.loginBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.loginBtn.Location = new System.Drawing.Point(168, 334);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(200, 50);
            this.loginBtn.TabIndex = 8;
            this.loginBtn.Text = "Вход";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 500);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 63);
            this.label5.TabIndex = 9;
            this.label5.Text = "Авторизируйтесь для \r\nполучения доступа\r\nк функционалу программы\r\n";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dirRadio);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.loginBtn);
            this.panel2.Controls.Add(this.emplRadio);
            this.panel2.Controls.Add(this.loginTb);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.managerRadio);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.passwordTb);
            this.panel2.Location = new System.Drawing.Point(300, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 500);
            this.panel2.TabIndex = 10;
            // 
            // dirRadio
            // 
            this.dirRadio.AutoSize = true;
            this.dirRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dirRadio.Location = new System.Drawing.Point(296, 174);
            this.dirRadio.Name = "dirRadio";
            this.dirRadio.Size = new System.Drawing.Size(91, 20);
            this.dirRadio.TabIndex = 9;
            this.dirRadio.TabStop = true;
            this.dirRadio.Text = "Директор";
            this.dirRadio.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox loginTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton managerRadio;
        private System.Windows.Forms.RadioButton emplRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton dirRadio;
    }
}

