using SimpleSheduler.BD;
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
            FillGrid();
            Loaded += MainWindow_Loaded;
          //  GridSheduler.MouseDoubleClick += GridSheduler_MouseDoubleClick;
            GridSheduler.PreviewMouseDoubleClick += GridSheduler_MouseDoubleClick;
        }

        private void GridSheduler_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var UCATOC = (UnionCuriculaAndTypeOfClasses)GridSheduler.CurrentCell.Item;
            Window1 window1 = new Window1(UCATOC.Group, UCATOC.Subject);
            window1.ShowDialog();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TabSheduler.Focus();
        }

        /// <summary>
        /// Заполнение Всех DataGrid
        /// </summary>
        private void FillGrid()
        {
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
                dataGridTextColumn.Binding = new Binding($"CountPairs[{i}]");
                GridSheduler.Columns.Add(dataGridTextColumn);
            }

        }

        private void DataGridComboBoxColumn_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

       

        
    }

    
}
