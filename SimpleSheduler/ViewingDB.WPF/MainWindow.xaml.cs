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




            var uni = FillingUnionCuriculaAndTypeOfClasses();
            GridSheduler.ItemsSource = uni.;
            var dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Header = "Группа";
            dataGridTextColumn.Binding = new Binding("NameGroup");
            GridSheduler.Columns.Add(dataGridTextColumn);
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Header = "Предмет";
            dataGridTextColumn.Binding = new Binding("NameSubject");
            GridSheduler.Columns.Add(dataGridTextColumn);
            //for (int i = 0; i < WorkToMyDbContext.typeOfClasses.Count; i++)
            //{
            //    dataGridTextColumn = new DataGridTextColumn();
            //    dataGridTextColumn.Header = uni[0].NameTypeOfClasses[i];
            //    dataGridTextColumn.Binding = new Binding("CountPairs[i]");
            //    GridSheduler.Columns.Add(dataGridTextColumn);
            //}

        }

        private void DataGridComboBoxColumn_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        public class UnionCuriculaAndTypeOfClasses
        {
            public string NameGroup;
            public string NameSubject;
            public List<string> NameTypeOfClasses;
            public List<int> CountPairs;
        }

        public List<UnionCuriculaAndTypeOfClasses> FillingUnionCuriculaAndTypeOfClasses()
        {
            List<UnionCuriculaAndTypeOfClasses> unionCuriculaAndTypeOfClasses = new List<UnionCuriculaAndTypeOfClasses>();
            foreach (var curricula in WorkToMyDbContext.curricula)
            {
                var unionCATOC = new UnionCuriculaAndTypeOfClasses();
                unionCATOC.NameGroup = curricula.Group.FullName;
                unionCATOC.NameSubject = curricula.Subject.FullName;
                unionCATOC.NameTypeOfClasses = new List<string>();
                foreach (var typeOfClass in WorkToMyDbContext.typeOfClasses)
                {
                    unionCATOC.NameTypeOfClasses.Add(typeOfClass.FullName);
                }
                unionCATOC.CountPairs = new List<int>();
                foreach (var nameTypeOfClass in unionCATOC.NameTypeOfClasses)
                {
                    if (Equals( nameTypeOfClass,curricula.TypeOfClasses.FullName))
                    {
                        unionCATOC.CountPairs.Add(curricula.Number);
                    }
                    else
                    {
                        unionCATOC.CountPairs.Add(0);
                    }
                }
                unionCuriculaAndTypeOfClasses.Add(unionCATOC);
            }
            return unionCuriculaAndTypeOfClasses;
        }
    }
}
