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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace kursBd
{
    public partial class directorPanel : Form
    {
        private MySqlConnection conn;
        private string query;
        private MySqlCommand cmd;
        private DataTable dt;

        public directorPanel(string connect)
        {
            InitializeComponent();
            conn=new MySqlConnection(connect);
        }
        
        private void directorPanel_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти?\nНесохраненные изменения будут утеряны", "Выход",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==DialogResult.Cancel)
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
            query = "select * from pgkurs.managers";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();            
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
            
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
                        query = "insert into pgkurs.managers(surname,name,patronymic,education,salary,dateofstart,login,password) " +
                            "values(@surn,@name,@patr,@edu,@sal,@date,@log,@pas)";
                        cmd= new MySqlCommand(query,conn);
                        cmd.Parameters.AddWithValue("@name", nameTb.Text);
                        cmd.Parameters.AddWithValue("@edu", eduTb.Text);
                        cmd.Parameters.AddWithValue("@sal", sal);
                        cmd.Parameters.AddWithValue("@log", loginTb.Text);
                        cmd.Parameters.AddWithValue("@pas", passTb.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@surn", string.IsNullOrEmpty(surnameTb.Text) ? null : surnameTb.Text);
                        cmd.Parameters.AddWithValue("@patr", string.IsNullOrEmpty(patrTb.Text) ? null : patrTb.Text);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numericUpDown1.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_man"].Value.ToString());
                surnameTb.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                nameTb.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                patrTb.Text = dataGridView1.Rows[e.RowIndex].Cells["patronymic"].Value.ToString();
                eduTb.Text = dataGridView1.Rows[e.RowIndex].Cells["education"].Value.ToString();
                salTb.Text = dataGridView1.Rows[e.RowIndex].Cells["salary"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["dateofstart"].Value.ToString());
                loginTb.Text= dataGridView1.Rows[e.RowIndex].Cells["login"].Value.ToString();
                passTb.UseSystemPasswordChar = false;
                passTb.Text= dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();

            }
        }

        private void delManBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("При удалении учетной записи менеджера,\n" +
                "будут так же удалены связанные с ним договоры", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    query = "call manDel(@manId)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@manId", int.Parse(numericUpDown1.Value.ToString()));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Успешно удалено");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                    conn.Close();
                    return;
                }
            }
            else
            {
                return;                
            }
            
        }

        private void updateManBtn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(nameTb.Text) &&
                string.IsNullOrEmpty(eduTb.Text) &&
                string.IsNullOrEmpty(salTb.Text) &&
                string.IsNullOrEmpty(loginTb.Text) &&
                string.IsNullOrEmpty(passTb.Text)))
            {
                if (double.TryParse(salTb.Text, out double sal))
                {
                    try
                    {
                        query = "update pgkurs.managers set surname=@surn,name=@name,patronymic=@patr,education=@edu," +
                            "salary=@sal, dateofstart=@date,login=@log,password=@pas where id_man=@manId";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@manId", int.Parse(numericUpDown1.Value.ToString()));
                        cmd.Parameters.AddWithValue("@name", nameTb.Text);
                        cmd.Parameters.AddWithValue("@edu", eduTb.Text);
                        cmd.Parameters.AddWithValue("@sal", sal);
                        cmd.Parameters.AddWithValue("@log", loginTb.Text);
                        cmd.Parameters.AddWithValue("@pas", passTb.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@surn", string.IsNullOrEmpty(surnameTb.Text) ? null : surnameTb.Text);
                        cmd.Parameters.AddWithValue("@patr", string.IsNullOrEmpty(patrTb.Text) ? null : patrTb.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Данные успшено обновлены");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
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

        private void button5_Click(object sender, EventArgs e)
        {
            query = "select sum(tbl.cnt) from (select count(*) as cnt from pgkurs.managers " +
                "union all select count(*) as cnt from pgkurs.employees)tbl;";
            cmd= new MySqlCommand(query,conn);
            try
            {
                conn.Open();
                emplLabel.Text = $"{cmd.ExecuteScalar()} Сотрудников";
                query = "select count(*) from pgkurs.orders";
                cmd = new MySqlCommand(query,conn);
                orderLabel.Text = $"{cmd.ExecuteScalar()} Договоров";
                query = "select sum(price) from pgkurs.orders";
                cmd = new MySqlCommand(query, conn);
                profitLabel.Text = $"{cmd.ExecuteScalar()} руб";
                conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void selectEmpl_Click(object sender, EventArgs e)
        {
            query = "select * from pgkurs.employees";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numericUpDown2.Value = decimal.Parse(dataGridView2.Rows[e.RowIndex].Cells["id_empl"].Value.ToString());
                numericUpDown3.Value = decimal.Parse(dataGridView2.Rows[e.RowIndex].Cells["positionId"].Value.ToString());
                emplSName.Text = dataGridView2.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                emplName.Text = dataGridView2.Rows[e.RowIndex].Cells["name"].Value.ToString();
                emplPatr.Text = dataGridView2.Rows[e.RowIndex].Cells["patronymic"].Value.ToString();
                emplEdu.Text = dataGridView2.Rows[e.RowIndex].Cells["education"].Value.ToString();
                dateTimePicker2.Value = DateTime.Parse(dataGridView2.Rows[e.RowIndex].Cells["dateofstart"].Value.ToString());
                emplLog.Text = dataGridView2.Rows[e.RowIndex].Cells["login"].Value.ToString();
                emplPas.UseSystemPasswordChar = false;
                emplPas.Text = dataGridView2.Rows[e.RowIndex].Cells["password"].Value.ToString();

            }
        }

        private void addEmpl_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(emplName.Text)&&
                string.IsNullOrEmpty(emplEdu.Text) &&
                string.IsNullOrEmpty(emplLog.Text) &&
                string.IsNullOrEmpty(emplPas.Text)))
            {
                
                try
                {
                    query = "call emplIns(@surn,@name,@patr,@edu,@posId,@date,@log,@pas)";
                    cmd = new MySqlCommand(query,conn);
                    cmd.Parameters.AddWithValue("@name", emplName.Text);
                    cmd.Parameters.AddWithValue("@edu", emplEdu.Text);
                    cmd.Parameters.AddWithValue("@posId", int.Parse(numericUpDown3.Value.ToString()));
                    cmd.Parameters.AddWithValue("@log", emplLog.Text) ;
                    cmd.Parameters.AddWithValue("@pas", emplPas.Text) ;
                    cmd.Parameters.AddWithValue("@date", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@surn", string.IsNullOrEmpty(emplSName.Text) ? null : emplSName.Text);
                    cmd.Parameters.AddWithValue("@patr", string.IsNullOrEmpty(emplPatr.Text) ? null : emplPatr.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Данные успешно добавлены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                    conn.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\nНе все обязательные поля заполнены.");
                return;
            }
           
        }

        private void delEmpl_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("При удалении учетной записи сотрудника,\n" +
                "будут так же удалены связанные с ним записи", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    cmd = new MySqlCommand("call emplDel(@emplid)", conn);
                    cmd.Parameters.AddWithValue("@emplid", int.Parse(numericUpDown2.Value.ToString()));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Данные успешно удалены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                    conn.Close();
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void updEmpl_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(emplName.Text) &&
                string.IsNullOrEmpty(emplEdu.Text) &&
                string.IsNullOrEmpty(emplLog.Text) &&
                string.IsNullOrEmpty(emplPas.Text)))
            {
                    try
                    {

                        query = "call emplUpdate(@emplId,@surn,@name,@patr,@edu,@posId,@date,@log,@pas)";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@emplId",int.Parse(numericUpDown2.Value.ToString()));
                        cmd.Parameters.AddWithValue("@name", emplName.Text);
                        cmd.Parameters.AddWithValue("@edu", emplEdu.Text);
                        cmd.Parameters.AddWithValue("@posId",int.Parse(numericUpDown3.Value.ToString()));
                        cmd.Parameters.AddWithValue("@log", emplLog.Text);
                        cmd.Parameters.AddWithValue("@pas", emplPas.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker2.Value);
                        cmd.Parameters.AddWithValue("@surn", string.IsNullOrEmpty(emplSName.Text) ? null : emplSName.Text);
                        cmd.Parameters.AddWithValue("@patr", string.IsNullOrEmpty(emplPatr.Text) ? null : emplPatr.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Данные успшено обновлены");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                        conn.Close();
                        return;
                    }


            }
            else
            {
                MessageBox.Show("Ошибка!\nНе все обязательные поля заполнены.");
                return;
            }
        }

        private void selectPos_Click(object sender, EventArgs e)
        {
            query = "select * from pgkurs.position_salary";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView3.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numericUpDown5.Value = decimal.Parse(dataGridView3.Rows[e.RowIndex].Cells["id_pos"].Value.ToString());
                posName.Text = dataGridView3.Rows[e.RowIndex].Cells["name"].Value.ToString();
                posSal.Text = dataGridView3.Rows[e.RowIndex].Cells["salary"].Value.ToString();                

            }
        }

        private void addPos_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(posName.Text) &&
                string.IsNullOrEmpty(posSal.Text)))
            {
                if (double.TryParse(posSal.Text, out double sal))
                {
                    try
                    {
                        query = "insert into pgkurs.position_salary(name,salary) values(@name,@sal)";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", posName.Text);
                        cmd.Parameters.AddWithValue("@sal", sal);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Данные успшено вставлены");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
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

        private void updPos_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(posName.Text) &&
                string.IsNullOrEmpty(posSal.Text)))
            {
                if (double.TryParse(posSal.Text, out double sal))
                {
                    try
                    {
                        query = "update pgkurs.position_salary set name=@name,salary=@sal where id_pos=@posId";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@posId", int.Parse(numericUpDown5.Value.ToString()));
                        cmd.Parameters.AddWithValue("@name", posName.Text);
                        cmd.Parameters.AddWithValue("@sal", sal);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Данные успшено обновлены");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
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

        private void delPos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("При удалении должности,\n" +
                "будут так же удалены связанные с ней записи сотрудников", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    query = "call posDel(@posId)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@posId", int.Parse(numericUpDown5.Value.ToString()));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Данные успешно удалены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                    conn.Close();
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
