using Interface.Interface;
using Interface.Interfaces;
using PlanOfLessons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanOfLessons
{
    public class PlanOfLessons : IPlanOfLessonsWithConsole
    {
        public IGroup Group { get; set; }
        public List<INumberOfLesson> NumberOfLesson { get; set; }

        public PlanOfLessons(IGroup group, List<INumberOfLesson> numberOfLesson)
        {
            if (group == null) 
            {
                throw new ArgumentNullException("Группа не должна быть пустой!",nameof(group));
            }
            if (numberOfLesson == null)
            {
                throw new ArgumentNullException("План не должен быть пустым!", nameof(numberOfLesson));
            }
            if (numberOfLesson.Count <= 0) 
            {
                throw new ArgumentNullException("План не должен быть пустым!", nameof(numberOfLesson));
            }
            Group = group;
            NumberOfLesson = numberOfLesson;
        }

        public override string ToString()
        {
            string ret = "";
            ret += Group.ToString();
            ret += "\n";
            foreach (var item in NumberOfLesson)
            {
                ret += $"{"",4}";
                ret += item.ToString();
                ret += "\n";
            }
            return ret;
        }

        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
