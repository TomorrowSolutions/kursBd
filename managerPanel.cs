using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kursBd
{
    public partial class managerPanel : Form
    {
        private MySqlConnection conn;
        private string query;
        private MySqlCommand cmd;
        private DataTable dt;
        private int manId;
        MySqlDataReader reader;

        public managerPanel(string connect, int id, List<string> l)
        {
            InitializeComponent();
            conn = new MySqlConnection(connect);
            manId = id;
            updateInfo(l[1], l[0]);
            personType.SelectedIndex = 0;
        }
        private void updateInfo(string sal, string namePatr)
        {
            salLabel.Text = sal;
            helloLabel.Text += ", " + namePatr;
            query = $"select count(*) from pgkurs.orders where managerid={manId}";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            orderLabel.Text = $"{cmd.ExecuteScalar()} Договоров";
            conn.Close();
            lastUpdateLabel.Text += " " + DateTime.Now.ToString();
        }

        private void managerPanel_FormClosing(object sender, FormClosingEventArgs e)
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

        private void selectServ_Click(object sender, EventArgs e)
        {
            query = "select * from pgkurs.services";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView4.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void addService_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(servName.Text) &&
                string.IsNullOrEmpty(servPrice.Text) &&
                string.IsNullOrEmpty(servPeriod.Text)))
            {
                if (double.TryParse(servPrice.Text, out double price) &&
                    int.TryParse(servPeriod.Text, out int period))
                {
                    try
                    {
                        query = "insert into pgkurs.services(name,price,periodofexecution) " +
                            "values(@name,@price,@period)";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", servName.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@period", period);
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
                    MessageBox.Show("Ошибка!\nНе корректное значение цены и/или периода выполнения.");
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
            if (e.RowIndex >= 0)
            {
                numericUpDown4.Value = decimal.Parse(dataGridView4.Rows[e.RowIndex].Cells["id_serv"].Value.ToString());
                servName.Text = dataGridView4.Rows[e.RowIndex].Cells["name"].Value.ToString();
                servPrice.Text = dataGridView4.Rows[e.RowIndex].Cells["price"].Value.ToString();
                servPeriod.Text = dataGridView4.Rows[e.RowIndex].Cells["periodofexecution"].Value.ToString();
            }
        }

        private void updServ_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(servName.Text) &&
                string.IsNullOrEmpty(servPrice.Text) &&
                string.IsNullOrEmpty(servPeriod.Text)))
            {
                if (double.TryParse(servPrice.Text, out double price) &&
                    int.TryParse(servPeriod.Text, out int period))
                {
                    try
                    {
                        query = "update pgkurs.services set name=@name,price=@price,periodofexecution=@period where id_serv=@servId";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@servId", (int)numericUpDown4.Value);
                        cmd.Parameters.AddWithValue("@name", servName.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@period", period);
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
                    MessageBox.Show("Ошибка!\nНе корректное значение цены и/или периода выполнения.");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Ошибка!\nНе все обязательные поля заполнены.");
                return;
            }
        }

        private void delServ_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("При удалении услуг," +
                "будут так же удалены связанные с ней записи в таблице соотношений работников и услуг,\n" +
                "а также договоры если в них будет присутствовать данная услуга.", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    query = "call servDel(@servId)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@servId", int.Parse(numericUpDown4.Value.ToString()));
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

        private void selectManBtn_Click(object sender, EventArgs e)
        {
            query = "select * from pgkurs.clients";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numericUpDown1.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_client"].Value.ToString());
                clientSurn.Text = dataGridView1.Rows[e.RowIndex].Cells["surnamepred"].Value.ToString();
                clientName.Text = dataGridView1.Rows[e.RowIndex].Cells["namepred"].Value.ToString();
                clientPatr.Text = dataGridView1.Rows[e.RowIndex].Cells["patronymicpred"].Value.ToString();
                clientPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["phonenum"].Value.ToString();
                personType.SelectedIndex = dataGridView1.Rows[e.RowIndex].Cells["typeofperson"].Value.ToString() == "legal" ?
                    1 : 0;
                clientCity.Text = dataGridView1.Rows[e.RowIndex].Cells["city"].Value.ToString();
                clientStreet.Text = dataGridView1.Rows[e.RowIndex].Cells["street"].Value.ToString();
                clientBuild.Text = dataGridView1.Rows[e.RowIndex].Cells["building"].Value.ToString();
                clientAcc.Text = dataGridView1.Rows[e.RowIndex].Cells["accountnumber"].Value.ToString();

            }
        }


        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void addManBtn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(clientCity.Text) ||
                string.IsNullOrEmpty(clientBuild.Text) ||
                string.IsNullOrEmpty(clientStreet.Text)))
            {
                try
                {
                    query = "insert into pgkurs.clients(surnamepred,namepred,patronymicpred,phonenum,typeofperson,city,street,building,accountnumber) " +
                        "values(@surn,@name,@patr,@phone,@type,@city,@street,@build,@acc)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@surn", clientSurn.Text);
                    cmd.Parameters.AddWithValue("@name", clientName.Text);
                    cmd.Parameters.AddWithValue("@patr", clientPatr.Text);
                    cmd.Parameters.AddWithValue("@phone", clientPhone.Text.All(char.IsDigit) ? clientPhone.Text:string.Empty);
                    cmd.Parameters.AddWithValue("@type", personType.SelectedIndex == 1 ? "legal":"individual");
                    cmd.Parameters.AddWithValue("@city", clientCity.Text);
                    cmd.Parameters.AddWithValue("@street", clientStreet.Text);
                    cmd.Parameters.AddWithValue("@build", clientBuild.Text);
                    cmd.Parameters.AddWithValue("@acc", clientAcc.Text.All(char.IsDigit) ? clientPhone.Text : string.Empty);
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

        private void updateManBtn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(clientCity.Text) ||
               string.IsNullOrEmpty(clientBuild.Text) ||
               string.IsNullOrEmpty(clientStreet.Text)))
            {
                try
                {
                    query = "update pgkurs.clients set surnamepred=@surn,namepred=@name,patronymicpred=@patr,phonenum=@phone," +
                        "typeofperson=@type,city=@city,street=@street,building=@build,accountnumber=@acc where id_client=@clientId";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@clientId", (int)numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@surn", clientSurn.Text);
                    cmd.Parameters.AddWithValue("@name", clientName.Text);
                    cmd.Parameters.AddWithValue("@patr", clientPatr.Text);
                    cmd.Parameters.AddWithValue("@phone", clientPhone.Text.All(char.IsDigit) ? clientPhone.Text : string.Empty);
                    cmd.Parameters.AddWithValue("@type", personType.SelectedIndex == 1 ? "legal" : "individual");
                    cmd.Parameters.AddWithValue("@city", clientCity.Text);
                    cmd.Parameters.AddWithValue("@street", clientStreet.Text);
                    cmd.Parameters.AddWithValue("@build", clientBuild.Text);
                    cmd.Parameters.AddWithValue("@acc", clientAcc.Text.All(char.IsDigit) ? clientAcc.Text : string.Empty);
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

        private void delManBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("При удалении учетной записи клиента,\n" +
                "будут так же удалены связанные с ним договоры", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    query = "call clientDel(@clientId)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@clientId", (int)numericUpDown1.Value);
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

        private void loadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Выберите изображение (*.jpg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                preview.Image = Image.FromFile(ofd.FileName);
            }
        }
        private byte[] imgToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms,img.RawFormat);
            byte[] data = ms.ToArray();
            return data;
        }

        private void addObj_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objName.Text) ||
                string.IsNullOrEmpty(objCity.Text) ||
                string.IsNullOrEmpty(objStreet.Text)||
                string.IsNullOrEmpty(objBuild.Text) ||
                string.IsNullOrEmpty(objType.Text)))
            {
                try
                {
                    query = "insert into pgkurs.objects(name,image,city,street,building,type) " +
                        "values(@name,@img,@city,@street,@build,@type)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", objName.Text);
                    cmd.Parameters.AddWithValue("@img", preview.Image==null ? null: imgToByte(preview.Image));
                    cmd.Parameters.AddWithValue("@city", objCity.Text);
                    cmd.Parameters.AddWithValue("@street", objStreet.Text);
                    cmd.Parameters.AddWithValue("@build", objBuild.Text);
                    cmd.Parameters.AddWithValue("@type", objType.Text);
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

        private void selectObj_Click(object sender, EventArgs e)
        {
            query = "select * from pgkurs.objects";
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
                numericUpDown2.Value = decimal.Parse(dataGridView2.Rows[e.RowIndex].Cells["id_obj"].Value.ToString());
                objName.Text = dataGridView2.Rows[e.RowIndex].Cells["name"].Value.ToString();
                preview.Image =Image.FromStream( 
                   new MemoryStream((byte[])dataGridView2.Rows[e.RowIndex].Cells["image"].Value));
                objCity.Text = dataGridView2.Rows[e.RowIndex].Cells["city"].Value.ToString();
                objStreet.Text = dataGridView2.Rows[e.RowIndex].Cells["street"].Value.ToString();
                objBuild.Text = dataGridView2.Rows[e.RowIndex].Cells["building"].Value.ToString();
                objType.Text = dataGridView2.Rows[e.RowIndex].Cells["type"].Value.ToString();
            }
        }

        private void updateObj_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objName.Text) ||
                string.IsNullOrEmpty(objCity.Text) ||
                string.IsNullOrEmpty(objStreet.Text) ||
                string.IsNullOrEmpty(objBuild.Text) ||
                string.IsNullOrEmpty(objType.Text)))
            {
                try
                {
                    query = "update pgkurs.objects set name=@name,image=@img,city=@city,street=@street,building=@build,type=@type " +
                        "where id_obj=@objId"; 
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@objId", (int)numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@name", objName.Text);
                    cmd.Parameters.AddWithValue("@img", preview.Image == null ? null : imgToByte(preview.Image));
                    cmd.Parameters.AddWithValue("@city", objCity.Text);
                    cmd.Parameters.AddWithValue("@street", objStreet.Text);
                    cmd.Parameters.AddWithValue("@build", objBuild.Text);
                    cmd.Parameters.AddWithValue("@type", objType.Text);
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

        private void deleteObj_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("При удалении записи объекта, " +
                "будут так же удалены связанные с ним договоры и события", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    query = "call objDel(@objId)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@objId", (int)numericUpDown2.Value);
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
    }
}
