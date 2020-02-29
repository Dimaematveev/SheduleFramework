using System;
using System.Globalization;
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

namespace MainSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime? Begin = null;
        DateTime? End = null;
        HelperDate helperDate;
        public MainWindow()
        {
            InitializeComponent();
            Begin = new DateTime(2020, 2, 01);
            End = new DateTime(2020, 2, 28);
            DatePickerBegin.Text = Begin.Value.ToShortDateString();
            DatePickerEnd.Text = End.Value.ToShortDateString();

            DatePickerBegin.SelectedDateChanged += DatePickerBegin_SelectedDateChanged;
            DatePickerEnd.SelectedDateChanged += DatePickerEnd_SelectedDateChanged;
            ButtonOK.Click += ButtonOK_Click;

                       
        }

        private void DatePickerBegin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Begin = ((DatePicker)e.OriginalSource).SelectedDate;
        }

        private void DatePickerEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            End = ((DatePicker)e.OriginalSource).SelectedDate;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            helperDate = new HelperDate(Begin.Value, End.Value);
            str += "Количество";
            str += $"\nПериод с {Begin.Value.ToShortDateString()} по {End.Value.ToShortDateString()}";
            str += "\nДней: ";
            str += $"{helperDate.CountDays}";
            str += "\nНедель: ";
            str += $"{helperDate.CountWeek}";
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                str += $"\n{day}: ";
                str += $"{helperDate.CountDayOfWeek[day]}";
            }
           
            
            MessageBox.Show(str);

            Calendar1.DisplayDateStart = Begin;
            Calendar1.DisplayDateEnd = End;
            Calendar1.SelectionMode = CalendarSelectionMode.MultipleRange;
            Calendar1.MouseRightButtonUp += Calendar1_MouseRightButtonUp;


            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemWorkDay = new MenuItem();
            menuItemWorkDay.Header = "Рабочие дни";
            MenuItem menuItemDayOff = new MenuItem();
            menuItemDayOff.Header = "Выходные дни";
            MenuItem menuItemReducedDay = new MenuItem();
            menuItemReducedDay.Header = "Сокращенные дни";
            for (int i = 1; i <= 6; i++)
            {
                MenuItem menuItemReducedDayCountPair = new MenuItem();
                menuItemReducedDayCountPair.Header = $"{i}";
                menuItemReducedDay.Items.Add(menuItemReducedDayCountPair);
            }
            contextMenu.Items.Add(menuItemWorkDay);
            contextMenu.Items.Add(menuItemDayOff);
            contextMenu.Items.Add(menuItemReducedDay);
            Calendar1.ContextMenu = contextMenu;
            Calendar1.SelectedDates.
        }

        private void Calendar1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            
        }
    }
    
}
