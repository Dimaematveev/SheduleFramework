using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSheduler.WPF
{
    /// <summary>
    /// Класс количество пар по дням.
    /// </summary>
    public class PairsToDay: IComparable
    {
        
        /// <summary>
        /// Дата пары
        /// </summary>
        public DateTime DatePair { get; set; }
        /// <summary>
        /// Количество пар если null значит полный день, если 0 то выходной, иначе день сокращен до стольких пар
        /// </summary>
        public int? CountPair { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datePair">Дата пары</param>
        /// <param name="countPair">Количество пар если null значит полный день, если 0 то выходной, иначе день сокращен до стольких пар</param>
        public PairsToDay(DateTime datePair, int? countPair)
        {
            DatePair = datePair;
            CountPair = countPair;
        }

        public override string ToString()
        {
            string str = "";
            if (CountPair > 0)
            {
                str += $"[{DatePair.ToShortDateString()},{CountPair}]";
            }
            else
            {
                str += $"[{DatePair.ToShortDateString()}]";
            }
            return str;
        }

        public override bool Equals(object obj)
        {
            return DatePair.Equals(((PairsToDay)obj).DatePair);
        }

        public int CompareTo(object obj)
        {
            return DatePair.CompareTo(((PairsToDay)obj).DatePair);
        }

        
    }

    /// <summary>
    /// пары по всем дням
    /// </summary>
    public class PairsToDays
    {

        /// <summary>
        /// Список количества пар для всех дней
        /// </summary>
        public List<PairsToDay> pairsToDays { get; private set; }

        /// <summary>
        /// Максимальное кол-во пар
        /// </summary>
        public int MaxCountPair { get; }
        public List<PairsToDay> WorkDay { get; private set; }
        public List<PairsToDay> DayOff { get; private set; }
        public List<PairsToDay> ReducedDay { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pairsToDayList">Список всех кол-во пар по дням</param>
        /// <param name="maxCountPair"> максимальное кол-во пар в день</param>
        public PairsToDays(IEnumerable<PairsToDay> pairsToDayList, int maxCountPair)
        {
            pairsToDays = pairsToDayList.ToList();
            MaxCountPair = maxCountPair;
            GetListDays();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDate">Дата начала отсчета пар</param>
        /// <param name="endDay">Дата окончания отсчета пар</param>
        /// <param name="maxCountPair"> максимальное кол-во пар в день</param>
        public PairsToDays(DateTime beginDate, DateTime endDay, int maxCountPair)
        {
            var PairsToDayList = new List<PairsToDay>();

            for (DateTime i = beginDate; i <= endDay; i = i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Sunday)
                {
                    PairsToDayList.Add(new PairsToDay(i, 0));
                }
                else
                {
                    PairsToDayList.Add(new PairsToDay(i, null));
                }
            }
            pairsToDays = PairsToDayList;
            MaxCountPair = maxCountPair;
            GetListDays();
        }

        
        /// <summary>
        /// заполнить все списки дней, рабочи выходные неполные
        /// </summary>
        private void GetListDays()
        {
            DayOff = pairsToDays.Where(x => x.CountPair == 0).ToList();
            DayOff.Sort();
            ReducedDay = pairsToDays.Where(x => x.CountPair > 0).ToList();
            ReducedDay.Sort();
            WorkDay = pairsToDays.Where(x => x.CountPair == null).ToList();
            WorkDay.Sort();
        }
       

        /// <summary>
        /// Изменить кол-во пар в день
        /// </summary>
        /// <param name="datePair">Дата пары</param>
        /// <param name="countPair">кол-во пар</param>
        public void ResetDay(DateTime datePair, int? countPair)
        {
            pairsToDays.Where(x => x.DatePair == datePair).First().CountPair = countPair;
            GetListDays();
        }

        /// <summary>
        /// Изменить кол-во пар в дни
        /// </summary>
        /// <param name="datePairs"> Список дней</param>
        /// <param name="countPair"> кол-во пар</param>
        public void ResetDays(IEnumerable<DateTime> datePairs, int? countPair)
        {
            pairsToDays.Where(x => datePairs.Contains(x.DatePair)).ToList().ForEach(x=>x.CountPair = countPair);
            GetListDays();
        }
    }
}
