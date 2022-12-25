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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
        MySqlDataReader reader;
        private void openManPage(string conn, int id, List<string> list) => Application.Run(new managerPanel(conn,id,list));
        private void openEmplPage(string conn,int id) => Application.Run(new employeePanel(conn,id));
        private void openDirPage(string conn) => Application.Run(new directorPanel(conn));
        private List<string> getManInfo(int manId)
        {
            List<string> list = new List<string>();
            query = $"select concat_ws(' ',name,patronymic) as namepatr from employees where id_empl={manId}";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            list.Add(cmd.ExecuteScalar().ToString());
            query = "select salary from position_salary where name='Менеджер'";
            cmd = new MySqlCommand(query, conn);
            list.Add(cmd.ExecuteScalar().ToString());
            conn.Close();
            return list;
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Thread thr;

            if (emplRadio.Checked)                
            {
                loginTb.Text = "Petr"; passwordTb.Text = "abc123";
                query = String.Format("select id_empl as id, positionid as pos from pgkurs.employees where login='{0}' and password='{1}'",
                                     loginTb.Text, passwordTb.Text);
            }
            else if (dirRadio.Checked)
            {
                loginTb.Text = "director";passwordTb.Text = "admin";
                directorConnString= "server=localhost;uid=director;pwd=admin;database=pgkurs";
                query = "select * from pgkurs.employees";
            }
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }
            if (emplRadio.Checked )
            {
                conn = new MySqlConnection(visitorConnString);
                try
                {
                    int id=0, posId = 0,manPosId=0;
                    conn.Open();
                    cmd = new MySqlCommand(query,conn);
                    reader = cmd.ExecuteReader();
                    bool isLogin = false;
                    while (reader.Read())
                    {
                       isLogin = int.TryParse(reader["id"].ToString(), out id) &&
                                   int.TryParse(reader["pos"].ToString(), out posId);
                    }                    
                    reader.Close();
                    query = "select id_pos from position_salary where name='Менеджер'";
                    cmd = new MySqlCommand(query,conn);
                    bool isFindManager = int.TryParse(cmd.ExecuteScalar().ToString(), out manPosId);
                    conn.Close();
                    MessageBox.Show(isLogin&&isFindManager ? "Авторизация прошла успешно." : "Не удалось авторизоваться.");
                    if (isLogin==false||isFindManager==false)
                    {
                        return;
                    }
                    if (posId==manPosId)
                    {                
                        this.Close();
                        thr = new Thread(() => openManPage("server=localhost;uid=managers;pwd=man;database=pgkurs",
                            id, getManInfo(id)));
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                    }
                    else
                    {
                        this.Close();
                        thr = new Thread(() => openEmplPage("server=localhost;uid=employees;pwd=empl;database=pgkurs", id));
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
