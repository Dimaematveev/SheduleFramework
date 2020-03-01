using System;
using System.Collections.Generic;
using System.Linq;

namespace MainSheduler.WPF
{
    public class HelperDate
    {
        /// <summary>
        /// Список дней
        /// </summary>
        public List<DateTime> DateRange { get; }
        /// <summary>
        /// Количество дней
        /// </summary>
        public int CountDays { get; }
        /// <summary>
        /// Количество недель
        /// </summary>
        public int CountWeek { get; }
        /// <summary>
        /// Количество учебных недель
        /// </summary>
        public int CountStudyWeek { get; }
     
        /// <summary>
        /// Количество определенного дня в неделе понедельников, вторников,...
        /// </summary>
        public Dictionary<DayOfWeek, int> CountDayOfWeek { get; }

        /// <summary>
        /// Конструктор с указание начала недели
        /// </summary>
        /// <param name="dateBegin"> дата начала</param>
        /// <param name="dateEnd"> дата окончания</param>
        /// <param name="beginWeek"> День начала недели(по умолчанию понедельник)</param>
        public HelperDate(DateTime dateBegin, DateTime dateEnd)
        {
            DateRange = new List<DateTime>();
            for (DateTime i = dateBegin; i <= dateEnd; i = i.AddDays(1))
            {
                DateRange.Add(i);
            }
            DateRange.Sort();
            CountDayOfWeek = GetCountDayOfWeek();
            CountDays = GetCountDays();
            CountWeek = GetCountWeek();
            CountStudyWeek = GetCountCalendarWeek();
        }

        


        /// <summary>
        /// Констркуктор со списком включаемых дней
        /// </summary>
        /// <param name="dateRange">Список дней</param>
        /// <param name="beginWeek"> День начала недели</param>
        public HelperDate(List<DateTime> dateRange)
        {
            DateRange = dateRange;
            DateRange.Sort();

            CountDayOfWeek = GetCountDayOfWeek();
            CountDays = GetCountDays();
            CountWeek = GetCountWeek();
            CountStudyWeek = GetCountCalendarWeek();
        }

        private Dictionary<DayOfWeek, int> GetCountDayOfWeek()
        {
            var ret= new Dictionary<DayOfWeek, int>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                ret.Add(day, 0);
            }
            foreach (var date in DateRange)
            {
                ret[date.DayOfWeek] = ret[date.DayOfWeek] + 1;
            }
            return ret;
        }
        private int GetCountWeek()
        {
            return CountDayOfWeek.Values.Min();
        }

        private int GetCountDays()
        {
            return CountDayOfWeek.Values.Sum();
        }
        private int GetCountCalendarWeek()
        {
            int count = 0;
            List<DateTime> Temp = new List<DateTime>();
            Temp.Clear();
            Temp.Add(DateRange[0]);
            if (DateRange[0].DayOfWeek != DayOfWeek.Monday) 
            {
                count++;
                
                for (int i = 1; i < 7; i++)
                {
                    Temp.Add(DateRange[0].AddDays(i));
                }
            }
            DateTime dateTimeFistMonday = Temp.Find(x => x.DayOfWeek == DayOfWeek.Monday);

            Temp.Clear();
            Temp.Add(DateRange.Last());
            if (DateRange.Last().DayOfWeek != DayOfWeek.Sunday)
            {
                count++;
                for (int i = 1; i < 7; i++)
                {
                    Temp.Add(DateRange.Last().AddDays(-i));
                }
            }
            DateTime dateTimeLastSunday = Temp.FindLast(x => x.DayOfWeek == DayOfWeek.Sunday);
            count += ((dateTimeLastSunday - dateTimeFistMonday).Days / 7) + 1;
            return count;
        }

        public override string ToString()
        {
            string str = "";
            str += $" Период с {DateRange[0].ToShortDateString()} по {DateRange.Last().ToShortDateString()}";
            str += "\n Количество";
            str += "\n Дней: ";
            str += $"{CountDays}";
            str += "\n Недель: ";
            str += $"{CountWeek}";
            str += "\n Учебных недель: ";
            str += $"{CountStudyWeek}";
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                str += $"\n{day}: ";
                str += $"{CountDayOfWeek[day]}";
            }
            return str;
        }
    }
    
}
