using Npgsql;
using System;
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
    public partial class employeePanel : Form
    {
        private NpgsqlConnection conn;
        private string query;
        private NpgsqlCommand cmd;
        readonly private int emplId;

        public employeePanel(string connect, int id)
        {
            InitializeComponent();
            conn = new NpgsqlConnection(connect);
            emplId=id;
        }
        
        private void employeePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?\nНесохраненные изменения будут утеряны", "Выход", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
