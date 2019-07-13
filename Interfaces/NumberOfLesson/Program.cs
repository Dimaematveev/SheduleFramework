
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            List<NumberOfLesson> numberLessons = new List<NumberOfLesson>
            {
                new NumberOfLesson(new Subject.Subject("Математика"),3),
                new NumberOfLesson(new Subject.Subject("Физика"),4),
            };

            foreach (var item in numberLessons)
            {
                item.ToConsole();
            }
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
