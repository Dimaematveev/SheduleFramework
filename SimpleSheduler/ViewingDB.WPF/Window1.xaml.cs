using SimpleSheduler.BD;
using System.Collections.Generic;
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
        }

        public void GetCuriculaForGroup()
        {
            CurriculumForGroup = new List<Curriculum>();
            CurriculumForGroup = WorkToMyDbContext.curricula.FindAll(x => x.Group.Equals(Group) && x.Subject.Equals(Subject));
        }
    }
}
