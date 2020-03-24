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


                TextBoxMaxClassroom.Text=$"Max classrooms={classroms.Max(x=>x.NumberOfSeats)}";

               
                TextBoxUnionAll.Text=$"{unionsGroups}";
                var unionsGroupsSeminar = unionsGroups.FilterUnionGroups(FilterSeminar);
                TextBoxUnionFilterSeminar.Text=$"{unionsGroupsSeminar}";
                var unionsGroupsPotok = unionsGroups.FilterUnionGroups(FilterPotok);
                TextBoxUnionFilterPotok.Text = $"{unionsGroupsPotok}";




            }
        }

        bool FilterSeminar(Groups gr1, Groups gr2)
        {
            return gr1.Seminar == gr2.Seminar;
        }
        bool FilterPotok(Groups gr1, Groups gr2)
        {
            return gr1.Potok == gr2.Potok;
        }
    }
}
