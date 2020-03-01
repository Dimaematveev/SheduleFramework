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

namespace SimpleSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для NotPlan.xaml
    /// </summary>
    public partial class NotPlan : Window 
    {
        public NotPlan(object sourse)
        {
            
            InitializeComponent();
            DatagridItems.ItemsSource =(IEnumerable<Curriculum>)sourse;
            DatagridItems.BeginInit();
            DatagridItems.EndInit(); 

        }
    }
}
