using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.CMD
{
    public class ConsoleOut
    {
        /// <summary>
        /// На сколько каждый раз смещается курсов в Консоли
        /// </summary>
        private static readonly int posit = 5;




        /// <summary>
        /// Вывод на консоль заполнения 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fillings"></param>
        /// <param name="nameTable">Название таблицы(Распределение по...)</param>
        public static void ConsoleFilling<T>(Filling<T>[] fillings,
                                             string nameTable) where T : IName
        {
            ConsoleTable consoleTable = new ConsoleTable
            {
                Name = nameTable
            };
            consoleTable.AddColumn("№");
            consoleTable.AddColumn("день");
            consoleTable.AddColumn("пара");
            foreach (var filling in fillings)
            {
                consoleTable.AddColumn($"{filling.Value.NameString()}");
            }

            for (int i = 0; i < fillings[0].PossibleFillings.Length; i++)
            {
                var temp = fillings[0].PossibleFillings[i];
                var AddTemp = new List<string>
                {
                    $"{temp.StudyDay.NumberOfWeek}",
                    $"{temp.StudyDay.NameDayOfWeek}",
                    $"{temp.Pair.NumberThePair}"
                };
                foreach (var filling in fillings)
                {
                    var busyPairTemp = filling.PossibleFillings[i].BusyPair;
                    string value = "NULL";
                    if (busyPairTemp != null)
                    {
                        value = "";

                        if (!(fillings is Filling<Classroom>[]))
                        {
                            value += $"C{busyPairTemp.Classroom.Name.Substring(busyPairTemp.Classroom.Name.Length - 1, 1)}_";
                        }
                        if (!(fillings is Filling<Teacher>[]))
                        {
                            value += $"T{busyPairTemp.Teacher.Name.Substring(busyPairTemp.Teacher.Name.Length - 1, 1)}_";
                        }
                        if (!(fillings is Filling<Subject>[]))
                        {
                            value += $"S{busyPairTemp.Subject.Name.Substring(0, 5)}_";
                        }
                        if (!(fillings is Filling<Group>[]))
                        {
                            value += $"G:";
                            foreach (var group in busyPairTemp.Groups)
                            {
                                value += $"{group.Name.Substring(group.Name.Length - 1, 1)},";
                            }
                            value += "_";
                        }
                    }
                    AddTemp.Add(value);
                }
                consoleTable.Add(AddTemp.ToArray());
            }


            consoleTable.ToConsole();
        }




        /// <summary>
        /// Вывод на консоль Аудиторий
        /// </summary>
        /// <param name="classrooms">Массив аудиторий</param>
        /// <param name="pos">на сколько отступить с начала строки</param>
        public static void ConsoleClassroom(Classroom[] classrooms,
                                            int pos = 0)
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
        public static void ConsoleGroup(Group[] groups,
                                        int pos = 0,
                                        bool All = true)
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
        public static void ConsoleSubject(Subject[] subjects,
                                          int pos = 0,
                                          bool All = true)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = pos + 0 * posit;

            Console.WriteLine($"ПРЕДМЕТЫ ({subjects.Length}):");
            Console.ForegroundColor = ConsoleColor.White;
            if (subjects == null || subjects.Length < 1)
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
        public static void ConsoleTeacher(Teacher[] teachers,
                                          int pos = 0,
                                          bool All = true)
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
                string subjectOfTeacherPair = teacher.SubjectOfTeachers.Aggregate(0, (x, y) => x + y.Subject.Curricula.Aggregate(0, (x1, x2) => x1 + x2.NumberOfPairs)).ToString().PadRight(3);

                Console.CursorLeft = pos + 1 * posit;
                Console.WriteLine($"ID:{ id}, Имя преподавателя :{name}, Количество предметов:{subjectOfTeacherCount} Всего пар {subjectOfTeacherPair}.");
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
        public static void ConsoleCurriculum(Curriculum[] curricula,
                                             int pos = 0)
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
        public static void ConsoleSubjectOfTeacher(SubjectOfTeacher[] subjectOfTeachers,
                                                   int pos = 0)
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
        public static void ConsolePair(Pair[] pairs,
                                       int pos = 0)
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
        public static void ConsoleStudyDay(StudyDay[] studyDays,
                                           int pos = 0)
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
