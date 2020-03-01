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
        private HelperDate helperDate;
        PairsToDays pairsToDays;

        
        public MainWindow()
        {
            InitializeComponent();
            DatePickerBegin.SelectedDate = new DateTime(2020, 2, 01);
            DatePickerEnd.SelectedDate = new DateTime(2020, 2, 28);
            ButtonOK.Click += ButtonOK_Click;
            ButtonProv.Click += ButtonProv_Click;
        }

        private void ButtonProv_Click(object sender, RoutedEventArgs e)
        {
            var DateRange = new List<DateTime>();
            DateRange.AddRange(pairsToDays.ReducedDay.Select(x => x.DatePair));
            DateRange.AddRange(pairsToDays.WorkDay.Select(x => x.DatePair));
            helperDate = new HelperDate(DateRange);
            TextBoxInfo.Text = helperDate.ToString();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {

            helperDate = new HelperDate(DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value);
            TextBoxInfo.Text = helperDate.ToString();

            Calendar1.DisplayDateStart = DatePickerBegin.SelectedDate;
            Calendar1.DisplayDateEnd = DatePickerEnd.SelectedDate;
            Calendar1.SelectionMode = CalendarSelectionMode.MultipleRange;



            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemWorkDay = new MenuItem();
            menuItemWorkDay.Header = "Рабочие дни";
            menuItemWorkDay.Click += (sender1, EventArgs1) => { MenuItemDayCountPair_Click(null); };
            MenuItem menuItemDayOff = new MenuItem();
            menuItemDayOff.Header = "Выходные дни";
            menuItemDayOff.Click += (sender1, EventArgs1) => { MenuItemDayCountPair_Click(0); };
            MenuItem menuItemReducedDay = new MenuItem();
            menuItemReducedDay.Header = "Сокращенные дни";
            for (int i = 1; i <= 6; i++)
            {
                int z = i;
                MenuItem menuItemReducedDayCountPair = new MenuItem();
                menuItemReducedDayCountPair.Header = $"Кол-во пар: {z}";
                menuItemReducedDayCountPair.Click += (sender1, EventArgs1) => { MenuItemDayCountPair_Click(z); };
                menuItemReducedDay.Items.Add(menuItemReducedDayCountPair);
            }
            contextMenu.Items.Add(menuItemWorkDay);
            contextMenu.Items.Add(menuItemDayOff);
            contextMenu.Items.Add(menuItemReducedDay);
            Calendar1.ContextMenu = contextMenu;

            pairsToDays = new PairsToDays(DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value, 6);

            UpdateAllListView();
        }

     

        /// <summary>
        /// Функия при нажимании на контекстное меню каледаря
        /// </summary>
        /// <param name="count"> кол-во пар, 0- выходной, null-полный день, число кол-во пар</param>
        private void MenuItemDayCountPair_Click(int? count)
        {
            pairsToDays.ResetDays(Calendar1.SelectedDates, count);
            UpdateAllListView();
        }


        /// <summary>
        /// Обновить все Списки дней
        /// </summary>
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
