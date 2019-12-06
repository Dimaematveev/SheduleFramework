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

namespace ViewingDB.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> assa = new List<int> { 1, 2, 3, 4 };
            var s = TabControls.Items.GetItemAt(0) as TabItem;
            DataGrid dataGrid = new DataGrid();



            DataGridColumn dataGridColumn = new DataGridTextColumn();

            dataGridColumn.Header = "222";
            dataGridColumn.Visibility = Visibility.Visible;
            dataGridColumn.IsReadOnly = false;


            dataGrid.Columns.Add(dataGridColumn);

            //var sss = dataGrid.Items;
            s.Content = dataGrid;
            TabItem tabItem = new TabItem();

            tabItem.Name = "as2";
            tabItem.ToolTip = "as3";
            tabItem.Header = "as4";
            
            

            TabControls.Items.Add(tabItem);
        }
    }
}
