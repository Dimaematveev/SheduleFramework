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
            var sem = new Semester(new DateTime(2019, 06, 01), new DateTime(2019, 08, 01));
            sem.ToConsole();

            Console.ReadLine();
        }
    }
}
