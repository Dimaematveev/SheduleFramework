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
        //В какую аудиторию какие группы могут поместиться
        protected List<List<List<Group>>> vec = new List<List<List<Group>>>();//Auditory,Number Group, Group
        // количество человек при этом 
        protected List<List<int>> zap = new List<List<int>>();//Auditory,Number Group

        public  void GetVec()
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
                            if (vec[a1][i][j] != null)
                            {
                                vec[a1][i][j].GetVar1();
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

       


        public void Var()
        {
            //TODO:
            
            //Проходим по аудиториям
            for (int a1 = 0; a1 < audit[0].RetKol(); a1++)
            {
                //Лист с чемто)
                vec.Add(new List<List<Group>>());
                //Второй лист с кол-во человек в аудитории
                zap.Add(new List<int>());
                //список для последнего чегото
                List<int> LastId = new List<int>();
                //проход по группам
                for (int i = 0; i < grou[0].RetKol(); i++)
                {
                    //кол-во человек в группе или равно  чем в аудитории
                    if (grou[i].RetNumberPersons() <= audit[a1].RetPeopleClassroom())
                    {
                        //пустой лист групп
                        List<Group> vec1 = new List<Group>();
                        //добавляем в лист эту группу
                        vec1.Add(grou[i]);
                        //добавляем в последний рассмотренный индекс наш индекс группы
                        LastId.Add(i);
                        //добавляем в век наш лист групп
                        vec[a1].Add(vec1);
                        // в зап добавляем кол-во человек
                        zap[a1].Add(grou[i].RetNumberPersons());
                    }
                }
                //проходим по заполненности аудиторий
                for (int i = 0; i < zap[a1].Count; i++)
                {
                    // до заполняем  теми группами которые еще вмещаются в аудиторию

                    for (int j = LastId[i] + 1; j < grou[0].RetKol(); j++)
                    {
                        if (zap[a1][i] + grou[j].RetNumberPersons() <= audit[a1].RetPeopleClassroom())
                        {
                            List< Group> vec1 = new List<Group>(vec[a1][i]);
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
