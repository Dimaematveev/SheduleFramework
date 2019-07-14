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
            if (string.IsNullOrWhiteSpace(nameType))
            {
                throw new ArgumentException("Имя типа занятия не должно быть пустым!", nameof(nameType));
            }

            NameType = nameType;
        }
        public void ToConsole()
        {
            Console.WriteLine(NameType);
        }
    }
}
