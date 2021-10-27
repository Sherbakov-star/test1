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

namespace Учет_домашних_финансов
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public static string ConnectString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\shher\OneDrive\Рабочий стол\учеба\Курсовая\База Данных для учета домашних финансов.accdb");
        private OleDbConnection myConnection;
        public Window3()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id2.Text);
                string istochnicdoh = Convert.ToString(isdoh.Text);
                string dohod = Convert.ToString(doh.Text);
                string istochnicras = Convert.ToString(isras.Text);
                string rashod = Convert.ToString(ras.Text);
                string query2 = "INSERT INTO Финансы ([Код],[Мебель],[Кол-во],[Посуда],[Количество]) VALUES (" + id + ",'" + istochnicdoh + "', '" + dohod + "','" + istochnicras + "','" + rashod + "')";
                OleDbCommand command = new OleDbCommand(query2, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные добавленны");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат");
                throw;
            }
            

        }

        
    }
}
