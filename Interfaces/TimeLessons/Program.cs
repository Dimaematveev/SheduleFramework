using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            var timesLessons = new List<TimeLessons>();

            TimeSpan dateTime = new TimeSpan(9, 0, 0);
            for (int i = 0; i < 6; i++)
            {
                timesLessons.Add(new TimeLessons(dateTime, dateTime.Add(new TimeSpan(1, 30, 0)), i + 1));
                dateTime = dateTime.Add(new TimeSpan(1, 40, 0));
            }

            foreach (var item in timesLessons)
            {
                item.ToConsole();
            }

            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
