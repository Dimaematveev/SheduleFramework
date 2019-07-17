using ClassRoom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoom
{
    public class ClassRoom : IClassRoomWithConsole
    {
        

        public string NameClass { get ; set ; }
        public int NumberOfPeople { get; set; }

        public ClassRoom(string nameClass, int numberOfPeople)
        {
            if (string.IsNullOrWhiteSpace(nameClass))
            {
                throw new ArgumentNullException($"Имя аудитории не должно быть пустым.", nameof(nameClass));
            }
            if (numberOfPeople <= 0)
            {
                throw new ArgumentNullException($"Количество людей в аудитории должно быть больше нуля.", nameof(numberOfPeople));
            }
            NameClass = nameClass;
            NumberOfPeople = numberOfPeople;
        }
        public override string ToString()
        {
            return $"Аудитория {NameClass} вмещает {NumberOfPeople}.";
        }
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
