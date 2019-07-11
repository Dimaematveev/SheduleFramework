using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanOfLessons
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");
            List<PlanOfLessons> planOfLessons = new List<PlanOfLessons>();
            List<Group.Group> groups = new List<Group.Group>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string name = Guid.NewGuid().ToString().Substring(1, 4);
                int cours = rnd.Next(1, 5);
                var typeOfTraining = (TypeStudy)rnd.Next(0, 3);
                groups.Add(new Group.Group(name, rnd.Next(7, 63), cours, $"{name}-{cours}", typeOfTraining));
            }

            var subjects = new List<Subject.Subject>()
            {
                new Subject.Subject("Английский"),
                new Subject.Subject("Программирование","КБ-5"),
                new Subject.Subject("Математический анализ","КБ-5"),
            };
            
            foreach (var item1 in groups)
            {
                foreach (var item2 in subjects)
                {
                    planOfLessons.Add(new PlanOfLessons(item1,item2,rnd.Next(10,40)));
                }
            }

            foreach (var item in planOfLessons)
            {
                item.ToConsole();
            }
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
