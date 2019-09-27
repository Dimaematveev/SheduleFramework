using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class BeginTime : Common
    {

        private string Time;
        private static int number;
        public override void GetVar()
        {
            //cout << "Call '" << typeid(Time).name() << "' static number='" << number << "' id='" << id << "' " << endl;
            Console.WriteLine("Time:'" + Time + "'");
            Console.WriteLine();
        }
        //TODO:
        public override void GetVar1()
        {
            Console.WriteLine(Time);

        }
        //TODO:
        public override void SetVar(MyFile file, int line) 
        {
            this.file = file;
            this.line = line;
            var kkk = this.file.GetOut(line).Split(';');
            Time = kkk[0];
            number++;
        }
        public override int RetNumber()
        {
            return number;
        }
        public string RetTime()
        {
            return Time;
        }

}
}
