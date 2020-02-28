using SimpleSheduler.BD;
using System;
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
            NameLesson.Text = "0";
            TypeLesson.ItemsSource = WorkToMyDbContext.typeOfClasses;
            ssw.Value = 10;
            ssw.Maximum = 10;
            ssw.ValueChanged += Ssw_ValueChanged;
            
            //TypeOfClass.ItemsSource = WorkToMyDbContext.typeOfClasses;
            
        }

        private void Ssw_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //В какую сторону изменилось значение
            var raz = Prov(e.OldValue, e.NewValue);

            NameLesson.Text = (Convert.ToInt32(NameLesson.Text) + raz).ToString();
        }
        //a1>a2 то 1 иначе -1 если равны 0
        private int Prov(double a1, double a2)
        {
            if (a1 > a2)
            {
                return 1;
            }
            else if (a1 < a2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
