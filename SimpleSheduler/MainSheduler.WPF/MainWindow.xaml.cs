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
        /// <summary>
        /// Праздничные дни
        /// </summary>
        List<DateTime> Dayoff1 = new List<DateTime>
        {
            new DateTime(2020,1,1),
            new DateTime(2020,1,2),
            new DateTime(2020,1,3),
            new DateTime(2020,1,4),
            new DateTime(2020,1,5),
            new DateTime(2020,1,6),
            new DateTime(2020,1,7),
            new DateTime(2020,1,8),
            new DateTime(2020,1,9),
            new DateTime(2020,2,22),
            new DateTime(2020,2,23),
            new DateTime(2020,2,24),
            new DateTime(2020,3,7),
            new DateTime(2020,3,8),
            new DateTime(2020,3,9),
            new DateTime(2020,5,1),
            new DateTime(2020,5,2),
            new DateTime(2020,5,3),
            new DateTime(2020,5,4),
            new DateTime(2020,5,8),
            new DateTime(2020,5,9),
            new DateTime(2020,5,10),
            new DateTime(2020,6,12),
            new DateTime(2020,6,13),
        };
        
        public MainWindow()
        {
            InitializeComponent();
            DatePickerBegin.SelectedDate = new DateTime(2020, 1, 01);
            DatePickerEnd.SelectedDate = new DateTime(2020, 6, 28);
            ButtonOK.Click += (sender1, EventArgs1) => { ButtonOK_Click(); };
            ButtonProv.Click += (sender1, EventArgs1) => { ButtonProv_Click(); };

            Loaded += (object sender, RoutedEventArgs e) => { MainWindow_Loaded(); };
        }

        private void MainWindow_Loaded()
        {
            ButtonOK_Click();
            

            pairsToDays.ResetDays(Dayoff1, 0);
            UpdateAllListView();

            ButtonProv_Click();
        }

        private void ButtonProv_Click()
        {
            var DateRange = new List<DateTime>();
            DateRange.AddRange(pairsToDays.ReducedDay.Select(x => x.DatePair));
            DateRange.AddRange(pairsToDays.WorkDay.Select(x => x.DatePair));
            helperDate = new HelperDate(DateRange);
            TextBoxInfo.Text = helperDate.ToString();
        }

        private void ButtonOK_Click()
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
            contextMenu.Items.Add(menuItemWorkDay);
            MenuItem menuItemDayOff = new MenuItem();
            menuItemDayOff.Header = "Выходные дни";
            menuItemDayOff.Click += (sender1, EventArgs1) => { MenuItemDayCountPair_Click(0); };
            contextMenu.Items.Add(menuItemDayOff);
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
            contextMenu.Items.Add(menuItemReducedDay);
            //TODO: это перенос дня, не сделано. после надо подумать над реализацией
            MenuItem menuItemPerenos = new MenuItem();
            menuItemDayOff.Header = "Перенос дня";
            contextMenu.Items.Add(menuItemPerenos);
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
