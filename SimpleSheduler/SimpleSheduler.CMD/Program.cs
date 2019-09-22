using SimpleSheduler.BD;
using SimpleSheduler.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.CMD
{
   
    class Program
    {
        /// <summary>
        /// На сколько каждый раз смещается курсов в Консоли
        /// </summary>
        const int posit = 5;
        static void Main()
        {
            Console.WriteLine("Привет мир!");

            ///Создаем подключение к БД
            ///т.к. работает с внешним хранилищем и за безопасность
            ///
            //InitialFilling.Filling();
            //InitialFilling.Filling1();
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

                /*
                ConsoleClassroom(classrooms, 0, false);
                ConsoleGroup(groups, 0, false);
                ConsoleSubject(subjects, 0, false);
                ConsoleTeacher(teachers, 0, false);

                ConsoleCurriculum(curricula);
                ConsoleSubjectOfTeacher(subjectOfTeachers);

                ConsolePair(pairs);
                ConsoleStudyDay(studyDays);
                */

                ///Получили когда возможно свободные  пары по дням
                possibleFillings = GetPossibleFilling(pairs, studyDays);
                ///Получили когда возможно свободные  пары по дням и по преподавателям
                fillingTeachers = GetFilling(teachers, possibleFillings);
                ///Получили когда возможно свободные  пары по дням и по группам
                fillingGroups = GetFilling(groups, possibleFillings);
                ///Получили когда возможно свободные  пары по дням и по аудиториям
                fillingClassrooms = GetFilling(classrooms, possibleFillings);


                






                //Todo:Нужно какие группы в какие аудитории поместятся
                //Todo:объединение групп

                //Элемент с максимальным числом пар в 2 недели
                var curriculaMax = curricula.OrderByDescending(x => x.NumberOfPairs).First();
                while (curriculaMax.NumberOfPairs!=0)
                {
                    //беру по одной паре и добавляю преподаватнля 
                    //todo: подругому сделать поиск преподавателя
                    //todo: сделать указания какие преподаватели уже есть в группе

                    //Знаем и преподавателя и предмет и группу осталась аудитория
                    var teacher = subjectOfTeachers.First(x => x.SubjectId == curriculaMax.SubjectId).Teacher;
                    //Массив со всеми аудиториями подходящими и сортированный максимально заполненной
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
                            //Условия что в этот день в эту пару Преподватель группа и классная комната не заняты
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
                            if (numberClass> oneClass.Length)
                            {
                                wh = false;
                            }
                        }
                    }
                    if (success == false)
                    {
                        Console.WriteLine($"Не получилось((subj={curriculaMax.Subject.Name} group={curriculaMax.Group.Name}");
                    }
                    curriculaMax.NumberOfPairs--;
                    curriculaMax = curricula.OrderByDescending(x => x.NumberOfPairs).First();
                }


                consoleFilling(fillingClassrooms);
            }

            Console.ReadLine();

        }

        private static void consoleFilling(Filling<Classroom>[] fillingClassrooms)
        {
            Console.WriteLine("РАСПРЕДЕЛЕНИЕ ПО АУДИТОРИЯМ");
            int padOneStolb = " Номер и день недели ".Length;
            int padTwoStolb = " Номер и пара ".Length;
            string oneStolb = " Номер и день недели ".PadRight(padOneStolb);
            string twoStolb = " Номер и пара ".PadRight(padTwoStolb);
            Console.Write($"{oneStolb}|{twoStolb}|");
            int padClassroom = fillingClassrooms.Max(x => x.Value.Name.Length);
            foreach (var fillingClassroom in fillingClassrooms)
            {
                string classroom = fillingClassroom.Value.Name.PadRight(padClassroom);
                Console.Write($"| {classroom} |");
            }
            int countFillingClassrooms = fillingClassrooms[0].PossibleFillings.Length;
            Console.WriteLine();
            for (int i = 0; i < fillingClassrooms[0].PossibleFillings.Length; i++)
            {
                var temp = fillingClassrooms[0].PossibleFillings[i];
                oneStolb = $"{temp.StudyDay.NumberOfWeek}_{temp.StudyDay.NameDayOfWeek}".PadRight(padOneStolb);
                twoStolb = $"{temp.Pair.NumberThePair}_{temp.Pair.NameThePair}".PadRight(padTwoStolb);
                Console.Write($"{oneStolb}|{twoStolb}|");
                foreach (var fillingClassroom in fillingClassrooms)
                {
                    var busyPairTemp = fillingClassroom.PossibleFillings[i].BusyPair;
                    string classroom = " NULL".PadRight(padClassroom);
                    if (busyPairTemp!=null)
                    {
                        string teac = busyPairTemp.Teacher.Name.Substring(busyPairTemp.Teacher.Name.Length-1,1);
                        string group = busyPairTemp.Group.Name.Substring(busyPairTemp.Group.Name.Length - 1, 1);
                        string subj = busyPairTemp.Subject.Name.Substring(0, 5);
                        classroom =$"t{teac}_g{group}_{subj}".PadRight(padClassroom);
                    }
                    
                    Console.Write($"| {classroom} |");
                }
                Console.WriteLine();
            }
          
        }


        /// <summary>
        /// Получить заполнение по каждому (преподавателю,группе,аудитории)
        /// </summary>
        /// <typeparam name="T">(преподавателю,группе,аудитории)</typeparam>
        /// <param name="array">массив (преподавателю,группе,аудитории)</param>
        /// <param name="possibleFillings">массив свободных дней</param>
        /// <returns>массив заполнение по каждому (преподавателю,группе,аудитории)</returns>
        private static Filling<T>[] GetFilling<T>(T[] array, PossibleFilling[] possibleFillings)
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


        /// <summary>
        /// Вывод на консоль Аудиторий
        /// </summary>
        /// <param name="classrooms">Массив аудиторий</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        /// <param name="All">True -Надо ли выводить подтаблицы; false - не надо</param>
        private static void ConsoleClassroom(Classroom[] classrooms,int pos=0, bool All=true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;
            Console.WriteLine($"АУДИТОРИИ ({classrooms.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (classrooms == null || classrooms.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет аудиторий!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = classrooms.Max(x => x.ClassroomId.ToString().Length);
            int padName = classrooms.Max(x => x.Name.Length);
            int padNumberOfSeats = classrooms.Max(x => x.NumberOfSeats.ToString().Length);
            foreach (var classroom in classrooms)
            {
                string id = classroom.ClassroomId.ToString().PadRight(padId);
                string name = classroom.Name.ToString().PadRight(padName);
                string numberOfSeats = classroom.NumberOfSeats.ToString().PadRight(padNumberOfSeats);
                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{id}, Название:{name}, Мест:{numberOfSeats}.");
            }
        }
        /// <summary>
        /// Вывод на консоль групп
        /// </summary>
        /// <param name="groups">Массив групп</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        /// <param name="All">True -Надо ли выводить подтаблицы; false - не надо</param>
        private static void ConsoleGroup(Group[] groups, int pos = 0, bool All = true)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"ГРУППЫ ({groups.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (groups == null || groups.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет групп!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = groups.Max(x => x.GroupId.ToString().Length);
            int padName = groups.Max(x => x.Name.Length);
            int padNumberOfPersons = groups.Max(x => x.NumberOfPersons.ToString().Length);
            int padAllPair = groups.Max(x => x.Curricula.Aggregate(0, (x1, x2) => x1 + x2.NumberOfPairs).ToString().Length);
            foreach (var group in groups)
            {
                string id = group.GroupId.ToString().PadRight(padId);
                string name = group.Name.ToString().PadRight(padName);
                string numberOfPersons = group.NumberOfPersons.ToString().PadRight(padNumberOfPersons);
                string allPair = group.Curricula.Aggregate(0, (x1, x2) => x1 + x2.NumberOfPairs).ToString().PadRight(padAllPair);
                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{id}, Название:{name}, Количество человек:{numberOfPersons}, Всего пар {allPair}.");
                if (All)
                {
                    ConsoleCurriculum(group.Curricula.ToArray(), pos + 2 * posit);
                }
            }
        }

        /// <summary>
        /// Вывод на консоль предметов
        /// </summary>
        /// <param name="subjects">Массив предметов</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        /// <param name="All">True -Надо ли выводить подтаблицы; false - не надо</param>
        private static void ConsoleSubject(Subject[] subjects, int pos = 0, bool All = true)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"ПРЕДМЕТЫ ({subjects.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (subjects==null || subjects.Length<1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет предметов!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = subjects.Max(x => x.SubjectId.ToString().Length);
            int padName = subjects.Max(x => x.Name.Length);
            int padSubjectOfTeacherCount = subjects.Max(x => x.SubjectOfTeachers.Count.ToString().Length);
            int padAllPairs = subjects.Max(x => x.Curricula.Aggregate(0, (x1, x2) => x1 + x2.NumberOfPairs).ToString().Length);

            foreach (var subject in subjects)
            {
                string id = subject.SubjectId.ToString().PadRight(padId);
                string name = subject.Name.ToString().PadRight(padName);
                string subjectOfTeacherCount = subject.SubjectOfTeachers.Count.ToString().PadRight(padSubjectOfTeacherCount);
                string allPairs = subject.Curricula.Aggregate(0, (x1, x2) => x1 + x2.NumberOfPairs).ToString().PadRight(padAllPairs);

                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{ id}, Название:{name}, Количество преподавателей:{subjectOfTeacherCount}, Всего пар {allPairs}.");
                if (All)
                {
                  
                    ConsoleCurriculum(subject.Curricula.ToArray(), pos + 2 * posit);
                   
                    Console.WriteLine();
                    ConsoleSubjectOfTeacher(subject.SubjectOfTeachers.ToArray(), pos + 2 * posit);
                    
                }
            }
        }
        /// <summary>
        /// Вывод на консоль Преподавателей
        /// </summary>
        /// <param name="teachers">Массив преподавателей</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        /// <param name="All">True -Надо ли выводить подтаблицы; false - не надо</param>
        private static void ConsoleTeacher(Teacher[] teachers, int pos = 0, bool All = true)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"ПРЕПОДАВАТЕЛИ ({teachers.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (teachers == null || teachers.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет Преподавателей!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = teachers.Max(x => x.TeacherId.ToString().Length);
            int padName = teachers.Max(x => x.Name.Length);
            int padSubjectOfTeacherCount = teachers.Max(x => x.SubjectOfTeachers.Count.ToString().Length);

            foreach (var teacher in teachers)
            {
                string id = teacher.TeacherId.ToString().PadRight(padId);
                string name = teacher.Name.ToString().PadRight(padName);
                string subjectOfTeacherCount = teacher.SubjectOfTeachers.Count.ToString().PadRight(padSubjectOfTeacherCount);

                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{ id}, Имя преподавателя :{name}, Количество предметов:{subjectOfTeacherCount}.");
                if (All)
                {
                    ConsoleSubjectOfTeacher(teacher.SubjectOfTeachers.ToArray(), pos + 2 * posit);
                }
            }
        }

        /// <summary>
        /// Вывод на консоль Плана занятий
        /// </summary>
        /// <param name="curricula">Массив плана занятий</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        private static void ConsoleCurriculum(Curriculum[] curricula, int pos = 0)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"Учебный план ({curricula.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (curricula == null || curricula.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет Учебного плана!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = curricula.Max(x => x.CurriculumId.ToString().Length);
            int padGroup = curricula.Max(x => x.Group.Name.Length);
            int padSubject = curricula.Max(x => x.Subject.Name.Length);
            int padNumberOfPairs = curricula.Max(x => x.NumberOfPairs.ToString().Length);
            foreach (var curriculum in curricula)
            {
                string id = curriculum.CurriculumId.ToString().PadRight(padId);
                string group = curriculum.Group.Name.ToString().PadRight(padGroup);
                string subject = curriculum.Subject.Name.ToString().PadRight(padSubject);
                string numberOfPairs = curriculum.NumberOfPairs.ToString().PadRight(padNumberOfPairs);

                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{id}, Название группы :{group}, Название предмета:{subject}, Количество пар:{numberOfPairs}.");
                
            }
        }

        /// <summary>
        /// Вывод на консоль предметов преподавателей
        /// </summary>
        /// <param name="subjectOfTeachers">Массив предметов преподавателей</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        private static void ConsoleSubjectOfTeacher(SubjectOfTeacher[] subjectOfTeachers, int pos = 0)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"Предметы преподавателей ({subjectOfTeachers.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (subjectOfTeachers == null || subjectOfTeachers.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет Предмета у преподавателя!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = subjectOfTeachers.Max(x => x.SubjectOfTeacherId.ToString().Length);
            int padTeacher = subjectOfTeachers.Max(x => x.Teacher.Name.Length);
            int padSubject = subjectOfTeachers.Max(x => x.Subject.Name.Length);
            foreach (var subjectOfTeacher in subjectOfTeachers)
            {
                string id = subjectOfTeacher.SubjectOfTeacherId.ToString().PadRight(padId);
                string teacher = subjectOfTeacher.Teacher.Name.ToString().PadRight(padTeacher);
                string subject = subjectOfTeacher.Subject.Name.ToString().PadRight(padSubject);
                
                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{id}, Имя преподавателя :{teacher}, Название предмета:{subject}.");

            }
        }
        /// <summary>
        /// Вывод на консоль пар
        /// </summary>
        /// <param name="pairs">Массив пар</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        private static void ConsolePair(Pair[] pairs, int pos = 0)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"Пары ({pairs.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (pairs == null || pairs.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет Пар!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = pairs.Max(x => x.PairId.ToString().Length);
            int padName = pairs.Max(x => x.NameThePair.Length);
            int padNumber = pairs.Max(x => x.NumberThePair.ToString().Length);
            foreach (var pair in pairs)
            {
                string id = pair.PairId.ToString().PadRight(padId);
                string name = pair.NameThePair.ToString().PadRight(padName);
                string number = pair.NumberThePair.ToString().PadRight(padNumber);

                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{id}, Название пары :{name}, Номер пары:{number}.");

            }
        }

        /// <summary>
        /// Вывод на консоль учебных дней
        /// </summary>
        /// <param name="studyDays">Массив учебных дней</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        private static void ConsoleStudyDay(StudyDay[] studyDays, int pos = 0)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"Учебные дни ({studyDays.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (studyDays == null || studyDays.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет Учебных дней!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int padId = studyDays.Max(x => x.StudyDayId.ToString().Length);
            int padName = studyDays.Max(x => x.NameDayOfWeek.Length);
            int padNumber = studyDays.Max(x => x.NumberOfWeek.ToString().Length);
            foreach (var studyDay in studyDays)
            {
                string id = studyDay.StudyDayId.ToString().PadRight(padId);
                string name = studyDay.NameDayOfWeek.ToString().PadRight(padName);
                string number = studyDay.NumberOfWeek.ToString().PadRight(padNumber);

                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{id}, День недели :{name}, Номер недели:{number}.");

            }
        }
    }
}
