using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheduler.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало!");
            ISemester semester = new Semester.Semester(new DateTime(2019, 09, 01), new DateTime(2019, 12, 31));
            ((IConsole)semester).ToConsole();

            Console.WriteLine("Конец!");
            Console.ReadLine();
        }
    }
}
