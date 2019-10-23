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
        readonly GetDataFromBD getDataFromBD = new GetDataFromBD();
        List<Filling<Group>> fillingGroups;
        List<Filling<Classroom>> fillingClassrooms;
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
            string sNamespace = typeof(StudyDay).FullName;
            var table = getDataFromBD.GetDateTableBD(sNamespace);
            OpenGridBD(table);
        }

        private void ButtonOpenPair_Click(object sender, RoutedEventArgs e)
        {
            string sNamespace = typeof(Pair).FullName;
            var table = getDataFromBD.GetDateTableBD(sNamespace);
            OpenGridBD(table);
        }

        private void ButtonOpenClassroom_Click(object sender, RoutedEventArgs e)
        {
            string sNamespace = typeof(Classroom).FullName;
            var table = getDataFromBD.GetDateTableBD(sNamespace);
            var outClassList = OpenGridBD(table, true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSave_Click(sender1, EventArgs1, outClassList); };
        }

        private void ButtonOpenSubject_Click(object sender, RoutedEventArgs e)
        {
            string sNamespace = typeof(Subject).FullName;
            var table = getDataFromBD.GetDateTableBD(sNamespace);
            OpenGridBD(table);
        }
        
        private void ButtonOpenCurricila_Click(object sender, RoutedEventArgs e)
        {
            string sNamespace = typeof(Curriculum).FullName;
            var table = getDataFromBD.GetDateTableBD(sNamespace);
            var outClassList =  OpenGridBD(table,true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSave_Click(sender1, EventArgs1, outClassList); };
        }
        private void ButtonOpenGroup_Click(object sender, RoutedEventArgs e)
        {
            string sNamespace = typeof(Group).FullName;
            var table = getDataFromBD.GetDateTableBD(sNamespace);

            var outClassList = OpenGridBD(table,true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSave_Click(sender1, EventArgs1, outClassList); }; 
            
        }


        private void ButtonGetDataFromBD_Click(object sender, RoutedEventArgs e)
        {
            getDataFromBD.ReadDB();
            string ret = "";
            ret += $"Количество:\n";
            ret += $"Аудиторий={getDataFromBD.classrooms.Count}, ";
            ret += $"Групп={getDataFromBD.groups.Count}, ";
            ret += $"Предметов={getDataFromBD.subjects.Count}, ";
            ret += $"В плане={getDataFromBD.curricula.Count}, ";
            ret += $"Пар в день={getDataFromBD.pairs.Count}, ";
            ret += $"Учебных дней за 2 недели={getDataFromBD.studyDays.Count}.";
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
       
        
        private OutClassList OpenGridBD(DataTable collection, bool save = false)
        {
            OutClassList outGroup = new OutClassList();
            outGroup.DataTable = collection;
            outGroup.ButtonSave.IsEnabled = save;
            outGroup.Show();
            return outGroup;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e, OutClassList outClassList)
        {
            getDataFromBD.SetBD(outClassList.DataTable);
            
        }

        private DataTable GetDateTableFilling<T>(List<Filling<T>> fillings) where T : class, IName
        {
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "NumberOfWeek",
                    Caption = "Номер недели"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    ColumnName = "NameDayOfWeek",
                    Caption = "День недели"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "NumberThePair",
                    Caption = "Номер Пары"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                foreach (var filling in fillings)
                {
                    column = new DataColumn
                    {
                        DataType = typeof(BusyPair),
                        ColumnName = $"{filling.Value.NameString()}",
                        Caption = $"{filling.Value.NameString()}"
                    };
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                }
            }
            for (int i = 0; i < fillings[0].PossibleFillings.Count; i++)
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
                    row[stolb] = filling.PossibleFillings[i].BusyPair;
                    stolb++;
                }
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
