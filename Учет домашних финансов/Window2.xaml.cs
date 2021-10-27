using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Учет_домашних_финансов
{
    public partial class Window2 : Window
    {
        public static string ConnectString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\shher\OneDrive\Рабочий стол\учеба\Курсовая\База Данных для учета домашних финансов.accdb");
        private OleDbConnection myConnection;
        public Window2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ID.Text);
                string stolb = Convert.ToString(x.Text);
                string znach = Convert.ToString(y.Text);
                string query2 = $"UPDATE [Финансы] SET [{stolb}] = '{znach}' WHERE [Код] = {id} ";
                OleDbCommand command = new OleDbCommand(query2, myConnection);

                command.ExecuteNonQuery();
                MessageBox.Show("Данные заменены");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат");
                throw;
            }
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ID.Text);
                string query = $"DELETE FROM Финансы WHERE [Код] = {id} ";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные удалены");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат");
                throw;
            }
            
        }

    }
}
