using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            var subjects = new List<Subject>()
            {
                new Subject("Английский"),
                new Subject("Программирование","КБ-5"),
                new Subject("Математический анализ","КБ-5"),
            };


            foreach (var item in subjects)
            {
                item.ToConsole();
            }

            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
