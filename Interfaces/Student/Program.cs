using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!!");
            List<Student> students = new List<Student>();    

            List<Group.Group> groups = new List<Group.Group >();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string name = Guid.NewGuid().ToString().Substring(1, 4);
                int cours = rnd.Next(1, 5);
                var typeOfTraining = (TypeStudy)rnd.Next(0, 3);
                groups.Add(new Group.Group(name, rnd.Next(7, 63), cours, $"{name}-{cours}", typeOfTraining));
            }

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
            foreach (var item in groups)
            {
                for (int i = 0; i < rnd.Next(7,35); i++)
                {
                    students.Add(new Student(item, new Person.Person(names[rnd.Next(names.Count)], genders[rnd.Next(genders.Count)], new DateTime(rnd.Next(1993, 1999), rnd.Next(1, 12), rnd.Next(1, 28)), "Не знаю")));

                }
            }

            foreach (var item in students)
            {
                item.ToConsole();
            }



            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
