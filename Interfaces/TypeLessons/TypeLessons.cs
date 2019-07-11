using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLessons.Interfaces;

namespace TypeLessons
{
    public class TypeLessons : ITypeLessonsWithConsole
    {
        
        public string NameType { get; set; }

        public TypeLessons(string nameType)
        {
            NameType = nameType;
        }
        public void ToConsole()
        {
            Console.WriteLine(NameType);
        }
    }
}
