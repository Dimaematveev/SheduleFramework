using Interface.Interface;
using SubjectOfTeacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");

            //List<Teacher> teachers = new List<Teacher>();

            //Random rnd = new Random();
            //for (int i = 0; i < 15; i++)
            //{


            //    List<ISubjectOfTeacherWithConsole> subjectOfTeachers = new List<ISubjectOfTeacherWithConsole>();
            //    var subjects = new List<Subject.Subject>()
            //    {

            //        new Subject.Subject("Английский"),
            //        new Subject.Subject("Программирование","КБ-5"),
            //        new Subject.Subject("Математический анализ","КБ-5"),
            //    };

            //    foreach (var item in subjects)
            //    {
            //        subjectOfTeachers.Add(new SubjectOfTeacher.SubjectOfTeacher(item, rnd.Next(0, 100)));
            //    }



            //    List<string> names = new List<string>
            //    {
            //        "Dima",
            //        "Vova",
            //        "Maksim",
            //        "Oleg"
            //    };
            //    List<Gender.Gender> genders = new List<Gender.Gender>()
            //    {
            //        new Gender.Gender("мужчина"),
            //        new Gender.Gender("женщина")
            //    };


            //    teachers.Add(new Teacher(subjectOfTeachers, "Нету", rnd.Next(1, 4), new Person.Person(names[rnd.Next(names.Count)], genders[rnd.Next(genders.Count)], new DateTime(rnd.Next(1946, 1992), rnd.Next(1, 12), rnd.Next(1, 28)), "Не знаю")));
            //}

            //foreach (var item in teachers)
            //{
            //    item.ToConsole();
            //}
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();

        }
    }
}
