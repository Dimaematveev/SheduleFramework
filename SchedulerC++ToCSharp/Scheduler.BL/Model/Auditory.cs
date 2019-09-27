using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class Auditory : Common
    {
        private int PeopleClassroom;
        private string NumberClassroom;
        public static int number;

        public override void GetVar()
        {
            //cout << "Call '" << typeid(Auditory).name() << "' static number='" << number << "' id='" << id << "' " << endl;
            Console.WriteLine("NumberPersons:'" + PeopleClassroom + "' NameGroup:'" + NumberClassroom + "'");

        }
        //TODO:
        public override void GetVar1()
        {
            Console.WriteLine(NumberClassroom + "(" + PeopleClassroom + ")");

        }
        //todo:
        public override void SetVar(MyFile file, int line)
        {
            this.file = file;
            this.line = line;
            var kkk = this.file.GetOut(line).Split(';');
            PeopleClassroom = Convert.ToInt32(kkk[0]);
            NumberClassroom = kkk[1];
            number++;
        }
        public override int RetNumber()
        {
            return number;
        }
        public int RetPeopleClassroom()
        {
            return PeopleClassroom;
        }
        public string RetNumberClassroom()
        {
            return NumberClassroom;
        }


}
}
