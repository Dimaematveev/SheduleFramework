using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleProject
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Begin");

            //Gender.Gender gender = new Gender.Gender("мужской");
            //var genders = new List<Gender.Gender>
            //{
            //    new Gender.Gender("мужской"),
            //    new Gender.Gender("женский"),
            //};
            //ClassRoom.ClassRoom classRoom = new ClassRoom.ClassRoom("Аудит1", 101);
            //var classRooms = new List<ClassRoom.ClassRoom>
            //{
            //    new ClassRoom.ClassRoom("Аудит1", 50),
            //    new ClassRoom.ClassRoom("Аудит2", 34),
            //    new ClassRoom.ClassRoom("Аудит3", 45),
            //    new ClassRoom.ClassRoom("Аудит4", 107),
            //    new ClassRoom.ClassRoom("Аудит5", 31),
            //};
            //Group.Group group = new Group.Group("TBO",  2, "TBO-2", Interface.Interface.TypeStudy.FullTimeEducation,35);
            //var groups = new List<Group.Group>
            //{
            //    new Group.Group("TBO", 1, "TBO-1", Interface.Interface.TypeStudy.FullTimeEducation,35),
            //    new Group.Group("TBO", 2, "TBO-2", Interface.Interface.TypeStudy.FullTimeEducation,25),
            //    new Group.Group("TMO", 3, "TMO-3", Interface.Interface.TypeStudy.FullTimeEducation,11),
            //    new Group.Group("TCO", 2, "TCO-2", Interface.Interface.TypeStudy.FullTimeEducation,54),
            //};
            //Subject.Subject subject = new Subject.Subject("Математика");
            //var subjects = new List<Subject.Subject>
            //{
            //     new Subject.Subject("программирование 2 курс"),
            //     new Subject.Subject("математический анализ 3 курс"),
            //     new Subject.Subject("введение в специальность 1 курс"),
            //     new Subject.Subject("история России 1-4 курс"),
            //};

            //NumberOfLesson.NumberOfLesson numberOfLesson = new NumberOfLesson.NumberOfLesson(subject, 5);
            //var numberOfLessons = new List<NumberOfLesson.NumberOfLesson>[groups.Count];
            //for (int i = 0; i < groups.Count; i++)
            //{
            //    int r1 = i * 5 % subjects.Count;
            //    int r2 = i * 3 % subjects.Count;
            //    if (r1 == r2)
            //    {
            //        r1 = (r1 + 1) % subjects.Count;
            //    }
            //    var tempNumberOfLessons = new List<NumberOfLesson.NumberOfLesson>
            //    {
            //        new NumberOfLesson.NumberOfLesson(subjects[r1],7),
            //        new NumberOfLesson.NumberOfLesson(subjects[r2],9),
            //    };
            //    numberOfLessons[i] = tempNumberOfLessons;
            //};


            //Semester.Semester semester = new Semester.Semester(new DateTime(2019, 02, 02), new DateTime(2019, 05, 31));
           

            //DaysOfStudy.DaysOfStudy daysOfStudy = new DaysOfStudy.DaysOfStudy(DateTime.Now,Interface.Interface.HowDays.DayOff);
            //Person.Person person = new Person.Person("Dima", gender, new DateTime(1996, 05, 19), "Юго западная");
           
            //SubjectOfTeacher.SubjectOfTeacher subjectOfTeacher = new SubjectOfTeacher.SubjectOfTeacher(subject, 10);
            //Teacher.Teacher teacher = new Teacher.Teacher(new List<SubjectOfTeacher.Interfaces.ISubjectOfTeacherWithConsole> { subjectOfTeacher }, "none", 1, person);
            //var teachers = new List<Teacher.Teacher>();
            //string[] names = { "Александр", "Максим", "Виктор", "Дмитрий", "Олег" };
            //for (int i = 0; i < 5; i++)
            //{
                
            //    int r1 = i * 5 % subjects.Count;
            //    int r2 = i * 3 % subjects.Count;
            //    if (r1==r2)
            //    {
            //        r1=(r1+1)% subjects.Count;
            //    }
            //    var subjectOfTeacher1 = new List<SubjectOfTeacher.Interfaces.ISubjectOfTeacherWithConsole>
            //    {
            //        new SubjectOfTeacher.SubjectOfTeacher(subjects[r1], 100),
            //        new SubjectOfTeacher.SubjectOfTeacher(subjects[r2], 100),
            //    };
            //    var person1 = new Person.Person(names[i],genders[0],new DateTime(1958+i,(17*i)%12+1,(23*i)%28+1),"Not info");
            //    var teacher1 = new Teacher.Teacher(subjectOfTeacher1,"none",1, person1);
            //    teachers.Add(teacher1);
            //}

            //TimeLessons.TimeLessons timeLessons = new TimeLessons.TimeLessons(new TimeSpan(09, 00, 00), new TimeSpan(10, 30, 00), 1);
            //var timeLessonss = new List<TimeLessons.TimeLessons>
            //{
            //    new TimeLessons.TimeLessons(new TimeSpan(09, 00, 00), new TimeSpan(10, 30, 00), 1),
            //    new TimeLessons.TimeLessons(new TimeSpan(10, 40, 00), new TimeSpan(12, 10, 00), 2),
            //    new TimeLessons.TimeLessons(new TimeSpan(13, 00, 00), new TimeSpan(14, 30, 00), 3),
            //    new TimeLessons.TimeLessons(new TimeSpan(14, 40, 00), new TimeSpan(16, 10, 00), 4),
            //    new TimeLessons.TimeLessons(new TimeSpan(16, 20, 00), new TimeSpan(17, 50, 00), 5),
            //    new TimeLessons.TimeLessons(new TimeSpan(18, 00, 00), new TimeSpan(19, 30, 00), 6),
            //};
            //TypeLessons.TypeLessons typeLessons = new TypeLessons.TypeLessons("Лекция");
            //var typeLessonss = new List<TypeLessons.TypeLessons>
            //{
            //    new TypeLessons.TypeLessons("Лекция"),
            //    new TypeLessons.TypeLessons("Практика"),
            //};





            Console.WriteLine("Вы вышли в основную программу!");
            Console.ReadLine();
        }
    }
}
