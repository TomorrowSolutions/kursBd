using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private string directorConnString = String.Empty;
        private NpgsqlConnection conn;
        private string query;
        private NpgsqlCommand cmd;
        private void openManPage() => Application.Run(new managerPanel());
        private void openEmplPage() => Application.Run(new employeePanel());
        private void openDirPage() => Application.Run(new directorPanel());
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Thread thr;

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
            else if (dirRadio.Checked)
            {
                directorConnString= string.Format("Server={0};Port={1};" +
                                                        "User Id={2};Password={3};Database={4};",
                                                        "localhost", 5432, loginTb.Text, passwordTb.Text, "dbKurs");
                query = "select * from \"Managers\"";
            }
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }
            if (emplRadio.Checked | managerRadio.Checked)
            {
                conn = new NpgsqlConnection(visitorConnString);
                try
                {
                    conn.Open();
                    cmd = new NpgsqlCommand(query, conn);
                    bool isLogin = bool.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    MessageBox.Show(isLogin ? "Авторизация прошла успешно." : "Не удалось авторизоваться.");
                    if (isLogin==false)
                    {
                        return;
                    }
                    if (emplRadio.Checked)
                    {
                       employeePanel.emplConnString= string.Format("Server={0};Port={1};" +
                                                        "User Id={2};Password={3};Database={4};",
                                                        "localhost", 5432, "employees", "empl", "dbKurs");
                        this.Close();
                        thr= new Thread(openEmplPage);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();

                    }
                    else if (managerRadio.Checked)
                    {
                        managerPanel.manConnString = string.Format("Server={0};Port={1};" +
                                                        "User Id={2};Password={3};Database={4};",
                                                        "localhost", 5432, "managers", "man", "dbKurs");
                        this.Close();
                        thr = new Thread(openManPage);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Ошибка!" + System.Environment.NewLine + ex.Message);
                    MessageBox.Show("Ошибка!\nПроверьте правильность введенных данныхю.");
                    return;
                }
            }
            else if (dirRadio.Checked)
            {
                conn= new NpgsqlConnection(directorConnString);
                try
                {
                    conn.Open();
                    cmd= new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    directorPanel.dirConnString = directorConnString;
                    this.Close();
                    thr = new Thread(openDirPage);
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\nПроверьте правильность введенных данныхю.");
                    return ;
                }
            }
            else
            {
                MessageBox.Show("Не удалось выполнить подключение.");
                return ;
            }
            
            
        }
    }
}
