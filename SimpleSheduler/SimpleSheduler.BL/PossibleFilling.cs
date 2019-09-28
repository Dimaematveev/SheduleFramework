using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    /// <summary>
    /// Когда возможно заполнить пару. список свободных дней и пар.
    /// </summary>
    public class PossibleFilling:ICloneable
    {
        //Для красивого вывода
        static int padNameThePair = 0;
        static int padNumberThePair = 0;
        static int padNameDayOfWeek = 0;
        static int padNumberOfWeek = 0;

        public PossibleFilling(Pair pair, StudyDay studyDay)
        {
            if (pair.NameThePair.Length> padNameThePair)
            {
                padNameThePair = pair.NameThePair.Length;
            }
            if (pair.NumberThePair.ToString().Length > padNumberThePair)
            {
                padNumberThePair = pair.NumberThePair.ToString().Length;
            }
            if (studyDay.NameDayOfWeek.Length > padNameDayOfWeek)
            {
                padNameDayOfWeek = studyDay.NameDayOfWeek.Length;
            }
            if (studyDay.NumberOfWeek.ToString().Length > padNumberOfWeek)
            {
                padNumberOfWeek = studyDay.NumberOfWeek.ToString().Length;
            }
            Pair = pair;
            StudyDay = studyDay;
        }

        public Pair Pair { get; set; }
        public StudyDay StudyDay { get; set; }
        public BusyPair BusyPair { get; set; } = null;
        public string OutputPair()
        {
            string nameThePair = Pair.NameThePair.PadRight(padNameThePair);
            string numberThePair = Pair.NumberThePair.ToString().PadRight(padNumberThePair);
            return $"Название пары:{nameThePair}, Номер пары:{numberThePair}";
        }
        public string OutputStudyDay()
        {
            string nameDayOfWeek = StudyDay.NameDayOfWeek.PadRight(padNameDayOfWeek);
            string numberOfWeek = StudyDay.NumberOfWeek.ToString().PadRight(padNumberOfWeek);
            return $"День недели:{nameDayOfWeek}, Номер недели:{numberOfWeek}";
        }
        public string OutputAll()
        {
            return OutputStudyDay()+","+ OutputPair();
        }

        public object Clone()
        {
            return new PossibleFilling(Pair, StudyDay);
        }
    }
}
