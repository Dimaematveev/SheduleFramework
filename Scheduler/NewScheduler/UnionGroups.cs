using SQL;
using System.Collections.Generic;
using System.Linq;

namespace NewScheduler
{
    public partial class MainWindow
    {
        /// <summary>
        /// Класс Объединение групп. сюда записываются все объединенные группы. Одно объединение
        /// </summary>
        public class UnionGroups
        {
            /// <summary> Объединенные группы </summary>
            public List<Groups> Groups { get;private set; }
            /// <summary> кол-во объединенных групп  </summary>
            public int Count { get => Groups.Count; }
            /// <summary> максимальный ID </summary>
            public int MaxId { get => Groups.Max(x => x.GroupId); }
            /// <summary> Кол-во человек </summary>
            public int AllNumberOfPersons { get => Groups.Sum(x => x.NumberOfPersons); }

            public UnionGroups()
            {
                Groups = new List<Groups>();
            }

            public UnionGroups(List<Groups> groups)
            {
                Groups = new List<Groups>();
                Add(groups);
            }

            public UnionGroups(Groups group)
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


        


        
    }
}
