using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Rental_Point
{
    public partial class Control_orders : UserControl
    {
        public Control_orders()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        DataTable table_order;
        private void Control_orders_Load(object sender, EventArgs e)
        {
            table_order = SQL.table(@"Select Order1.id as 'Код', Order1.datetime as 'Дата', (Customers.surname +' ' +Customers.name + ' '+ Customers.patronymic ) as 'ФИО',
            Order_status.name as 'Статус', rental_time as 'Продолжительность' , date_close as 'Дата закрытия'
            from  [Order] Order1
            Inner Join Customers Customers on Customers.id = Order1.client
            Inner Join Order_status Order_status on Order_status.id = Order1.staus").Tables[0];
            dataGridView1.DataSource = table_order;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string link = "" + AppDomain.CurrentDomain.BaseDirectory;
 
            dialog.InitialDirectory = link + @"Barcode_pdf\";

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                BarcodeReader reader = new BarcodeReader();
                Bitmap bitmap = new Bitmap(dialog.FileName);
                var result_decode = reader.Decode(bitmap);
                if (result_decode != null)
                {
                    string str = result_decode.Text;
                    str = str.Remove(str.Length - 18);
             
                    table_order = SQL.table($@"Select Order1.id as 'Код', Order1.datetime as 'Дата', (Customers.surname +' ' +Customers.name + ' '+ Customers.patronymic ) as 'ФИО',
                Order_status.name as 'Статус', rental_time as 'Продолжительность' , date_close as 'Дата закрытия'
                from  [Order] Order1
                Inner Join Customers Customers on Customers.id = Order1.client
                Inner Join Order_status Order_status on Order_status.id = Order1.staus where Order1.id  = {str}").Tables[0];
                    dataGridView1.DataSource = table_order;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
        }
        string startupPath = Environment.CurrentDirectory;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(startupPath + $@"\Order_pdf\Заказ {dataGridView1[0, e.RowIndex].Value.ToString()}.pdf");
                }
                catch (Exception)
                {

               
                }
            }
           
        }
    }
}
