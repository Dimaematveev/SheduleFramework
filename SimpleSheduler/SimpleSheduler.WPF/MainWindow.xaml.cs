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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using SimpleSheduler.WPF.BL;

namespace SimpleSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Данные из БД
        GetDataFromBD getDataFromBD = new GetDataFromBD();
        Filling<Group>[] fillingGroups;
        Filling<Classroom>[] fillingClassrooms;
        public MainWindow()
        {
            GetDataFromBD.RepositoryBase();
            InitializeComponent();
            ButtonGetDataFromBD.Click += ButtonGetDataFromBD_Click;
            ButtonOpenGroup.Click += ButtonOpenGroup_Click;
            ButtonOpenCurricila.Click += ButtonOpenCurricila_Click;
            ButtonOpenSubject.Click += ButtonOpenSubject_Click;
            ButtonOpenClassroom.Click += ButtonOpenClassroom_Click;


            GetFilling.Click += GetFilling_Click;
            FillingClassrooms.Click += FillingClassrooms_Click;
            FillingGroups.Click += FillingGroups_Click;
        }

        private void FillingGroups_Click(object sender, RoutedEventArgs e)
        {


            DataTable table = new DataTable("Group");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "№";
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "День";
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Пара";
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            foreach (var filling in fillingGroups)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = $"{filling.Value.NameString()}";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
            }

            for (int i = 0; i < fillingGroups[0].PossibleFillings.Length; i++)
            {
                row = table.NewRow();
                var temp = fillingGroups[0].PossibleFillings[i];
                row[0]=$"{temp.StudyDay.NameDayOfWeek}";
                row[1]=$"{temp.StudyDay.NumberDayOfWeek}";
                row[2]=$"{temp.Pair.NumberThePair}";
                int stolb = 3;
                foreach (var filling in fillingGroups)
                {
                    if (filling.PossibleFillings[i].BusyPair==null)
                    {
                        row[stolb]="null";
                        stolb++;
                    }
                    else
                    {
                        
                        row[stolb] = filling.PossibleFillings[i].BusyPair.ToString();
                        stolb++;
                    }
                    
                }
                table.Rows.Add(row);
            }

            OpenGridBD(table);
        }

        private void FillingClassrooms_Click(object sender, RoutedEventArgs e)
        {
            OpenGridBD(fillingClassrooms.Select(x => x.PossibleFillings).ToList());
        }

        private void GetFilling_Click(object sender, RoutedEventArgs e)
        {
            fillingGroups = GetFillingClass.GetFilling(getDataFromBD.groups, getDataFromBD.pairs, getDataFromBD.studyDays);
            fillingClassrooms = GetFillingClass.GetFilling(getDataFromBD.classrooms, getDataFromBD.pairs, getDataFromBD.studyDays);

        }

        private void ButtonOpenClassroom_Click(object sender, RoutedEventArgs e)
        {
            OpenGridBD(getDataFromBD.classrooms);
        }

        private void ButtonOpenSubject_Click(object sender, RoutedEventArgs e)
        {
            OpenGridBD(getDataFromBD.subjects);
        }

        private void ButtonOpenCurricila_Click(object sender, RoutedEventArgs e)
        {
            OpenGridBD(getDataFromBD.curricula);
        }

        private void ButtonGetDataFromBD_Click(object sender, RoutedEventArgs e)
        {
            getDataFromBD.ReadDB();
            string ret = "";
            ret += $"Количество:\n";
            ret += $"Аудиторий={getDataFromBD.classrooms.Length}, ";
            ret += $"Групп={getDataFromBD.groups.Length}, ";
            ret += $"Предметов={getDataFromBD.subjects.Length}, ";
            ret += $"В плане={getDataFromBD.curricula.Length}, ";
            ret += $"Пар в день={getDataFromBD.pairs.Length}, ";
            ret += $"Учебных дней за 2 недели={getDataFromBD.studyDays.Length}.";
            TexboxFromBD.Text = ret;

            if (getDataFromBD.groups != null)
            {
                ButtonOpenGroup.IsEnabled = true;
            }
            if (getDataFromBD.classrooms != null)
            {
                ButtonOpenClassroom.IsEnabled = true;
            }
            if (getDataFromBD.subjects != null)
            {
                ButtonOpenSubject.IsEnabled = true;
            }
            if (getDataFromBD.curricula != null)
            {
                ButtonOpenCurricila.IsEnabled = true;
            }
        }
        private void ButtonOpenGroup_Click(object sender, RoutedEventArgs e)
        {
            OpenGridBD(getDataFromBD.groups);
        }

        private void OpenGridBD<T>(ICollection<T> collection)
        {
            OutClassList outGroup = new OutClassList();
            outGroup.List = collection.Select(x => (object)x).ToList();
            outGroup.ShowDialog();
        }

        private void OpenGridBD(DataTable collection)
        {
            OutClassList outGroup = new OutClassList();
            outGroup.DataTable = collection;
            outGroup.ShowDialog();
        }

        private void OpenGridFilling<T>(ICollection<Filling<T>> collection)where T:class,IName
        {
            OutFilling outGroup = new OutFilling();

            outGroup.List = collection.Select(x=>(object)x).ToList();
            outGroup.ShowDialog();
        }

    }
}
