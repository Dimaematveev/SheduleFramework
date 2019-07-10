using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");

            List<string> names = new List<string>
            {
                "Dima",
                "Vova",
                "Maksim",
                "Oleg"
            };
            List<Gender.Gender> genders = new List<Gender.Gender>()
            {
                new Gender.Gender("мужчина"),
                new Gender.Gender("женщина")
            };
            Random rnd = new Random();
            var pers = new List<Person>();

            for (int i = 0; i < 100; i++)
            {

                pers.Add(new Person(names[rnd.Next(names.Count)], genders[rnd.Next(genders.Count)], new DateTime(rnd.Next(1905, 2018), rnd.Next(1, 12), rnd.Next(1, 28)), "Не знаю"));
            }
            foreach (var item in pers)
            {
                item.ToConsole();
            }
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
