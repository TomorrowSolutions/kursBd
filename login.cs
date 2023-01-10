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
        //Строка подключение гостя, для аутентификации сотрудников
        private string visitorConnString = "server=localhost;uid=visitor;pwd=1;database=pgkurs";
        //Строка подключения директора, так как он является единственным пользователем этой учетной записи
        private string directorConnString = String.Empty;
        private MySqlConnection conn;
        private string query;
        private MySqlCommand cmd;
        MySqlDataReader reader;
        //Метод для открытия панели менеджера и передачи сопутсвующей информации
        private void openManPage(string conn, int id, List<string> list) => Application.Run(new managerPanel(conn,id,list));
        //Метод для открытия панели работника и передачи сопутсвующей информации
        private void openEmplPage(string conn,int id, List<string> list) => Application.Run(new employeePanel(conn,id,list));
        //Метод для открытия панели директора
        private void openDirPage(string conn) => Application.Run(new directorPanel(conn));
        //Метод для получения информации о менеджере
        private List<string> getManInfo(int manId)
        {
            List<string> list = new List<string>();
            //Получение строки с именем и фамилией
            query = $"select concat_ws(' ',name,patronymic) as namepatr from employees where id_empl={manId}";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            list.Add(cmd.ExecuteScalar().ToString());
            //Получение строки с информацией об окладе
            query = "select salary from position_salary where name='Менеджер'";
            cmd = new MySqlCommand(query, conn);
            list.Add(cmd.ExecuteScalar().ToString());
            conn.Close();
            return list;
        }
        //Метод для получения информации о сотруднике
        private List<string> getEmplInfo(int emplId)
        {
            List<string> list = new List<string>();
            //Получение строки с именем и фамилией
            query = $"select concat_ws(' ',name,patronymic) as namepatr from employees where id_empl={emplId}";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            list.Add(cmd.ExecuteScalar().ToString());
            //Получение строки с информацией об окладе
            query = $"select salary from position_salary where id_pos=(select positionid from employees where id_empl={emplId})";
            cmd = new MySqlCommand(query, conn);
            list.Add(cmd.ExecuteScalar().ToString());
            conn.Close();
            return list;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Thread thr;
            //проверка типа учетной записи 
            if (emplRadio.Checked)                
            {
                //loginTb.Text = "LosevAA"; passwordTb.Text = "xz85";
                //loginTb.Text = "Petr"; passwordTb.Text = "abc123";
                //Выборка номера работника, должности с заданными логином и паролем
                query = String.Format("select id_empl as id, positionid as pos from pgkurs.employees where login='{0}' and password='{1}'",
                                     loginTb.Text, passwordTb.Text);
            }
            else if (dirRadio.Checked)
            {
                loginTb.Text = "director";passwordTb.Text = "admin";
                //Задние строки подключения директора с заданными логином и паролем
                directorConnString= $"server=localhost;uid={loginTb.Text};pwd={passwordTb.Text};database=pgkurs";
                query = "select * from pgkurs.employees";
            }
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }
            //Обработка в зависимости от типа учетной записи
            if (emplRadio.Checked )
            {
                //Создание нового подключения под учетной записью гостя
                conn = new MySqlConnection(visitorConnString);
                try
                {
                    //Переменные для получения данных
                    int id=0, posId = 0,manPosId=0;
                    conn.Open();
                    cmd = new MySqlCommand(query,conn);
                    reader = cmd.ExecuteReader();
                    //Переменная для проверки авторизации 
                    bool isLogin = false;
                    //Парсинг значений id 
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
                        thr = new Thread(() => openEmplPage("server=localhost;uid=employees;pwd=empl;database=pgkurs", id,
                            getEmplInfo(id)));
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
                    MessageBox.Show("Не удалось авторизоваться.");
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
