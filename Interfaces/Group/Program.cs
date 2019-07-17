using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!!");
            //List<Group> groups = new List<Group>();
            //Random rnd = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    string name = Guid.NewGuid().ToString().Substring(1, 4);
            //    int cours = rnd.Next(1, 5);
            //    var typeOfTraining = (TypeStudy)rnd.Next(0, 3);
            //    groups.Add(new Group(name, rnd.Next(7, 63), cours, $"{name}-{cours}", typeOfTraining));
            //}

            //foreach (var item in groups)
            //{
            //    item.ToConsole();
            //}

            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
