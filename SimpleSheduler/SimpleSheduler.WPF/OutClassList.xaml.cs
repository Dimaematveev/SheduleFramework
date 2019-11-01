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

            Closed += OutClassList_Closed;
            Closing += OutClassList_Closing;

        }

        private void OutClassList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
             MessageBox.Show("Закрытие", "1", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
             MessageBox.Show("Закрытие", "2", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.None);
             MessageBox.Show("Закрытие", "3", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.RightAlign);
             MessageBox.Show("Закрытие", "4", MessageBoxButton.YesNoCancel, MessageBoxImage.Hand, MessageBoxResult.None, MessageBoxOptions.RtlReading);
             MessageBox.Show("Закрытие", "5", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
             MessageBox.Show("Закрытие", "6", MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
             MessageBox.Show("Закрытие", "7", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.None);
             MessageBox.Show("Закрытие", "8", MessageBoxButton.YesNoCancel, MessageBoxImage.Stop, MessageBoxResult.None, MessageBoxOptions.RightAlign);
             MessageBox.Show("Закрытие", "9", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.RtlReading);
             */
            DataGridGroup.CancelEdit();
            DataGridGroup.CommitEdit();
        }

        private void OutClassList_Closed(object sender, EventArgs e)
        {
            
            
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
                            if (myDataGridProperty.ItemsSource!=null)
                            {

                                DataGridComboBoxColumn dataGridComboBoxColumn = new DataGridComboBoxColumn();
                                dataGridComboBoxColumn.Header = myDataGridProperty.ColumnOutName;
                                dataGridComboBoxColumn.ItemsSource = myDataGridProperty.ItemsSource;
                                
                                DataGridGroup.Columns[i] = dataGridComboBoxColumn;
                                DataGridGroup.PreparingCellForEdit += DataGridGroup_PreparingCellForEdit;
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

        private void DataGridGroup_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            MessageBox.Show("dwdwd");
        }
    }
}
