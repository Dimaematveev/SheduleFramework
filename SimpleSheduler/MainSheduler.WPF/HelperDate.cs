using System;
using System.Collections.Generic;
using System.Linq;

namespace MainSheduler.WPF
{
    public class HelperDate
    {
        /// <summary>
        /// Начало отсчета
        /// </summary>
        public DateTime DateBegin { get; }
        /// <summary>
        /// Окончание отсчета включая эту дату
        /// </summary>
        public DateTime DateEnd { get; }
        /// <summary>
        /// Количество дней
        /// </summary>
        public int CountDays { get; }
        /// <summary>
        /// Количество недель
        /// </summary>
        public int CountWeek { get; }
        /// <summary>
        /// С какого дня начинается календарная неделя(По умолчанию понедельник)
        /// </summary>
        public DayOfWeek BeginWeek { get; }
        /// <summary>
        /// Количество определенного дня в неделе понедельников, вторников,...
        /// </summary>
        public Dictionary<DayOfWeek, int> CountDayOfWeek { get; }

        /// <summary>
        /// Конструктор с указание начала недели
        /// </summary>
        /// <param name="dateBegin"> дата начала</param>
        /// <param name="dateEnd"> дата окончания</param>
        /// <param name="beginWeek"> День начала недели</param>
        public HelperDate(DateTime dateBegin, DateTime dateEnd, DayOfWeek beginWeek)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            BeginWeek = beginWeek;

            CountDayOfWeek = new Dictionary<DayOfWeek, int>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                CountDayOfWeek.Add(day, 0);
            }
            for (DateTime i = DateBegin; i <= DateEnd; i=i.AddDays(1))
            {
                CountDayOfWeek[i.DayOfWeek] = CountDayOfWeek[i.DayOfWeek] + 1;
            }
            CountDays = CountDayOfWeek.Values.Sum();
            CountWeek = CountDayOfWeek.Values.Min();
        }
        /// <summary>
        /// Конструктор без указания начала недели,значит начинается с понедельника
        /// </summary>
        /// <param name="dateBegin"> дата начала</param>
        /// <param name="dateEnd"> дата окончания</param>
        public HelperDate(DateTime dateBegin, DateTime dateEnd) :this(dateBegin, dateEnd,DayOfWeek.Monday)
        {
        }


    }
    
}
