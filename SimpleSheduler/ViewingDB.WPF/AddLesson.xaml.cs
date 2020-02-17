using SimpleSheduler.BD;
using System.Collections.Generic;
using System.Windows;

namespace ViewingDB.WPF
{
    /// <summary>
    /// Логика взаимодействия для AddLesson.xaml
    /// </summary>
    public partial class AddLesson : Window
    {
        Group Group;
        Subject Subject;
        List<Curriculum> CurriculumForGroup;

        public AddLesson(Group group, Subject subject, List<Curriculum> curriculumForGroup)
        {
            Group = group;
            Subject = subject;
            CurriculumForGroup = curriculumForGroup;
            InitializeComponent();

            NameGroup.Text = Group.FullName.ToString();
            NameSubject.Text = Subject.FullName.ToString();
            TypeLesson.ItemsSource = WorkToMyDbContext.typeOfClasses;
            ssw.
            ssw.Value = 0;
            ssw.LargeChange = 1;
            ssw.Maximum = 100;
            ssw.ValueChanged += Ssw_ValueChanged;
            NameLesson.Text = ssw.Value.ToString();
            
            //TypeOfClass.ItemsSource = WorkToMyDbContext.typeOfClasses;
            
        }

        private void Ssw_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            NameLesson.Text = ssw.Value.ToString();
        }
    }
}
