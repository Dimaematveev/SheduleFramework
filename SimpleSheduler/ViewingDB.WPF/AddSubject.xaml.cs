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
    public partial class AddSubject : Window
    {
        public int ID { get; private set; }
        public AddSubject(string nameSubject)
        {
            InitializeComponent();
            SubjectName.Text = nameSubject;
            SokrSubjectName.Text = "";
            Add.Click += (sender, e) => { GroupAdd(); };
        }


        private void GroupAdd()
        {
            string notWork = "";
            if (string.IsNullOrWhiteSpace(SubjectName.Text)) 
            {
                notWork += $"{nameof(SubjectName)} is null\n";
            }
            if (string.IsNullOrWhiteSpace(SokrSubjectName.Text))
            {
                notWork += $"{nameof(SokrSubjectName)} is null\n";
            }
          

            if (notWork == "")
            {
                MessageBox.Show("Work");
                var subject = new Subject()
                {
                    FullName = SubjectName.Text,
                    Abbreviation = SokrSubjectName.Text,
                    SubjectId = WorkToMyDbContext.subjects.Max(x => x.SubjectId) + 1
                };
                WorkToMyDbContext.subjects.Add(subject);
                WorkToMyDbContext.SaveDB();
                ID = subject.SubjectId;
            }
            else
            {
                notWork = "Не добавится группа пока: \n" + notWork;
                MessageBox.Show(notWork);
            }


           
        }
    }
}
