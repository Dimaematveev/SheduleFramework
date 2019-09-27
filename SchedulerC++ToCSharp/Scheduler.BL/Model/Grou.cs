using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class Grou : Common
    {
        protected int NumberPersons;
        protected string NameGroup;
        protected string NameSeminar;
        protected string NameSteam;
        protected int NumberLesons;
        protected static int number;


        public override void GetVar()
        {
            Console.WriteLine("NumberPersons:'" + NumberPersons + "' NameGroup:'" + NameGroup + "' NameSeminar:'" + NameSeminar + "' NameSteam:'" + NameSteam + "'");

        }
        public override void GetVar1()
        {
            //TODO:
            //stringstream out;
            //out << NameGroup << "(" << NumberPersons << ")";
            //cout << setw(10) << out.str();
            throw new NotImplementedException();
        }
        //TODO:
        public override void SetVar(MyFile file, int line)
        {
            this.file = file;
            this.line = line;
            var kkk = this.file.GetOut(line).Split(';');
            NumberPersons = Convert.ToInt32( kkk[0]);
            NameGroup = kkk[1];
            NameSeminar = kkk[2];
            NameSteam = kkk[3];
            this.NumberLesons = 0;
            SetNumberLessons();
            number++;
        }
        public override int RetNumber()
        {
            return number;
        }
        public void SetNumberLessons()
        {
            /*cout << "Complete the number of lessons for two weeks in a group:" << endl;
            GetVar();
            cout << " lessons=";*/
            int k;
            //cin >> k;
            k = 2;
            //cout << k << endl;
            this.NumberLesons = k;
        }

        public int RetNumberPersons()
        {
            return NumberPersons;
        }
        public string RetNameSeminar()
        {
            return NameSeminar;
        }
        public string RetNameSteam()
        {
            return NameSteam;
        }
        public string RetNameGroup()
        {
            return NameGroup;
        }
        public int RetNumberLesons()
        {
            return NumberLesons;
        }

}
}
