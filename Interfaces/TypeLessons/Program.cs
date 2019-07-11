using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            List<TypeLessons> typeLessons = new List<TypeLessons>()
            {
                new TypeLessons("Лекция"),
                new TypeLessons("Практика"),
                new TypeLessons("Семинар")
            };
           
            foreach (var item in typeLessons)
            {
                item.ToConsole();
            }
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
