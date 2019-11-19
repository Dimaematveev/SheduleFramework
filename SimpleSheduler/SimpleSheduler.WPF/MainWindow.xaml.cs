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
        readonly private GetDataFromBD getDataFromBD = new GetDataFromBD();
        //Данные по заполнению
        private GetFillingClass getFillingClass;
       
        CreateScheduler createScheduler1;
        public MainWindow()
        {
            GetDataFromBD.RepositoryBase();
            InitializeComponent();
            ButtonGetDataFromBD.Click += ButtonGetDataFromBD_Click;

            ButtonOpenClassroom.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(Classroom).FullName); };
            ButtonOpenSubject.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(Subject).FullName); };
            ButtonOpenCurricila.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(Curriculum).FullName); };
            ButtonOpenGroup.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(Group).FullName); };
            ButtonOpenPair.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(Pair).FullName); };
            ButtonOpenStudyDay.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(StudyDay).FullName); };
            ButtonOpenTypeUnionGroup.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(TypeUnionGroup).FullName); };
            ButtonOpenTypeOfClasses.Click += (sender1, EventArgs1) => { ButtonOpenBD_Click(typeof(TypeOfClasses).FullName); };



            GetFilling.Click += GetFilling_Click;
            SetFillingClassrooms.Click += (sender1, EventArgs1) => { SetFilling_Click(typeof(Filling<Classroom>).FullName); };
            SetFillingGroups.Click += (sender1, EventArgs1) => { SetFilling_Click(typeof(Filling<Group>).FullName); };
            CreateScheduler.Click += CreateScheduler_Click;
            GetFillingClassrooms.Click += (sender1, EventArgs1) => { GetFillingFromScheduler_Click(typeof(Filling<Classroom>).FullName); };
            GetFillingGroups.Click += (sender1, EventArgs1) => { GetFillingFromScheduler_Click(typeof(Filling<Group>).FullName); };

            PlanNotScheduler.Click += (sender1, EventArgs1) => { ShowMess(); };
            this.Loaded += MainWindow_Loaded;
        }

       

        /// <summary>
        /// Для упрощения процесса запущу сразу
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //getDataFromBD.AddNewBD();
            ButtonGetDataFromBD_Click(sender,e);
            GetFilling_Click(sender, e);
            //CreateScheduler_Click(sender, e);
        }

        /// <summary>
        /// В начале какие кнопки активны
        /// </summary>
        private void ButtonEnable_Start()
        {
            ButtonOpenGroup.IsEnabled = false;
            ButtonOpenClassroom.IsEnabled = false;
            ButtonOpenSubject.IsEnabled = false;
            ButtonOpenCurricila.IsEnabled = false;
            GetFilling.IsEnabled = false;
            SetFillingGroups.IsEnabled = false;
            SetFillingClassrooms.IsEnabled = false;
            ButtonOpenPair.IsEnabled = false;
            ButtonOpenStudyDay.IsEnabled = false;
            CreateScheduler.IsEnabled = false;
            GetFillingGroups.IsEnabled = false;
            GetFillingClassrooms.IsEnabled = false;
        }

        /// <summary>
        /// Подключение к базе и считывание из нее информации. 
        /// Также дает доступ к кнопкам показывающие БД.
        /// Инициализация Заполнения
        /// </summary>
        private void ButtonGetDataFromBD_Click(object sender, RoutedEventArgs e)
        {
            getDataFromBD.ReadDB();
            getFillingClass = new GetFillingClass();
            string ret = "";
            ret += $"Количество:\n";
            ret += $"Аудиторий={getDataFromBD.classrooms.Count}, ";
            ret += $"Групп={getDataFromBD.groups.Count}, ";
            ret += $"Предметов={getDataFromBD.subjects.Count}, ";
            ret += $"В плане={getDataFromBD.curricula.Count}, ";
            ret += $"Пар в день={getDataFromBD.pairs.Count}, ";
            ret += $"Учебных дней за 2 недели={getDataFromBD.studyDays.Count}.";
            TexboxFromBD.Text = ret;

            ButtonEnable_ButtonGetDataFromBD_Click();
        }

        private void ButtonEnable_ButtonGetDataFromBD_Click()
        {
            ButtonEnable_Start();

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
            if (getDataFromBD.typeUnionGroups != null)
            {
                ButtonOpenTypeUnionGroup.IsEnabled = true;
            }
            if (getDataFromBD.typeOfClasses != null)
            {
                ButtonOpenTypeOfClasses.IsEnabled = true;
            }
            if (getDataFromBD.groups != null && getDataFromBD.classrooms != null && getDataFromBD.pairs != null && getDataFromBD.studyDays != null)
            {
                GetFilling.IsEnabled = true;
            }
        }
        /// <summary>
        /// Открытие для изменения Таблиц из БД.
        /// </summary>
        /// <param name="sNamespace"> typeof(Class).FullName Полное имя класса который будем показывать </param>
        private void ButtonOpenBD_Click(string sNamespace)
        {
            var myDataGrid = getDataFromBD.GetDateGridBD(sNamespace);
            var myDataGridProperty = getDataFromBD.GetDateGridPropertyBD(sNamespace);

            var outClassList = OpenGridBD(myDataGrid, myDataGridProperty, true);
            //Кнопке save приписываем действие
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSaveBD_Click(sNamespace); };
        }



        /// <summary>
        /// Показывает DataTable  в новом окне 
        /// </summary>
        /// <param name="dataGrid">DataGrid которую стоит показать</param>
        /// <param name="myDataGridProperty"> Параметры показа DataGrid</param>
        /// <param name="save">Активна ли кнопка сохранить. False - не активна, True- активна</param>
        /// <returns> Ссылка на открытое окно</returns>
        private OutClassList OpenGridBD(System.Windows.Controls.DataGrid dataGrid, MyDataGridProperty myDataGridProperty, bool save = false)
        {
            OutClassList outGroup = new OutClassList();
            outGroup.DataGrid = dataGrid;
            outGroup.MyDataGridProperty = myDataGridProperty;
            outGroup.ButtonSave.IsEnabled = save;
            outGroup.Show();
            return outGroup;
        }

        /// <summary>
        /// Показывает DataTable  в новом окне 
        /// </summary>
        /// <param name="collection">Таблица которую стоит показать</param>
        /// <param name="save">Активна ли кнопка сохранить. False - не активна, True- активна</param>
        /// <returns> Ссылка на открытое окно</returns>
        private OutClassList OpenGridBD(DataTable collection, bool save = false)
        {
            OutClassList outGroup = new OutClassList();
            outGroup.DataTable = collection;
            outGroup.ButtonSave.IsEnabled = save;
            outGroup.Show();
            return outGroup;
        }

        /// <summary>
        /// Действие кнопки Save в открытом окне
        /// </summary>
        private void ButtonSaveBD_Click(string sNamespace)
        {
            getDataFromBD.Save(sNamespace);
        }

        /// <summary>
        /// Инициализировать GetFillingClass из БД. 
        /// Дать возможность посмотреть и отредактировать Заполнение.
        /// Дать возможность создать расписание.
        /// </summary>
        private void GetFilling_Click(object sender, RoutedEventArgs e)
        {
            getFillingClass.GetFilling(getDataFromBD);
            ButtonEnable_GetFilling_Click();

        }
        private void ButtonEnable_GetFilling_Click()
        {
            ButtonEnable_ButtonGetDataFromBD_Click();
            SetFillingClassrooms.IsEnabled = true;
            SetFillingGroups.IsEnabled = true;
            CreateScheduler.IsEnabled = true;
        }

        /// <summary>
        /// Возможность изменить заполнение аудиторий
        /// </summary>
        private void SetFilling_Click(string sNamespace)
        {
            var table = getFillingClass.GetDateTableFilling(sNamespace);
            
            var outClassList = OpenGridBD(table, true);
            outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSaveFilling_Click(outClassList); };

        }

        /// <summary>
        ///  Действие кнопки Save в открытом окне Заполнения
        /// </summary>
        /// <param name="outClassList">Окно</param>
        private void ButtonSaveFilling_Click(OutClassList outClassList)
        {
            getFillingClass.SetDateTableFilling(outClassList.DataTable);


        }

        /// <summary>
        /// Создание рассписания на основе данных из БД и заполнения.
        /// Дает возможеость посмотреть составленное расписание.
        /// </summary>
        private void CreateScheduler_Click(object sender, RoutedEventArgs e)
        {
            createScheduler1 = new CreateScheduler(getDataFromBD.groups, getDataFromBD.classrooms, getDataFromBD.subjects, getDataFromBD.curricula, getFillingClass.fillingGroups, getFillingClass.fillingClassrooms);
            if (createScheduler1.NotUnion.Length>0)
            {
                ShowMess();
            }

            ButtonEnable_CreateScheduler_Click();
        }

        /// <summary>
        /// Показывает сообщение с планами не в расписании
        /// </summary>
        private void ShowMess()
        {
            string mess = "";
            foreach (var item in createScheduler1.NotUnion)
            {
                mess += item.ToString();
                mess += "\n";
            }
            System.Windows.MessageBox.Show(mess, "Не смог внести в расписание!", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void ButtonEnable_CreateScheduler_Click()
        {
            ButtonEnable_GetFilling_Click();
            GetFillingClassrooms.IsEnabled = true;
            GetFillingGroups.IsEnabled = true;
            PlanNotScheduler.IsEnabled = true;
        }


        /// <summary>
        /// Возможность посмотреть заполнение аудиторий в созданном рассписании
        /// </summary>
        private void GetFillingFromScheduler_Click(string sNamespace)
        {
            var table = getFillingClass.GetDateTableFilling(sNamespace, createScheduler1);

            var outClassList = OpenGridBD(table, false);
        }



    }
}
