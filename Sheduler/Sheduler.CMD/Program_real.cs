using Interface.Interface;
using Interface.Interfaces;
using Sheduler.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheduler.CMD
{
    //учебный план школы 2019-2020 год
    class Program_Real
    {
        public static void Main1()
        {
            Console.WriteLine(" Начало!");

            //Семестр
            Console.WriteLine("\n Семестр нач!");
            ISemester semester = new Semester.Semester(new DateTime(2019, 09, 01), new DateTime(2019, 12, 31));
            ((IConsole)semester).ToConsole();
            Console.WriteLine(" Семестр окон!\n");

            //Предмет
            Console.WriteLine("\n Предмет нач!");
            List<ISubject> subjects = new List<ISubject>
            {
                new Subject.Subject("Русский язык"),
                new Subject.Subject("Литературное чтение"),
                new Subject.Subject("Русский родной язык"),
                new Subject.Subject("Литературное чтение на русском родном языке"),
                new Subject.Subject("Иностранный язык (англ.)"),
                new Subject.Subject("Второй язык"),
                new Subject.Subject("Математика"),
                new Subject.Subject("Окружающий мир"),
                new Subject.Subject("Основы религиозных культур и светской этики"),
                new Subject.Subject("Музыка"),
                new Subject.Subject("Изобразительное искусство"),
                new Subject.Subject("Технология "),
                new Subject.Subject("Физическая культура"),
            };
            foreach (var subject in subjects)
            {
                ((IConsole)subject).ToConsole();
            }
            
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
            foreach (var classRoom in classRooms)
            {
                ((IConsole)classRoom).ToConsole();
            }
            Console.WriteLine(" Аудитория окон!\n");

            //Группа
            Console.WriteLine("\n Группа нач!");
            List<IGroup> groups = new List<IGroup>
            {
                new Group.Group("Класс-1",1,"Класс", TypeStudy.FullTimeEducation,8),
                new Group.Group("Класс-2",2,"Класс", TypeStudy.FullTimeEducation,59),
                new Group.Group("Класс-3",3,"Класс", TypeStudy.FullTimeEducation,10),
                new Group.Group("Класс-4",4,"Класс", TypeStudy.FullTimeEducation,11),
            };
            foreach (var group in groups)
            {
                ((IConsole)group).ToConsole();
            }
            
            Console.WriteLine("Группа окон!\n");

            //План занятий
            Console.WriteLine("\n План занятий нач!");
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>();
            int[][] ClassYear = new int[][] {
                new int[] { 165, 132, 0, 0, 0, 0, 132, 66, 0, 33, 33, 33, 99 },
                new int[] { 136, 102, 34, 34, 68, 0, 136, 68, 0, 34, 34, 34, 102 },
                new int[] { 170, 136, 0, 0, 68, 0, 136, 68, 0, 34, 34, 34, 102 },
                new int[] { 170, 102, 0, 0, 68, 0, 136, 68, 34, 34, 34, 34, 102 },
            };
            foreach (var group in groups)
            {
                List<INumberOfLesson> numberOfLessons = new List<INumberOfLesson>();
                for (int i = 0; i < subjects.Count; i++)
                {
                    if (ClassYear[group.Cours - 1][i] / 2 > 0)
                    {
                        numberOfLessons.Add(new NumberOfLesson.NumberOfLesson(subjects[i], ClassYear[group.Cours - 1][i] / 2));
                    }
                    
                }

                planOfLessons.Add( new PlanOfLessons.PlanOfLessons(group, numberOfLessons));
            }
            foreach (var planOfLesson in planOfLessons)
            {
                ((IConsole)planOfLesson).ToConsole();
            }
            Console.WriteLine(" План занятий окон!\n");

            //Преподаватель
            Console.WriteLine("\n Преподаватель нач!");
            List<ITeacher> teachers = new List<ITeacher>();

            List<IPerson> persons = new List<IPerson>
            {
                new Person.Person("Преподаватель1", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель2", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель3", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель4", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель5", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель6", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель7", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель8", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель9", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель10", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель11", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель12", Gender.men, new DateTime(1982, 01, 01), "None"),
                new Person.Person("Преподаватель13", Gender.men, new DateTime(1982, 01, 01), "None"),
            };
            ISubjectOfTeacher[][] subjectOfTeachers1 = new ISubjectOfTeacher[][]
            {
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[0], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[1], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[2], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[3], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[0], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[1], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[2], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[3], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[0], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[1], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[2], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[3], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[0], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[1], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[2], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[3], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[4], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[5], 100)},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[4], 100),new SubjectOfTeacher.SubjectOfTeacher(subjects[5], 100)},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[6], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[7], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[8], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[9], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[10], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[11], 100),},
                new ISubjectOfTeacher[] { new SubjectOfTeacher.SubjectOfTeacher(subjects[12], 100),},
            };
            for (int i = 0; i < subjects.Count; i++)
            {
                teachers.Add(new Teacher.Teacher(subjectOfTeachers1[i].ToList(), "none", 1, persons[i]));
            }
            foreach (var teacher in teachers)
            {
                ((IConsole)teacher).ToConsole();
            }
            
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
            foreach (var timeLesson in timeLessons)
            {
                ((IConsole)timeLesson).ToConsole();
            }
            Console.WriteLine("Время занятий окон!\n");






            Version1 version1 = new Version1(semester, groups, classRooms, planOfLessons, teachers, timeLessons);
            version1.SetFree();
            var kk1 = version1.CheckLesson();
            var kk2 = version1.NumberWorkDayofWeekFoeGroup();
            var kk3 = version1.LessonOfWeekToGroups();
            Console.WriteLine(" Конец!");
            Console.ReadLine();
        }
    }
}
