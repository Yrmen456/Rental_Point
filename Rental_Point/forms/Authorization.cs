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
    public partial class Authorization : MyForm
    {
        string[] s = new string[] { null , null};
      
        public static bool time_up = false;
        public Authorization()
        {   
            InitializeComponent();
            int[] position_cards = new int[5];
            for (int i = 0; i < 5; i++)
            {
                position_cards[i] = i;
            }
            Random random = new Random();
            for (int i = position_cards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = position_cards[j];
                position_cards[j] = position_cards[i];
                position_cards[i] = temp;
                title.Text += temp;
                //Debug.Log("-" + temp);//|| _game.FindCar


            }
            Program.authorization = this;
        }
        int visible_password_click = 1;
        private void visible_password_Click(object sender, EventArgs e)
        {
            if (visible_password_click == 1)
            {
                visible_password.BackgroundImage = Properties.Resources.open;
                visible_password_click = 2;
                password_textbox.UseSystemPasswordChar = false;
            }
            else
            {
                password_textbox.UseSystemPasswordChar = true;
                visible_password_click = 1;
                visible_password.BackgroundImage = Properties.Resources.close;
            }

        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            time_num.Text = "";
            if (time_up == true)
            {
                login_up.Enabled = false;
                timer1.Enabled = true;
                timer1.Tick += timer1_Tick;
            }
            users = SQL.table("Select login, password from Employees ").Tables[0];
            dataGridView1.DataSource = users;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.ScrollBars = ScrollBars.Vertical;
          
        }


        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            form_authorization.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
        public static int proverka = 0;

        DataTable users;
        private void login_up_Click(object sender, EventArgs e)
        {
            if (proverka != 0)
            {

                Captcha captcha = new Captcha();
                captcha.ShowDialog();
            }
            if (proverka != 0)
            {
                return;
            }
            if (SQL.zapros2($"Select * from Employees where login = '{login_textbox.Text}' and password = '{password_textbox.Text}'") == "1")
            {

                DataTable user = SQL.table($@"Select * from Employees, post where Employees.id_post = Post.id and login = '{login_textbox.Text}' and password = '{password_textbox.Text}' ").Tables[0];
                var stringArr = user.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
                string id_user = stringArr[0];
                string id_role = stringArr[6];
                MessageBox.Show($"Добро пожаловать ({stringArr[9]})\n {stringArr[1]} {stringArr[2][0].ToString().ToUpper()}. {stringArr[3][0].ToString().ToUpper()}.");
                SQL.Zapros($@"Insert Logins_system(id_employees,date_time,id_input_type) values ('{id_user}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','1')");
                myApplicationContext.Open(new Main(id_user, id_role));
                this.Close();
            }
            else
            {
                if (SQL.zapros2($"Select * from Employees where login = '{login_textbox.Text}'") == "1")
                {
                    DataTable user = SQL.table($@"Select * from Employees, post where Employees.id_post = Post.id and login = '{login_textbox.Text}'" ).Tables[0];
                    var stringArr = user.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                    Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
                    string id_user = stringArr[0];
                    SQL.Zapros($@"Insert Logins_system(id_employees,date_time,id_input_type) values ('{id_user}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','2')");
                }
                proverka = proverka + 1;
                MessageBox.Show("Неверный Логин или Пароль");
            }
          
        }

        private void login_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_authorization_MouseDown(object sender, MouseEventArgs e)
        {
            form_authorization.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            title.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox_logo.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataTable Data_Table = users;
            if (e.RowIndex >= 0)
            {
                login_textbox.Text = Data_Table.Rows[e.RowIndex][0].ToString();
                password_textbox.Text = Data_Table.Rows[e.RowIndex][1].ToString();
            }
        }

        public int Dostyp_proverka
        {
            get { return proverka; }
            set { proverka = value; }
        }
        public static int time = 3000;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;

            int time_second = time / 10;
            int time_min = time_second / 60;
            int time_h = time_min / 60;

            time_num.Text = "" + time_h + ":" + (time_min % 60) + ":" + (time_second % 60) + "";
            if (time <= 0)
            {
                timer1.Stop();
                time = 3000;
                login_up.Enabled = true;
                time_num.Text = "";
                time_up = false;
            }
        }
        public bool Dostyp_time_up
        {
            get { return time_up; }
            set { time_up = value; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            //string json = JsonConvert.SerializeObject(users);
            //json = "{ \"array\": " + json + "}";
            //Users user = JsonConvert.DeserializeObject<Users>(json);
            //MessageBox.Show("" + user.array[0].UserPassword);

            //string json = JsonConvert.SerializeObject(UserTabel);
            //json = json.Trim('[', ']');
            //User user = JsonConvert.DeserializeObject<User>(json);
            //MessageBox.Show(user.UserLogin);
            //dataGridView1.DataSource = myTestCollection;
            //    class User
            //{
            //    public string UserLogin { get; set; }
            //    public string UserPassword { get; set; }

            //}

            //class Users
            //{
            //    public Users_Array[] array;
            //}

            //public class Users_Array
            //{
            //    public int Id;
            //    public string UserLogin;
            //    public string UserPassword;
            //}
        }

        private void form_authorization_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
