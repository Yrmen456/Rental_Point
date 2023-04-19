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

using Word = Microsoft.Office.Interop.Word;


namespace Rental_Point
{
    public partial class Control_clients : UserControl
    {
        public Control_clients()
        {
            InitializeComponent();
        }
        DataTable table_client;
        private void Control_clients_Load(object sender, EventArgs e)
        {
            table_client = SQL.table(@"Select 
            id as 'Код',  (surname +' ' +name + ' '+ patronymic ) as 'ФИО', (series +' '+ nomer)AS 'Серия/Номер', birthday as 'Дата рождения', address as 'Адресс', email as 'Почта'  
            from Customers
            ").Tables[0];
            dataGridView1.DataSource = table_client;
        }
    }
}
