using MySql.Data.MySqlClient;
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
    public partial class managerPanel : Form
    {
        private MySqlConnection conn;
        private string query;
        private MySqlCommand cmd;
        readonly private int managerId; 
        public managerPanel(string connect,int id)
        {
            InitializeComponent();
            conn = new MySqlConnection(connect);
            managerId = id;
        }
        

        private void managerPanel_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти?\nНесохраненные изменения будут утеряны", "Выход",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
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
