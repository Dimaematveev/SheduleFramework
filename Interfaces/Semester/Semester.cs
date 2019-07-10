using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester
{
    class Semester : ISemester
    {
       
        public DateTime BeginSemestr { get; set ; }
        public DateTime EndSemestr { get ; set; }
        public List<IDaysOfStudy> DaysOfStudies { get; set; }
        public Semester(DateTime beginSemestr, DateTime endSemestr)
        {
            //TODO: BeginSemestr < EndSemestr
            //TODO: Их разница не более полугода.
            BeginSemestr = beginSemestr;
            EndSemestr = endSemestr;
            DaysOfStudies = new List<IDaysOfStudy>();
            for (var i = BeginSemestr; i <= EndSemestr; i=i.AddDays(1))
            {
                if (i.DayOfWeek==DayOfWeek.Sunday)
                {
                    DaysOfStudies.Add(new DaysOfStudy(i, 0));
                }
                else
                {
                    DaysOfStudies.Add(new DaysOfStudy(i, 1));
                }
            }
        }
        public void ToConsole()
        {
            Console.WriteLine($"'{this.GetType()}' заглушка");
            
            CultureInfo culInf = new CultureInfo("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentCulture = culInf;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culInf;
            var cultureDataFormat = DateTimeFormatInfo.CurrentInfo;
            cultureDataFormat.FirstDayOfWeek=DayOfWeek.Monday;


            Console.WriteLine(cultureDataFormat.MonthNames[BeginSemestr.Month-1]);
            Console.Write($"{"",4}");
            for (var i = (int)cultureDataFormat.FirstDayOfWeek; i < (int)(7 + cultureDataFormat.FirstDayOfWeek); i++)
            {
                Console.Write($"{cultureDataFormat.AbbreviatedDayNames[i%7],4}");
            }

            foreach (var item in DaysOfStudies)
            {
                item.ToConsole();
            }
            Console.WriteLine();

        }




    }
}
