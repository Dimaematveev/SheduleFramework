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

        public void ToConsole()
        {
            ((IConsole)Group).ToConsole();
            foreach (var item in NumberOfLesson)
            {
                Console.Write($"{"",4}");
                ((IConsole)item).ToConsole();
            }
            Console.WriteLine();
        }
    }
}
