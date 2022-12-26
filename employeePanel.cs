using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace kursBd
{
    public partial class employeePanel : Form
    {
        private MySqlConnection conn;
        private string query;
        private MySqlCommand cmd;
        readonly private int emplId;
        private MySqlDataReader dr;
        private DataTable dt;

        public employeePanel(string connect, int id, List<string> list)
        {
            InitializeComponent();
            conn = new MySqlConnection(connect);
            emplId = id;
            updateInfo(list[0], list[1]);
        }
        private void updateInfo(string namePatr, string sal)
        {
            salLabel.Text = sal;
            helloLabel.Text += ", " + namePatr;
            query = $"select count(*) from employee_service where employeeid={emplId}";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            servLabel.Text = $"{cmd.ExecuteScalar()} услуг";
            conn.Close();
            lastUpdateLabel.Text += " " + DateTime.Now.ToString();
        }


        private void employeePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?\nНесохраненные изменения будут утеряны", "Выход",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private Dictionary<int, string> obj;

        private void selectEvents_Click(object sender, EventArgs e)
        {
            obj = new Dictionary<int, string>();
            query = "select id_event,objectid as номер_объекта,name as название,dateofevent as дата from events";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView4.DataSource = dt;
                dataGridView4.Columns["id_event"].Visible = false;
                query = "select id_obj, name from objects";
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(dr.GetInt32(0), dr.GetString(1));
                }
                objDD.DataSource = obj.Select(kv => kv.Value).ToList();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void addOrdDet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(eventName.Text))
            {
                try
                {
                    query = "call eventIns(@objId,@name,@data)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@objId",
                    obj.First(kv => kv.Value == objDD.SelectedItem.ToString()).Key);
                    cmd.Parameters.AddWithValue("@name", eventName.Text);
                    cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
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
                MessageBox.Show("Ошибка!\nНе все обязательные поля заполнены.");
                return;
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dateTimePicker1.Value = DateTime.Parse(dataGridView4.Rows[e.RowIndex].Cells["дата"].Value.ToString());
            }
            catch (Exception)
            {

            }
            finally
            {
                numericUpDown4.Value = decimal.Parse(dataGridView4.Rows[e.RowIndex].Cells["id_event"].Value.ToString());
                objDD.SelectedIndex = objDD.FindString(
                       obj[int.Parse(dataGridView4.Rows[e.RowIndex].Cells["номер_объекта"].Value.ToString())]);
                eventName.Text = dataGridView4.Rows[e.RowIndex].Cells["название"].Value.ToString();
            }
        }

        private void eventUpd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(eventName.Text))
            {
                try
                {
                    query = "call eventUpd(@evId,@objId,@name,@data)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@evId", (int)numericUpDown4.Value);
                    cmd.Parameters.AddWithValue("@objId",
                    obj.First(kv => kv.Value == objDD.SelectedItem.ToString()).Key);
                    cmd.Parameters.AddWithValue("@name", eventName.Text);
                    cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
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

        private void eventDel_Click(object sender, EventArgs e)
        {
            try
            {
                query = "delete from events where id_event=@evId";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@evId", (int)numericUpDown4.Value);
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
    }
}
