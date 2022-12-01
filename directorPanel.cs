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
    public partial class directorPanel : Form
    {
        private NpgsqlConnection conn;
        private string query;
        private NpgsqlCommand cmd;
        private DataTable dt;

        public directorPanel(string connect)
        {
            InitializeComponent();
            conn=new NpgsqlConnection(connect);
        }
        
        private void directorPanel_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти?\nНесохраненные изменения будут утеряны", "Выход", MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }            
        }

        private void selectManBtn_Click(object sender, EventArgs e)
        {
            query = "select * from \"Managers\"";
            conn.Open();
            cmd = new NpgsqlCommand(query,conn);
            dt=new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void addManBtn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(nameTb.Text)&&
                string.IsNullOrEmpty(eduTb.Text)&&
                string.IsNullOrEmpty(salTb.Text)&&
                string.IsNullOrEmpty(loginTb.Text)&&
                string.IsNullOrEmpty(passTb.Text)))
            {
                if (double.TryParse(salTb.Text, out double sal))
                {
                    try
                    {
                        
                        cmd = new NpgsqlCommand();
                        cmd.CommandText = "manins";
                        cmd.Parameters.AddWithValue("@_name",nameTb.Text);
                        cmd.Parameters.AddWithValue("@_education",eduTb.Text);
                        cmd.Parameters.AddWithValue("@_salary",sal);
                        cmd.Parameters.AddWithValue("@_login",loginTb.Text);
                        cmd.Parameters.AddWithValue("@_password",passTb.Text);
                        cmd.Parameters.AddWithValue("@_startdate",dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@_surname",string.IsNullOrEmpty(surnameTb.Text)? null: surnameTb.Text);
                        cmd.Parameters.AddWithValue("@_patronymic",string.IsNullOrEmpty(patrTb.Text)? null: patrTb.Text);
                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Данные успшено вставлены");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!"+Environment.NewLine+ex.Message);
                        conn.Close();
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ошибка!\nНе корректное значение зарплаты.");
                    return;
                }
               
            }
            else
            {
                MessageBox.Show("Ошибка!\nНе все обязательные поля заполнены.");
                return;
            }
        }
    }
}
