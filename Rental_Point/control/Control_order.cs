using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

using Word = Microsoft.Office.Interop.Word;

namespace Rental_Point
{
    public partial class Control_order : UserControl
    {
        public Control_order()
        {
            InitializeComponent();
        }
        public static DataTable client;
        public static DataTable servis_order;
        private void Control_order_Load(object sender, EventArgs e)
        {
            Program.Control_order = this;
            data();
        }

        async void data()
        {
            button8.Enabled = false;
            DataTable id_order = SQL.table("Select max(id) as 'max'  FROM [Order]").Tables[0];
            numericUpDown1.Value = Convert.ToInt32(id_order.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[0]) +1;
            client = SQL.table("Select id , (surname +' ' +name + ' '+ patronymic ) as 'ФИО',  address from Customers").Tables[0];
            comboBox2.DataSource = client.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray(); ;
            servis_order = SQL.table("Select * from Services").Tables[0];
            comboBox1.DataSource = servis_order.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
        } 
        bool tr_code = false;
        private void button4_Click(object sender, EventArgs e)
        {
            tr_code = true;
        }
        public int order_code = -1;
        public DateTime order_barcode_date = DateTime.Now;
        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable id_order = SQL.table($"Select id as 'max'  FROM [Order] where id = {Convert.ToInt32(numericUpDown1.Value)}").Tables[0];
                if(id_order.Rows.Count != 0)
                {
                    MessageBox.Show("Номер заказа занят");
                    return;
                }
                tr_code = true;
                label1.Text = "Номер заказа потдвержден";
                label1.ForeColor = Color.Green;
                order_code = Convert.ToInt32(numericUpDown1.Value);
                numericUpDown1.Enabled = false;
                try
                {
                    order_barcode_date = DateTime.Now;
                    Random rnd = new Random();
                    string Encode_txt = Convert.ToInt32(numericUpDown1.Value).ToString() + order_barcode_date.ToString().Replace(".","").Replace(" ", "").Replace(":", "")+ rnd.Next(1000,9999);
                    BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                    pictureBox1.Image = writer.Write(Encode_txt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            button8.Enabled = false;
            tr_code = false;
            numericUpDown1.Enabled = true;
            label1.Text = "Номер заказа не потдвержден";
            label1.ForeColor = Color.Red;
        }

        private async void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = comboBox1.GetItemText(comboBox1.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip1.Show(text, comboBox1, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(comboBox1);
        }
        int order_sym = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            order_sym = order_sym + Convert.ToInt32(servis_order.Rows.OfType<DataRow>().Select(k => k[3].ToString()).ToArray()[comboBox1.SelectedIndex]);
            dataGridView1.Rows.Add(servis_order.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox1.SelectedIndex],  servis_order.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray()[comboBox1.SelectedIndex], servis_order.Rows.OfType<DataRow>().Select(k => k[3].ToString()).ToArray()[comboBox1.SelectedIndex]);
            label7.Text = (order_sym * Convert.ToInt32(numericUpDown2.Value)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >0)
            {
            
                int a = dataGridView1.CurrentRow.Index;
                order_sym = (order_sym - (Convert.ToInt32(dataGridView1[2, a].Value)));
                label7.Text = (order_sym * Convert.ToInt32(numericUpDown2.Value)).ToString();
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
            }
       
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label7.Text= (order_sym *  Convert.ToInt32(numericUpDown2.Value)).ToString();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
       

            if (e.KeyCode == Keys.Delete)
            {
               
                if (dataGridView1.Rows.Count > 0)
                {
                    int a = dataGridView1.CurrentRow.Index;
                    order_sym = (order_sym - (Convert.ToInt32(dataGridView1[2, a].Value)));
                    label7.Text = (order_sym * Convert.ToInt32(numericUpDown2.Value)).ToString();

                    dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                }
            }
        }
        string startupPath = Environment.CurrentDirectory;

