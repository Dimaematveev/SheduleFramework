using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ClassRoom.ClassRoom classRoom = new ClassRoom.ClassRoom("Аудит1", 101);
            DaysOfStudy.DaysOfStudy daysOfStudy;
            Gender.Gender gender = new Gender.Gender("Мужчина");
            Group.Group group = new Group.Group("TBO", 35, 2, "TBO-2", Interface.Interface.TypeStudy.FullTimeEducation);
            Person.Person person = new Person.Person("Dima", gender, new DateTime(1996, 05, 19), "Юго западная");
            Subject.Subject subject = new Subject.Subject("Математика");
            PlanOfLessons.PlanOfLessons planOfLessons = new PlanOfLessons.PlanOfLessons(group, subject, 14);
            Semester.Semester semester = new Semester.Semester(new DateTime(2019, 02, 02), new DateTime(2019, 06, 01));
            Student.Student student = new Student.Student(group, person);
            SubjectOfTeacher.SubjectOfTeacher subjectOfTeacher = new SubjectOfTeacher.SubjectOfTeacher(subject, 10);
            Teacher.Teacher teacher = new Teacher.Teacher(new List<SubjectOfTeacher.Interfaces.ISubjectOfTeacherWithConsole> { subjectOfTeacher }, "none", 1, person);
            TimeLessons.TimeLessons timeLessons = new TimeLessons.TimeLessons(new TimeSpan(09, 00, 00), new TimeSpan(10, 30, 00), 1);
            TypeLessons.TypeLessons typeLessons = new TypeLessons.TypeLessons("Лекция");

        }
    }
}
