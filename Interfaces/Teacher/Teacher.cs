using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.Interface;
using Interface.Interfaces;
using SubjectOfTeacher.Interfaces;
using Teacher.Interfaces;

namespace Teacher
{
    public class Teacher : ITeacherWithConsole<ISubjectOfTeacherWithConsole>
    {
        

        public List<ISubjectOfTeacherWithConsole> SubjectOfTeachers { get; set; }
        public string Certification { get; set; }
        public int Rate { get; set; }
        public IPerson Person { get; set; }

        public Teacher( List<ISubjectOfTeacherWithConsole> subjectOfTeachers, 
                        string certification, 
                        int rate, 
                        IPerson person)
        {
            if (subjectOfTeachers == null || subjectOfTeachers.Count<=0)
            {
                throw new ArgumentNullException("Предмет учителя не должен быть пустым!", nameof(subjectOfTeachers));
            }

            if (string.IsNullOrWhiteSpace(certification))
            {
                throw new ArgumentException("Сертификаты не должны быть пусты!", nameof(certification));
            }
            if (rate < 1) 
            {
                throw new ArgumentException("Ставка не может быть меньше 1!", nameof(rate));
            }
            if (rate > 4)
            {
                throw new ArgumentException("Ставка не может быть больше 4!", nameof(rate));
            }
            if (person == null)
            {
                throw new ArgumentNullException("Человек не должен быть пустым!", nameof(person));
            }
            SubjectOfTeachers = subjectOfTeachers;
            Certification = certification;
            Rate = rate;
            Person = person;
        }

        public void ToConsole()
        {
            ((IConsole)Person).ToConsole();
            foreach (var item in SubjectOfTeachers)
            {
                item.ToConsole();
            }
        }
    }
}
