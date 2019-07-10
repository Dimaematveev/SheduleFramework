using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ClassRoom> classRooms = new List<ClassRoom>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                classRooms.Add(new ClassRoom(Guid.NewGuid().ToString().Substring(0, 6), rnd.Next(15, 120)));
            }
            foreach (var item in classRooms)
            {
                item.ToConsole();
            }

            Console.ReadLine();
        }
    }
}
