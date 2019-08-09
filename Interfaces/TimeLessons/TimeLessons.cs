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
           
            if (numberLessons <= 0)
            {
                throw new ArgumentException("Номер пары не должен быть меньше 0!", nameof(numberLessons));
            }
            if (beginTime  >= endTime)
            {
                throw new ArgumentException("Время начала пары должно быть меньше времени окончания пары!", nameof(beginTime) +" "+ nameof(endTime));
            }
            if ((endTime - beginTime) > new TimeSpan(12,0,0)) 
            {
                throw new ArgumentException("Пара не может быть больше 12 часов!", nameof(beginTime) + " " + nameof(endTime));
            }
            BeginTime = beginTime;
            EndTime = endTime;
            NumberLessons = numberLessons;
        }
        public override string ToString()
        {
            return $"Пара № {NumberLessons} с {BeginTime} по {EndTime}";
        }
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
