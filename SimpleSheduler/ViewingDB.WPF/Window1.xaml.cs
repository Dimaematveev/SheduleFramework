using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
