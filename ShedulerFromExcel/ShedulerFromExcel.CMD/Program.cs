﻿using ShedulerFromExcel.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShedulerFromExcel.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            EasyExcel easyExcel = new EasyExcel();
            
            easyExcel.sta();
            Console.ReadLine();
        }
    }
}
