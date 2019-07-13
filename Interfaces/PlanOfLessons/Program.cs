using Interface.Interface;
using Interface.Interfaces;
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
                var numberOfLessons = new List<INumberOfLesson>
                {
                    new NumberOfLesson.NumberOfLesson(subjects[rnd.Next(0,subjects.Count)],rnd.Next(0,19)),
                    new NumberOfLesson.NumberOfLesson(subjects[rnd.Next(0,subjects.Count)],rnd.Next(0,19)),
                    new NumberOfLesson.NumberOfLesson(subjects[rnd.Next(0,subjects.Count)],rnd.Next(0,19)),
                };
                planOfLessons.Add(new PlanOfLessons(item1, numberOfLessons));
               
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
