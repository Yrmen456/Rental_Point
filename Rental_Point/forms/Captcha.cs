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
    public partial class Captcha : Form
    {
        public Captcha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
            {
                this.Close();
                Program.authorization.Dostyp_proverka = 0;
            }
            else
            {
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                MessageBox.Show("Ошибка!");
            }
              
   
        }

        private void Captcha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }
        private string text = String.Empty;
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = 5;
            int Ypos = 5;

            //Добавим различные цвета ддя текста
            Brush[] colors = {
                     Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green,
                     Brushes.Yellow,
                     Brushes.White,
                     Brushes.Tomato,
                     Brushes.Sienna,
                     Brushes.Pink };

            //Добавим различные цвета линий
            Pen[] colorpens = {
                     Pens.Black,
                     Pens.Red,
                     Pens.RoyalBlue,
                     Pens.Green,
                     Pens.Yellow,
                     Pens.White,
                     Pens.Tomato,
                     Pens.Sienna,
                     Pens.Pink };

            //Делаем случайный стиль текста
            FontStyle[] fontstyle = {
                     FontStyle.Bold,
                     FontStyle.Italic,
                     FontStyle.Regular,
                     FontStyle.Strikeout,
                     FontStyle.Underline};

            //Добавим различные углы поворота текста
            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Делаем случайный угол поворота текста
            g.RotateTransform(rotate[rnd.Next(rotate.Length)]);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890АаБбВвГгДдЕеЁеЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЯяШшЩщЪъЫыЬьЭэЮюЯя";
            int col = rnd.Next(5, 7);
            for (int i = 0; i < col; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 50, fontstyle[rnd.Next(fontstyle.Length)]),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            //Линии из углов
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
