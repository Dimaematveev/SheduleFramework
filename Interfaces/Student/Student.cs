using Interface.Interface;
using Interface.Interfaces;
using Student.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student : IStudentWithConsole
    {
        public IGroup Group { get ; set; }
        public IPerson Person { get ; set; }

        public Student(IGroup group, IPerson person)
        {
            Group = group;
            Person = person;
        }
        public void ToConsole()
        {
            ((IConsole)Group).ToConsole();
            ((IConsole)Person).ToConsole();
        }
    }
}
