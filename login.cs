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
        private void openManPage(string conn, int id) => Application.Run(new managerPanel(conn,id));
        private void openEmplPage(string conn,int id) => Application.Run(new employeePanel(conn,id));
        private void openDirPage(string conn) => Application.Run(new directorPanel(conn));
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Thread thr;

            if (emplRadio.Checked)
            {
                query = String.Format("select  \"id_empl\" from \"{0}\" WHERE login='{1}' and \"password\"='{2}'",
                                    "Employees", loginTb.Text, passwordTb.Text);
            }
            else if (managerRadio.Checked)
            {
                query = String.Format("select \"id_man\" from \"{0}\" WHERE login='{1}' and \"password\"='{2}'",
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
                    int id;
                    bool isLogin = int.TryParse(cmd.ExecuteScalar().ToString(), out id) ;
                    conn.Close();
                    MessageBox.Show(isLogin ? "Авторизация прошла успешно." : "Не удалось авторизоваться.");
                    if (isLogin==false)
                    {
                        return;
                    }
                    if (emplRadio.Checked)
                    {                       
                        this.Close();
                        thr= new Thread(()=>openEmplPage(string.Format("Server={0};Port={1};" +
                                                        "User Id={2};Password={3};Database={4};",
                                                        "localhost", 5432, "employees", "empl", "dbKurs"),id));
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                    }
                    else if (managerRadio.Checked)
                    {                        
                        this.Close();
                        thr = new Thread(() => openManPage(string.Format("Server={0};Port={1};" +
                                                        "User Id={2};Password={3};Database={4};",
                                                        "localhost", 5432, "managers", "man", "dbKurs"),id));
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
                    
                    this.Close();
                    thr = new Thread(()=>openDirPage(directorConnString));
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
