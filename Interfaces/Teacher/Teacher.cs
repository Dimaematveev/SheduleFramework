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
    public class Teacher : ITeacherWithConsole
    {
        

        public List<ISubjectOfTeacher> SubjectOfTeachers { get; set; }
        public string Certification { get; set; }
        public int Rate { get; set; }
        public IPerson Person { get; set; }

        public Teacher( List<ISubjectOfTeacher> subjectOfTeachers, 
                        string certification, 
                        int rate, 
                        IPerson person)
        {
            if (subjectOfTeachers == null )
            {
                throw new ArgumentNullException("Предмет учителя не должен быть null!", nameof(subjectOfTeachers));
            }
            if (subjectOfTeachers.Count == 0)
            {
                throw new ArgumentNullException("Предмет учителя не должен быть пустым!", nameof(subjectOfTeachers));
            }
            if (string.IsNullOrWhiteSpace(certification))
            {
                throw new ArgumentNullException("Сертификаты не должны быть пусты!", nameof(certification));
            }
            if (rate <= 0 || rate >= 5) 
            {
                throw new ArgumentException($"Ставка не может быть <= 0 или >=5. Сейчас-rate={rate}!", $"{nameof(rate)}");
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

        public override string ToString()
        {
            string ret = "";
            ret+=Person.ToString();
            ret += "\n";
            foreach (var item in SubjectOfTeachers)
            {
                ret += item.ToString();
                ret += "\n";
            }
            return ret;
        }
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
