using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace kursBd
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private string visitorConnString = string.Format("Server={0};Port={1};" +
                                                        "User Id={2};Password={3};Database={4};",
                                                        "localhost",5432,"visitor","1","dbKurs");
        private NpgsqlConnection conn;
        private string query;
        private NpgsqlCommand cmd;
        private void loginBtn_Click(object sender, EventArgs e)
        {

            if (emplRadio.Checked)
            {
                query = String.Format("select exists(select 1 from \"{0}\" WHERE login='{1}' and \"password\"='{2}')",
                                    "Employees", loginTb.Text, passwordTb.Text);
            }
            else if (managerRadio.Checked)
            {
                query = String.Format("select exists(select 1 from \"{0}\" WHERE login='{1}' and \"password\"='{2}')",
                                   "Managers", loginTb.Text, passwordTb.Text);
            }
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }

            conn=new NpgsqlConnection(visitorConnString);
            try
            {
                conn.Open();                
                cmd=new NpgsqlCommand(query,conn);
                bool isLogin = bool.Parse( cmd.ExecuteScalar().ToString());                
                conn.Close();
                MessageBox.Show((isLogin ? "Авторизация прошла успешно.":"Не удалось авторизоваться."));

                if (emplRadio.Checked)
                {
                   
                }
                else if (managerRadio.Checked)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!"+System.Environment.NewLine+ex.Message);
            }
            
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
