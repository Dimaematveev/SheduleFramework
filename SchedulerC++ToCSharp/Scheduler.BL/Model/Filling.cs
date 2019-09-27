using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class Filling: Fillin
    {
        //TODO:
        protected List<List<List<Group>>> vec = new List<List<List<Group>>>();//Auditory,Number Group, Group
        protected List<List<int>> zap = new List<List<int>>();//Auditory,Number Group
        protected  void GetVec()
        {
            for (int t1 = 0; t1 < tim[0].RetKol(); t1++)
            {
                for (int a1 = 0; a1 < audit[0].RetKol(); a1++)
                {
                    audit[a1].GetVar1();
                    tim[t1].GetVar1();
                    Console.WriteLine(" vec.size='" + vec[a1].Count + "'");
                    for (int i = 0; i < vec[a1].Count; i++)
                    {
                        Console.WriteLine("i='" + i + "'Filling='" + zap[a1][i] + "'");
                        for (int j = 0; j < vec[a1][i].Count; j++)
                        {
                            //TODO:Не понимаю условия это вывод
                            //if (vec[a1][i][j]!=null)
                            //{
                            //    vec[a1][i][j].GetVar1();
                            //}
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public void Var()
        {
            //TODO:
            vec.Add(new List<List<Group>>());
            zap.Add(new List<int>());
            for (int a1 = 0; a1 < audit[0].RetKol(); a1++)
            {
                List<int> LastId = new List<int>();
                for (int i = 0; i < grou[0].RetKol(); i++)
                {
                    if (grou[i].RetNumberPersons() <= audit[a1].RetPeopleClassroom())
                    {
                        List<Group> vec1 = new List<Group>();
                        vec1.Add(grou[i]);
                        LastId.Add(i);
                        vec[a1].Add(vec1);
                        zap[a1].Add(grou[i].RetNumberPersons());
                    }
                }

                for (int i = 0; i < zap[a1].Count; i++)
                {
                    for (int j = LastId[i] + 1; j < grou[0].RetKol(); j++)
                    {
                        if (zap[a1][i] + grou[j].RetNumberPersons() <= audit[a1].RetPeopleClassroom())
                        {
                            List<Group> vec1 = new List<Group>();
                            vec1 = vec[a1][i];
                            vec1.Add(grou[j]);
                            LastId.Add(j);
                            vec[a1].Add(vec1);
                            zap[a1].Add(zap[a1][i] + grou[j].RetNumberPersons());
                        }
                    }
                }
            }


        }

    }
}
