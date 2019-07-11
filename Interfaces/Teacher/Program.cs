using Interface.Interface;
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

            List<Teacher> teachers = new List<Teacher>();

            

            List<SubjectOfTeacher.SubjectOfTeacher> subjectOfTeachers = new List<SubjectOfTeacher.SubjectOfTeacher>();
            var subjects = new List<Subject.Subject>()
            {

                new Subject.Subject("Английский"),
                new Subject.Subject("Программирование","КБ-5"),
                new Subject.Subject("Математический анализ","КБ-5"),
            };
            Random rnd = new Random();
            foreach (var item in subjects)
            {
                subjectOfTeachers.Add(new SubjectOfTeacher.SubjectOfTeacher(item, rnd.Next(0, 100)));
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


            var teacher = new Teacher((List<ISubjectOfTeacher>)subjectOfTeachers, "Нету",rnd.Next(1,4),);
            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();

        }
    }
}
