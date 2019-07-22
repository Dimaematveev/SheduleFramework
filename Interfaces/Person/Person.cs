using Interface.Interfaces;
using Person.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person : IPersonWithConsole
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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не должно быть пустым!", nameof(name));
            }
            if (gender==null)
            {
                throw new ArgumentNullException("Гендер не должен быть пустым!", nameof(gender));
            }
            if (birthDay >DateTime.Now || birthDay<new DateTime(1870,1,1))
            {
                throw new ArgumentException($"Дата рождения не должна быть больше '{DateTime.Now.ToShortDateString()}' и меньше '01.01.1870'!", nameof(birthDay));
            }
            if (string.IsNullOrWhiteSpace(living))
            {
                throw new ArgumentNullException("Место жительства не должно быть пустым!", nameof(living));
            }

            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Living = living;
        }
        public override string ToString()
        {
            return $"Пол {Gender.NameGender} имя {Name} возраст {Age}";
        }
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