        private void button7_Click(object sender, EventArgs e)
        {
          
            if (tr_code == true)
            {
                DataTable id_order = SQL.table($"Select id as 'max'  FROM [Order] where id = {Convert.ToInt32(numericUpDown1.Value)}").Tables[0];
                if (id_order.Rows.Count != 0)
                {
                    MessageBox.Show("Номер заказа занят");
                    return;
                }
                if (dataGridView1.Rows.Count <=0)
                {
                    MessageBox.Show("Нет услуг");
                    return;
                }
                SQL.Zapros($@"INSERT INTO [dbo].[Order]([id],[datetime],[client],[staus],[rental_time]) VALUES
                ('{Convert.ToInt32(numericUpDown1.Value)}','{order_barcode_date.ToString("yyyy-MM-dd HH:mm:ss")}', '{client.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox2.SelectedIndex]}','{1}','{Convert.ToInt32(numericUpDown2.Value)}:00:00');");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SQL.Zapros($@"INSERT INTO [dbo].[Order_items]([id_order],[id_services]) VALUES
                    ('{Convert.ToInt32(numericUpDown1.Value)}','{dataGridView1[0,i].Value.ToString()}');");

                }
    
                pictureBox1.Image.Save(startupPath + $@"\Barcode_pdf\Заказ {Convert.ToInt32(numericUpDown1.Value)}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg); ;
                MessageBox.Show("Заказ оформлен");
                button8.Enabled = true;
                Word.Document doc = null;
                try
                {
                    Word.Application app = new Word.Application();
                    string source = startupPath + @"\standart.docx";
                    doc = app.Documents.Open(source);
                    doc.Activate();
                    doc.SaveAs2(startupPath + @"\standart2.docx");

                    doc.Close();
                    doc = null;
                }
                catch
                {
                    doc = null;
                    return;
                }
                try
                {
                    Word.Application app = new Word.Application();
                    // Путь до шаблона документа
                    //string source = startupPath + @"\standart.docx.docx";
                    string source = startupPath + @"\standart2.docx";
                    // Открываем
                    doc = app.Documents.Open(source);
                    doc.Activate();
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    int i = 0;
                    string[] data = new string[6] { Convert.ToInt32(numericUpDown1.Value).ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), client.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox2.SelectedIndex].ToString(), comboBox2.Text, client.Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray()[comboBox2.SelectedIndex].ToString(), $"{Convert.ToInt32(numericUpDown2.Value)}:00:00" };
                    foreach (Word.Bookmark mark in wBookmarks)
                    {

                        wRange = mark.Range;
                        wRange.Text = data[i];
                        var d = wRange.InlineShapes;
                        i++;
                        if (i >= data.Length)
                        {
                            break;
                        }
                    }
                    pictureBox1.Image.Save(startupPath + @"\code.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    doc.Bookmarks.get_Item("s7").Range.InlineShapes.AddPicture(startupPath + @"\code.jpg");


                    //  



                    Word.Range range = app.Selection.Range;
                    Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                    Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;
                    System.Data.DataTable dataTable = null;
                    dataGridView1.DataSource = dataTable;

                    int columns = dataGridView1.Columns.Count - 1;
                    int rows = dataGridView1.Rows.Count;
                    doc.Bookmarks.get_Item("s6").Range.Tables.Add(doc.Bookmarks.get_Item("s6").Range, rows + 2, columns, ref behiavor, ref autoFitBehiavor);
                    doc.Tables[1].Cell(1, 1).Range.Text = dataGridView1.Columns[1].HeaderText.ToString();
                    doc.Tables[1].Cell(1, 2).Range.Text = dataGridView1.Columns[2].HeaderText.ToString();
                    for (int j = 0; j < rows; j++)
                    {
                        if (dataGridView1[0, j].Value != null)
                        {
                            doc.Tables[1].Cell(j + 2, 1).Range.Text = dataGridView1[1, j].Value.ToString();
                        }
                        if (dataGridView1[1, j].Value != null)
                        {
                            doc.Tables[1].Cell(j + 2, 2).Range.Text = dataGridView1[2, j].Value.ToString();
                        }

                    }

                    doc.Tables[1].Cell(rows + 2, 1).Range.Text = "Итог:";
                    doc.Tables[1].Cell(rows + 2, 2).Range.Text = "" + label7.Text;


                    doc.SaveAs2(startupPath + @"\ww4.docx");
                    doc.SaveAs2(startupPath + $@"\Order_pdf\Заказ {Convert.ToInt32(numericUpDown1.Value)}.pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);

                    doc.Close();
                    doc = null;
               
                }
                catch (Exception ex)
                {

                    doc.Close();
                    doc = null;
                    MessageBox.Show("Во время выполнения произошла ошибка! \n" + ex);
                    Console.ReadLine();
                }
            }
            else
            {
                MessageBox.Show("Подтвердите код") ;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable id_order = SQL.table("Select max(id) as 'max'  FROM [Order]").Tables[0];
            numericUpDown1.Value = Convert.ToInt32(id_order.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[0]) + 1;
            dataGridView1.Rows.Clear();
            numericUpDown2.Value = 1;
            label7.Text = ""+0;
            pictureBox1.Image = null;
            button8.Enabled = false;
            tr_code = false;
            numericUpDown1.Enabled = true;
            label1.Text = "Номер заказа не потдвержден";
            label1.ForeColor = Color.Red;
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            Client_add client_Add = new Client_add();
            client_Add.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(startupPath + $@"\Order_pdf\Заказ {Convert.ToInt32(numericUpDown1.Value).ToString()}.pdf");
            }
            catch (Exception)
            {

                throw;
            }
         
          
        }

        public ComboBox dostyp_comboBox2
        {
            get { return comboBox2; }
            set { comboBox2 = value; }
        }
        public DataTable dostyp_DataTable_client
        {
            get { return client; }
            set { client = value; }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
