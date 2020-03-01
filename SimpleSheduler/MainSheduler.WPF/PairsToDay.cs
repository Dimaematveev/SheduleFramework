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
        public List<PairsToDay> pairsToDays { get; set; }

        /// <summary>
        /// Максимальное кол-во пар
        /// </summary>
        public int MaxCountPair { get; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pairsToDayList">Список всех кол-во пар по дням</param>
        /// <param name="maxCountPair"> максимальное кол-во пар в день</param>
        public PairsToDays(IEnumerable<PairsToDay> pairsToDayList, int maxCountPair)
        {
            pairsToDays = pairsToDayList.ToList();
            MaxCountPair = maxCountPair;
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
        }

        /// <summary>
        /// Получить все полные рабочие дни
        /// </summary>
        /// <returns> список всех рабочих дней</returns>
        public List<PairsToDay> GetWorkDay()
        {
            var ret =  pairsToDays.Where(x => x.CountPair == null).ToList();
            ret.Sort();
            return ret;
        }
        /// <summary>
        /// Получить все выходные
        /// </summary>
        /// <returns> список всех выходных</returns>
        public List<PairsToDay> GetDayOff()
        {
            var ret = pairsToDays.Where(x => x.CountPair == 0).ToList();
            ret.Sort();
            return ret;
        }
        /// <summary>
        /// Получить все неполные рабочие дни
        /// </summary>
        /// <returns> список всех неполных рабочих дней</returns>
        public List<PairsToDay> GetReducedDay()
        {
            var ret = pairsToDays.Where(x => x.CountPair > 0).ToList();
            ret.Sort();
            return ret;
        }
    }
}
