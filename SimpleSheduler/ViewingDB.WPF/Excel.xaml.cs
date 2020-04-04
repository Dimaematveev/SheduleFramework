using ShedulerFromExcel.BL;
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
using SimpleSheduler.BD;

namespace ViewingDB.WPF
{
    /// <summary>
    /// Логика взаимодействия для Excel.xaml
    /// </summary>
    public partial class Excel : Window
    {
        public Excel(string filename)
        {
            InitializeComponent();
            Add.Click += (sender,e) =>{ Add_Click(); };
            Init(filename);
        }

        private void Add_Click()
        {
            var group = WorkToMyDbContext.groups.Find(x => x.FullName == GroupName.Text);
            int groupID;
            if (group == null) 
            {
                AddGroup addGroup = new AddGroup(GroupName.Text, Potok.Text, Seminar.Text);
                addGroup.ShowDialog();
                groupID = addGroup.ID;
            }
            else
            {
                MessageBox.Show($"ok {GroupName.Text} и {group.ToString()}");
                groupID = group.GroupId;
            }

            var tabItem = (TabItem)ExcelControl.SelectedItem;

            var dataGrid = (DataGrid)tabItem.Content;
            string str = "";
            foreach (var item in dataGrid.Items)
            {
                if (item as System.Data.DataRowView != null)
                {
                    var rows = (System.Data.DataRowView)item;
                    var subject = WorkToMyDbContext.subjects.Find(x => x.FullName == rows.Row[2].Text);
                    int subjectID;
                    if (subject == null)
                    {
                        AddGroup addGroup = new AddGroup(GroupName.Text, Potok.Text, Seminar.Text);
                        addGroup.ShowDialog();
                        groupID = addGroup.ID;
                    }
                    else
                    {
                        MessageBox.Show($"ok {GroupName.Text} и {group.ToString()}");
                        groupID = group.GroupId;
                    }


                    for (int i = 0; i < dataGrid.Columns.Count; i++)
                    {
                        str += rows.Row[i] + "__";
                    }
                    str += "\n";
                }
            }


            MessageBox.Show($"{str}");
        }

        private void Init(string filename)
        {
            EasyExcel easyExcel = new EasyExcel(filename);
            foreach (var Course in easyExcel.AllCourses)
            {
                DataGrid dataGrid1 = new DataGrid();
                dataGrid1.ItemsSource = Course.Semester1.DefaultView;
                TabItem tabItem1 = new TabItem();
                tabItem1.Content = dataGrid1;
                tabItem1.Header = Course.Semester1.TableName;
                ExcelControl.Items.Add(tabItem1);

                DataGrid dataGrid2 = new DataGrid();
                dataGrid2.ItemsSource = Course.Semester2.DefaultView;
                TabItem tabItem2 = new TabItem();
                tabItem2.Content = dataGrid2;
                tabItem2.Header = Course.Semester2.TableName;
                ExcelControl.Items.Add(tabItem2);
            }


            FileName.Text = filename.Split('\\').Last();
            GroupName.Text = filename.Split('_')[1];
            Year.Text = easyExcel.Title.YearBegin;
            Kafedra.Text = easyExcel.Title.Kafedra;
            Napravl.Text = easyExcel.Title.Napravl;
            Potok.Text = easyExcel.Title.Potok;
            Profil.Text = easyExcel.Title.Profil;


            
        }
    }
}
