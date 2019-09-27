using Scheduler.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.CMD
{
    class Program
    {
        //TODO:
        //int Auditory.number;
        //int Grou.number;
        //int BeginTime.number;
        //List<string> Group.pgs(1);
        //List<int> Group.pgi(1);
        //List<string> Group.grs(1);
        //List<int> Group.gri(1);
        //List<string> Group.sgs(1);
        //List<int> Group.sgi(1);
        static void Main(string[] args)
        {

            int N = 3;//Number files
            

            string[] file = new string[]
            {
                "group_kol.txt",
                "aud_mest.txt",
                "par_nach.txt"
            };
            MyFile[] bp = new MyFile[N];
            for (int i = 0; i < N; i++)
            {
                bp[i] = new MyFile();
                bp[i].SetVar(file[i]);
            }
            /*********************************************************************************/

            //START creating an array of abstract classes
            Group[] g = new Group[bp[0].RetNumberLines()];
            for (int j = 0; j < bp[0].RetNumberLines(); j++)
            {
                g[j] = new Group();
                g[j].SetVar(bp[0], j);
            }
            Auditory[] a = new Auditory[bp[1].RetNumberLines()];
            for (int j = 0; j < bp[1].RetNumberLines(); j++)
            {
                a[j] = new Auditory();
                a[j].SetVar(bp[1], j);
            }
            BeginTime[] t = new BeginTime[bp[2].RetNumberLines()];
            for (int j = 0; j < bp[2].RetNumberLines(); j++)
            {
                t[j] = new BeginTime();
                t[j].SetVar(bp[2], j);
            }
            //END creating an array of abstract classes
            /*********************************************************************************/

            /*********************************************************************************/
            //START constructor class Filling
            Console.WriteLine("Enter potok\'p\' or Seminar \'s\':");
            char ch;// = 'p';//s or p
            do
            {
                ch = Console.ReadKey().KeyChar;
            } while (ch != 'p' && ch != 's');
            Console.WriteLine();
            Filling1 Fil = new Filling1();
            Fil.SetVar(a, t, g);
            Fil.Var(ch);
            Fil.SetMass();
            closeAnswer(Fil);

                //END constructor class Filling
                /*********************************************************************************/

                /*********************************************************************************/
                //START free dynamic memory
            

            /*else {
            cout << "Goodby. Some file not open!";
            }*/

            ////END free dynamic memory
            /*********************************************************************************/

            
        }


            public static void menu()
            {
            const int N = 6;
            int m = 50;
            for (int i = 0; i <= m; i++)
            {
                Console.Write( "=");
            }
            Console.WriteLine();

            string str = "МЕНЮ УПРАВЛЕНИЯ МЕНЕДЖЕРОМ РАСПИСАНИЯ";
            Console.WriteLine(" ".PadRight(((m - str.Length) / 2)) + str);
            for (int i = 0; i <= m; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            string[] str1 = new string[] 
            {
                "Выход из программы",
                "Изменить Выборку",
                "Составить расписание",
                "Расписание для определенной группы",
                "Вывод аудиторий",
                "Вывод групп"
            };
            for (int i = 1; i <= N; i++)
            {
                //stringstream out;
                //out << setw(2) << i % N << " | " << str1[i % N];
                //Console.WriteLine(left + "|" + setw(m - 1) + out.str() + "|");
                for (int j = 0; j <= m; j++) 
                {
                    Console.Write( "-");
                }
                Console.WriteLine();
            }
        }


        public static void closeAnswer(Filling1 Fil)
        {
            int userAnswer = -1;
            char userClose = '1';
            char ch;
            while (userClose == '1')
            {
                menu();
                Console.WriteLine("Введите значение для перехода по меню: ");
                do
                {
                    //ch = 13;
                    //cout << ch;
                    ch = Console.ReadKey().KeyChar;
                } while (ch < '0' || ch > '5');
                Console.WriteLine();
                userAnswer = ch - '0';
                userClose = 'q';
                string column="";
                switch (userAnswer)
                {
                    case 1:
                        Console.WriteLine("код для изменения поток(\'p\') или семинар (\'s\')");
                        Console.WriteLine("Enter potok\'p\' or Seminar \'s\':");
                        //char ch;// = 'p';//s or p
                        do
                        {
                            ch = Console.ReadKey().KeyChar;
                        } while (ch != 'p' && ch != 's');
                        Console.WriteLine();
                        Fil.Var(ch);
                        Fil.SetMass();
                        userClose = '1';
                        break;
                    case 2:
                        Console.WriteLine("код для составления расписания");
                        Fil.GetTable(-1);
                        Console.WriteLine("Continue? yes-\'1\', no-\'0\')" );
                        break;
                    case 3:
                        Console.WriteLine("код для вывода расписания определенной группы");
                        Fil.GetTable(Fil.RetProvGroup(column));
                        Console.WriteLine("Continue? yes-\'1\', no-\'0\')" );
                        break;
                    case 4:
                        Console.WriteLine("код для вывода аудиторий");
                        Fil.GetAuditory();
                        Console.WriteLine("Continue? yes-\'1\', no-\'0\')" );
                        break;
                    case 5:
                        Console.WriteLine("код для вывода групп");
                        Fil.GetGroup();
                        Console.WriteLine("Continue? yes-\'1\', no-\'0\')" );
                        break;
                    case 0:
                        userClose = '0';
                        break;
                }
                while (userClose != '1' && userClose != '0')
                {
                    
                    userClose = Console.ReadKey().KeyChar;
                }
            }
            Console.WriteLine();
            Console.WriteLine( "Спасибо за использование программы!");
        }

    }
}
