using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!!");
            List<Gender> genders = new List<Gender>()
            {
                new Gender("мужчина"),
                new Gender("женщина")
            };
            foreach (var item in genders)
            {
                item.ToConsole();
            }

            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
