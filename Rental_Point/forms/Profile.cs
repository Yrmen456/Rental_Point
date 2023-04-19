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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            Program.profile = this;
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.profile =null;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            
        }

        private void Profile_Activated(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            //  MessageBox.Show("sadf");
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("Секретка");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не робит");
        }
    }
}
