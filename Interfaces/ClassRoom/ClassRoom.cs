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
            //TODO:Проверка что Number>0
            NameClass = nameClass;
            NumberOfPeople = numberOfPeople;
        }

        public void ToConsole()
        {
            Console.WriteLine($"Аудитория {NameClass} вмещает {NumberOfPeople}.");
        }
    }
}
