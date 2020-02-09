using SimpleSheduler.BD;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ViewingDB.WPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Group Group;
        Subject Subject;
        List<Curriculum> CurriculumForGroup;
        public Window1(Group group, Subject subject)
        {
            Group = group;
            Subject = subject;
            
            InitializeComponent();
            NameGroup.Text = Group.FullName.ToString();
            NameSubject.Text = Subject.FullName.ToString();
            TypeOfClass.ItemsSource = WorkToMyDbContext.typeOfClasses;
            GetCuriculaForGroup();
            GridCurriculum.ItemsSource = CurriculumForGroup;

           // GridCurriculum.AddingNewItem += GridCurriculum_AddingNewItem;
           // GridCurriculum.InitializingNewItem += GridCurriculum_InitializingNewItem;
           
        }

        private void GridCurriculum_InitializingNewItem(object sender, System.Windows.Controls.InitializingNewItemEventArgs e)
        {
            MessageBox.Show("Test2");
        }

        private void GridCurriculum_AddingNewItem(object sender, System.Windows.Controls.AddingNewItemEventArgs e)
        {
            Curriculum curriculum = new Curriculum();
            curriculum.CurriculumId = WorkToMyDbContext.curricula.Max(x => x.CurriculumId) + 1;
            curriculum.Group = Group;
            curriculum.Subject = Subject;
            WorkToMyDbContext.curricula.Add(curriculum);
            CurriculumForGroup.Add(curriculum);
        }

        public void GetCuriculaForGroup()
        {
            CurriculumForGroup = new List<Curriculum>();
            CurriculumForGroup = WorkToMyDbContext.curricula.FindAll(x => x.Group.Equals(Group) && x.Subject.Equals(Subject));
        }
    }
}
