using Subject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject
{
    public class Subject : ISubjectWithConsole
    {
        public string NameSubject { get; set; }
        public string Departament { get; set; }

        public Subject(string nameSubject)
        {
            NameSubject = nameSubject;
        }

        public Subject(string nameSubject, string departament) : this(nameSubject)
        {
            Departament = departament;
        }

        public void ToConsole()
        {
            Console.WriteLine(NameSubject);
        }
    }
}
