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
    public partial class Control_main : UserControl
    {
        public Control_main()
        {
            InitializeComponent();

        }

        async void InitializeAsync()
        {
          
            //Program.main.main_left_panel_dostyp.Controls["main_button"].Enabled = false;

            //panel1.Visible = true;
            dataGridView1.DataSource = null;
            //pictureBox1.Visible = true;
            // Asynchronously initialize this instance.
            DataTable dataTable = null;
            await Task.Run(() =>
            {

            });

            //await Task.Delay(1000);
            panel1.Visible = false;
            pictureBox1.Visible = false;
            //Program.main.main_left_panel_dostyp.Controls["main_button"].Enabled = true;
        }

        private void Control_main_Load(object sender, EventArgs e)
        {
            InitializeAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("rfg");
        }
    }
}
