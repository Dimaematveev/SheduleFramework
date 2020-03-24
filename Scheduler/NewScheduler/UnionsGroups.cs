using SQL;
using System.Collections.Generic;
using System.Linq;

namespace NewScheduler
{
    public partial class MainWindow
    {
        /// <summary>
        /// Класс Все Объединения групп. сюда записываются все объединенные группы. по всем объединениям
        /// </summary>
        public class UnionsGroups
        {
            /// <summary> Объединенные объединения групп </summary>
            private List<UnionGroups> UnionsGroup;
            /// <summary> кол-во объединений </summary>
            public int Count { get => UnionsGroup.Count; }
            /// <summary> обращение к одному объединению по  index </summary>
            public UnionGroups this[int i]
            { 
                get => UnionsGroup[i]; 
            }

            public UnionsGroups()
            {
                UnionsGroup = new List<UnionGroups>();
            }

            /// <summary>
            /// Получить объединения групп
            /// </summary>
            /// <param name="groups"> Список групп </param>
            /// <param name="maxUnionPeople"> макс объединение по кол-ву человек </param>
            public UnionsGroups(List<Groups> groups, int maxUnionPeople)
            {
                UnionsGroup = new List<UnionGroups>();
                foreach (Groups gr in groups)
                {
                    if (gr.NumberOfPersons <= maxUnionPeople)
                    {
                        UnionsGroup.Add(new UnionGroups(gr));
                    }
                }

                for (int i = 0; i < Count; i++)
                {
                    foreach (Groups group in groups)
                    {
                        if ((group.GroupId > UnionsGroup[i].MaxId) && ((group.NumberOfPersons + UnionsGroup[i].AllNumberOfPersons) <= maxUnionPeople))
                        {
                            var temp = new UnionGroups(UnionsGroup[i].Groups);
                            temp.Add(group);
                            UnionsGroup.Add(temp);
                        }
                    }
                }
            }
            public int Add(UnionGroups unionsGroup)
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


        


        
    }
}
