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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleSheduler.WPF.BL;

namespace SimpleSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Данные из БД
        GetDataFromBD getDataFromBD = new GetDataFromBD();
        public MainWindow()
        {
            GetDataFromBD.RepositoryBase();
            InitializeComponent();
            ButtonGetDataFromBD.Click += ButtonGetDataFromBD_Click;
            ButtonOpenGroup.Click += ButtonOpenGroup_Click;
        }

        private void ButtonGetDataFromBD_Click(object sender, RoutedEventArgs e)
        {
            getDataFromBD.ReadDB();
            string ret = "";
            ret += $"Количество:\n";
            ret += $"Аудиторий={getDataFromBD.classrooms.Length}, ";
            ret += $"Групп={getDataFromBD.groups.Length}, ";
            ret += $"Предметов={getDataFromBD.subjects.Length}, ";
            ret += $"В плане={getDataFromBD.curricula.Length}, ";
            ret += $"Пар в день={getDataFromBD.pairs.Length}, ";
            ret += $"Учебных дней за 2 недели={getDataFromBD.studyDays.Length}.";
            TexboxFromBD.Text = ret;
        }
        private void ButtonOpenGroup_Click(object sender, RoutedEventArgs e)
        {
            OutGroup outGroup = new OutGroup();
            outGroup.List = getDataFromBD.groups.Select(x=>(object)x).ToList();
            outGroup.ShowDialog();

        }
    }
}
