using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSheduler.CMD
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Привет мир!");

            ///Создаем подключение к БД
            ///т.к. работает с внешним хранилищем и за безопасность
            ///
            //InitialFilling.Filling();
            //InitialFilling.Filling1();
            // InitialFilling.Filling2();

            Filling<Teacher>[] fillingTeachers;
            Filling<Group>[] fillingGroups;
            Filling<Classroom>[] fillingClassrooms;
            PossibleFilling[] possibleFillings;
            using (var context = new MyDbContext())
            {
                var classrooms = context.Classrooms.ToArray();
                var groups = context.Groups.ToArray();
                var subjects = context.Subjects.ToArray();
                var teachers = context.Teachers.ToArray();
                var curricula = context.Curricula.ToArray();
                var subjectOfTeachers = context.SubjectsOfTeachers.ToArray();
                var pairs = context.Pairs.ToArray();
                var studyDays = context.StudyDays.ToArray();


                //Выводы на консоль
                //ConsoleOut.ConsoleClassroom(classrooms, 0);
          
                //ConsoleOut.ConsoleGroup(groups, 0, false);
                //ConsoleOut.ConsoleSubject(subjects, 0, false);
                //ConsoleOut.ConsoleTeacher(teachers, 0, false);

                //ConsoleOut.ConsoleCurriculum(curricula);
                //ConsoleOut.ConsoleSubjectOfTeacher(subjectOfTeachers);

                //ConsoleOut.ConsolePair(pairs);
                //ConsoleOut.ConsoleStudyDay(studyDays);

                ///Получили когда возможно свободные  пары по дням
                possibleFillings = GetPossibleFilling(pairs, studyDays);
                possibleFillings = possibleFillings.OrderBy(x => x.StudyDay.NameDayOfWeek).ToArray();
                ///Получили когда возможно свободные  пары по дням и по преподавателям
                fillingTeachers = GetFilling(teachers, possibleFillings);
                ///Получили когда возможно свободные  пары по дням и по группам
                fillingGroups = GetFilling(groups, possibleFillings);
                ///Получили когда возможно свободные  пары по дням и по аудиториям
                fillingClassrooms = GetFilling(classrooms, possibleFillings);

                //TODO: первый без объединения групп второй с объединением
                CreateScheduler createScheduler = new CreateScheduler();
                //var NotFill = createScheduler.SetSchedule(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
                var NotFillUnion = createScheduler.SetScheduleWithUniouGroup(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
                //var Not1Fill = FillingMaxNumberPair(fillingTeachers, fillingGroups, fillingClassrooms,possibleFillings, classrooms, curricula, subjectOfTeachers);

                //Для вывода лучше сдать таблицу, потом выводить
                ConsoleOut.ConsoleFilling(fillingClassrooms, "РАСПРЕДЕЛЕНИЕ ПО АУДИТОРИЯМ");
                ConsoleOut.ConsoleFilling(fillingTeachers, "РАСПРЕДЕЛЕНИЕ ПО ПРЕПОДАВАТЕЛЯМ");
                ConsoleOut.ConsoleFilling(fillingGroups, "РАСПРЕДЕЛЕНИЕ ПО ГРУППАМ");

            }

            Console.ReadLine();

        }




        /// <summary>
        /// Получить заполнение по каждому (преподавателю,группе,аудитории)
        /// </summary>
        /// <typeparam name="T">(преподавателю,группе,аудитории)</typeparam>
        /// <param name="array">массив (преподавателю,группе,аудитории)</param>
        /// <param name="possibleFillings">массив свободных дней</param>
        /// <returns>массив заполнение по каждому (преподавателю,группе,аудитории)</returns>
        private static Filling<T>[] GetFilling<T>(T[] array, PossibleFilling[] possibleFillings) where T:IName
        {
            var result = new List<Filling<T>>();

            foreach (var item in array)
            {
                var tempPossibleFillings = new List<PossibleFilling>();
                foreach (var possibleFilling in possibleFillings)
                {
                    tempPossibleFillings.Add(possibleFilling.Clone() as PossibleFilling);
                }
                result.Add(new Filling<T>(item, tempPossibleFillings.ToArray()));
            }
            return result.ToArray();
        }

        /// <summary>
        /// Все  возможные свободные дни с парами
        /// </summary>
        /// <param name="pairs">Какие пары в этот день</param>
        /// <param name="studyDays">Какие дни</param>
        /// <returns>Массив возможные свободные дни с парами</returns>
        private static PossibleFilling[] GetPossibleFilling(Pair[] pairs, StudyDay[] studyDays)
        {
            var possibleFillings = new List<PossibleFilling>();
            foreach (var studyDay in studyDays)
            {
                foreach (var pair in pairs)
                {
                    possibleFillings.Add(new PossibleFilling(pair, studyDay));
                }
            }
            return possibleFillings.ToArray();
        }


        
    }
}
