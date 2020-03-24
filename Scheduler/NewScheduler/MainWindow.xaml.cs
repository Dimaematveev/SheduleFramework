using SQL;
using System.Linq;
using System.Windows;

namespace NewScheduler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonOn.Click += (sender,e)=> { ButtonOn_Click(); };


            ButtonOn_Click();
        }

        private void ButtonOn_Click()
        {
            using (ShedEntities db = new ShedEntities())
            {
                var classroms = db.Classrooms.ToList();

                int maxNumberOfSeatsOfClassrooms = classroms.Max(x => x.NumberOfSeats);

                var unionsGroups = new UnionsGroups(db.Groups.ToList(),maxNumberOfSeatsOfClassrooms);


                TextBoxMaxClassroom.Text=$"Max classrooms={classroms.Max(x=>x.NumberOfSeats).ToString()}";

               
                TextBoxUnion.Text=$"{unionsGroups.ToString()}";

            }
        }
    }
}
