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
                ConsoleOut.ConsoleClassroom(classrooms, 0);
          
                ConsoleOut.ConsoleGroup(groups, 0, false);
                ConsoleOut.ConsoleSubject(subjects, 0, false);
                ConsoleOut.ConsoleTeacher(teachers, 0, false);

                ConsoleOut.ConsoleCurriculum(curricula);
                ConsoleOut.ConsoleSubjectOfTeacher(subjectOfTeachers);

                ConsoleOut.ConsolePair(pairs);
                ConsoleOut.ConsoleStudyDay(studyDays);

                ///Получили когда возможно свободные  пары по дням
                possibleFillings = GetPossibleFilling(pairs, studyDays);
                possibleFillings = possibleFillings.OrderBy(x => x.StudyDay.NameDayOfWeek).ToArray();
                ///Получили когда возможно свободные  пары по дням и по преподавателям
                fillingTeachers = GetFilling(teachers, possibleFillings);
                ///Получили когда возможно свободные  пары по дням и по группам
                fillingGroups = GetFilling(groups, possibleFillings);
                ///Получили когда возможно свободные  пары по дням и по аудиториям
                fillingClassrooms = GetFilling(classrooms, possibleFillings);


                var NotFill = FillingMaxNumberPair(fillingTeachers, fillingGroups, fillingClassrooms, possibleFillings, classrooms, curricula, subjectOfTeachers);

                //Для вывода лучше сдать таблицу, потом выводить
                ConsoleOut.ConsoleFilling(fillingClassrooms, "РАСПРЕДЕЛЕНИЕ ПО АУДИТОРИЯМ");
                ConsoleOut.ConsoleFilling(fillingTeachers, "РАСПРЕДЕЛЕНИЕ ПО ПРЕПОДАВАТЕЛЯМ");
                ConsoleOut.ConsoleFilling(fillingGroups, "РАСПРЕДЕЛЕНИЕ ПО ГРУППАМ");

            }

            Console.ReadLine();

        }

        /// <summary>
        /// Метод заполнения пар преподавателю, группе, аудитории.
        /// Заполнение идет в порядке уменьшения количества пар у всех групп
        /// </summary>
        /// <param name="fillingTeachers"> занятость преподавателя </param>
        /// <param name="fillingGroups"> занятость группы </param>
        /// <param name="fillingClassrooms"> занятость аудитории </param>
        /// <param name="possibleFillings">  занятость (скопирована для всех) </param>
        /// <param name="classrooms"> аудитория </param>
        /// <param name="curricula"> План занятий </param>
        /// <param name="subjectOfTeachers"> Предмет и преподаватель</param>
        private static Curriculum[] FillingMaxNumberPair(Filling<Teacher>[] fillingTeachers,
                                                 Filling<Group>[] fillingGroups,
                                                 Filling<Classroom>[] fillingClassrooms,
                                                 PossibleFilling[] possibleFillings,
                                                 Classroom[] classrooms,
                                                 Curriculum[] curricula,
                                                 SubjectOfTeacher[] subjectOfTeachers)
        {
            //Todo-:Нужно какие группы в какие аудитории поместятся-необязательно уже фильтруются ниже
            //Todo:объединение групп

            //план который не вошел
            var curriculaNot = new List<Curriculum>();
            //Элемент с максимальным числом пар в 2 недели
            var curriculaMax = curricula.OrderByDescending(x => x.NumberOfPairs).First();
            while (curriculaMax.NumberOfPairs != 0)
            {
                //беру по одной паре и добавляю преподавателя 
                //todo: по другому сделать поиск преподавателя
                //todo: сделать указания какие преподаватели уже есть в группе

                //Знаем и преподавателя и предмет и группу осталась аудитория
                var teacher = subjectOfTeachers.First(x => x.SubjectId == curriculaMax.SubjectId).Teacher;
                //Массив со всеми аудиториями подходящими и сортированный максимально заполненной
                //todo?: Сделать так чтобы добавлялись по парам в один день, потом в эту пару через неделю
                var oneClass = classrooms.Where(x => x.NumberOfSeats >= curriculaMax.Group.NumberOfPersons)
                                     .OrderBy(x => x.NumberOfSeats - curriculaMax.Group.NumberOfPersons)
                                     .ToArray();
                var fillingTeacher = fillingTeachers.First(x => x.Value.TeacherId == teacher.TeacherId);
                var fillingGroup = fillingGroups.First(x => x.Value.GroupId == curriculaMax.GroupId);
                var fillingClassroom = fillingClassrooms.First(x => x.Value.ClassroomId == oneClass[0].ClassroomId);

                //Успешноли добавилось?
                bool success = false;
                //Цикл для success
                bool wh = true;
                // С какая  аудитория проверяется из oneClass
                int numberClass = 0;
                while (wh)
                {
                    for (int i = 0; i < possibleFillings.Length; i++)
                    {
                        //Условия что в этот день в эту пару Преподаватель группа и классная комната не заняты
                        bool FT = fillingTeacher.PossibleFillings[i].BusyPair == null;
                        bool FG = fillingGroup.PossibleFillings[i].BusyPair == null;
                        bool FC = fillingClassroom.PossibleFillings[i].BusyPair == null;
                        if (FT && FG && FC)
                        {
                            BusyPair busyPair = new BusyPair(oneClass[numberClass], teacher, curriculaMax.Subject, curriculaMax.Group);
                            fillingTeacher.PossibleFillings[i].BusyPair = busyPair;
                            fillingGroup.PossibleFillings[i].BusyPair = busyPair;
                            fillingClassroom.PossibleFillings[i].BusyPair = busyPair;
                            success = true;
                            wh = false;
                            break;
                        }
                    }
                    if (success == false)
                    {
                        numberClass++;
                        if (numberClass >= oneClass.Length)
                        {
                            wh = false;
                        }
                        else
                        {
                            fillingClassroom = fillingClassrooms.First(x => x.Value.ClassroomId == oneClass[numberClass].ClassroomId);
                        }
                    }
                }
                if (success == false)
                {
                    int ind = curriculaNot.FindIndex(x => x.CurriculumId == curriculaMax.CurriculumId);
                    if (ind == -1)
                    {
                        curriculaNot.Add(
                            new Curriculum()
                            {
                                CurriculumId = curriculaMax.CurriculumId,
                                Group = curriculaMax.Group,
                                GroupId = curriculaMax.GroupId,
                                Subject = curriculaMax.Subject,
                                SubjectId = curriculaMax.SubjectId,
                                NumberOfPairs = 1
                            }
                        );
                    }
                    else
                    {
                        curriculaNot[ind].NumberOfPairs++;
                    }
                    
                }
                curriculaMax.NumberOfPairs--;
                curriculaMax = curricula.OrderByDescending(x => x.NumberOfPairs).First();
            }
            foreach (var item in curriculaNot)
            {
                Console.WriteLine($"Не получилось((group={item.Group.Name}  Number pair ={item.NumberOfPairs,3} subj={item.Subject.Name} " );
            }
            return curriculaNot.ToArray();
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
