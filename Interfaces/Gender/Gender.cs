using Gender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gender
{
    class Gender : IGenderWithConsole
    {
        
        public string NameGender { get; set; }

        public Gender(string nameGender)
        {
            NameGender = nameGender;
        }

        public void ToConsole()
        {
            Console.WriteLine(NameGender);
        }
    }
}
