﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursBd
{
    public partial class directorPanel : Form
    {
        public directorPanel()
        {
            InitializeComponent();
        }
        public static string dirConnString;

        private void directorPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите выйти", "Выход", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                this.Hide();
                login logForm = new login();
                logForm.Show();
            }else if(res == DialogResult.Cancel)
            {
                e.Cancel=true;
            }

        }
    }
}
