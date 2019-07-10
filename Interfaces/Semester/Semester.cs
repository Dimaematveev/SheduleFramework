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
            if (BeginSemestr.Day!=1)
            {
                MethodConsole(cultureDataFormat, BeginSemestr);
            }
            
            foreach (var item in DaysOfStudies)
            {
                if (item.Day.Day==1)
                {
                    Console.WriteLine();
                    MethodConsole(cultureDataFormat, item.Day);

                }
                if(item.Day.DayOfWeek== cultureDataFormat.FirstDayOfWeek)
                {
                    Console.WriteLine();
                }
                item.ToConsole();
            }
            Console.WriteLine();

        }

        void MethodConsole( DateTimeFormatInfo cultureDataFormat, DateTime dateTime)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{cultureDataFormat.MonthNames[dateTime.Month - 1],10}");
            Console.ForegroundColor = ConsoleColor.White;


            for (var i = (int)cultureDataFormat.FirstDayOfWeek; i < (int)(7 + cultureDataFormat.FirstDayOfWeek); i++)
            {
                Console.Write($"{cultureDataFormat.AbbreviatedDayNames[i % 7],4}");
            }
            if (dateTime.DayOfWeek != cultureDataFormat.FirstDayOfWeek)
            {
                Console.WriteLine();
                string sss = new string(' ', 4 * (int)(dateTime.DayOfWeek - 1));
                Console.Write($"{sss}");
            }

        }


    }
}
