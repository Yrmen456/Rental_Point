using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Point
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CancellationTokenSource _tokenSource;
        private async  void button1_Click(object sender, EventArgs e)
        {
            //через него будем оповещать о ходе выполнения задачи
            Progress<string> progess = new Progress<string>(text => this.label1.Text = text);

            //готовим токен отмены
            _tokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _tokenSource.Token;

            //запускаем долгую задачу
            try
            {
                this.label1.Text = "Начинаем...";

               
                //обратите внимание на передачу токена отмены, и экземпл. прогресса
                this.dataGridView1.DataSource = await Task.Run(() => DoSomething(cancelToken), cancelToken);
            }
            catch (OperationCanceledException)
            {
                this.label1.Text = "Задача отменена.";
            }
            catch (Exception ex)
            {
                this.label1.Text = $"В задаче произошла ошибка: {ex.Message}";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
        }
        private DataTable DoSomething(CancellationToken cancelToken)
        {
            DataTable dataTable = null;
            
            dataTable = SQL.table("Select   * from Table_1").Tables[0];
            cancelToken.ThrowIfCancellationRequested();
            return dataTable;
        }
    }
}
