using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysOfStudy
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");
            Random rnd = new Random();
            var Days = new List<DaysOfStudy>();
            for (int i = 0; i < 100; i++)
            {
                DateTime dateTime = new DateTime(2019, rnd.Next(1, 12), rnd.Next(1, 28));
                HowDays howDays = (HowDays)(rnd.Next(0, 2)-1);
                Days.Add(new DaysOfStudy(dateTime, howDays));
            }
            foreach (var item in Days)
            {
                item.ToConsole();
            }
            DateTime date1 = new DateTime();
            var Day = new DaysOfStudy(date1,HowDays.WorkingDay);

            Console.WriteLine();
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
