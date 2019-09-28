using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{

    //TODO: Весь класс переделать
    public class Filling1 : Filling 
    {
        AuditoryFund AuditoryFund = new AuditoryFund();
        public override void SetVar(Auditory[] A, BeginTime[] BT, Group[] G)
        {
            base.SetVar(A, BT, G);
            AuditoryFund.SetVar(A, BT, G, this);
        }

        private void VarS()
        {
            AuditoryFund.vecsp = vec;
            AuditoryFund.zapsp = zap;
            for (int a1 = 0; a1 < audit[0].RetKol(); a1++)
            {
                for (int i = 0; i < AuditoryFund.vecsp[a1].Count; i++)
                {
                    for (int j = 1; j < AuditoryFund.vecsp[a1][i].Count; j++)
                    {
                        if (AuditoryFund.vecsp[a1][i][0].RetNameSeminar() != AuditoryFund.vecsp[a1][i][j].RetNameSeminar())
                        {
                            AuditoryFund.vecsp[a1].RemoveAt( i);
                            AuditoryFund.zapsp[a1].RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }
            }

        }
        private void VarP()
        {
            AuditoryFund.vecsp = vec;
            AuditoryFund.zapsp = zap;
            for (int a1 = 0; a1 < audit[0].RetKol(); a1++)
            {
                for (int v3 = 0; v3 < AuditoryFund.vecsp[a1].Count; v3++)
                {
                    for (int v4 = 1; v4 < AuditoryFund.vecsp[a1][v3].Count; v4++)
                    {
                        if (AuditoryFund.vecsp[a1][v3][0].RetNameSteam() != AuditoryFund.vecsp[a1][v3][v4].RetNameSteam())
                        {
                            AuditoryFund.vecsp[a1].RemoveAt(v3);
                            AuditoryFund.zapsp[a1].RemoveAt(v3);
                            v3--;
                            break;
                        }
                    }
                }
                for (int v3 = 0; v3 < AuditoryFund.vecsp[a1].Count; v3++)
                {
                    bool p = false;
                    for (int v4 = 0; v4 < Group.pgs.Count; v4++)
                    {
                        if (AuditoryFund.vecsp[a1][v3][0].RetNameSteam() == Group.pgs[v4] && AuditoryFund.zapsp[a1][v3] == Group.pgi[v4])
                        {
                            p = true;
                        }
                    }
                    if (p == false)
                    {
                        AuditoryFund.vecsp[a1].RemoveAt(v3);
                        AuditoryFund.zapsp[a1].RemoveAt(v3);
                        v3--;
                    }
                }
            }

        }

        public void GetAuditory()
        {
            for (int i = 0; i < audit[0].RetNumber(); i++)
            {
                audit[i].GetVar();
                Console.WriteLine();
            }
        }


        public void GetGroup()
        {
            for (int i = 0; i < grou[0].RetNumber(); i++)
            {
                grou[i].GetVar();
                Console.WriteLine();
            }
        }


        public void GetTable(int k)
        {
            throw new NotImplementedException();
        }


        public int RetProvGroup(string str)
        {
            for (int i = 0; i < grou[0].RetNumber(); i++)
            {
                Console.WriteLine( "Group Name=" + grou[i].RetNameGroup());

            }

            do
            {
                str = Console.ReadLine();
                for (int i = 0; i < grou[0].RetNumber(); i++)
                {
                    if (str == grou[i].RetNameGroup())
                        return i;
                }
            } while (true);
        }


        public void SetMass()
        {
            AuditoryFund.SetMass();
        }

        public void SetTable()
        {
            AuditoryFund.SetTable();
        }

        public void Var(char ch)
        {
            if (vec.Count == 0)
            {
                base.Var();
            }
            if (ch == 's')
            {
                VarS();
            }
            else
            {
                VarP();
            }
            AuditoryFund.SetVarCh(ch);

        }


        void GetVecSP(BeginTime[] BT)
        {
            Console.WriteLine();
            for (int a1 = 0; a1 < AuditoryFund.vecsp.Count; a1++)
            {
                Console.Write(" time=\'");
                BT[0].GetVar1();
                Console.Write("\' auditory=\'");
                audit[a1].GetVar1();
                Console.WriteLine("\' number of options =\'" + AuditoryFund.vecsp[a1].Count + "\'" );
                for (int i = 0; i < AuditoryFund.vecsp[a1].Count; i++)
                {
                    Console.WriteLine("number=\'" + (i + 1) + "' completed=\'" + AuditoryFund.zapsp[a1][i] + "\' of \'" + audit[a1].RetPeopleClassroom() + "\'");
                    for (int j = 0; j < AuditoryFund.vecsp[a1][i].Count; j++)
                    {
                        AuditoryFund.vecsp[a1][i][j].GetVar1();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }

    }
}
