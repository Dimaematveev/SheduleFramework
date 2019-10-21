using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
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

namespace SimpleSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для OutFilling.xaml
    /// </summary>
    public partial class OutFilling : Window
    {
        public List<object> List;
        public OutFilling()
        {
            InitializeComponent();
            Loaded += OutFilling_Loaded;
        }

        private void OutFilling_Loaded(object sender, RoutedEventArgs e)
        {
            List<PossibleFilling[]> possibleFillings = List.Select(x => ((Filling<IName>)x).PossibleFillings).ToList();

            DataGridFilling.ItemsSource = possibleFillings;
        }
    }
}
