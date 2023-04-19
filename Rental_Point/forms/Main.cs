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
    public partial class Main : MyForm
    {
        string id_role = "1";
        string id_user = "1";
        string[,] rol = new string[,] { { "1","Order_add"},{ "1","Customers"},{ "2", "Logins_system" }, { "3", "Employees" },
        {"3","Order_add"},{"3","Order"},{"3","Charts"},{"2","Order"},{"1","Order"},{ "3","Customers"},{ "1", "Services" }, { "3", "Services" },{ "2", "Logins_system" }, { "3", "Employees" }
        };
        DataTable user;

        public Main(string id_user, string id_role)
        {
            InitializeComponent();

            this.id_role = id_role;
            this.id_user = id_user;
            Program.main = this;

        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Color color = System.Drawing.ColorTranslator.FromHtml("#D2D2D2");
            Pen p = new Pen(color, 1);// цвет линии и ширина
            Point p1 = new Point(-2, 0);// первая точка
            Point p2 = new Point(this.Width + 2, 0);// вторая точка
            gr.DrawLine(p, p1, p2);// рисуем линию
            gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
        }
        private void title_left_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Color color = System.Drawing.ColorTranslator.FromHtml("#7F7F7F");
            Pen p = new Pen(color, 1);// цвет линии и ширина
            Point p1 = new Point(-2, 28);// первая точка
            Point p2 = new Point(this.Width + 2, 28);// вторая точка
            gr.DrawLine(p, p1, p2);// рисуем линию
            gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой



        }



        private void Main_Load(object sender, EventArgs e)
        {
            time = 6000;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            for (int i = 0; i < rol.GetLength(0); i++)
            {
                if (id_role == rol[i, 0])
                {



                    main_left_panel.Controls[rol[i, 1]].Visible = true;

                }
            }
            user = SQL.table($@"Select * from Employees, post where Employees.id_post = Post.id and Employees.id = {id_user} ").Tables[0];
            var stringArr = user.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            user_label.Text = $"{stringArr[1]} {stringArr[2][0].ToString().ToUpper()}. {stringArr[3][0].ToString().ToUpper()}.";
            Panel_Controler.Controls.Clear();
            Control_main control_main = new Control_main();
            control_main.Name = "abonent_CRM_control";

            control_main.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_main);
            try
            {
                   pictureBox2.BackgroundImage =  Image.FromFile("Employees\\" + stringArr[7]);
            }
            catch
            {
                pictureBox2.BackgroundImage =  Image.FromFile("Employees\\" + stringArr[7]);
            }
          
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void login_out_Click(object sender, EventArgs e)
        {
            Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
            myApplicationContext.Open(new Authorization());
            this.Close();
        }


        public delegate void mydelegate();
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                int CursorX = Cursor.Position.X;
                int CursorY = Cursor.Position.Y;
                Form_menu loginForm = new Form_menu();
                loginForm.StartPosition = FormStartPosition.CenterParent;
                Form_menu panel_menu = new Form_menu();
                Button exit = new Button();
                exit.Text = "exit";
                Button exit2 = new Button();

                object[] buttons = new object[] { exit, exit2 };
                object[] buttons_name = new object[] { "exit_Click", "exit2_Click" };
                Form_menu.mydelegate[] mydelegates = new Form_menu.mydelegate[] { exit_Click, exit2_Click };
                Form form = this;
                List<string> arr_name_columns = new List<string> {"Выход","Профиль" };
                new Form_menu(CursorX- 200, CursorY+10, 200, buttons,mydelegates, arr_name_columns ).Show();



            }
        }

        private void Logins_system_Click(object sender, EventArgs e)
        {
            Panel_Controler.Controls.Clear();
            Control_Logins_system control_main = new Control_Logins_system();
            control_main.Name = "abonent_CRM_control";

            control_main.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_main);
        }
        private void main_button_Click(object sender, EventArgs e)
        {
            Panel_Controler.Controls.Clear();
            Control_main control_main = new Control_main();
            control_main.Name = "abonent_CRM_control";

            control_main.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_main);
        }
        private void Order_Click(object sender, EventArgs e)
        {
            Panel_Controler.Controls.Clear();
            Control_order control_order = new Control_order();
            control_order.Name = "abonent_CRM_control";

            control_order.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_order);
        }
        private void Order_Click_1(object sender, EventArgs e)
        {
            Panel_Controler.Controls.Clear();
            Control_orders control_orders = new Control_orders();
            control_orders.Name = "abonent_CRM_control";

            control_orders.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_orders);
        }
        private void Customers_Click(object sender, EventArgs e)
        {
            Panel_Controler.Controls.Clear();
            Control_clients control_clients = new Control_clients();
            control_clients.Name = "abonent_CRM_control";

            control_clients.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_clients);
        }
        private void Employees_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Юра наговнокодил");
        }

        private void Services_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не трогай меня");
        }
        private void Charts_Click(object sender, EventArgs e)
        {
            Panel_Controler.Controls.Clear();
            Control_charts control_charts = new Control_charts();
            control_charts.Name = "abonent_CRM_control";

            control_charts.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(control_charts);
        }
        public Panel main_left_panel_dostyp
        {
            get { return main_left_panel; }
            set { main_left_panel = value; }
        }

        public static void exit_Click()
        {
            Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
            myApplicationContext.Open(new Authorization());
            //Authorization authorization = new Authorization();
            //authorization.Show();
            Program.main.Close();
            if (Program.profile != null)
            {
                Program.profile.Close();
            }

        }
        public  static void exit2_Click()
        {
     
            if (Program.profile == null)
            {
                Program.form_menu.Close();
                Profile form1 = new Profile();
                Program.profile.Show();
                Program.profile.Focus();
            }
            else
            {
                Program.form_menu.Close();
                Program.profile.Focus();
           
            }
        
  
        }
       
        public Panel Dostyp_Panel_Controler
        {
            get { return Panel_Controler; }
            set { Panel_Controler = value; }
        }
        public static int time = 6000;

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
     
            int time_second = time / 10;
            int time_min = time_second / 60;
            int time_h = time_min / 60;
           
            time_num.Text = ""+ time_h+":"+(time_min % 60)+ ":" + (time_second % 60)+ "";
            if (time == 3000)
            {
                MessageBox.Show("Осталось 5 минут");
            }

                if (time <= 0)
            {
                timer1.Stop();
                Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
                Authorization authorization = new Authorization();
                authorization.Dostyp_time_up = true;
                myApplicationContext.Open(authorization);
           
                if (Program.main != null)
                {
                    Program.main.Close();

                }
                time = 6000;
            }
        }


    }
}
