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


                var NotFill = SetSchedule(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
                //var Not1Fill = FillingMaxNumberPair(fillingTeachers, fillingGroups, fillingClassrooms,possibleFillings, classrooms, curricula, subjectOfTeachers);

                //Для вывода лучше сдать таблицу, потом выводить
                ConsoleOut.ConsoleFilling(fillingClassrooms, "РАСПРЕДЕЛЕНИЕ ПО АУДИТОРИЯМ");
                ConsoleOut.ConsoleFilling(fillingTeachers, "РАСПРЕДЕЛЕНИЕ ПО ПРЕПОДАВАТЕЛЯМ");
                ConsoleOut.ConsoleFilling(fillingGroups, "РАСПРЕДЕЛЕНИЕ ПО ГРУППАМ");

            }

            Console.ReadLine();

        }


        /// <summary>
        /// Функция задание расписания:
        /// </summary>
        /// <param name="fillingTeachers"> занятость преподавателя </param>
        /// <param name="fillingGroups"> занятость группы </param>
        /// <param name="fillingClassrooms"> занятость аудитории </param>
        /// <param name="classrooms"> аудитория </param>
        /// <param name="curricula"> План занятий </param>
        /// <param name="subjectOfTeachers"> Предмет и преподаватель</param>
        /// <returns>Массив план не заполненный </returns>
        private static Curriculum[] SetSchedule(
            Filling<Teacher>[] fillingTeachers,
            Filling<Group>[] fillingGroups,
            Filling<Classroom>[] fillingClassrooms,
            Classroom[] classrooms,
            Curriculum[] curricula,
            SubjectOfTeacher[] subjectOfTeachers)
        {
            //1. Аудитории сортированы по количеству мест
            classrooms = classrooms.OrderBy(x => x.NumberOfSeats).ToArray();
            //Номер Аудитории из массива которая сейчас будет рассматриваться
            int NumClassroom =0;
            //2. Сортируем план занятий по кол-во пар(макс первый)
            curricula = curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
            //план который не вошел
            var curriculaNot = new List<Curriculum>();
            //3. Цикл по плану занятий пока первый элемент он же максимальный не равен 0
            while (curricula[0].NumberOfPairs!=0)
            {
               
                //a. Из первого элемента плана понимаем что за предмет и какая группа
                var group = curricula[0].Group;
                var subject = curricula[0].Subject;
                //b. Ищем на предмет первого преподавателя
                var teacher = subjectOfTeachers.First(x => x.Subject == subject).Teacher;
                //c. Выбираем аудитории с кол-во мест больше чем в группе 
                //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
                NumClassroom = Array.FindIndex(classrooms,x => x.NumberOfSeats >= group.NumberOfPersons);

                //Теперь для каждой  группы, преподавателя подцепляем занятость
                var fillingTeacher = fillingTeachers.First(x => x.Value.TeacherId == teacher.TeacherId);
                var fillingGroup = fillingGroups.First(x => x.Value.GroupId == curricula[0].GroupId);
              

                //Лучше циклы по аудиториям и по расписаниями поменять местами
                //Добавилась ли пара
                bool success = false;
                //i. Цикл по расписанию
                for (int cu = 0; cu < fillingTeacher.PossibleFillings.Length; cu++)
                {
                   
                    //d. Цикл по аудиториям
                    for (int cl = NumClassroom; cl < classrooms.Length; cl++)
                    {
                        //Теперь для аудитории подцепляем занятость
                        var fillingClassroom = fillingClassrooms.First(x => x.Value.ClassroomId == classrooms[cl].ClassroomId);
                        //Условия что в этот день в эту пару Преподаватель группа и классная комната не заняты
                        bool FT = fillingTeacher.PossibleFillings[cu].BusyPair == null;
                        bool FG = fillingGroup.PossibleFillings[cu].BusyPair == null;
                        bool FC = fillingClassroom.PossibleFillings[cu].BusyPair == null;
                        //1. Если в этот день свободна и группа и преподаватель и аудитория
                        if (FT && FG && FC)
                        {
                            
                            BusyPair busyPair = new BusyPair(classrooms[cl], teacher, subject, group);
                            //a. Добавляем им пару
                            fillingTeacher.PossibleFillings[cu].BusyPair = busyPair;
                            fillingGroup.PossibleFillings[cu].BusyPair = busyPair;
                            fillingClassroom.PossibleFillings[cu].BusyPair = busyPair;
                            //b. Заканчиваем 2 цикла(по расписанию и по аудиториям)
                            success = true;
                            break;
                        }

                        //b. Заканчиваем 2 цикла(по расписанию и по аудиториям) если пара добавилась
                        if (success)
                        {
                            break;
                        }
                        
                        //Если закончено
                    }

                    //Цикл по расписанию закончен
                }
                //Цикл аудиторий закончен

                //e. Если не смогли добавить то
                if (!success)
                {
                    
                    int ind = curriculaNot.FindIndex(x => x.CurriculumId == curricula[0].CurriculumId);
                    //i. Если был  такой элемент
                   
                    if (ind == -1)
                    {
                        //1. Сохраняем что не смогли добавить в кол-ве 1 пара
                        curriculaNot.Add(
                            new Curriculum()
                            {
                                CurriculumId = curricula[0].CurriculumId,
                                Group = curricula[0].Group,
                                GroupId = curricula[0].GroupId,
                                Subject = curricula[0].Subject,
                                SubjectId = curricula[0].SubjectId,
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
                //f. Убираем у первого элемента 1 пару
                curricula[0].NumberOfPairs--;
                //g. Сортируем план занятий по кол-во пар(макс первый)
                curricula = curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
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
