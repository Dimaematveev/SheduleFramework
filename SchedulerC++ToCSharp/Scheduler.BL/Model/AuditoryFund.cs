using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class AuditoryFund: IAuditoryFund
    {
        //TODO:
        private Auditory[] A;
        private BeginTime[] BT;
        private Group[] G;
        private Filling1 F;
        char ch;
        //TODO:
        private string[][][][] AuditFund;

        //TODO:
        public List<List<List<Group>>> vecsp;//Vector. Auditory+NumberGroup+Group
        public List<List<int>> zapsp;
        protected List<int> NumberOfLesson;
        //TODO:
        public void SetVar(Auditory[] A, BeginTime[] BT, Group[] G, Filling1 F)
        {
            this.A = A;
            this.BT = BT;
            this.G = G;
            this.F = F;

        }
        public void SetVarCh(char ch)
        {
            this.ch = ch;
        }

        public void SetMass()
        {
            AuditFund = new string[2][][][];
            for (int w = 0; w < 2; w++)
            {
                AuditFund[w] = new string[BT[0].RetKol()][][];
                for (int t1 = 0; t1 < BT[0].RetKol(); t1++)
                {
                    AuditFund[w][t1] = new string[A[0].RetKol()][];
                    for (int a1 = 0; a1 < A[0].RetKol(); a1++)
                    {
                        AuditFund[w][t1][a1] = new string[G[0].RetKol()];
                        for (int i = 0; i < G[0].RetKol(); i++)
                            AuditFund[w][t1][a1][i] = "";
                    }
                }
            }
            SetTable();

        }
        public void SetTable()
        {
            int[] NumLess = new int[G[0].RetKol()];
            for (int i = 0; i < G[0].RetKol(); i++)
            {
                NumLess[i] = G[i].RetNumberLesons();
            }

            for (int w = 0; w < 2; w++)
            {
                for (int t1 = 0; t1 < BT[0].RetKol(); t1++)
                {
                    F.Var(ch);
                    for (int a1 = 0; a1 < A[0].RetKol(); a1++)
                    {
                        for (int vv3 = 0; vv3 < vecsp[a1].Count; vv3++)
                        {
                            for (int v4 = 0; v4 < vecsp[a1][vv3].Count; v4++)
                            {
                                if (vecsp[a1][vv3][v4] != null)
                                {
                                    if (NumLess[vecsp[a1][vv3][v4].RetLine()] == 0)
                                    {
                                        for (int v14 = 0; v14 < vecsp[a1][vv3].Count; v14++)
                                        {
                                            vecsp[a1][vv3][v14] = null;
                                        }
                                        zapsp[a1][vv3] = 0;
                                        break;
                                    }
                                }
                            }
                        }
                        //done for number of time = 1

                        //only last element
                        int v3 = vecsp[a1].Count;
                        do
                        {
                            v3--;
                            if (v3 < 0) break;
                            //TODO:Не понимаю условия
                        } while (vecsp[a1][v3][0]!=null);
                        if (v3 >= 0)
                        {
                            for (int i = vecsp[a1][v3].Count; i > 0; i--)
                            {
                                for (int j = 0; j < G[0].RetKol(); j++)
                                {
                                    if (G[j] == vecsp[a1][v3][i - 1])
                                    {
                                        AuditFund[w][t1][a1][j] = "Filling";
                                        NumLess[j]--;
                                        for (int a2 = 0; a2 < A[0].RetKol(); a2++)
                                        {
                                            for (int v13 = 0; v13 < vecsp[a2].Count; v13++)
                                            {
                                                for (int v14 = 0; v14 < vecsp[a2][v13].Count; v14++)
                                                {
                                                    if (G[j] == vecsp[a2][v13][v14])
                                                    {
                                                        vecsp[a2][v13][v14] = null;
                                                        zapsp[a2][v13] = 0;
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    /*for (int a1 = 0; a1 < vecsp.Count; a1++)
                    {
                          for (int v3 = 0; v3 < vecsp[a1].Count; v3++)
                          {

                                for (int v4 = 0; v4 < vecsp[a1][v3].Count; v4++)
                                {
                                      if (vecsp[a1][v3][v4] == nullptr)
                                      {
                                            vecsp[a1].erase(vecsp[a1].begin() + v3);
                                            zapsp[a1].erase(zapsp[a1].begin() + v3);
                                            v3--;
                                            break;
                                      }
                                }
                          }

                          if (vecsp[a1].Count == 0)
                          {
                                vecsp.erase(vecsp.begin() + a1);
                                zapsp.erase(zapsp.begin() + a1);
                                a1--;
                          }
                    }*/
                    //F.GetVecSP(&BT[t1]);
                    //cout <<endl;
                }
            }
            for (int i = 0; i < G[0].RetKol(); i++)
            {
                if (NumLess[i] != 0)
                {
                    G[i].GetVar();
                    Console.WriteLine(" occurs " + (G[i].RetNumberLesons() - NumLess[i]) + " times out of " + G[i].RetNumberLesons());
                }
            }


        }
        public void GetTable(int column)
        {
            const int setW1 = 19, setW2 = 7;
            Console.Write(" ".PadRight(setW1) + "|");
            if (column == -1)
            {
                for (int i = 0; i < G[0].RetKol(); i++)
                {
                    Console.Write(G[i].RetNameGroup() + "|");
                }
            }
            else
            {
                Console.Write(G[column].RetNameGroup() + "|");
            }
            Console.WriteLine();
            for (int i = 0; i < setW1; i++)
            {
                Console.Write("=");
            }
            Console.Write("|");
            if (column == -1)
            {
                for (int i = 0; i < G[0].RetKol(); i++)
                {
                    for (int j = 0; j < setW2; j++)
                        Console.Write("=");
                    Console.Write("|");
                }
            }
            else
            {
                for (int j = 0; j < setW2; j++)
                    Console.Write("=");
                Console.Write("|");
            }
            Console.WriteLine();
            for (int t1 = 0; t1 < BT[0].RetKol(); t1++)
            {
                for (int a1 = 0; a1 < A[0].RetKol(); a1++)
                {
                    for (int w = 0; w < 2; w++)
                    {
                        A[a1].GetVar1();
                        Console.Write(" ");
                        BT[t1].GetVar1();
                        switch (w)
                        {
                            case 0:
                                Console.Write("-I ");
                                break;
                            case 1:
                                Console.Write("-II");
                                break;
                        }
                        Console.Write("|");
                        if (column == -1)
                        {
                            for (int j = 0; j < G[0].RetKol(); j++)
                            {
                                Console.Write(AuditFund[w][t1][a1][j] + "|");
                            }
                        }
                        else
                        {
                            Console.Write(AuditFund[w][t1][a1][column] + "|");
                        }
                        Console.WriteLine();
                    }
                    //cout << endl;
                }
                //cout << endl;
            }
            //cout << endl;

        }


    }
}
