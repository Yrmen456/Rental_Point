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
    public partial class Form_menu : Form
    {
        public Form_menu()
        {
            InitializeComponent();
            Program.form_menu = this;       
        }
        public delegate void mydelegate();
        public delegate void mydelegate2(string pr1, string pr2 );
        public Form_menu(int CursorX, int CursorY, int width , object[] buttons, mydelegate[] buttons_click, List<string> arr_name_columns)
        : this()
        {
            
            int Height = 0;
            for (int i = 0; i < buttons_click.Length; i++)
            {
                if (buttons[i].GetType()== typeof(Button))
                {
                    Button button = new Button();
                    button.Name = $"Button_panel{i}";
                    button.Text = $"{arr_name_columns[i]}";
                    int newSize = 10;
                    button.Height = 30;
                    Height = Height + 30;
                    button.Font = new Font(button.Font.FontFamily, newSize);
                    button.BackColor = Color.LightGray;
                    button.Dock = DockStyle.Top;
                    int d = i;
                    button.Click += (sender, args) => buttons_click[d](); ;
                    button.Tag = i;
                    button.Left = 100;
                    //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                    panel1.SuspendLayout();
                    panel1.Controls.Add(button);
                    //перемещаем последний добавленный элемент в начало списка контролов
                    panel1.Controls.SetChildIndex(button, 0);
                    //"размораживаем" панель
                    panel1.ResumeLayout();
                }
                if (buttons[i].GetType() == typeof(RadioButton))
                {
                    RadioButton button = new RadioButton();
                    button.Name = $"Button_panel{i}";
                    button.Text = $"{arr_name_columns[i]}";
                    int newSize = 10;
                    button.Height = 30;
                    Height = Height + 30;
                    button.Font = new Font(button.Font.FontFamily, newSize);
                    button.BackColor = Color.LightGray;
                    button.Dock = DockStyle.Top;
                    int d = i;
                    button.Click += (sender, args) => buttons_click[d](); ;
                    button.Tag = i;
                    button.Left = 100;
                    //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                    panel1.SuspendLayout();
                    panel1.Controls.Add(button);
                    //перемещаем последний добавленный элемент в начало списка контролов
                    panel1.Controls.SetChildIndex(button, 0);
                    //"размораживаем" панель
                    panel1.ResumeLayout();
                }


            }
            this.Width = width;
            this.Height = 0;
            InitializeAsyncP(Height + 7);
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Location = new Point(CursorX, CursorY);

        }
        public Form_menu(int CursorX, int CursorY, int width, object[] buttons, mydelegate2[] buttons_click, List<string> arr_name_columns,string[,] param)
        : this()
        {

            int Height = 0;
            for (int i = 0; i < buttons_click.Length; i++)
            {
                if (buttons[i].GetType() == typeof(Button))
                {
                    Button button = new Button();
                    button.Name = $"Button_panel{i}";
                    button.Text = $"{arr_name_columns[i]}";
                    int newSize = 10;
                    button.Height = 30;
                    Height = Height + 30;
                    button.Font = new Font(button.Font.FontFamily, newSize);
                    button.BackColor = Color.LightGray;
                    button.Dock = DockStyle.Top;
                    int d = i;
                    button.Click += (sender, args) => buttons_click[d](param[0,i], param[1,i]); ;
                    //button.Click += (sender, args) =>  Program.profile.Focus() ; ;
                    button.Tag = i;
                    button.Left = 100;
                    //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                    panel1.SuspendLayout();
                    panel1.Controls.Add(button);
                    //перемещаем последний добавленный элемент в начало списка контролов
                    panel1.Controls.SetChildIndex(button, 0);
                    //"размораживаем" панель
                    panel1.ResumeLayout();
                }
                if (buttons[i].GetType() == typeof(RadioButton))
                {
                    RadioButton button = new RadioButton();
                    button.Name = $"Button_panel{i}";
                    button.Text = $"{arr_name_columns[i]}";
                    int newSize = 10;
                    button.Height = 30;
                    Height = Height + 30;
                    button.Font = new Font(button.Font.FontFamily, newSize);
                    button.BackColor = Color.LightGray;
                    button.Dock = DockStyle.Top;
                    int d = i;
                    button.Click += (sender, args) => buttons_click[d](param[d, 0], param[d, 1]); ;
                    button.Tag = i;
                    button.Left = 100;
                    //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                    panel1.SuspendLayout();
                    panel1.Controls.Add(button);
                    //перемещаем последний добавленный элемент в начало списка контролов
                    panel1.Controls.SetChildIndex(button, 0);
                    //"размораживаем" панель
                    panel1.ResumeLayout();
                }


            }
            this.Width = width;
            this.Height = 0;
            InitializeAsyncP(Height + 7);
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Location = new Point(CursorX, CursorY);

        }
        async void InitializeAsyncP(int height)
        {
            while(this.Height < height)
            {
                this.Height = this.Height + 5;
                await Task.Delay(1);
            }
           
        }
    
        private void Form_menu_Deactivate(object sender, EventArgs e)
        {

            this.Close();
     
        }

        private void textBox_MouseHover(object sender, EventArgs e)
        {
            TextBox cb = (TextBox)sender;
            cb.BackColor = System.Drawing.ColorTranslator.FromHtml("#AFAFAF");
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox cb = (TextBox)sender;
            cb.BackColor = Color.Gainsboro;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
            myApplicationContext.Open(new Authorization());
            Program.main.Close();
        
  
           
        }

        private void Form_menu_Load(object sender, EventArgs e)
        {

        }

        private void Form_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }

        private void Form_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
    
}
