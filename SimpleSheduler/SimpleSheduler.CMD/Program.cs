using SimpleSheduler.BD;
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
        static void Main(string[] args)
        {
            Console.WriteLine("Привет мир!");

            ///Создаем подключение к БД
            ///т.к. работает с внешним хранилищем и за безопасность
            ///

            //InitialFilling initialFilling = new InitialFilling();
            //initialFilling.Filling();
           
            using (var context = new MyDbContext())
            {
                ConsoleClassroom(context.Classrooms.ToArray());
                ConsoleGroup(context.Groups.ToArray());
                ConsoleSubject(context.Subjects.ToArray());
                ConsoleTeacher(context.Teachers.ToArray());

                ConsoleCurriculum(context.Curricula.ToArray());
                ConsoleSubjectOfTeacher(context.SubjectsOfTeachers.ToArray());
            }
                   
            Console.ReadLine();

        }

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
                    //foreach (var curriculum in group.Curricula)
                    //{
                    //    Console.CursorLeft = pos + 2 * posit;
                    //    Console.WriteLine($"ID:{ curriculum.CurriculumId}, Название предмета:{curriculum.Subject.Name}, Количество пар:{curriculum.NumberOfPairs}.");
                    //}
                }
            }
        }

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
                    //foreach (var curriculum in subject.Curricula)
                    //{
                    //    Console.CursorLeft = pos + 2 * posit;
                    //    Console.WriteLine($"ID:{ curriculum.CurriculumId}, Название группы:{curriculum.Group.Name}, Количество пар:{curriculum.NumberOfPairs}.");
                    //}
                    Console.WriteLine();
                    ConsoleSubjectOfTeacher(subject.SubjectOfTeachers.ToArray(), pos + 2 * posit);
                    //foreach (var subjectOfTeacher in subject.SubjectOfTeachers)
                    //{
                    //    Console.CursorLeft = pos + 2 * posit;
                    //    Console.WriteLine($"ID:{ subjectOfTeacher.SubjectOfTeacherId}, Имя преподавателя:{subjectOfTeacher.Teacher.Name}.");
                    //}
                }
            }
        }

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
                    //foreach (var subjectOfTeacher in teacher.SubjectOfTeachers)
                    //{
                    //    Console.CursorLeft = pos + 2 * posit;
                    //    Console.WriteLine($"ID:{ subjectOfTeacher.SubjectOfTeacherId}, Название предмета:{subjectOfTeacher.Subject.Name}.");
                    //}
                }
            }
        }


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
    }
}
