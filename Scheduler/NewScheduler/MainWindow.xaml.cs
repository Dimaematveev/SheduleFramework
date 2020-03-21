using SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace NewScheduler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonOn.Click += (sender,e)=> { ButtonOn_Click(); };


            ButtonOn_Click();
        }

        private void ButtonOn_Click()
        {
            using (ShedEntities db = new ShedEntities())
            {
                var classroms = db.Classrooms.ToList();

                int maxNumberOfSeatsOfClassrooms = classroms.Max(x => x.NumberOfSeats);

                var unionsGroups = UnionGroup(db.Groups.ToList(),maxNumberOfSeatsOfClassrooms);


                TextBoxMaxClassroom.Text=$"Max classrooms={classroms.Max(x=>x.NumberOfSeats).ToString()}";

               
                TextBoxUnion.Text=$"{unionsGroups.ToString()}";

            }
        }
        
        /// <summary>
        /// Класс Объединение групп. сюда записываются все объединенные группы. Одно объединение
        /// </summary>
        public class UnionsGroup
        {
            public List<Groups> Groups { get;private set; }
            public int Count { get => Groups.Count; }

            public int MaxId { get => Groups.Max(x => x.GroupId); }
            public int AllNumberOfPersons { get => Groups.Sum(x => x.NumberOfPersons); }
            public UnionsGroup()
            {
                Groups = new List<Groups>();
            }
            public UnionsGroup(List<Groups> groups)
            {
                Groups = new List<Groups>();
                Add(groups);
            }
            public UnionsGroup(Groups group)
            {
                Groups = new List<Groups>();
                Add(group);
                
            }
            public int Add(List<Groups> groups)
            {   
                foreach (var group in groups)
                {
                    if (Groups.Contains(group)) 
                    {
                        return 1;
                    }
                }
                Groups.AddRange(groups);
                Groups = Groups.OrderBy(x => x.GroupId).ToList();
                return 0;
            }
            public int Add(Groups group)
            {
                if (!Groups.Contains(group))
                {
                    Groups.Add(group);
                    Groups = Groups.OrderBy(x => x.GroupId).ToList();
                    return 0;
                }
                return 1;
            }


            public override string ToString()
            {
                string res = $"Count:{Count.ToString().PadRight(2)}, AllNumberOfPersons:{AllNumberOfPersons.ToString().PadRight(4)}, Groups:";
                foreach (var group in Groups)
                {
                    res += group.GroupId.ToString().PadRight(3);
                    res += ",";
                }
                res= res.Remove(res.Length - 1);
                res += ".";
                return res;
            }
        }

        /// <summary>
        /// Класс Все Объединения групп. сюда записываются все объединенные группы. по всем объединениям
        /// </summary>
        public class UnionsGroups
        {
            private List<UnionsGroup> UnionsGroup;
            public int Count { get => UnionsGroup.Count; }

            public UnionsGroup this[int i]
            { get => UnionsGroup[i]; }
            public UnionsGroups()
            {
                UnionsGroup = new List<UnionsGroup>();
            }

            
            public int Add(UnionsGroup unionsGroup)
            {
                if (!UnionsGroup.Contains(unionsGroup))
                {
                    UnionsGroup.Add(unionsGroup);
                    UnionsGroup = UnionsGroup.OrderBy(x => x.Count).ToList();;
                    return 0;
                }
                return 1;
            }
            public override string ToString()
            {
                string res = "";
                foreach (var unionsGroup in UnionsGroup)
                {
                    res += unionsGroup.ToString();
                    res += "\n";
                }
                return res;
            }
        }

        private UnionsGroups UnionGroup(List<Groups> groups, int maxClassroms)
        {
            var unionsGroups = new UnionsGroups();
            foreach (Groups gr in groups)
            {
                if (gr.NumberOfPersons <= maxClassroms) 
                {
                    unionsGroups.Add(new UnionsGroup(gr));
                }
            }

            for (int i = 0; i < unionsGroups.Count; i++)
            {
                foreach (Groups gr in groups)
                {

                    if ((gr.GroupId > unionsGroups[i].MaxId) && ((gr.NumberOfPersons + unionsGroups[i].AllNumberOfPersons) <= maxClassroms)) 
                    {
                        var temp = new UnionsGroup(gr);
                        temp.Add(unionsGroups[i].Groups);
                        unionsGroups.Add(temp);
                    }
                }
            }


            return unionsGroups;


        }


        
    }
}
