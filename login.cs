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
using MySql.Data.MySqlClient;

namespace kursBd
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private string visitorConnString = "server=localhost;uid=visitor;pwd=1;database=pgkurs";
        private string directorConnString = String.Empty;
        private MySqlConnection conn;
        private string query;
        private MySqlCommand cmd;
        private void openManPage(string conn, int id) => Application.Run(new managerPanel(conn,id));
        private void openEmplPage(string conn,int id) => Application.Run(new employeePanel(conn,id));
        private void openDirPage(string conn) => Application.Run(new directorPanel(conn));
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Thread thr;

            if (emplRadio.Checked)
            {
                query = String.Format("select id_empl from pgkurs.employees where login='{0}' and password='{1}'",
                                     loginTb.Text, passwordTb.Text);
            }
            else if (managerRadio.Checked)
            {
                query = String.Format("select id_man from pgkurs.managers where login='{0}' and password='{1}'",
                                    loginTb.Text, passwordTb.Text);
            }
            else if (dirRadio.Checked)
            {
                loginTb.Text = "director";passwordTb.Text = "admin";
                directorConnString= "server=localhost;uid=director;pwd=admin;database=pgkurs";
                query = "select * from pgkurs.managers";
            }
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }
            if (emplRadio.Checked | managerRadio.Checked)
            {
                conn = new MySqlConnection(visitorConnString);
                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(query,conn);
                    //int id;
                    bool isLogin = int.TryParse(cmd.ExecuteScalar().ToString(), out int id) ;
                    conn.Close();
                    MessageBox.Show(isLogin ? "Авторизация прошла успешно." : "Не удалось авторизоваться.");
                    if (isLogin==false)
                    {
                        return;
                    }
                    if (emplRadio.Checked)
                    {                       
                        this.Close();
                        thr= new Thread(()=>openEmplPage("server=localhost;uid=employees;pwd=empl;database=pgkurs",id));
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                    }
                    else if (managerRadio.Checked)
                    {                        
                        this.Close();
                        thr = new Thread(() => openManPage("server=localhost;uid=managers;pwd=man;database=pgkurs", id));
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!" + System.Environment.NewLine + ex.Message);
                    return;
                }
            }
            else if (dirRadio.Checked)
            {
                conn= new MySqlConnection(directorConnString);
                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(query,conn) ;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Авторизация прошла успешно");
                    this.Close();
                    thr = new Thread(()=>openDirPage(directorConnString));
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!"+Environment.NewLine+ex.Message);
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
