﻿using System;
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
    /// Логика взаимодействия для OutGroup.xaml
    /// </summary>
    public partial class OutClassList : Window
    {
        public List<object> List;
        public OutClassList()
        {
            InitializeComponent();
            Loaded += Load;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            DataGridGroup.ItemsSource = List;
            Type typeList = List[0].GetType();
            this.Title = typeList.GetType().Name;
        }

    }
}