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
    public partial class Control_Logins_system : UserControl
    {

        public Control_Logins_system()
        {
            InitializeComponent();
  

        }
        private void Control_Logins_system_Load_1(object sender, EventArgs e)
        {
            Program.control_Logins_system = this;

            InitializeAsync($@"Select Logins_system.id,Logins_system.date_time as 'Дата/Время',CAST(Logins_system.date_time AS DATE) As 'Дата',
				CAST(Logins_system.date_time AS Time) As 'Время', Employees.id,Employees.surname as'Фамилия',
				Employees.name as'Имя',Employees.patronymic as'Отчетство',(Employees.surname +' '+
				Employees.name +' '+Employees.patronymic) as 'ФИО',Employees.login as'Логин',
				Employees.id_post, Post.name as'Должность',Status_system.id,Status_system.name as'Статус'           
				from Logins_system
                inner join Employees Employees on Employees.id = Logins_system.id_employees
                inner join Status_system Status_system on Status_system.id = Logins_system.id_input_type 
				inner join Post Post on Post.id = Employees.id_post where Logins_system.id  is not null ");
        }
 
        List<string> arr_name_columns = new List<string> { } ;
        List<string> DataTable_name_columns = new List<string> { };
        async void InitializeAsync(string sql)
        {
            Program.main.main_left_panel_dostyp.Controls["Logins_system"].Enabled = false;
            dataGridView1.Visible = false;
            dataGridView1.DataSource = null;
            pictureBox1.Visible = true;
                 arr_name_columns.Clear();
            // Asynchronously initialize this instance.
            DataTable dataTable = null;
            await Task.Run(() =>
            {
                dataTable = SQL.table(sql).Tables[0];
            });
            dataGridView1.DataSource = dataTable;

       
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (dataGridView1.Columns[i].Name.ToString().Contains("id") == true) 
                {
                    dataGridView1.Columns[i].Visible = false;
                }
                else
                {
                    if (i !=0)
                    {
                        arr_name_columns.Add(dataGridView1.Columns[i].Name.ToString());
                        DataTable_name_columns.Add(dataTable.Columns[i].ColumnName.ToString());
                    }
                  
                    


                }

            }
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[12].Value.ToString() == "1")
                    {

                        row.DefaultCellStyle.BackColor = Color.White;

                    }
                    else if (row.Cells[12].Value.ToString() == "2")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        
                    }

                 
                }
                catch
                {
                    // здесь можно отреагировать на неправильные данные, а можно ничего не делать
                }
            }
            await Task.Delay(1000);
     
            pictureBox1.Visible = false;
            Program.main.main_left_panel_dostyp.Controls["Logins_system"].Enabled = true;
            dataGridView1.Visible = true;

        }
   
        private void Control_Logins_system_Load(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string where = "";
            string where2 = "";
            if (radioButton.Tag.ToString() != "0")
            {
                where = $" and id_input_type = {radioButton.Tag.ToString()}";
            }
  
            if (radioButton.Checked)
            {
                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Clear();
                InitializeAsync($@"Select Logins_system.id,Logins_system.date_time as 'Дата/Время',CAST(Logins_system.date_time AS DATE) As 'Дата',
				CAST(Logins_system.date_time AS Time) As 'Время', Employees.id,Employees.surname as'Фамилия',
				Employees.name as'Имя',Employees.patronymic as'Отчетство',(Employees.surname +' '+
				Employees.name +' '+Employees.patronymic) as 'ФИО',Employees.login as'Логин',
				Employees.id_post, Post.name as'Должность',Status_system.id,Status_system.name as'Статус'           
				from Logins_system
                inner join Employees Employees on Employees.id = Logins_system.id_employees
                inner join Status_system Status_system on Status_system.id = Logins_system.id_input_type 
				inner join Post Post on Post.id = Employees.id_post where Logins_system.id  is not null  {where} {where_main}");

            }
        }
        bool list_rb = false;
        private  void button1_Click(object sender, EventArgs e)
        {
            if (arr_name_columns.Count == 0)
            {
                return ;
            }
            int CursorX = Cursor.Position.X;
            int CursorY = Cursor.Position.Y;
            Form_menu loginForm = new Form_menu();
            loginForm.StartPosition = FormStartPosition.CenterParent;
            Form_menu panel_menu = new Form_menu();
            RadioButton exit0 = new RadioButton();
            RadioButton exit1 = new RadioButton();
            RadioButton exit2 = new RadioButton();
            RadioButton exit3 = new RadioButton();
            RadioButton exit4 = new RadioButton();
            RadioButton exit5 = new RadioButton();
            RadioButton exit6 = new RadioButton();
            RadioButton exit7 = new RadioButton();
            RadioButton exit8 = new RadioButton();
            RadioButton exit9 = new RadioButton();
            object[] buttons = new object[] { exit0, exit1, exit2, exit3, exit4, exit5, exit6, exit7, exit8, exit9 };
            Form_menu.mydelegate2[] mydelegates = new Form_menu.mydelegate2[] { exit_Click, exit_Click, exit_Click, exit_Click, exit_Click, exit_Click, exit_Click, exit_Click, exit_Click, exit_Click };
            Point locationOnForm =
               button_rb.Parent.PointToScreen(button_rb.Location);
            string[,] arr = new string[arr_name_columns.Count,2];
            for (int i = 0; i < arr_name_columns.Count; i++)
            {
                arr[i,0]= DataTable_name_columns[i];
                arr[i,1] = arr_name_columns[i];
            }
            
            new Form_menu(locationOnForm.X, locationOnForm.Y, 200,buttons, mydelegates,arr_name_columns, arr).Show();
        }
        public static  DataTable tb_status = SQL.table("Select * from Status_system").Tables[0];
        public static DataTable tb_post = SQL.table("Select * from Post").Tables[0];
        public static string sort = "";
        public string where_main = "";
        public static void exit_Click(string pr1, string pr2)
        {
            Program.control_Logins_system.Dostyp_sortirovka = "нет";
            Program.control_Logins_system.Dostyp_DateTimePicker1.Visible = false;
            Program.control_Logins_system.Dostyp_DateTimePicker2.Visible = false;
            Program.control_Logins_system.Dostyp_comboBox_search.Visible = false;
            Program.control_Logins_system.Dostyp_textBox_search.Visible = false;
            Program.control_Logins_system.Dostyp_button.Text = "Параметр:" + pr2;
            if (pr1 == "Дата/Время")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Дата/Время";
                Program.control_Logins_system.Dostyp_DateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
                Program.control_Logins_system.Dostyp_DateTimePicker1.Format = DateTimePickerFormat.Custom;
                Program.control_Logins_system.Dostyp_DateTimePicker1.ShowUpDown = false;
                Program.control_Logins_system.Dostyp_DateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
                Program.control_Logins_system.Dostyp_DateTimePicker2.Format = DateTimePickerFormat.Custom;
                Program.control_Logins_system.Dostyp_DateTimePicker2.ShowUpDown = false;
                Program.control_Logins_system.Dostyp_DateTimePicker1.Visible = true;
                Program.control_Logins_system.Dostyp_DateTimePicker2.Visible = true;

            }
            else if(pr1 == "Дата")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Дата";
                Program.control_Logins_system.Dostyp_DateTimePicker1.CustomFormat = "yyyy-MM-dd";
                Program.control_Logins_system.Dostyp_DateTimePicker1.Format = DateTimePickerFormat.Custom;
                Program.control_Logins_system.Dostyp_DateTimePicker1.ShowUpDown = false;
                Program.control_Logins_system.Dostyp_DateTimePicker2.CustomFormat = "yyyy-MM-dd";
                Program.control_Logins_system.Dostyp_DateTimePicker2.Format = DateTimePickerFormat.Custom;
                Program.control_Logins_system.Dostyp_DateTimePicker2.ShowUpDown = false;
                Program.control_Logins_system.Dostyp_DateTimePicker1.Visible = true;
                Program.control_Logins_system.Dostyp_DateTimePicker2.Visible = true;
            }
            else
            if (pr1 == "Время")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Время";
                Program.control_Logins_system.Dostyp_DateTimePicker1.CustomFormat = "HH:mm";
                Program.control_Logins_system.Dostyp_DateTimePicker1.Format = DateTimePickerFormat.Custom;
                Program.control_Logins_system.Dostyp_DateTimePicker1.ShowUpDown = true;
                Program.control_Logins_system.Dostyp_DateTimePicker2.CustomFormat = "HH:mm";
                Program.control_Logins_system.Dostyp_DateTimePicker2.Format = DateTimePickerFormat.Custom;
                Program.control_Logins_system.Dostyp_DateTimePicker2.ShowUpDown = true;
                Program.control_Logins_system.Dostyp_DateTimePicker1.Visible = true;
                Program.control_Logins_system.Dostyp_DateTimePicker2.Visible = true;
            }
            else
            if (pr1 == "Фамилия")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Фамилия";
                Program.control_Logins_system.Dostyp_textBox_search.Visible = true;

            }
            else
            if (pr1 == "Имя")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Имя";
                Program.control_Logins_system.Dostyp_textBox_search.Visible = true;
            }
            else
            if (pr1 == "Отчетство")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Отчетство";
                Program.control_Logins_system.Dostyp_textBox_search.Visible = true;
            }
            else
            if (pr1 == "ФИО")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "ФИО";
                Program.control_Logins_system.Dostyp_textBox_search.Visible = true;
            }
            else
            if (pr1 == "Логин")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Логин";
                Program.control_Logins_system.Dostyp_textBox_search.Visible = true;
            }
            else
            if (pr1 == "Должность")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Должность";
                Program.control_Logins_system.Dostyp_comboBox_search.Visible = true;
                Program.control_Logins_system.Dostyp_comboBox_search.DataSource = Program.control_Logins_system.Dostyp_tb_post.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            }
            else
            if (pr1 == "Статус")
            {
                Program.control_Logins_system.Dostyp_sortirovka = "Статус";
                Program.control_Logins_system.Dostyp_comboBox_search.Visible = true;
           
                Program.control_Logins_system.Dostyp_comboBox_search.DataSource = Program.control_Logins_system.Dostyp_tb_status.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            }
            
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        public static void exit2_Click(string pr1, string pr2)
        {
            string where = "";

            Program.control_Logins_system.InitializeAsync($@"Select Logins_system.id,Logins_system.date_time as 'Дата попытки',CAST(Logins_system.date_time AS DATE) As 'Дата',
				CAST(Logins_system.date_time AS Time) As 'Время', Employees.id,Employees.surname as'Фамилия',
				Employees.name as'Имя',Employees.patronymic as'Отчетство',(Employees.surname +' '+
				Employees.name +' '+Employees.patronymic) as 'ФИО',Employees.login as'Логин',
				Employees.id_post, Post.name as'Должность',Status_system.id,Status_system.name as'Статус'           
				from Logins_system
                inner join Employees Employees on Employees.id = Logins_system.id_employees
                inner join Status_system Status_system on Status_system.id = Logins_system.id_input_type 
				inner join Post Post on Post.id = Employees.id_post where Logins_system.id  is not null  {where}");
 
            //Program.main.Dostyp_Panel_Controler.Controls[0].
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string where = "";
            string where2 = "";
            where_main = "";
            if (radioButton1.Checked == true )
            {
                where = $" and id_input_type = {radioButton1.Tag.ToString()}";

            }
            if (radioButton2.Checked == true)
            {
                where = $" and id_input_type = {radioButton2.Tag.ToString()}";
            }
            if (radioButton3.Checked == true)
            {
                where = $" ";
            }
            if (Program.control_Logins_system.Dostyp_sortirovka == "Дата/Время")
            {
                where_main = $@" and 
				Logins_system.date_time >= '{dateTimePicker_search1.Text}' and  Logins_system.date_time <= '{dateTimePicker_search2.Text}' ";
   
            }
            else if (Program.control_Logins_system.Dostyp_sortirovka == "Дата")
            {
                where_main = $@" and 
				CAST(Logins_system.date_time AS DATE) >= '{dateTimePicker_search1.Text}' and CAST(Logins_system.date_time AS DATE) <= '{dateTimePicker_search2.Text}' ";
            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Время")
            {
                where_main = $@" and 
				CAST(Logins_system.date_time AS Time)  >= '{dateTimePicker_search1.Text}' and  CAST(Logins_system.date_time AS Time) <= '{dateTimePicker_search2.Text}' ";


            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Фамилия")
            {
                where_main = $@"and 
                Employees.surname Like N'%{textBox_search.Text}%' ";

            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Имя")
            {
                where_main = $@"and 
                Employees.name Like N'%{textBox_search.Text}%' ";
            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Отчетство")
            {
                where_main = $@"and 
                Employees.patronymic Like N'%{textBox_search.Text}%' ";
            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "ФИО")
            {
                where_main = $@"and 
                (Employees.surname + ' ' + Employees.name + ' ' + Employees.patronymic) Like N'%{textBox_search.Text}%' ";
   
               
            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Логин")
            {
                where_main = $@"and 
                Employees.login Like N'%{textBox_search.Text}%' ";

            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Должность")
            {

            }
            else
            if (Program.control_Logins_system.Dostyp_sortirovka == "Статус")
            {

            }
            InitializeAsync($@"Select Logins_system.id,Logins_system.date_time as 'Дата попытки',CAST(Logins_system.date_time AS DATE) As 'Дата',
				CAST(Logins_system.date_time AS Time) As 'Время', Employees.id,Employees.surname as'Фамилия',
				Employees.name as'Имя',Employees.patronymic as'Отчетство',(Employees.surname +' '+
				Employees.name +' '+Employees.patronymic) as 'ФИО',Employees.login as'Логин',
				Employees.id_post, Post.name as'Должность',Status_system.id,Status_system.name as'Статус'           
				from Logins_system
                inner join Employees Employees on Employees.id = Logins_system.id_employees
                inner join Status_system Status_system on Status_system.id = Logins_system.id_input_type 
				inner join Post Post on Post.id = Employees.id_post where Logins_system.id  is not null  {where} {where_main}");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button_rb.Text = "Параметры:";

            dateTimePicker_search1.Visible = false;
            dateTimePicker_search2.Visible = false;
            comboBox_search.Visible = false;

            textBox_search.Visible = true;
            textBox_search.Text = "";
            string where = "";
            string where2 = "";
            where_main = "";
            if (radioButton1.Checked == true)
            {
                where = $" and id_input_type = {radioButton1.Tag.ToString()}";

            }
            if (radioButton2.Checked == true)
            {
                where = $" and id_input_type = {radioButton2.Tag.ToString()}";
            }
            if (radioButton3.Checked == true)
            {
                where = $"";
            }
            where_main = "";
            InitializeAsync($@"Select Logins_system.id,Logins_system.date_time as 'Дата попытки',CAST(Logins_system.date_time AS DATE) As 'Дата',
				CAST(Logins_system.date_time AS Time) As 'Время', Employees.id,Employees.surname as'Фамилия',
				Employees.name as'Имя',Employees.patronymic as'Отчетство',(Employees.surname +' '+
				Employees.name +' '+Employees.patronymic) as 'ФИО',Employees.login as'Логин',
				Employees.id_post, Post.name as'Должность',Status_system.id,Status_system.name as'Статус'           
				from Logins_system
                inner join Employees Employees on Employees.id = Logins_system.id_employees
                inner join Status_system Status_system on Status_system.id = Logins_system.id_input_type 
				inner join Post Post on Post.id = Employees.id_post where Logins_system.id  is not null  {where} {where_main}");
        }
        private  void Control_Logins_system_Click(object sender, EventArgs e)
        {

            MessageBox.Show("d");
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void control_rb1_Load(object sender, EventArgs e)
        {

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public DataGridView Dostyp_datagrid
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
        public Panel Dostyp_Panel1_Controler
        {
            get { return panel_datagrid; }
            set { panel_datagrid = value; }
        }
        public Button Dostyp_button
        {
            get { return button_rb; }
            set { button_rb = value; }
        }
        public DateTimePicker Dostyp_DateTimePicker1
        {
            get { return dateTimePicker_search1; }
            set { dateTimePicker_search1 = value; }
        }
        public DateTimePicker Dostyp_DateTimePicker2
        {
            get { return dateTimePicker_search2; }
            set { dateTimePicker_search2 = value; }
        }
        public TextBox Dostyp_textBox_search
        {
            get { return textBox_search; }
            set { textBox_search = value; }
        }
        public ComboBox Dostyp_comboBox_search
        {
            get { return comboBox_search; }
            set { comboBox_search = value; }
        }
        public DataTable Dostyp_tb_status
        {
            get { return tb_status; }
            set { tb_status = value; }
        }        
        public DataTable Dostyp_tb_post
        {
            get { return tb_post; }
            set { tb_post = value; }
        }        
        public string Dostyp_sortirovka
        {
            get { return sort; }
            set { sort = value; }
        }

   
    }
}
