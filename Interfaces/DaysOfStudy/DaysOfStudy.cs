using Interface.Interface;
using DaysOfStudy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysOfStudy
{
    public class DaysOfStudy : IDaysOfStudyWithConsole
    {
        public DateTime Date { get; set; }
        public HowDays Study { get; set; }
        public DaysOfStudy(DateTime day, HowDays study)
        {
            Date = day;
            Study = study;
        }
        public void ToConsole()
        {
            //Console.WriteLine($"'{this.GetType()}' заглушка");
            if (Study == HowDays.DayOff)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{Date.Day,4}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (Study == HowDays.WorkingDay)
            {
                Console.Write($"{Date.Day,4}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{Date.Day,4}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
