using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    class Temp
    {

        /// <summary>
        /// Функция задание расписания без объединения групп:
        /// </summary>
        /// <returns>Массив план не заполненный </returns>
        ///
        /*
        public Curriculum[] SetSchedule()
        {
            //1. Аудитории сортированы по количеству мест
            Classrooms = Classrooms.OrderBy(x => x.NumberOfSeats).ToArray();
            //Номер Аудитории из массива которая сейчас будет рассматриваться
            int NumClassroom = 0;
            //2. Сортируем план занятий по кол-во пар(макс первый)
            //curricula = curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
            //Создал пару по учебному плану с ключем Учебный план и значением равным количеству оставшихся пар
            Dictionary<Curriculum, int> curriculaAndNumPairs = Curricula.ToDictionary(c => c, c => c.NumberOfPairs);
            //Максимальный элемент в паре
            var MaxKey = curriculaAndNumPairs.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var MaxValue = curriculaAndNumPairs[MaxKey];
            //план который не вошел
            var curriculaNot = new List<Curriculum>();
            //3. Цикл по плану занятий пока первый элемент он же максимальный не равен 0
            while (MaxValue != 0)
            {
                //a. Из первого элемента плана понимаем что за предмет и какая группа
                var group = MaxKey.Group;
                var subject = MaxKey.Subject;
                //b. Ищем на предмет первого преподавателя
                var teacher = SubjectOfTeachers.First(x => x.Subject == subject).Teacher;
                //c. Выбираем аудитории с кол-во мест больше чем в группе 
                //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
                NumClassroom = Array.FindIndex(Classrooms, x => x.NumberOfSeats >= group.NumberOfPersons);

                //Теперь для каждой  группы, преподавателя подцепляем занятость
                var fillingTeacher = FillingTeachers.First(x => x.Value.TeacherId == teacher.TeacherId);
                var fillingGroup = FillingGroups.First(x => x.Value.GroupId == MaxKey.GroupId);


                //Лучше циклы по аудиториям и по расписаниями поменять местами
                //Добавилась ли пара
                bool success = false;
                //i. Цикл по расписанию
                for (int cu = 0; cu < fillingTeacher.Length; cu++)
                {

                    //d. Цикл по аудиториям
                    for (int cl = NumClassroom; cl < Classrooms.Length; cl++)
                    {
                        //Теперь для аудитории подцепляем занятость
                        var fillingClassroom = FillingClassrooms.First(x => x.Value.ClassroomId == Classrooms[cl].ClassroomId);
                        //Условия что в этот день в эту пару Преподаватель группа и классная комната не заняты
                        bool FT = fillingTeacher[cu].BusyPair == null;
                        bool FG = fillingGroup[cu].BusyPair == null;
                        bool FC = fillingClassroom[cu].BusyPair == null;
                        //1. Если в этот день свободна и группа и преподаватель и аудитория
                        if (FT && FG && FC)
                        {

                            BusyPair busyPair = new BusyPair(Classrooms[cl], teacher, subject, group);
                            //a. Добавляем им пару
                            fillingTeacher[cu].BusyPair = busyPair;
                            fillingGroup[cu].BusyPair = busyPair;
                            fillingClassroom[cu].BusyPair = busyPair;
                            //b. Заканчиваем 2 цикла(по расписанию и по аудиториям)
                            success = true;
                            break;
                        }



                        //Если закончено
                    }

                    //Цикл по расписанию закончен

                    //b. Заканчиваем 2 цикла(по расписанию и по аудиториям) если пара добавилась
                    if (success)
                    {
                        break;
                    }
                }
                //Цикл аудиторий закончен

                //e. Если не смогли добавить то
                if (!success)
                {

                    int ind = curriculaNot.FindIndex(x => x.CurriculumId == MaxKey.CurriculumId);
                    //i. Если был  такой элемент

                    if (ind == -1)
                    {
                        //1. Сохраняем что не смогли добавить в кол-ве 1 пара
                        curriculaNot.Add(
                            new Curriculum()
                            {
                                CurriculumId = MaxKey.CurriculumId,
                                Group = MaxKey.Group,
                                GroupId = MaxKey.GroupId,
                                Subject = MaxKey.Subject,
                                SubjectId = MaxKey.SubjectId,
                                NumberOfPairs = 1
                            }
                        );
                    }
                    //Иначе если не было такого элемента
                    else
                    {
                        //1. Добавляем к элементу 1 пару
                        curriculaNot[ind].NumberOfPairs++;
                    }
                    //Если закончено
                }
                //Если закончено
                //f. Убираем у максимального элемента 1 пару
                curriculaAndNumPairs.Remove(MaxKey);
                curriculaAndNumPairs.Add(MaxKey, MaxValue - 1);
                //g. Сортируем план занятий по кол-во пар(макс первый)
                MaxKey = curriculaAndNumPairs.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                MaxValue = curriculaAndNumPairs[MaxKey];
            }
            //Цикл плана закончен
            foreach (var item in curriculaNot)
            {
                Console.WriteLine($"Не получилось((group={item.Group.Name}  Number pair ={item.NumberOfPairs,3} subj={item.Subject.Name} ");
            }
            //4. На выход отдаём что не смогли добавить из п.3, e, i
            return curriculaNot.ToArray();
            //Конец функции задание расписания

        }
        */

    }
}
