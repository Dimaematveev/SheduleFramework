using System;
using System.Collections.Generic;
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
        private DateTime? Begin = null;
        private DateTime? End = null;
        private HelperDate helperDate;
        PairsToDays pairsToDays;

        
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
        


            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemWorkDay = new MenuItem();
            menuItemWorkDay.Header = "Рабочие дни";
            menuItemWorkDay.Click += MenuItemWorkDay_Click;
            MenuItem menuItemDayOff = new MenuItem();
            menuItemDayOff.Header = "Выходные дни";
            menuItemDayOff.Click += MenuItemDayOff_Click;
            MenuItem menuItemReducedDay = new MenuItem();
            menuItemReducedDay.Header = "Сокращенные дни";
            for (int i = 1; i <= 6; i++)
            {
                int z = i;
                MenuItem menuItemReducedDayCountPair = new MenuItem();
                menuItemReducedDayCountPair.Header = $"Кол-во пар: {z}";
                menuItemReducedDayCountPair.Click += (sender1, EventArgs1) => { MenuItemReducedDayCountPair_Click(z); };
                menuItemReducedDay.Items.Add(menuItemReducedDayCountPair);
            }
            contextMenu.Items.Add(menuItemWorkDay);
            contextMenu.Items.Add(menuItemDayOff);
            contextMenu.Items.Add(menuItemReducedDay);
            Calendar1.ContextMenu = contextMenu;

            pairsToDays = new PairsToDays(Begin.Value, End.Value, 6);
            
            UpdateAllListView();
        }

        private void MenuItemReducedDayCountPair_Click(int count)
        {
            pairsToDays.ResetDays(Calendar1.SelectedDates, count);
            UpdateAllListView();
        }

        private void MenuItemDayOff_Click(object sender, RoutedEventArgs e)
        {
            pairsToDays.ResetDays(Calendar1.SelectedDates, 0);
            UpdateAllListView();
        }

        private void MenuItemWorkDay_Click(object sender, RoutedEventArgs e)
        {
            pairsToDays.ResetDays(Calendar1.SelectedDates, null);
            UpdateAllListView();
        }

        private void UpdateAllListView()
        {
            ListViewWorkDay.BeginInit();
            ListViewWorkDay.ItemsSource = pairsToDays.WorkDay;
            ListViewWorkDay.EndInit();
            ListViewReducedDay.BeginInit();
            ListViewReducedDay.ItemsSource = pairsToDays.ReducedDay;
            ListViewReducedDay.EndInit();
            ListViewDayOff.BeginInit();
            ListViewDayOff.ItemsSource = pairsToDays.DayOff;
            ListViewDayOff.EndInit();
        }

    }
    
}
