using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    public class BusyPair
    {
        public Classroom Classroom{get;set;}
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public Group Group { get; set; }
        public BusyPair(Classroom classroom, Teacher teacher, Subject subject, Group group)
        {
            Classroom = classroom;
            Teacher = teacher;
            Subject = subject;
            Group = group;
        }
    }
}
