using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");
            var sem = new Semester(new DateTime(2019, 02, 02), new DateTime(2019, 05, 28));

            sem.CommandConsole();

            Console.WriteLine("Вы вышли в основную программу!");    
            Console.ReadLine();
        }
    }
}
