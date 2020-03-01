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
        private SortedDictionary<DateTime, string> ReducedDay = new SortedDictionary<DateTime, string>();
        private SortedDictionary<DateTime, string> DayOff = new SortedDictionary<DateTime, string>();
        private SortedDictionary<DateTime, string> WorkDay = new SortedDictionary<DateTime, string>();

        
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

            ListViewReducedDay.ItemsSource = ReducedDay.Values;
            ListViewDayOff.ItemsSource = DayOff.Values;
            ListViewWorkDay.ItemsSource = WorkDay.Values;
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

            //var aa = Calendar1.Template;
            //Calendar1.BorderBrush.Opacity = 1;
            //ControlTemplate controlTemplate = new ControlTemplate(typeof(System.Windows.Controls.Calendar));
            ////controlTemplate.Triggers.Add((new Trigger()).);
            ////controlTemplate.
            //var w = 1;\

            for (DateTime i = Begin.Value; i <= End.Value; i=i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Sunday) 
                {
                    AddCollection(DayOff, i);
                }
                else
                {
                    AddCollection(WorkDay, i);
                }
            }
            UpdateAllListView();
        }

        private void AddCollection(SortedDictionary<DateTime, string> collection, DateTime dateTime, int? count = null)
        {
            if (!collection.Keys.Contains(dateTime))
            {
                if (count == null)
                {
                    collection.Add(dateTime, $"[{dateTime.ToShortDateString()}]");
                }
                else
                {
                    collection.Add(dateTime, $"[{dateTime.ToShortDateString()},{count}]");
                }
            }
            
        }
        private void MenuItemReducedDayCountPair_Click(int count)
        {
            foreach (var item in Calendar1.SelectedDates)
            {
                WorkDay.Remove(item);
                AddCollection(ReducedDay, item, count);
                DayOff.Remove(item);
            }
            UpdateAllListView();
        }

        private void MenuItemDayOff_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Calendar1.SelectedDates)
            {
                WorkDay.Remove(item);
                ReducedDay.Remove(item);
                AddCollection(DayOff, item);
            }
            UpdateAllListView();
        }

        private void MenuItemWorkDay_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Calendar1.SelectedDates)
            {
                AddCollection(WorkDay, item);
                ReducedDay.Remove(item);
                DayOff.Remove(item);
            }
            UpdateAllListView();
        }

        private void UpdateAllListView()
        {
            ListViewWorkDay.BeginInit();
            ListViewWorkDay.EndInit();
            ListViewReducedDay.BeginInit();
            ListViewReducedDay.EndInit();
            ListViewDayOff.BeginInit();
            ListViewDayOff.EndInit();
        }

    }
    
}
