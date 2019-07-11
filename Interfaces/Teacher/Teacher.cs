using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.Interface;
using Interface.Interfaces;
using Teacher.Interfaces;

namespace Teacher
{
    class Teacher : ITeacherWithConsole
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
            SubjectOfTeachers = subjectOfTeachers;
            Certification = certification;
            Rate = rate;
            Person = person;
        }

        public void ToConsole()
        {
            ((IConsole)Person).ToConsole();
        }
    }
}
