using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace NewScheduler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Initial Catalog=Shed;";

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strSQL = "SELECT Max(NumberOfSeats)   FROM [Shed].[dbo].Classrooms";
            // Создание еще одного объекта команды с помощью свойств
            SqlCommand testCommand = new SqlCommand();
            testCommand.Connection = conn;
            testCommand.CommandText = strSQL;
            SqlDataReader dr = testCommand.ExecuteReader();
            string vaa = "";
            while (dr.Read())
            {
                vaa += $"Max classrooms: {dr[0]} \n";
            }   
            MessageBox.Show(vaa);
            conn.Close();
        }
    }
}
