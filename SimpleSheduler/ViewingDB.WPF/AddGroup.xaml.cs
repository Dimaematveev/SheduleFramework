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
            if (string.IsNullOrWhiteSpace(GroupName.Text))
            {
                notWork += $"{nameof(GroupName)} is null\n";
            }
            if (string.IsNullOrWhiteSpace(SokrGroupName.Text))
            {
                notWork += $"{nameof(SokrGroupName)} is null\n";
            }
            if (string.IsNullOrWhiteSpace(Potok.Text))
            {
                notWork += $"{nameof(Potok)} is null\n";
            }
            if (string.IsNullOrWhiteSpace(Seminar.Text))
            {
                notWork += $"{nameof(Seminar)} is null\n";
            }
            if (string.IsNullOrWhiteSpace(NumberPeople.Text))
            {
                notWork += $"{nameof(NumberPeople)} is null\n";
            }


            if (notWork == "")
            {
               
               
                if (WorkToMyDbContext.groups==null || WorkToMyDbContext.groups.Count==0)
                {
                    ID = 1;
                }
                else
                {
                    ID = WorkToMyDbContext.groups.Max(x => x.GroupId) + 1;
                }
                
                var group = new Group()
                {
                    FullName = GroupName.Text,
                    Abbreviation = SokrGroupName.Text,
                    Potok = Potok.Text,
                    Seminar = Seminar.Text,
                    NumberOfPersons = Convert.ToInt32(NumberPeople.Text),
                    GroupId = ID
                };
                WorkToMyDbContext.groups.Add(group);
                WorkToMyDbContext.SaveDB(typeof(Group).FullName);

                Close();
            }
            else
            {
                notWork = "Не добавится группа пока: \n" + notWork;
                MessageBox.Show(notWork);
            }


           
        }
    }
}
