using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLessons.Interfaces;

namespace TimeLessons
{
    public class TimeLessons : ITimeLessonsWithConsole
    {
       
        public TimeSpan BeginTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberLessons { get; set; }

        public TimeLessons(TimeSpan beginTime, TimeSpan endTime, int numberLessons)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            NumberLessons = numberLessons;
        }

        public void ToConsole()
        {
            Console.WriteLine($"Пара № {NumberLessons} с {BeginTime} по {EndTime}");
        }
    }
}
