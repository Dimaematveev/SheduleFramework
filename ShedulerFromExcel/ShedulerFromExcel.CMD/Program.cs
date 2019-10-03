using ShedulerFromExcel.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShedulerFromExcel.CMD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello!");
            var filePath19 = "..\\..\\..\\ShedulerFromExcel.CMD\\Need\\09.03.02_АПиМОБИС_ИКБСП_2019.plx.xls";
            var filePath17 = "..\\..\\..\\ShedulerFromExcel.CMD\\Need\\09.03.02_АПиМОБИС_ИКБСП_2017.plm.xml.xls";
            // Обращение к парсеру Планов.
            EasyExcel easyExcel17 = new EasyExcel(filePath17);
            EasyExcel easyExcel19 = new EasyExcel(filePath19);
            
            Console.ReadLine();
        }
    }
}
