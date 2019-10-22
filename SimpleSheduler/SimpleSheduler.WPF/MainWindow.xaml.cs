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
            ButtonOpenPair.Click += ButtonOpenPair_Click;
            ButtonOpenStudyDay.Click += ButtonOpenStudyDays_Click;
            GetFilling.Click += GetFilling_Click;
            FillingClassrooms.Click += FillingClassrooms_Click;
            FillingGroups.Click += FillingGroups_Click;
            CreateScheduler.Click += CreateScheduler_Click;

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonGetDataFromBD_Click(sender,e);
            GetFilling_Click(sender, e);
            CreateScheduler_Click(sender, e);
            FillingGroups_Click(sender, e);
        }

        private void CreateScheduler_Click(object sender, RoutedEventArgs e)
        {
            CreateScheduler createScheduler1 = new CreateScheduler(getDataFromBD.groups, getDataFromBD.classrooms, getDataFromBD.subjects, getDataFromBD.curricula, fillingGroups, fillingClassrooms);
        }

        private void FillingGroups_Click(object sender, RoutedEventArgs e)
        {
            var table = GetDateTableFilling(fillingGroups);
            table.TableName = "Заполнение Групп";
            OpenGridBD(table);
        }
        private void FillingClassrooms_Click(object sender, RoutedEventArgs e)
        {
            var table = GetDateTableFilling(fillingClassrooms);
            table.TableName = "Заполнение Аудиторий";
            OpenGridBD(table);
        }
        
        private void GetFilling_Click(object sender, RoutedEventArgs e)
        {
            fillingGroups = GetFillingClass.GetFilling(getDataFromBD.groups, getDataFromBD.pairs, getDataFromBD.studyDays);
            fillingClassrooms = GetFillingClass.GetFilling(getDataFromBD.classrooms, getDataFromBD.pairs, getDataFromBD.studyDays);
            FillingClassrooms.IsEnabled = true;
            FillingGroups.IsEnabled = true;
            CreateScheduler.IsEnabled = true;

        }

        private void ButtonOpenStudyDays_Click(object sender, RoutedEventArgs e)
        {
            var table = getDataFromBD.GetDateTableBDStudyDay();
            table.TableName = "Учебные дни";
            OpenGridBD(table);
        }

        private void ButtonOpenPair_Click(object sender, RoutedEventArgs e)
        {
            var table = getDataFromBD.GetDateTableBDPair();
            table.TableName = "Пары";
            OpenGridBD(table);
        }

        private void ButtonOpenClassroom_Click(object sender, RoutedEventArgs e)
        {
            var table = getDataFromBD.GetDateTableBDClassroom();
            table.TableName = "Аудитории";
            OpenGridBD(table);
        }

        private void ButtonOpenSubject_Click(object sender, RoutedEventArgs e)
        {
            var table = getDataFromBD.GetDateTableBDSubject();
            table.TableName = "Предметы";
            OpenGridBD(table);
        }
        
        private void ButtonOpenCurricila_Click(object sender, RoutedEventArgs e)
        {
            var table = getDataFromBD.GetDateTableBDCurriculum();
            table.TableName = "План";
            OpenGridBD(table);
        }
        private void ButtonOpenGroup_Click(object sender, RoutedEventArgs e)
        {
            var table = getDataFromBD.GetDateTableBDGroup();
            table.TableName = "Группы";
            OpenGridBD(table);
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
            if (getDataFromBD.pairs != null)
            {
                ButtonOpenPair.IsEnabled = true;
            }
            if (getDataFromBD.studyDays != null)
            {
                ButtonOpenStudyDay.IsEnabled = true;
            }

            if (getDataFromBD.groups != null && getDataFromBD.classrooms != null &&  getDataFromBD.pairs != null && getDataFromBD.studyDays != null)
            {
                GetFilling.IsEnabled = true;
            }
        }
       
        
        private void OpenGridBD(DataTable collection)
        {
            OutClassList outGroup = new OutClassList();
            outGroup.DataTable = collection;
            outGroup.ShowDialog();
        }





        private DataTable GetDateTableFilling<T>(Filling<T>[] fillings) where T : class, IName
        {
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.ColumnName = "№";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.ColumnName = "День";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.ColumnName = "Пара";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                foreach (var filling in fillings)
                {
                    column = new DataColumn();

                    column.DataType = typeof(string);
                    column.ColumnName = $"{filling.Value.NameString()}";
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                }
            }
            for (int i = 0; i < fillings[0].PossibleFillings.Length; i++)
            {
                DataRow row;
                row = table.NewRow();
                var temp = fillings[0].PossibleFillings[i];
                row[0] = $"{temp.StudyDay.NumberOfWeek}";
                row[1] = $"{temp.StudyDay.NameDayOfWeek}";
                row[2] = $"{temp.Pair.NumberThePair}";
                int stolb = 3;
                foreach (var filling in fillings)
                {
                    if (filling.PossibleFillings[i].BusyPair==null)
                    {
                        row[stolb] = "";
                    }
                    else
                    {
                        row[stolb] = filling.PossibleFillings[i].BusyPair.ToString().Substring(0,25);
                    }
                    
                    stolb++;
                }
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
