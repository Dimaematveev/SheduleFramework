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
    public class NeedFood
    {
        public string NameProduct { get; set; }
        public double Count1 { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<NeedFood> assa;
        public MainWindow()
        {
            InitializeComponent();
            MainWindow_Loaded1();
        }

        private void MainWindow_Loaded1()
        {
            assa = new List<NeedFood> { 
               new NeedFood(){Count1=1.2,NameProduct="sasa"},
               new NeedFood(){Count1=1.3,NameProduct="fe"},
               new NeedFood(){Count1=1.4,NameProduct="2ee"},
            };
            food.ItemsSource = assa;
           
            //var s = TabControls.Items.GetItemAt(0) as TabItem;
            //DataGrid dataGrid = new DataGrid();

          
            //dataGrid.ItemsSource = assa;
            //dataGrid.Items.Add(dataGridRow);
            //dataGrid.UpdateLayout()

            //var sss = dataGrid.Items;
            //s.Content = dataGrid;
            //TabItem tabItem = new TabItem();

            //tabItem.Name = "as2";
            //tabItem.ToolTip = "as3";
            //tabItem.Header = "as4";
            
            

            //TabControls.Items.Add(tabItem);
        }
    }
}
