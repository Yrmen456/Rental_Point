using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;

namespace Rental_Point
{
    public partial class Control_charts : UserControl
    {
        public Control_charts()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }
        int Query = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Tag);
                Query = int.Parse(radioButton.Tag.ToString());

            }
        }
        //Получаем данные и заполняем таблицу
        public async void Select_Table()
        {
            string datestart = dateTimePicker1.Value.ToString("yyyy-MM-dd"); //Дата начала
            string dateand = dateTimePicker2.Value.ToString("yyyy-MM-dd"); //Дата окончания
 
            if (Query == 1)
            {
                dataGridView1.DataSource = SQL.table($@"Select ((CAST(datetime AS DATE))) as 'Дата',(Sum(Order_items.count_servis))  as 'Количество Услуг'  from  [dbo].[Order] Orders
                    Inner Join (Select Order_items.id_order, (Count(Order_items.id_order)) as 'count_servis'  
                    from  Order_items where Order_items.id is not null 
                    Group By Order_items.id_order) as Order_items on Order_items.id_order = Orders.id 
                    where datetime between '{datestart} 00:00:00' and '{dateand} 23:59:59' 
                    Group By  CAST(datetime AS DATE)
                    Order By CAST(datetime AS DATE)").Tables[0];
            }
            else
               if (Query == 2)
            {
                dataGridView1.DataSource = SQL.table($@"		Select ((CAST(datetime AS DATE)))  as 'Дата', Order_items.id_services as 'Order_items_id_services', Order_items.name as 'Услуга',(Sum(Order_items.count_servis))  as 'Количество'  from  [dbo].[Order] Orders
                    Inner Join (Select Order_items.id_order, ((Order_items.id_services)), (Count(Order_items.id_services)) as 'count_servis', 
                    Services.name from  Order_items Inner Join Services Services on Services.id = Order_items.id_services
                    where Order_items.id is not null 
                    Group By Order_items.id_order, Order_items.id_services , Services.name) as Order_items on Order_items.id_order = Orders.id 
                    where datetime between '{datestart} 00:00:00' and '{dateand} 23:59:59' 
                    Group By  CAST(datetime AS DATE), Order_items.id_services,  Order_items.name
                    Order By CAST(datetime AS DATE)").Tables[0];
            }
            else
               if (Query == 3)
            {
                dataGridView1.DataSource = SQL.table($@"Select ((CAST(datetime AS DATE)))  as 'Дата' , COUNT(Orders.id)  as 'Количество Заказов' from  [dbo].[Order] Orders
                    where datetime between '{datestart} 00:00:00' and '{dateand} 23:59:59' 
                    Group By  ((CAST(datetime AS DATE))) ").Tables[0];
            }
            else
            {
                return;
            }
            if (Query == 2)
            {
                charr2();
            }
            else
            {
                ShowСhart();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select_Table();
        }

        //Рисуем график по получиным данным
        void ShowСhart()
        {
            chart1.Visible = true;
            List<DateTime> Date = new List<DateTime>();
            List<string> Quantity = new List<string>();
            var s = new Series();
            s.ChartType = SeriesChartType.Line;
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Что то не так с датами");
                return;
            }
            chart1.Series[0].Points.Clear();
            chart1.Series.Clear();
            Date.Clear();
            Quantity.Clear();
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Date.Add(Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value));
                Quantity.Add(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
            }
            int number;
            string GetStartupPath(){
                return "";
            }
            chart1.Series.Add(s);
            int id = 0;
            while (id < Date.Count)
            {
                if (date != Date[id])
                {
                    s.Points.AddXY(date, 0.00001f);
                    date = date.AddDays(1);
                }
                else
                {
                    s.Points.AddXY(Date[id], Quantity[id]);
                    id = id + 1;
                    date = date.AddDays(1);
                }

            }

            while (date <= DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd")))
            {
                s.Points.AddXY(date, 0.00001f);
                date = date.AddDays(1);

            }

            chart1.Series[0].XValueType = ChartValueType.DateTime;

            //chart1.ChartAreas.Add(new ChartArea()); // In some cases the winforms designer adds this already
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
            if ((DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"))).Days < -30)
            {
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                //comboBox1.Text = "Months"+(DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"))).Days;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                //comboBox1.Text = "Days"+(DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"))).Days;
            }
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[0].BorderWidth = 2;
            DateTime minDate = dateTimePicker1.Value.AddSeconds(-1);
            DateTime maxDate = dateTimePicker2.Value; // or DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();


        }
        List<int> Id_ = new List<int> { };
        List<string> Name_;
        List<DateTime> DateTime_;
        List<int> Count_;
        List<int> stop = new List<int> { };

        //Рисуем график по получиным данным
        async void charr2()
        {
            dataGridView2.Rows.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                Id_.Add(int.Parse(dataGridView1[1, i].Value.ToString()));


            }
            List<int> distinct = Id_.Distinct().ToList();

            MessageBox.Show(Id_.Count + " " + distinct.Count);
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Что то не так с датами");
                return;
            }
            chart1.Series.Clear();
            Random random = new Random();


            for (int y = 0; y < distinct.Count; y++)
            {

                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[random.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);
                var bmp = new Bitmap(150, 150);
                var g = Graphics.FromImage(bmp);
                bool boll = true;
                for (int i = 0; i < stop.Count; i++)
                {
                    if (distinct[y] == stop[i])
                    {
                        boll = false;
                    }
                }
                dataGridView2.Rows.Add(distinct[y].ToString(), distinct[y].ToString(), bmp, boll);
                if (!boll)
                {
                    return;
                }
                chart1.Visible = true;
                chart1.Series.Add(y.ToString());

                chart1.Series[y].Color = randomColor;
                g.Clear(randomColor);

                List<DateTime> moth = new List<DateTime>();
                List<string> cell = new List<string>();
                var s = new Series();
                chart1.Series[y].ChartType = SeriesChartType.Line;

                chart1.Series[y].Points.Clear();

                moth.Clear();
                cell.Clear();

                DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    if (Id_[y] == int.Parse(dataGridView1[1, i].Value.ToString()))
                    {

                        moth.Add(Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value));
                        cell.Add(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                        for (int f = 0; f < dataGridView2.Rows.Count; f++)
                        {
                            if (dataGridView2[0, f].Value.ToString() == Id_[y].ToString())
                            {
                                dataGridView2[1, f].Value = dataGridView1[2, f].Value.ToString();
                            }
                        }
                    }

                }


                int id = 0;
                while (id < moth.Count)
                {
                    if (date != moth[id])
                    {
                        chart1.Series[y].Points.AddXY(date, 0.00001f);
                        date = date.AddDays(1);
                    }
                    else
                    {
                        chart1.Series[y].Points.AddXY(moth[id], cell[id]);
                        id = id + 1;
                        date = date.AddDays(1);
                    }

                }

                while (date <= DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd")))
                {
                    chart1.Series[y].Points.AddXY(date, 0.00001f);
                    date = date.AddDays(1);

                }

                chart1.Series[y].XValueType = ChartValueType.DateTime;

                //chart1.ChartAreas.Add(new ChartArea()); // In some cases the winforms designer adds this already
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
                chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
                if ((DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"))).Days < -30)
                {
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                    //comboBox1.Text = "Months" + (DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"))).Days;
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                    //comboBox1.Text = "Days" + (DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"))).Days;
                }
                chart1.Series[y].IsVisibleInLegend = false;
                chart1.Series[y].BorderWidth = 2;
                DateTime minDate = dateTimePicker1.Value.AddSeconds(-1);
                DateTime maxDate = dateTimePicker2.Value; // or DateTime.Now;
                chart1.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();





            }
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        bool visible_table = false;
        private void button3_Click(object sender, EventArgs e)
        {

            if (visible_table == false)
            {
                dataGridView2.Size = new System.Drawing.Size(350, dataGridView2.Size.Height);
                visible_table = true;
            }
            else
            {
                dataGridView2.Size = new System.Drawing.Size(0, dataGridView2.Size.Height);

                visible_table = false;
            }
        }

        private async void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //await Task.Delay(1000);

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int intNumColumnDeleteAttribute = 3;
                //Фильтр для столбцов (обрабатывается только столбец Удаление атрибута)

                if ((bool)dataGridView2[intNumColumnDeleteAttribute, e.RowIndex].Value == true)
                {
                    stop.Add(int.Parse(dataGridView2[0, e.RowIndex].Value.ToString()));
                }

                else
                {

                }




            }

        }
        //Формируем отчеты
        string startupPath = Environment.CurrentDirectory;
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Выбирите вариант экспорта");
                return;
            }
            //Попытка открытия документа
            Word.Document doc = null;
            try
            {
                Word.Application app = new Word.Application();
                string source = startupPath + @"\chart_and_table.docx";
                doc = app.Documents.Open(source);
                doc.Activate();
                doc.SaveAs2(startupPath + @"\chart_and_table2.docx");

                doc.Close();
                doc = null;
            }
            catch
            {
                doc = null;
                return;
            }
            if (radioButton2.Checked == true)
            {
                try
                {
                    Word.Application app = new Word.Application();
                    // Путь до шаблона документа
                    //string source = startupPath + @"\standart.docx.docx";

                    string source = startupPath + @"\chart_and_table2.docx";
                    // Открываем
                    doc = app.Documents.Open(source);
                    doc.Activate();
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    int i = 0;
                    string txt = "";
                    if (radioButton1.Checked == true)
                    {
                        txt = radioButton1.Text;
                    }
                    if (radioButton2.Checked == true)
                    {
                        txt = radioButton2.Text;
                    }
                    if (radioButton3.Checked == true)
                    {
                        txt = radioButton3.Text;
                    }
                    string[] data = new string[2] { " " + dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("yyyy-MM-dd"), " " + txt };
                    foreach (Word.Bookmark mark in wBookmarks)
                    {

                        wRange = mark.Range;
                        wRange.Text = data[i];
                        var d = wRange.InlineShapes;
                        i++;
                        if (i >= data.Length)
                        {
                            break;
                        }
                    }
                    if (checkBox1.Checked == true)
                    {
                        chart1.SaveImage(startupPath + @"\codes.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        doc.Bookmarks.get_Item("q3").Range.InlineShapes.AddPicture(startupPath + @"\codes.jpg");
                    }



                    //  
                    if (checkBox2.Checked == true)
                    {
                        Word.Range range = app.Selection.Range;
                        Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                        Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;


                        int columns = dataGridView1.Columns.Count;
                        int rows = dataGridView1.Rows.Count;
                        MessageBox.Show("" + rows);
                        doc.Bookmarks.get_Item("s6").Range.Tables.Add(doc.Bookmarks.get_Item("s6").Range, rows + 1, 3, ref behiavor, ref autoFitBehiavor);
                        doc.Tables[1].Cell(1, 1).Range.Text = dataGridView1.Columns[0].HeaderText.ToString();
                        doc.Tables[1].Cell(1, 2).Range.Text = dataGridView1.Columns[2].HeaderText.ToString();
                        doc.Tables[1].Cell(1, 3).Range.Text = dataGridView1.Columns[3].HeaderText.ToString();
                        for (int j = 0; j < rows; j++)
                        {
                            if (dataGridView1[0, j].Value != null)
                            {
                                doc.Tables[1].Cell(j + 2, 1).Range.Text = DateTime.Parse(dataGridView1[0, j].Value.ToString()).ToString("yyyy-MM-dd");
                            }
                            if (dataGridView1[2, j].Value != null)
                            {
                                doc.Tables[1].Cell(j + 2, 2).Range.Text = dataGridView1[2, j].Value.ToString();
                            }
                            if (dataGridView1[3, j].Value != null)
                            {
                                doc.Tables[1].Cell(j + 2, 3).Range.Text = dataGridView1[3, j].Value.ToString();
                            }
                        }



                    }
                    doc.SaveAs2(startupPath + @"\ww5.docx");

                    Random rnd = new Random();
                    int num = rnd.Next(1, 9000);
                    doc.SaveAs2(startupPath + $@"\Order_reports\{dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + txt + " " + num }.pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);

                    doc.Close();
                    doc = null;
                    try
                    {
                        System.Diagnostics.Process.Start(startupPath + $@"\Order_reports\{dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + txt + " " + num  }.pdf");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {

                    doc.Close();
                    doc = null;
                    MessageBox.Show("Во время выполнения произошла ошибка! \n" + ex);
                    Console.ReadLine();
                }
            }
            else
            {
                try
                {
                    Word.Application app = new Word.Application();
                    // Путь до шаблона документа
                    //string source = startupPath + @"\standart.docx.docx";

                    string source = startupPath + @"\chart_and_table2.docx";
                    // Открываем
                    doc = app.Documents.Open(source);
                    doc.Activate();
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    int i = 0;
                    string txt = "";
                    if (radioButton1.Checked == true)
                    {
                        txt = radioButton1.Text;
                    }
                    if (radioButton2.Checked == true)
                    {
                        txt = radioButton2.Text;
                    }
                    if (radioButton3.Checked == true)
                    {
                        txt = radioButton3.Text;
                    }
                    string[] data = new string[2] { " " + dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("yyyy-MM-dd"), " " + txt };
                    foreach (Word.Bookmark mark in wBookmarks)
                    {

                        wRange = mark.Range;
                        wRange.Text = data[i];
                        var d = wRange.InlineShapes;
                        i++;
                        if (i >= data.Length)
                        {
                            break;
                        }
                    }
                    if (checkBox1.Checked == true)
                    {
                        chart1.SaveImage(startupPath + @"\codes.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        doc.Bookmarks.get_Item("q3").Range.InlineShapes.AddPicture(startupPath + @"\codes.jpg");
                    }

                    //  
                    if (checkBox2.Checked == true)
                    {
                        Word.Range range = app.Selection.Range;
                        Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                        Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;


                        int columns = dataGridView1.Columns.Count;
                        int rows = dataGridView1.Rows.Count;
                        MessageBox.Show("" + rows);
                        doc.Bookmarks.get_Item("s6").Range.Tables.Add(doc.Bookmarks.get_Item("s6").Range, rows + 1, 2, ref behiavor, ref autoFitBehiavor);
                        doc.Tables[1].Cell(1, 1).Range.Text = dataGridView1.Columns[0].HeaderText.ToString();
                        doc.Tables[1].Cell(1, 2).Range.Text = dataGridView1.Columns[1].HeaderText.ToString();
                        for (int j = 0; j < rows; j++)
                        {
                            if (dataGridView1[0, j].Value != null)
                            {
                                doc.Tables[1].Cell(j + 2, 1).Range.Text = DateTime.Parse(dataGridView1[0, j].Value.ToString()).ToString("yyyy-MM-dd");
                            }
                            if (dataGridView1[1, j].Value != null)
                            {
                                doc.Tables[1].Cell(j + 2, 2).Range.Text = dataGridView1[1, j].Value.ToString();
                            }

                        }

                    }


                    doc.SaveAs2(startupPath + @"\ww5.docx");

                    Random rnd = new Random();
                    int num = rnd.Next(1, 9000);
                    doc.SaveAs2(startupPath + $@"\Order_reports\{dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + txt + " " + num }.pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);

                    doc.Close();
                    doc = null;
                    try
                    {
                        System.Diagnostics.Process.Start(startupPath + $@"\Order_reports\{dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + txt + " " + num  }.pdf");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                catch (Exception ex)
                {

                    doc.Close();
                    doc = null;
                    MessageBox.Show("Во время выполнения произошла ошибка! \n" + ex);
                    Console.ReadLine();
                }
            }

        }
    }
}
