using Interface.Interface;
using SubjectOfTeacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectOfTeacher
{
    public class SubjectOfTeacher : ISubjectOfTeacherWithConsole
    {
        public ISubject Subject { get; set; }
        public int Percent { get; set; }
        public SubjectOfTeacher(ISubject subject, int percent)
        {
            Subject = subject;
            Percent = percent;
        }
        public void ToConsole()
        {
            Console.WriteLine($"Преподаватель готов вести предмет {Subject.NameSubject} с уверенностью в {Percent}%");
        }
    }
}
