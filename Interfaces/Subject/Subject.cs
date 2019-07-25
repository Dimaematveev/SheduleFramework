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
            if (string.IsNullOrWhiteSpace(nameSubject))
            {
                throw new ArgumentNullException("Название предмета не должно быть пустым!", nameof(nameSubject));
            }

            NameSubject = nameSubject;
        }

        public Subject(string nameSubject, string departament) : this(nameSubject)
        {
            if (string.IsNullOrWhiteSpace(departament))
            {
                throw new ArgumentNullException("Кафедра не должна быть пустой!", nameof(departament));
            }

            Departament = departament;
        }
        public override string ToString()
        {
            return NameSubject;
        }
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
