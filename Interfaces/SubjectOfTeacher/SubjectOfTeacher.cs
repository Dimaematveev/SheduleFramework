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
            if (subject == null)
            {
                throw new ArgumentNullException("Предмет не должен быть пустым!", nameof(subject));
            }
            if (percent <0 && percent > 100)
            {
                throw new ArgumentNullException("Процент не должен быть меньше 0 и больше 100!", nameof(percent));
            }
            Subject = subject;
            Percent = percent;
        }
        public override string ToString()
        {
            return $"Преподаватель готов вести предмет {Subject.NameSubject} с уверенностью в {Percent}%";
        }
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
