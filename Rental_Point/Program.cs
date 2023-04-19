using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Point
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static Authorization authorization;
        public static Main main;
        public static Control_Logins_system control_Logins_system;
        public static Profile profile;
        public static Form_menu form_menu;       
        public static Control_order Control_order;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyApplicationContext context = new MyApplicationContext();
            context.Open(new Authorization());
            Application.Run(context);


        }
        public static int formCount;
        public class MyApplicationContext : ApplicationContext
        {




            public MyApplicationContext()
            {

            }

            public void Open(Form form)
            {

                form.Closed += OnFormClosed;
                formCount++;
                form.Show();
                form.Focus();
            }

            private void OnFormClosed(object sender, EventArgs e)
            {

                formCount--;

            

                if (formCount <= 0)
                {
                    Application.Exit(); 
                }
            }
        }
    }
}
