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
        CreateScheduler createScheduler1;
        public MainWindow()
        {
            GetDataFromBD.RepositoryBase();
            InitializeComponent();
            ButtonGetDataFromBD.Click += ButtonGetDataFromBD_Click;
           
            ButtonOpenClassroom.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(sender1, EventArgs1, typeof(Classroom).FullName); };
            ButtonOpenSubject.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(sender1, EventArgs1, typeof(Subject).FullName); };
            ButtonOpenCurricila.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(sender1, EventArgs1, typeof(Curriculum).FullName); };
            ButtonOpenGroup.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(sender1, EventArgs1, typeof(Group).FullName); };
            ButtonOpenPair.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(sender1, EventArgs1, typeof(Pair).FullName); };
            ButtonOpenStudyDay.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(sender1, EventArgs1, typeof(StudyDay).FullName); };



            GetFilling.Click += GetFilling_Click;
            SetFillingClassrooms.Click += SetFillingClassrooms_Click;
            SetFillingGroups.Click += SetFillingGroups_Click;
            CreateScheduler.Click += CreateScheduler_Click;

            GetFillingClassrooms.Click += GetFillingClassrooms_Click; ;
            GetFillingGroups.Click += GetFillingGroups_Click; ;
            this.Loaded += MainWindow_Loaded;
        }

        private void GetFillingGroups_Click(object sender, RoutedEventArgs e)
        {
            var table = GetDateTableFilling(createScheduler1.FillingGroups, false);
            table.TableName = "Заполнение Групп";
            OpenGridBD(table);
        }

        private void GetFillingClassrooms_Click(object sender, RoutedEventArgs e)
        {
            var table = GetDateTableFilling(createScheduler1.FillingClassrooms, false);
            table.TableName = "Заполнение Аудиторий";
            OpenGridBD(table);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonGetDataFromBD_Click(sender,e);
            GetFilling_Click(sender, e);
            CreateScheduler_Click(sender, e);
        }

        private void CreateScheduler_Click(object sender, RoutedEventArgs e)
        {
            createScheduler1 = new CreateScheduler(getDataFromBD.groups, getDataFromBD.classrooms, getDataFromBD.subjects, getDataFromBD.curricula, fillingGroups, fillingClassrooms);

            GetFillingClassrooms.IsEnabled = true;
            GetFillingGroups.IsEnabled = true;
        }

        private void SetFillingGroups_Click(object sender, RoutedEventArgs e)
        {
            var table = GetDateTableFilling(fillingGroups,true);
            table.TableName = "Заполнение Групп";
            table.Namespace = typeof(Filling<Group>).FullName;
            var outClassList = OpenGridBD(table, true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSaveFilling_Click(sender1, EventArgs1, outClassList); };
        }
        private void SetFillingClassrooms_Click(object sender, RoutedEventArgs e)
        {
            var table = GetDateTableFilling(fillingClassrooms,true);
            table.TableName = "Заполнение Аудиторий";
            table.Namespace = typeof(Filling<Classroom>).FullName;
            var outClassList = OpenGridBD(table, true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSaveFilling_Click(sender1, EventArgs1, outClassList); };

        }
        
        private void GetFilling_Click(object sender, RoutedEventArgs e)
        {
            fillingGroups = GetFillingClass.GetFilling(getDataFromBD.groups, getDataFromBD.pairs, getDataFromBD.studyDays);
            fillingClassrooms = GetFillingClass.GetFilling(getDataFromBD.classrooms, getDataFromBD.pairs, getDataFromBD.studyDays);
            //TODO: Сделать так чтобы просто при передаче обновлялись поля в новосозданной в CreateScheduler
           // Сдесь только 1 и 0 по возможности занятости аудитории!!!! и группы соответстве
            SetFillingClassrooms.IsEnabled = true;
            SetFillingGroups.IsEnabled = true;
            CreateScheduler.IsEnabled = true;

        }


        private void ButtonOpenBD_Click(object sender, RoutedEventArgs e, string sNamespace)
        {
            var table = getDataFromBD.GetDateTableBD(sNamespace);
            var outClassList = OpenGridBD(table, true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSaveBD_Click(sender1, EventArgs1, outClassList); };
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

        private void ButtonSaveBD_Click(object sender, RoutedEventArgs e, OutClassList outClassList)
        {
            getDataFromBD.SetBD(outClassList.DataTable);
            
        }

        private void ButtonSaveFilling_Click(object sender, RoutedEventArgs e, OutClassList outClassList)
        {
            SetDateTableFilling(outClassList.DataTable);


        }

        private DataTable GetDateTableFilling<T>(List<Filling<T>> fillings , bool set = true) where T : class, IName
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
                    if (set)
                    {
                        column = new DataColumn
                        {

                            DataType = typeof(string),
                            ColumnName = $"{filling.Value.NameString()}",
                            Caption = $"{filling.Value.NameString()}"
                        };
                    }
                    else
                    {
                        column = new DataColumn
                        {

                            DataType = typeof(BusyPair),
                            ColumnName = $"{filling.Value.NameString()}",
                            Caption = $"{filling.Value.NameString()}"
                        };
                    }
                    
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
                    if (set)
                    {
                        string IsPair;
                        var BusyPair = filling.PossibleFillings[i].BusyPair;
                        IsPair = BusyPair == null ? null : BusyPair.Subject.Name;
                        row[stolb] = IsPair;
                    }
                    else
                    {
                        row[stolb] = filling.PossibleFillings[i].BusyPair;
                    }
                       
                    stolb++;
                }
                table.Rows.Add(row);
            }
            return table;
        }


        private void SetDateTableFilling(DataTable dataTable)
        {
            if (dataTable.Namespace == typeof(Filling<Group>).FullName)
            {
                SetDateTableFilling(dataTable, fillingGroups);
            }
            if (dataTable.Namespace == typeof(Filling<Classroom>).FullName)
            {
                SetDateTableFilling(dataTable, fillingClassrooms);
            }
        }

        private void SetDateTableFilling<T>(DataTable dataTable, List<Filling<T>> fillings) where T:class,IName
        {
            
            for (int i = 0; i < fillings.Count; i++)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    BusyPair busyPair;
                    if (dataTable.Rows[j][3 + i].ToString() == "")
                    {
                        busyPair = null;
                    }
                    else
                    {
                        busyPair = new BusyPair(new Classroom(), new Subject() { Name = (string)dataTable.Rows[j][3 + i] }, new Group());
                    }
                    fillings[i].PossibleFillings[j].BusyPair = busyPair;
                }
               
            }
            
        }
    }
}
