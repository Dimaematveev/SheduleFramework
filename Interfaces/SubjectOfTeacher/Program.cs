using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectOfTeacher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            List<SubjectOfTeacher> subjectOfTeachers = new List<SubjectOfTeacher>();
            var subjects = new List<Subject.Subject>()
            {
                new Subject.Subject("Английский"),
                new Subject.Subject("Программирование","КБ-5"),
                new Subject.Subject("Математический анализ","КБ-5"),
            };
            Random rnd = new Random();
            foreach (var item in subjects)
            {
                subjectOfTeachers.Add(new SubjectOfTeacher(item, rnd.Next(0, 100)));
            }
            foreach (var item in subjectOfTeachers)
            {
                item.ToConsole();
            }
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
