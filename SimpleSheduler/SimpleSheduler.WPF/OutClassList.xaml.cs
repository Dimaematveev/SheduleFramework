using System;
using System.Collections.Generic;
using System.Data;
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

namespace SimpleSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для OutGroup.xaml
    /// </summary>
    public partial class OutClassList : Window
    {
        
        public DataTable DataTable;
        public OutClassList()
        {
            InitializeComponent();
            Loaded += Load;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
           
            if (DataTable!=null)
            {
                int width = 1000;
                DataGridGroup.ItemsSource = DataTable.DefaultView;
                
                for (int i = 0; i < DataGridGroup.Columns.Count; i++)
                {
                    DataGridGroup.Columns[i].Header = DataTable.Columns[i].Caption;
                    
                }
                
                this.Title = DataTable.TableName;
                this.Width = width;
            }
            
        }

    }
}
