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
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        public int ID { get; private set; }
        public AddGroup(string nameGroup, string potok, string seminar)
        {
            InitializeComponent();
            GroupName.Text = nameGroup;
            SokrGroupName.Text = nameGroup;
            Potok.Text = potok;
            Seminar.Text = seminar;
            ScrollBarNumberPeople.ValueChanged += ScrollBarNumberPeople_ValueChanged;
            Add.Click += (sender, e) => { GroupAdd(); };
        }

        private void ScrollBarNumberPeople_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            NumberPeople.Text = ScrollBarNumberPeople.Value.ToString();
        }

        private void GroupAdd()
        {
            string notWork = "";
            if (GroupName.Text == null || GroupName.Text == "") 
            {
                notWork += $"{nameof(GroupName)} is null\n";
            }
            if (SokrGroupName.Text == null || SokrGroupName.Text == "")
            {
                notWork += $"{nameof(SokrGroupName)} is null\n";
            }
            if (Potok.Text == null || Potok.Text == "")
            {
                notWork += $"{nameof(Potok)} is null\n";
            }
            if (Seminar.Text == null || Seminar.Text == "")
            {
                notWork += $"{nameof(Seminar)} is null\n";
            }
            if (NumberPeople.Text == null || NumberPeople.Text == "")
            {
                notWork += $"{nameof(NumberPeople)} is null\n";
            }


            if (notWork == "")
            {
                MessageBox.Show("Work");
                var group = new Group()
                {
                    FullName = GroupName.Text,
                    Abbreviation = SokrGroupName.Text,
                    Potok = Potok.Text,
                    Seminar = Seminar.Text,
                    NumberOfPersons = Convert.ToInt32(NumberPeople.Text),
                    GroupId = WorkToMyDbContext.groups.Max(x => x.GroupId) + 1
                };
                WorkToMyDbContext.groups.Add(group);
                WorkToMyDbContext.SaveDB();
                ID = group.GroupId;
            }
            else
            {
                notWork = "Не добавится группа пока: \n" + notWork;
                MessageBox.Show(notWork);
            }


           
        }
    }
}
