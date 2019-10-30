using SimpleSheduler.WPF.BL;
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
        public DataGrid DataGrid;
        public MyDataGridProperty MyDataGridProperty;
        public OutClassList()
        {
            InitializeComponent();
            Loaded += Load;

            KeyUp += OutClassList_KeyUp;


        }

        private void OutClassList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
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
                //DataGridComboBoxColumn dataGridComboBoxColumn = new DataGridComboBoxColumn();
                //List<int> items = new List<int> { 1, 2, 3, 4, 5, };
                //dataGridComboBoxColumn.ItemsSource = items;
                //DataGridGroup.Columns[0] = dataGridComboBoxColumn;
                this.Title = DataTable.TableName;
                this.Width = width;
            }
            if (DataGrid!=null)
            {
               
                DataGridGroup.ItemsSource = DataGrid.ItemsSource;
                for (int i = 0; i < DataGridGroup.Columns.Count; i++)
                {
                    var column = DataGridGroup.Columns[i];
                    foreach (var myDataGridProperty in MyDataGridProperty.MyColumnProperties)
                    {
                        if (DataGridGroup.Columns[i].Header.ToString().Equals(myDataGridProperty.ColumnBDName))
                        {
                            if (false)
                            {
                                DataGridComboBoxColumn dataGridComboBoxColumn = new DataGridComboBoxColumn();
                                dataGridComboBoxColumn.Header = myDataGridProperty.ColumnOutName;
                                dataGridComboBoxColumn.ItemsSource = myDataGridProperty.ItemsSource;
                                
                                DataGridGroup.Columns[i] = dataGridComboBoxColumn;
                            }
                            else
                            {
                                DataGridGroup.Columns[i].Header = myDataGridProperty.ColumnOutName;
                                
                                DataGridGroup.Columns[i].Visibility = myDataGridProperty.Visibility;
                                DataGridGroup.Columns[i].IsReadOnly = myDataGridProperty.IsReadOnly;
                            }


                            break;
                        }
                    }
                }
                this.Title = DataGrid.Name;
            }
            
        }

    }
}
