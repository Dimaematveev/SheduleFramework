using SimpleSheduler.BD;
using SimpleSheduler.BL;
using SimpleSheduler.WPF.BL;
using System.Windows;

namespace SimpleSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        //Данные из БД
        //WorkToMyDbContext
        //Данные по заполнению
        private GetFillingClass getFillingClass;
       
        CreateScheduler createScheduler1;
        public MainWindow()
        {
            WorkToMyDbContext.RepositoryBase();
            InitializeComponent();
            ButtonGetDataFromBD.Click += ButtonGetDataFromBD_Click;

            GetFilling.Click += GetFilling_Click;
           // SetFillingClassrooms.Click += (sender1, EventArgs1) => { SetFilling_Click(typeof(Filling<Classroom>).FullName); };
           // SetFillingGroups.Click += (sender1, EventArgs1) => { SetFilling_Click(typeof(Filling<Group>).FullName); };
            CreateScheduler.Click += CreateScheduler_Click;
          //  GetFillingClassrooms.Click += (sender1, EventArgs1) => { GetFillingFromScheduler_Click(typeof(Filling<Classroom>).FullName); };
          //  GetFillingGroups.Click += (sender1, EventArgs1) => { GetFillingFromScheduler_Click(typeof(Filling<Group>).FullName); };

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
            CreateScheduler_Click(sender, e);
        }

        /// <summary>
        /// В начале какие кнопки активны
        /// </summary>
        private void ButtonEnable_Start()
        {

            GetFilling.IsEnabled = false;
            SetFillingGroups.IsEnabled = false;
            SetFillingClassrooms.IsEnabled = false;
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
            WorkToMyDbContext.ReadDB();
            getFillingClass = new GetFillingClass();
            string ret = "";
            ret += $"Количество:\n";
            ret += $"Аудиторий={WorkToMyDbContext.classrooms.Count}, ";
            ret += $"Групп={WorkToMyDbContext.groups.Count}, ";
            ret += $"Предметов={WorkToMyDbContext.subjects.Count}, ";
            ret += $"В плане={WorkToMyDbContext.curricula.Count}, ";
            ret += $"Пар в день={WorkToMyDbContext.pairs.Count}, ";
            ret += $"Учебных дней за 2 недели={WorkToMyDbContext.studyDays.Count}.";
            TexboxFromBD.Text = ret;

            ButtonEnable_ButtonGetDataFromBD_Click();
        }

        private void ButtonEnable_ButtonGetDataFromBD_Click()
        {
            ButtonEnable_Start();

            if (WorkToMyDbContext.groups != null && WorkToMyDbContext.classrooms != null && WorkToMyDbContext.pairs != null && WorkToMyDbContext.studyDays != null)
            {
                GetFilling.IsEnabled = true;
            }
        }
  
        /// <summary>
        /// Инициализировать GetFillingClass из БД. 
        /// Дать возможность посмотреть и отредактировать Заполнение.
        /// Дать возможность создать расписание.
        /// </summary>
        private void GetFilling_Click(object sender, RoutedEventArgs e)
        {
            getFillingClass.GetFilling();
            ButtonEnable_GetFilling_Click();

        }
        private void ButtonEnable_GetFilling_Click()
        {
            ButtonEnable_ButtonGetDataFromBD_Click();
            SetFillingClassrooms.IsEnabled = true;
            SetFillingGroups.IsEnabled = true;
            CreateScheduler.IsEnabled = true;
        }

        //TODO: это есть заполнение аудиторий
        ///// <summary>
        ///// Возможность изменить заполнение аудиторий
        ///// </summary>
        //private void SetFilling_Click(string sNamespace)
        //{
        //    var table = getFillingClass.GetDateTableFilling(sNamespace);
            
        //    var outClassList = OpenGridBD(table, true);
        //    outClassList.ButtonSave.Click += (sender1, EventArgs1) => { ButtonSaveFilling_Click(outClassList); };

        //}

     

        /// <summary>
        /// Создание рассписания на основе данных из БД и заполнения.
        /// Дает возможеость посмотреть составленное расписание.
        /// </summary>
        private void CreateScheduler_Click(object sender, RoutedEventArgs e)
        {
            createScheduler1 = new CreateScheduler(WorkToMyDbContext.groups, WorkToMyDbContext.classrooms, WorkToMyDbContext.subjects, WorkToMyDbContext.curricula, getFillingClass.fillingGroups, getFillingClass.fillingClassrooms);
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewingDB.WPF.MainWindow mainWindow = new ViewingDB.WPF.MainWindow();
            mainWindow.ShowDialog();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetFilling.WPF.MainWindow mainWindow = new SetFilling.WPF.MainWindow(createScheduler1);
            mainWindow.ShowDialog();
        }
    }
}
