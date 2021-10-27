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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;



namespace Учет_домашних_финансов
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\shher\OneDrive\Рабочий стол\учеба\Курсовая\База Данных для учета домашних финансов.accdb");
            con.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from Финансы", con);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Финансы");

            datagrid.ItemsSource = ds.Tables["Финансы"].DefaultView;
            con.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\shher\OneDrive\Рабочий стол\учеба\Курсовая\База Данных для учета домашних финансов.accdb");
            con.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from Финансы", con);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Финансы");

            datagrid.ItemsSource = ds.Tables["Финансы"].DefaultView;
            con.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Window1 passwordWindow = new Window1();

            if (passwordWindow.ShowDialog() == true)
            {
                if (passwordWindow.Password == "123")
                {
                   
                    Window2 add = new Window2();
                    add.Show();
                    MessageBox.Show("Авторизация пройдена");
                }
                else
                    MessageBox.Show("Неверный пароль");
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Window3 addd = new Window3();
            addd.Show();
        }
    }
}
