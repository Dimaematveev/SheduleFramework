using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Begin");
            var sem = new Semester( new DateTime(2019, 02, 12), new DateTime(2019, 06, 02));
            sem.CommandConsole();
            Console.WriteLine("Вы вышли в основную программу!");    
            Console.ReadLine();
        }
    }
}
