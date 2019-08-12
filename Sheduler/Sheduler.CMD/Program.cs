using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheduler.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Начало!");

            //Семестр
            Console.WriteLine("\n Семестр нач!");
            ISemester semester = new Semester.Semester(new DateTime(2019, 09, 01), new DateTime(2019, 12, 31));
            ((IConsole)semester).ToConsole();
            Console.WriteLine(" Семестр окон!\n");

            //Предмет
            Console.WriteLine("\n Предмет нач!");
            ISubject subject = new Subject.Subject("Математический анализ");
            ((IConsole)subject).ToConsole();
            Console.WriteLine(" Предмет окон!\n");

            //Аудитории
            Console.WriteLine("\n Аудитория нач!");
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                new ClassRoom.ClassRoom("Аудитория №1",101),
                new ClassRoom.ClassRoom("Аудитория №2",101),
                new ClassRoom.ClassRoom("Аудитория №3",59),
                new ClassRoom.ClassRoom("Аудитория №4",23),
                new ClassRoom.ClassRoom("Аудитория №5",45)
            };
            foreach (var item in classRooms)
            {
                ((IConsole)item).ToConsole();
            }
            Console.WriteLine(" Аудитория окон!\n");

            //Группа
            Console.WriteLine("\n Группа нач!");
            List<IGroup> groups = new List<IGroup>
            {
                new Group.Group("TBO-1",1,"TBO", TypeStudy.FullTimeEducation,8),
                new Group.Group("TBO-2",2,"TBO", TypeStudy.FullTimeEducation,59),
                new Group.Group("TBO-3",3,"TBO", TypeStudy.FullTimeEducation,10),
                new Group.Group("TMO-1",1,"TMO", TypeStudy.FullTimeEducation,11),
                new Group.Group("TMO-2",2,"TMO", TypeStudy.FullTimeEducation,8),
                new Group.Group("TMO-3",3,"TMO", TypeStudy.FullTimeEducation,13),
                new Group.Group("KB-1",1,"KB", TypeStudy.FullTimeEducation,14),
                new Group.Group("KB-2",2,"KB", TypeStudy.FullTimeEducation,15),
                new Group.Group("KB-3",3,"KB", TypeStudy.FullTimeEducation,16),
                new Group.Group("KB-4",4,"KB", TypeStudy.FullTimeEducation,17),
            };
            foreach (var item in groups)
            {
                ((IConsole)item).ToConsole();
            }
            
            Console.WriteLine("Группа окон!\n");

            //План занятий
            Console.WriteLine("\n План занятий нач!");
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>();
            foreach (var item in groups)
            {
                List<INumberOfLesson> numberOfLessons = new List<INumberOfLesson>
                {
                    new NumberOfLesson.NumberOfLesson(subject,95)
                };
                planOfLessons.Add( new PlanOfLessons.PlanOfLessons(item, numberOfLessons));
            }
            foreach (var item in planOfLessons)
            {
                ((IConsole)item).ToConsole();
            }
            Console.WriteLine(" План занятий окон!\n");

            //Преподаватель
            Console.WriteLine("\n Преподаватель нач!");
            List<ISubjectOfTeacher> subjectOfTeachers = new List<ISubjectOfTeacher>
            {
                new SubjectOfTeacher.SubjectOfTeacher(subject,100)
            };
            IPerson person = new Person.Person("Добронравов Андрей Геориевич", Gender.men, new DateTime(1982, 01, 01), "None");

            ITeacher teacher = new Teacher.Teacher(subjectOfTeachers,"none",1, person);
            ((IConsole)teacher).ToConsole();
            Console.WriteLine("Преподаватель окон!\n");

            //Время занятий
            Console.WriteLine("\n Время занятий нач!");
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                new TimeLessons.TimeLessons(new TimeSpan(09,00,00),new TimeSpan(10,30,00),1),
                new TimeLessons.TimeLessons(new TimeSpan(10,40,00),new TimeSpan(12,10,00),2),
                new TimeLessons.TimeLessons(new TimeSpan(13,00,00),new TimeSpan(14,30,00),3),
                new TimeLessons.TimeLessons(new TimeSpan(14,40,00),new TimeSpan(16,10,00),4),
                new TimeLessons.TimeLessons(new TimeSpan(16,20,00),new TimeSpan(17,50,00),5),
                new TimeLessons.TimeLessons(new TimeSpan(18,00,00),new TimeSpan(19,30,00),6)
            };
            foreach (var item in timeLessons)
            {
                ((IConsole)item).ToConsole();
            }
            Console.WriteLine("Время занятий окон!\n");


            Console.WriteLine(" Конец!");
            Console.ReadLine();
        }
    }
}
