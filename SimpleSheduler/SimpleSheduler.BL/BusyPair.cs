using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    /// <summary>
    /// Заолненая пара.
    /// </summary>
    public class BusyPair:ICloneable
    {
        public Classroom Classroom{get;set;}
       // public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public Group[] Groups { get; set; }
        public BusyPair(Classroom classroom,  Subject subject, Group group)
        {
            Classroom = classroom;
            
            Subject = subject;
            Groups = new Group[] { group };
        }

        public BusyPair(Classroom classroom, Subject subject, Group[] group)
        {
            Classroom = classroom;
           
            Subject = subject;
            Groups = group;
        }
        public object Clone()
        {
            var newClassroom = Classroom.Clone() as Classroom;
         
            var newSubject = Subject.Clone() as Subject;
            var newGroups = Groups.Clone() as Group[];

            BusyPair newBusyPair = new BusyPair(newClassroom,  newSubject, newGroups);
           
            return newBusyPair;
        }
        public override string ToString()
        {
            string str = $"C:{Classroom}, S:{Subject}, G:";
            string groups = "";
            foreach (var group in Groups)
            {
                groups += $"{group}_";
            }
            str += $"{groups.Remove(groups.Length - 1, 1)}.";
            return str;
        }
    }
}
