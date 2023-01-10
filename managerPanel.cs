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
        MySqlDataReader dr;

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    numericUpDown1.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_client"].Value.ToString());
                    personType.SelectedIndex = dataGridView1.Rows[e.RowIndex].Cells["тип_лица"].Value.ToString() == "юридическое" ?
                    1 : 0;
                }
                catch (Exception)
                {

                }
                finally
                {
                    clientSurn.Text = dataGridView1.Rows[e.RowIndex].Cells["фамилия_представителя"].Value.ToString();
                    clientName.Text = dataGridView1.Rows[e.RowIndex].Cells["имя_представителя"].Value.ToString();
                    clientPatr.Text = dataGridView1.Rows[e.RowIndex].Cells["отчество_представителя"].Value.ToString();
                    clientPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["номер_телефона"].Value.ToString();
                    clientCity.Text = dataGridView1.Rows[e.RowIndex].Cells["город"].Value.ToString();
                    clientStreet.Text = dataGridView1.Rows[e.RowIndex].Cells["улица"].Value.ToString();
                    clientBuild.Text = dataGridView1.Rows[e.RowIndex].Cells["здание"].Value.ToString();
                    clientAcc.Text = dataGridView1.Rows[e.RowIndex].Cells["номер_счета"].Value.ToString();
                }             
            }
        }

        private void loadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Выберите изображение (*.jpg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                preview.Image = Image.FromFile(ofd.FileName);
            }
        }
        private byte[] imgToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            byte[] data = ms.ToArray();
            return data;
        }

        private void addObj_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objName.Text) ||
                string.IsNullOrEmpty(objCity.Text) ||
                string.IsNullOrEmpty(objStreet.Text) ||
                string.IsNullOrEmpty(objBuild.Text)))
            {
                try
                {
                    query = "insert into pgkurs.objects(name,image,city,street,building) " +
                        "values(@name,@img,@city,@street,@build)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", objName.Text);
                    cmd.Parameters.AddWithValue("@img", preview.Image == null ? null : imgToByte(preview.Image));
                    cmd.Parameters.AddWithValue("@city", objCity.Text);
                    cmd.Parameters.AddWithValue("@street", objStreet.Text);
                    cmd.Parameters.AddWithValue("@build", objBuild.Text);
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
            query = "select id_obj, name as название, image, city as город, street as улица, building as здание " +
                "from objects";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView2.DataSource = dt;
                conn.Close();
                dataGridView2.Columns["id_obj"].Visible = false;
                dataGridView2.Columns["image"].Visible = false;
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
                try
                {
                    preview.Image = Image.FromStream(
                        new MemoryStream((byte[])dataGridView2.Rows[e.RowIndex].Cells["image"].Value));
                }
                catch (Exception)
                {
                    preview.Image = null;
                }
                finally
                {
                    numericUpDown2.Value = decimal.Parse(dataGridView2.Rows[e.RowIndex].Cells["id_obj"].Value.ToString());
                    objName.Text = dataGridView2.Rows[e.RowIndex].Cells["название"].Value.ToString();
                    objCity.Text = dataGridView2.Rows[e.RowIndex].Cells["город"].Value.ToString();
                    objStreet.Text = dataGridView2.Rows[e.RowIndex].Cells["улица"].Value.ToString();
                    objBuild.Text = dataGridView2.Rows[e.RowIndex].Cells["здание"].Value.ToString();
                }
            }
        }

        private void updateObj_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objName.Text) ||
                string.IsNullOrEmpty(objCity.Text) ||
                string.IsNullOrEmpty(objStreet.Text) ||
                string.IsNullOrEmpty(objBuild.Text)))
            {
                try
                {
                    query = "update pgkurs.objects set name=@name,image=@img,city=@city,street=@street,building=@build " +
                        "where id_obj=@objId";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@objId", (int)numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@name", objName.Text);
                    cmd.Parameters.AddWithValue("@img", preview.Image == null ? null : imgToByte(preview.Image));
                    cmd.Parameters.AddWithValue("@city", objCity.Text);
                    cmd.Parameters.AddWithValue("@street", objStreet.Text);
                    cmd.Parameters.AddWithValue("@build", objBuild.Text);
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

        private void selectClient_Click(object sender, EventArgs e)
        {
            query = "select id_client,surnamepred as фамилия_представителя, namepred as имя_представителя," +
                "patronymicpred as отчество_представителя," +
                "phonenum as номер_телефона, typeofperson as тип_лица, city as город, street as улица, building as здание," +
                "accountnumber as номер_счета from clients";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                conn.Close();
                dataGridView1.Columns["id_client"].Visible = false;
                dataGridView1.Columns["номер_телефона"].Visible = false;
                dataGridView1.Columns["номер_счета"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex.Message);
                conn.Close();
                return;
            }
        }

        private void addClient_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(clientCity.Text) ||
                string.IsNullOrEmpty(clientBuild.Text) ||
                string.IsNullOrEmpty(clientStreet.Text) ||
                string.IsNullOrEmpty(clientName.Text) ||
                string.IsNullOrEmpty(clientSurn.Text) ||
                string.IsNullOrEmpty(clientPatr.Text)
                ))
            {
                try
                {
                    query = "insert into pgkurs.clients(surnamepred,namepred,patronymicpred,phonenum,typeofperson,city,street,building,accountnumber) " +
                        "values(@surn,@name,@patr,@phone,@type,@city,@street,@build,@acc)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@surn", clientSurn.Text);
                    cmd.Parameters.AddWithValue("@name", clientName.Text);
                    cmd.Parameters.AddWithValue("@patr", clientPatr.Text);
                    cmd.Parameters.AddWithValue("@phone", clientPhone.Text.All(char.IsDigit) ? clientPhone.Text : string.Empty);
                    cmd.Parameters.AddWithValue("@type", personType.SelectedIndex == 1 ? "юридическое" : "физическое");
                    cmd.Parameters.AddWithValue("@city", clientCity.Text);
                    cmd.Parameters.AddWithValue("@street", clientStreet.Text);
                    cmd.Parameters.AddWithValue("@build", clientBuild.Text);
                    cmd.Parameters.AddWithValue("@acc", clientAcc.Text.All(char.IsDigit) ? clientAcc.Text : string.Empty);
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

        private void updateClient_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(clientCity.Text) ||
               string.IsNullOrEmpty(clientBuild.Text) ||
               string.IsNullOrEmpty(clientStreet.Text) ||
               string.IsNullOrEmpty(clientName.Text) ||
                string.IsNullOrEmpty(clientSurn.Text) ||
                string.IsNullOrEmpty(clientPatr.Text)
               ))
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
                    cmd.Parameters.AddWithValue("@type", personType.SelectedIndex == 1 ? "юридическое" : "физическое");
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

        private void delClient_Click(object sender, EventArgs e)
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

        private void delImg_Click(object sender, EventArgs e)
        {
            preview.Image = null;
        }

        private void helpOrder() => MessageBox.Show("При добавлении договора необходимо выбрать менеджера и клиента, которые его заключают, а также дату подписания." +
            "После этого создается пустой заказ, которому необходимо присовоить соответсвующие объекты и услуги;" +
            "Сделать это можно во вкладке детали заказов(номер созданного пустого заказа можно взять в таблице после выборки данных).");

        private void orderHelp_Click(object sender, EventArgs e)
        {
            helpOrder();
        }

        private void selectOrder_Click(object sender, EventArgs e)
        {
            //Выборка данных из таблицы договоров с локализацией
            query = "select id_order as номер_договора, managerid, clientid, dateofsigning as дата_подписания," +
                "dateofcomplete as дата_выполнения, price as стоимость from orders";
            cmd = new MySqlCommand(query, conn);
            dt = new DataTable();
            manDD.Items.Clear(); clientDD.Items.Clear();
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dataGridView3.DataSource = dt;
                dataGridView3.Columns["managerid"].Visible = false;
                dataGridView3.Columns["clientid"].Visible = false;
                //Выборка ФИО и номера работника
                query = "select id_empl as id, concat_ws(' ',surname,name,patronymic) as FIO from pgkurs.employees " +
                    "where positionid = (select id_pos from position_salary where name='Менеджер')";
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Занесение ФИО и номера работника в выпадающий список
                    manDD.Items.Add($"{dr["id"]}--{dr["FIO"]}");
                }
                dr.Close();
                //Выборка ФИО и номера клиента
                query = "select id_client as id,concat_ws(' ',surnamepred,namepred,patronymicpred) as FIO from clients";
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Занесение ФИО и номера клиента в выпадающий список 
                    clientDD.Items.Add($"{dr["id"]}--{dr["FIO"]}");
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Проверка индекса строки
            if (e.RowIndex >= 0)
            {
                //При выборе пустой строки может возникать ошибка парсинга
                try
                {
                    //Безопасное получение даты
                    dateTimePicker1.Value = DateTime.Parse(dataGridView3.Rows[e.RowIndex].Cells["дата_подписания"].Value.ToString());
                }
                catch (Exception)
                {

                }
                finally
                {
                    //Выбор соответствующего элемента выпадающего списка по номеру менеджера
                    manDD.SelectedIndex = manDD.FindString(dataGridView3.Rows[e.RowIndex].Cells["managerid"].Value.ToString());
                    //Выбор соответствующего элемента выпадающего списка по номеру клиента
                    clientDD.SelectedIndex = clientDD.FindString(dataGridView3.Rows[e.RowIndex].Cells["clientid"].Value.ToString());
                    //Занесение номера договора в скрытое поле для последующей работы с ним
                    numericUpDown3.Value = decimal.Parse(dataGridView3.Rows[e.RowIndex].Cells["номер_договора"].Value.ToString());
                }
            }
        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //Вызов хранимой процедуры для добавления заказа
                query = "call ordIns(@manId,@clientId,@data)";
                cmd = new MySqlCommand(query, conn);
                //Добавление параметров команды
                cmd.Parameters.AddWithValue("@manId", int.Parse(manDD.SelectedItem.ToString()
               .Substring(0, manDD.SelectedItem.ToString().IndexOf('-'))));// Выбор номера менеджера из выпадающего списка
                cmd.Parameters.AddWithValue("@clientId", int.Parse(clientDD.SelectedItem.ToString()
               .Substring(0, clientDD.SelectedItem.ToString().IndexOf('-'))));//Выбор номера клиента из выпадающего списка
                cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Данные успшено вставлены");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + Environment.NewLine + ex);
                conn.Close();
                return;
            }
        }

        private Dictionary<int, string> obj, serv;
        private void ordDetlLoad()
        {
            obj = new Dictionary<int, string>();
            serv = new Dictionary<int, string>();
            query = "select id_obj as id, name as name from objects";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.Add(dr.GetInt32(0), dr.GetString(1));
            }
            dr.Close();
            query = "select id_serv,name from services";
            cmd = new MySqlCommand(query, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                serv.Add(dr.GetInt32(0), dr.GetString(1));
            }
            dr.Close();
            conn.Close();
        }

        private void addOrdDet_Click(object sender, EventArgs e)
        {
            try
            {
                query = "call ordDetIns(@ordId,@objId,@servId,@amount)";
                cmd=new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ordId",(int)numericUpDown4.Value );
                cmd.Parameters.AddWithValue("@objId", 
                    obj.First(kv=>kv.Value==objDD.SelectedItem.ToString()).Key);
                cmd.Parameters.AddWithValue("@servId",
                    serv.First(kv => kv.Value == servDD.SelectedItem.ToString()).Key);
                cmd.Parameters.AddWithValue("@amount", (int)numericUpDown5.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close() ;
                MessageBox.Show("Успешно вставлено");
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
                try
                {
                    numericUpDown4.Value = decimal.Parse(dataGridView4.Rows[e.RowIndex].Cells["номер_договора"].Value.ToString());
                    numericUpDown5.Value = decimal.Parse(dataGridView4.Rows[e.RowIndex].Cells["количество_услуг"].Value.ToString());
                    objDD.SelectedIndex = objDD.FindString(
                                        obj[int.Parse(dataGridView4.Rows[e.RowIndex].Cells["номер_объекта"].Value.ToString())]);
                    //Номер объекта=ключ по нему получаем значение и ищем это значение в дд, которое возвращает индекс
                    servDD.SelectedIndex = servDD.FindString(
                       serv[int.Parse(dataGridView4.Rows[e.RowIndex].Cells["номер_услуги"].Value.ToString())]);
                }
                catch (Exception)
                {

                }           
            }
        }

        private void updOrder_Click(object sender, EventArgs e)
        {
            // Промежуточные таблицы для выборки данных
            DataTable srvPrice= new DataTable(),
                      srvAmount=new DataTable();
            try
            {
                // Выборка номера,стоимости, времени выполнения услуг, которые соответствуют текущему договоре
                query = "select id_serv as ID,price,periodofexecution as lng from services where id_serv in (select serviceid from orderdetails where orderid=@ordId)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ordId", (int)numericUpDown3.Value);
                conn.Open();
                srvPrice.Load(cmd.ExecuteReader());
                //Выборка номера и количества услуг в договоре
                query = "select serviceid as ID,amountofservice as amount from orderdetails where orderid=@ordId";
                cmd=new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ordId", (int)numericUpDown3.Value);
                srvAmount.Load(cmd.ExecuteReader());
                conn.Close();
                //соединение двух таблиц по номеру услуги
                var srvFin = from table1 in srvPrice.AsEnumerable()
                             join table2 in srvAmount.AsEnumerable() on (int)table1["ID"] equals (int)table2["ID"] 
                             select new
                             {
                                 servId = (int)table1["ID"],    
                                 price = (double)table1["price"],
                                 days = (int)table1["lng"],
                                 amount = (int)table2["amount"]
                             };
                //переменная для суммы стоимости всех услуг
                double sum = 0;
                //переменная для даты выполнения договора
                DateTime fin = dateTimePicker1.Value;
                foreach (var item in srvFin)
                {
                    //суммирование стоимости
                    sum+=item.price*item.amount;
                    //добавление дней к текущей дате для получения даты выполнения
                    fin=fin.AddDays(item.days);
                }
                //обновление данных в таблице
                query = "update orders set dateofcomplete=@fin, price=@sum where id_order=@ordId";
                cmd = new MySqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@ordId", (int)numericUpDown3.Value);
                cmd.Parameters.AddWithValue("@fin", fin);
                cmd.Parameters.AddWithValue("@sum", sum);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Данные успешно обновлены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" +Environment.NewLine+ ex.Message);
                return;
            }
            
            
        }

        private void delOrd_Click(object sender, EventArgs e)
        {
            //Предупреждение о возможной потере данных
            if (MessageBox.Show("При удалении договора,\n" +
               "будут так же удалены связанные с ним подробности", "Удаление",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    //вызов хранимой процедуры
                    query = "call ordDel(@ordId)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ordId", (int)numericUpDown3.Value);
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

        private void delOrdDet_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("При удалении  подробностей договора,\n" +
               "обновите связанный с ними договор для актуализации информации.", "Удаление",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    query = "delete from orderdetails where orderid=@ordId and objectid=@objId and serviceid=@servId";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ordId", (int)numericUpDown4.Value);
                    cmd.Parameters.AddWithValue("@objId",
                    obj.First(kv => kv.Value == objDD.SelectedItem.ToString()).Key);
                    cmd.Parameters.AddWithValue("@servId",
                        serv.First(kv => kv.Value == servDD.SelectedItem.ToString()).Key);
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

        private void selectOrdDet_Click(object sender, EventArgs e)
        {
            ordDetlLoad();
            query = "select orderid as номер_договора,objectid as номер_объекта,serviceid as номер_услуги," +
                "amountofservice as количество_услуг from orderdetails";
            cmd=new MySqlCommand(query, conn);
            dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());            
            dataGridView4.DataSource = dt;
            conn.Close();
            objDD.DataSource=obj.Select(kv=>kv.Value).ToList();
            servDD.DataSource=serv.Select(kv => kv.Value).ToList();
        }

        

    }
}
