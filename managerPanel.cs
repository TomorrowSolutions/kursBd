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
        public managerPanel()
        {
            InitializeComponent();
        }
        public static string manConnString;
        public static string manLogin;
        public static string manPassword;

        private void managerPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
