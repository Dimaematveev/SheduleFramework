using Interface.Interfaces;
using Person.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person : IPersonWithConsole
    {
        

        public string Name { get; set; }
        public IGender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age
        {
            get
            {
                if(DateTime.Now >= new DateTime(DateTime.Now.Year, BirthDay.Month,BirthDay.Day))
                {
                    return DateTime.Now.Year-BirthDay.Year;
                }
                else
                {
                    return DateTime.Now.Year - BirthDay.Year-1;
                }
            }
        }
        public string Living { get; set; }

        public Person(string name, IGender gender, DateTime birthDay, string living)
        {
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Living = living;
        }
        public void ToConsole()
        {
            Console.WriteLine($"Пол {Gender.NameGender} имя {Name} возраст {Age}");
        }
    }
}
