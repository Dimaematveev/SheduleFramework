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
        public DataGrid DataGridClassRooms = new DataGrid();
        public MainWindow()
        {
            InitializeComponent();
            this.Activated += MainWindow_Activated;  
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            GridClassRoom.ItemsSource = WorkToMyDbContext.classrooms;
            GridGroup.ItemsSource = WorkToMyDbContext.groups;
            GridSubject.ItemsSource = WorkToMyDbContext.subjects;
            GridCurriculum.ItemsSource = WorkToMyDbContext.curricula;
            GridPair.ItemsSource = WorkToMyDbContext.pairs;
            GridStudyDay.ItemsSource = WorkToMyDbContext.studyDays;
            GridTypeOfClasses.ItemsSource = WorkToMyDbContext.typeOfClasses;
            GridTypeUnionGroup.ItemsSource = WorkToMyDbContext.typeUnionGroups;

        }

    }
}
