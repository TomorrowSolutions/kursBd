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
        private MySqlDataReader dr;

        public directorPanel(string connect)
        {
            InitializeComponent();
            conn=new MySqlConnection(connect);
            loadPos();
        }       
        private void loadPos()
        {
            query = "select name from position_salary";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            dr=cmd.ExecuteReader();
            while (dr.Read()) {
                emplPosDD.Items.Add(dr["name"]);
            }
            dr.Close();
            conn.Close();
            emplPosDD.SelectedIndex = 0;
        }
        private int getPosId(string name)
        {
            int id = 0;
            query = $"select id_pos from position_salary where name='{name}'";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            id=(int)cmd.ExecuteScalar();
            conn.Close();
            return id;

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
                numericUpDown1.Value = decimal.Parse(dataGridView2.Rows[e.RowIndex].Cells["positionid"].Value.ToString());
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
                numericUpDown1.Value =getPosId(emplPosDD.SelectedItem.ToString());
                try
                {
                    query = "call emplIns(@surn,@name,@patr,@edu,@posId,@date,@log,@pas)";
                    cmd = new MySqlCommand(query,conn);
                    cmd.Parameters.AddWithValue("@name", emplName.Text);
                    cmd.Parameters.AddWithValue("@edu", emplEdu.Text);
                    cmd.Parameters.AddWithValue("@posId", (int)numericUpDown1.Value);
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
                numericUpDown1.Value = getPosId(emplPosDD.SelectedItem.ToString());
                try
                    {

                        query = "call emplUpdate(@emplId,@surn,@name,@patr,@edu,@posId,@date,@log,@pas)";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@emplId",int.Parse(numericUpDown2.Value.ToString()));
                        cmd.Parameters.AddWithValue("@name", emplName.Text);
                        cmd.Parameters.AddWithValue("@edu", emplEdu.Text);
                        cmd.Parameters.AddWithValue("@posId", (int)numericUpDown1.Value);
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

        private void emplServSelect_Click(object sender, EventArgs e)
        {
            query = "select * from pgkurs.employee_service";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            emplLB.Items.Clear();servLB.Items.Clear();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView4.DataSource = dt;
                query = "select id_empl as id, concat_ws(' ',surname,name,patronymic) as FIO from pgkurs.employees";
                cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emplLB.Items.Add($"{reader["id"]}--{reader["FIO"]}");
                }
                reader.Close();
                query = "select id_serv as id, name from pgkurs.services";
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    servLB.Items.Add($"{reader["id"]}--{reader["name"]}");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void emplLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown4.Value = int.Parse(emplLB.SelectedItem.ToString()
                .Substring(0, emplLB.SelectedItem.ToString().IndexOf('-')));
        }

        private void servLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown6.Value = int.Parse(servLB.SelectedItem.ToString()
              .Substring(0, servLB.SelectedItem.ToString().IndexOf('-')));
        }

        private void emplServAdd_Click(object sender, EventArgs e)
        {
            try
            {
                query = "call emplServIns(@emplId,@servId)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emplId", int.Parse(numericUpDown4.Value.ToString()));
                cmd.Parameters.AddWithValue("@servId", int.Parse(numericUpDown6.Value.ToString()));
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
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numericUpDown4.Value = int.Parse(dataGridView4.Rows[e.RowIndex].Cells["employeeid"].Value.ToString());
                numericUpDown6.Value = int.Parse(dataGridView4.Rows[e.RowIndex].Cells["serviceid"].Value.ToString());
                emplLB.SelectedIndex = emplLB.FindString(numericUpDown4.Value.ToString());
                servLB.SelectedIndex = servLB.FindString(numericUpDown6.Value.ToString());
            }
        }

        private void emplServDelete_Click(object sender, EventArgs e)
        {
            try
            {
                query = "delete from pgkurs.employee_service where employeeid=@emplId and serviceid=@servId";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emplId", int.Parse(numericUpDown4.Value.ToString()));
                cmd.Parameters.AddWithValue("@servId", int.Parse(numericUpDown6.Value.ToString()));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Данные успшено удалены");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void updateInfo_Click(object sender, EventArgs e)
        {
            query = "select count(*) from employees";
            cmd = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                emplLabel.Text = $"{cmd.ExecuteScalar()} Сотрудников";
                query = "select count(*) from pgkurs.orders";
                cmd = new MySqlCommand(query, conn);
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
    }
}
