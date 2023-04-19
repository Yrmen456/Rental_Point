using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Point
{
    public partial class Client_add : MyForm
    {
        public Client_add()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrWhiteSpace(textBoxName.Text)
              || String.IsNullOrWhiteSpace(textBoxSurname.Text)
              || String.IsNullOrWhiteSpace(textBoxPatronymic.Text)
              || String.IsNullOrWhiteSpace(textBoxAdress.Text)
              || String.IsNullOrWhiteSpace(textBoxSeriesPassport.Text)
              || String.IsNullOrWhiteSpace(textBoxNumberPassport.Text)
              || String.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            SQL.Zapros($@"Insert Customers(surname,name,patronymic,series,nomer,birthday,address,email) 
            values(N'{textBoxSurname.Text}',N'{textBoxName.Text}',N'{textBoxPatronymic.Text}',N'{textBoxSeriesPassport.Text}',N'{textBoxNumberPassport.Text}','{dateTimePickerDateOfBirth.Value.ToString("yyyy-MM-dd")}',N'{textBoxAdress.Text}',N'{textBoxEmail.Text}')");
            Program.Control_order.dostyp_DataTable_client = SQL.table("Select id , (surname +' ' +name + ' '+ patronymic ) as 'ФИО',  address from Customers").Tables[0];
            Program.Control_order.dostyp_comboBox2.DataSource = Program.Control_order.dostyp_DataTable_client.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            Program.Control_order.dostyp_comboBox2.SelectedIndex = Program.Control_order.dostyp_comboBox2.Items.Count - 1;

        }
        private void textBoxNumberPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Client_add_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Color color = System.Drawing.ColorTranslator.FromHtml("#D2D2D2");
            Pen p = new Pen(color, 1);// цвет линии и ширина
            Point p1 = new Point(-2, 0);// первая точка
            Point p2 = new Point(this.Width + 2, 0);// вторая точка
            gr.DrawLine(p, p1, p2);// рисуем линию
            gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
        }
    }
}
