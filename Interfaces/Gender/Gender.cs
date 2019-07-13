using Gender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gender
{
    public class Gender : IGenderWithConsole
    {
        
        public string NameGender { get; set; }

        public Gender(string nameGender)
        {
            if (string.IsNullOrWhiteSpace(nameGender))
            {
                throw new ArgumentNullException("Имя гендера не должно быть пустым!", nameof(nameGender));
            }

            NameGender = nameGender;
        }

        public void ToConsole()
        {
            Console.WriteLine(NameGender);
        }
    }
}
