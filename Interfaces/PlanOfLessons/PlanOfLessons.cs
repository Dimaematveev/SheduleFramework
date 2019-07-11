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
        public ISubject Subject { get; set; }
        public int NumberSubject { get; set; }
        public PlanOfLessons(IGroup group, ISubject subject, int numberSubject)
        {
            Group = group;
            Subject = subject;
            NumberSubject = numberSubject;
        }

        public void ToConsole()
        {
            ((IConsole)Group).ToConsole();
            ((IConsole)Subject).ToConsole();
            Console.WriteLine($"{NumberSubject}");
            Console.WriteLine();
        }
    }
}
