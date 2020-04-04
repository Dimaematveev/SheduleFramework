using Microsoft.Win32;
using ShedulerFromExcel.BL;
using SimpleSheduler.BD;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
            FillGrid();
            //Loaded += MainWindow_Loaded;
            GridSheduler.MouseDoubleClick += GridSheduler_MouseDoubleClick;
            //GridSheduler.PreviewMouseDoubleClick += GridSheduler_MouseDoubleClick;

            
        }

        private void GridSheduler_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var UCATOC = GridSheduler.CurrentItem as UnionCuriculaAndTypeOfClasses;
            if (UCATOC!=null)
            {
                Window1 window1 = new Window1(UCATOC.Group, UCATOC.Subject);
                window1.ShowDialog();
            } else {
                MessageBox.Show("Вы не выбрали строку!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TabSheduler.Focus();
            GridSheduler.Focus();
            //GridSheduler.SelectedItem = GridSheduler.Items[0];
            GridSheduler.SelectedIndex=0;

            //GridSheduler.ScrollIntoView(GridSheduler.Items[0]);
            GridSheduler.CurrentItem = GridSheduler.Items[0];
            MouseDevice mouse = Mouse.PrimaryDevice;
            MouseButtonEventArgs mouseButtonEventArgs = new MouseButtonEventArgs(mouse, 0, MouseButton.Left);
            GridSheduler_MouseDoubleClick(sender, mouseButtonEventArgs);
        }

        /// <summary>
        /// Заполнение Всех DataGrid
        /// </summary>
        private void FillGrid()
        {
            GridShedulerMain.ItemsSource = WorkToMyDbContext.shedulers;


            GridClassRoom.ItemsSource = WorkToMyDbContext.classrooms;
            GridGroup.ItemsSource = WorkToMyDbContext.groups;
            GridSubject.ItemsSource = WorkToMyDbContext.subjects;
            GridCurriculum.ItemsSource = WorkToMyDbContext.curricula;
         
            

            GridPair.ItemsSource = WorkToMyDbContext.pairs;
            GridStudyDay.ItemsSource = WorkToMyDbContext.studyDays;
            GridTypeOfClasses.ItemsSource = WorkToMyDbContext.typeOfClasses;
            GridTypeUnionGroup.ItemsSource = WorkToMyDbContext.typeUnionGroups;


            GridSheduler.ItemsSource = WorkToMyDbContext.unionCuriculaAndTypeOfClasses;
            var dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Header = "Группа";
            dataGridTextColumn.Binding = new Binding("Group");
            GridSheduler.Columns.Add(dataGridTextColumn);
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Header = "Предмет";
            dataGridTextColumn.Binding = new Binding("Subject");
            GridSheduler.Columns.Add(dataGridTextColumn);
            for (int i = 0; i < WorkToMyDbContext.typeOfClasses.Count; i++)
            {
                dataGridTextColumn = new DataGridTextColumn();
                dataGridTextColumn.Header = UnionCuriculaAndTypeOfClasses.TypeOfClasses[i].FullName;
                
                dataGridTextColumn.Binding = new Binding($"CountPairs[{i}].Number");
                GridSheduler.Columns.Add(dataGridTextColumn);
            }

        }

        private void DataGridComboBoxColumn_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void AddExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.ShowDialog();


            Excel excel = new Excel(openFileDialog1.FileName);
            excel.ShowDialog();

            


        }
    }

    
}
