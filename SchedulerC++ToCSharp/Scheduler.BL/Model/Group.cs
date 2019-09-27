using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class Group: Grou
    {
        public static List<string> pgs = new List<string>();
        public static List<int> pgi = new List<int>();
        public static List<string> sgs = new List<string>();
        public static List<int> sgi = new List<int>();
        public static List<string> grs = new List<string>();
        public static List<int> gri = new List<int>();

        //TODO:
        public override void SetVar(MyFile file, int line)
        {
            base.SetVar(file, line);
            SetVec();
        }

        public override int RetNumber()
        {
            return number;
        }
        public void SetVec()
        {
            int r = 0;
            for (int i = 0; i < pgs.Count; i++)
            {
                if (pgs[i] == NameSteam) { pgi[i] += NumberPersons; }
                else
                {
                    r++;
                    if (r == pgs.Count)
                    {
                        pgs.Add(NameSteam);
                        pgi.Add(0);
                    }
                }
            }
            r = 0;
            for (int i = 0; i < grs.Count; i++)
            {
                if (grs[i] == NameGroup) { gri[i] += NumberLesons; }
                else
                {
                    r++;
                    if (r == grs.Count)
                    {
                        grs.Add(NameGroup);
                        gri.Add(0);
                    }
                }
            }
            r = 0;
            for (int i = 0; i < sgs.Count; i++)
            {
                if (sgs[i] == NameSeminar) { sgi[i] += NumberPersons; }
                else
                {
                    r++;
                    if (r == sgs.Count)
                    {
                        sgs.Add(NameSeminar);
                        sgi.Add(0);
                    }
                }
            }

        }
        public void GetPub()
        {
            for (int i = 0; i < pgs.Count; i++)
                Console.WriteLine("Steam=" + pgs[i] + " number people =" + pgi[i]);
            for (int i = 0; i < sgs.Count; i++)
                Console.WriteLine("Seminar=" + sgs[i] + " number people=" + sgi[i]);
            for (int i = 0; i < grs.Count; i++)
                Console.WriteLine("Group=" + grs[i]);

        }

    }
}
