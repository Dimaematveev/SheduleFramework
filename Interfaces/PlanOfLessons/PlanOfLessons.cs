using Interface.Interface;
using PlanOfLessons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanOfLessons
{
    class PlanOfLessons : IPlanOfLessonsWithConsole
    {
        public IGroup Group { get; set; }
        public ISubject Subject { get; set; }
        public int NumberSubject { get; set; }

        public void ToConsole()
        {
            Console.WriteLine();
        }
    }
}
