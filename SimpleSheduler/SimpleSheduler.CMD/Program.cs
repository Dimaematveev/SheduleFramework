using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет мир!");

            ///Создаем подключение к БД
            ///т.к. работает с внешним хранилищем и за безопасность
            ///

            InitialFilling initialFilling = new InitialFilling();
            initialFilling.Filling();
            
           

        }
    }
}
