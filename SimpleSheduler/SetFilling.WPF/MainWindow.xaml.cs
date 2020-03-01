using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace SetFilling.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow(CreateScheduler createScheduler)
        {
            InitializeComponent();
            

            GridClassRoom.ItemsSource = GetDateTableFilling(createScheduler.FillingClassrooms,false).DefaultView;
            GridGroup.ItemsSource = GetDateTableFilling(createScheduler.FillingGroups,false).DefaultView;
        }



        private DataTable GetDateTableFilling<T>(List<Filling<T>> fillings, bool set = true) where T : class, IAbbreviation
        {
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "NumberOfWeek",
                    Caption = "Номер недели"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    ColumnName = "NameDayOfWeek",
                    Caption = "День недели"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "NumberThePair",
                    Caption = "Номер Пары"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                foreach (var filling in fillings)
                {
                    if (set)
                    {
                        column = new DataColumn
                        {

                            DataType = typeof(string),
                            ColumnName = $"{filling.Value.AbbreviationString()}",
                            Caption = $"{filling.Value.AbbreviationString()}"
                        };
                    }
                    else
                    {
                        column = new DataColumn
                        {

                            DataType = typeof(BusyPair),
                            ColumnName = $"{filling.Value.AbbreviationString()}",
                            Caption = $"{filling.Value.AbbreviationString()}"
                        };
                    }

                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                }
            }
            for (int i = 0; i < fillings[0].PossibleFillings.Count; i++)
            {
                DataRow row;
                row = table.NewRow();
                var temp = fillings[0].PossibleFillings[i];
                row[0] = $"{temp.StudyDay.NumberOfWeek}";
                row[1] = $"{temp.StudyDay.AbbreviationDayOfWeek}";
                row[2] = $"{temp.Pair.NumberThePair}";
                int stolb = 3;
                foreach (var filling in fillings)
                {
                    if (set)
                    {
                        string IsPair;
                        var BusyPair = filling.PossibleFillings[i].BusyPair;
                        IsPair = BusyPair == null ? null : BusyPair.Subject.Abbreviation;
                        row[stolb] = IsPair;
                    }
                    else
                    {
                        row[stolb] = filling.PossibleFillings[i].BusyPair;
                    }

                    stolb++;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
