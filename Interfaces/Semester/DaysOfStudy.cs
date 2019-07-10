﻿using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester
{
    class DaysOfStudy : IDaysOfStudy
    {
        public DateTime Day { get; set; }
        public int Study { get; set; }
        public DaysOfStudy(DateTime day, int study)
        {
            Day = day;
            Study = study;
        }
        public void ToConsole()
        {
            //Console.WriteLine($"'{this.GetType()}' заглушка");
            if (Study==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{Day.Day,4}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.Write($"{Day.Day,4}");
            }
        }
    }
}