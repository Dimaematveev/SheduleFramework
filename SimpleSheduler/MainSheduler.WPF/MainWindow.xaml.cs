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

namespace MainSheduler.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime Begin;
        DateTime End;
        public MainWindow()
        {
            InitializeComponent();
            CalendarBegin.SelectedDatesChanged += CalendarBegin_SelectedDatesChanged; ;
            TextBoxBegin.GotFocus += TextBoxBegin_GotFocus;
            //TextBoxBegin.LostFocus += ButtonBeginOK_Click;
            ButtonBeginOK.Click += ButtonBeginOK_Click;

            CalendarEnd.SelectedDatesChanged += CalendarEnd_SelectedDatesChanged; ;
            TextBoxEnd.GotFocus += TextBoxEnd_GotFocus;
            //TextBoxEnd.LostFocus += ButtonEndOK_Click;
            ButtonEndOK.Click += ButtonEndOK_Click;


            ButtonOK.Click += ButtonOK_Click;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            str+="Количество Недель: ";
            str+="Количество Понедельников: ";
            
            MessageBox.Show(str);
        }

        private void ButtonBeginOK_Click(object sender, RoutedEventArgs e)
        {
            CalendarBegin.Visibility = Visibility.Hidden;
            ButtonBeginOK.Visibility = Visibility.Hidden;
        }

        private void TextBoxBegin_GotFocus(object sender, RoutedEventArgs e)
        {
            CalendarBegin.Visibility = Visibility.Visible;
            ButtonBeginOK.Visibility = Visibility.Visible;
        }

        private void CalendarBegin_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Begin = ((Calendar)e.OriginalSource).SelectedDate.Value.Date;
            TextBoxBegin.Text = Begin.ToShortDateString();
        }
        private void ButtonEndOK_Click(object sender, RoutedEventArgs e)
        {
            CalendarEnd.Visibility = Visibility.Hidden;
            ButtonEndOK.Visibility = Visibility.Hidden;
        }

        private void TextBoxEnd_GotFocus(object sender, RoutedEventArgs e)
        {
            CalendarEnd.Visibility = Visibility.Visible;
            ButtonEndOK.Visibility = Visibility.Visible;
        }

        private void CalendarEnd_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            End = ((Calendar)e.OriginalSource).SelectedDate.Value.Date;
            TextBoxEnd.Text = End.ToShortDateString();
        }

    }
}
