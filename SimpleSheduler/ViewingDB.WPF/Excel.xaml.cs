using ShedulerFromExcel.BL;
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

namespace ViewingDB.WPF
{
    /// <summary>
    /// Логика взаимодействия для Excel.xaml
    /// </summary>
    public partial class Excel : Window
    {
        public Excel(string filename)
        {
            InitializeComponent();

            Init(filename);
        }

        private void Init(string filename)
        {
            EasyExcel easyExcel17 = new EasyExcel(filename);
            foreach (var Course in easyExcel17.AllCourses)
            {
                DataGrid dataGrid1 = new DataGrid();
                dataGrid1.ItemsSource = Course.Semester1.DefaultView;
                TabItem tabItem1 = new TabItem();
                tabItem1.Content = dataGrid1;
                tabItem1.Header = Course.Semester1.TableName;
                ExcelControl.Items.Add(tabItem1);

                DataGrid dataGrid2 = new DataGrid();
                dataGrid2.ItemsSource = Course.Semester2.DefaultView;
                TabItem tabItem2 = new TabItem();
                tabItem2.Content = dataGrid2;
                tabItem2.Header = Course.Semester2.TableName;
                ExcelControl.Items.Add(tabItem2);
            }


            Year.Text = easyExcel17.Title.YearBegin;
            Kafedra.Text = easyExcel17.Title.Kafedra;
            Napravl.Text = easyExcel17.Title.Napravl;
            Potok.Text = easyExcel17.Title.Potok;
            Profil.Text = easyExcel17.Title.Profil;

        }
    }
}
