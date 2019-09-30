using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    public class CreateScheduler
    {
<<<<<<< HEAD
        //занятость преподавателя 
        public Filling<Teacher>[] FillingTeachers { get; private set; }
        //занятость группы 
        public Filling<Group>[] FillingGroups { get; private set; }
        //занятость аудитории 
        public Filling<Classroom>[] FillingClassrooms { get; private set; }

        //План занятий 
        private Curriculum[] Curricula;
        // Предмет и преподаватель
        private SubjectOfTeacher[] SubjectOfTeachers;

        public CreateScheduler(
            Filling<Teacher>[] fillingTeachers,
            Filling<Group>[] fillingGroups,
            Filling<Classroom>[] fillingClassrooms,
            Curriculum[] curricula,
            SubjectOfTeacher[] subjectOfTeachers)
        {
            if (fillingTeachers == null || fillingTeachers.Length < 1)
            {
                throw new ArgumentNullException("Массив заполнения преподавателей не должен быть пустым!", nameof(fillingTeachers));
            }
            if (fillingGroups == null || fillingGroups.Length < 1)
            {
                throw new ArgumentNullException("Массив заполнения групп не должен быть пустым!", nameof(fillingGroups));
            }
            if (fillingClassrooms == null || fillingClassrooms.Length < 1)
            {
                throw new ArgumentNullException("Массив заполнения аудиторий не должен быть пустым!", nameof(fillingClassrooms));
            }

            if (curricula == null || curricula.Length < 1)
            {
                throw new ArgumentNullException("Массив плана занятий не должен быть пустым!", nameof(curricula));
            }
            if (subjectOfTeachers == null || subjectOfTeachers.Length < 1)
            {
                throw new ArgumentNullException("Массив предметов преподавателей не должен быть пустым!", nameof(subjectOfTeachers));
            }

            FillingTeachers = GetDeepClone(fillingTeachers);
            FillingGroups = GetDeepClone(fillingGroups);
            FillingClassrooms = GetDeepClone(fillingClassrooms);

            Curricula = GetDeepClone(curricula);
            SubjectOfTeachers = GetDeepClone(subjectOfTeachers);

        }


        private T[] GetDeepClone<T>(T[] oldObject) where T : class, ICloneable
        {
            var newObject = new T[oldObject.Length];
            for (int i = 0; i < oldObject.Length; i++)
            {
                newObject[i] = oldObject[i].Clone() as T;
            }
            return newObject;
        }

=======
        public CreateScheduler()
        {
        }


>>>>>>> 3334538... Создан класс для Создания рассписания!

        /// <summary>
        /// Функция задание расписания без объединения групп:
        /// </summary>
<<<<<<< HEAD
        /// <returns>Массив план не заполненный </returns>
        public Curriculum[] SetSchedule()
        {
            //1. Аудитории сортированы по количеству мест
            Classroom[] Classrooms = FillingClassrooms.Select(x => x.Value).OrderBy(x => x.NumberOfSeats).ToArray();
            //Номер Аудитории из массива которая сейчас будет рассматриваться
            int NumClassroom = 0;
            //2. Сортируем план занятий по кол-во пар(макс первый)
            Curricula = Curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
=======
        /// <param name="fillingTeachers"> занятость преподавателя </param>
        /// <param name="fillingGroups"> занятость группы </param>
        /// <param name="fillingClassrooms"> занятость аудитории </param>
        /// <param name="classrooms"> аудитория </param>
        /// <param name="curricula"> План занятий </param>
        /// <param name="subjectOfTeachers"> Предмет и преподаватель</param>
        /// <returns>Массив план не заполненный </returns>
        public Curriculum[] SetSchedule(
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
            int NumClassroom = 0;
            //2. Сортируем план занятий по кол-во пар(макс первый)
            curricula = curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
>>>>>>> 3334538... Создан класс для Создания рассписания!

            //план который не вошел
            var curriculaNot = new List<Curriculum>();
            //3. Цикл по плану занятий пока первый элемент он же максимальный не равен 0
<<<<<<< HEAD
            while (Curricula[0].NumberOfPairs != 0)
            {

                //a. Из первого элемента плана понимаем что за предмет и какая группа
                var group = Curricula[0].Group;
                var subject = Curricula[0].Subject;
                //b. Ищем на предмет первого преподавателя
                var teacher = SubjectOfTeachers.First(x => x.Subject.Equals(subject)).Teacher;
                //c. Выбираем аудитории с кол-во мест больше чем в группе 
                //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
                NumClassroom = Array.FindIndex(Classrooms, x => x.NumberOfSeats >= group.NumberOfPersons);

                //Теперь для каждой  группы, преподавателя подцепляем занятость
                var fillingTeacher = FillingTeachers.First(x => x.Value.Equals(teacher));
                var fillingGroup = FillingGroups.First(x => x.Value.Equals(Curricula[0].Group));
=======
            while (curricula[0].NumberOfPairs != 0)
            {

                //a. Из первого элемента плана понимаем что за предмет и какая группа
                var group = curricula[0].Group;
                var subject = curricula[0].Subject;
                //b. Ищем на предмет первого преподавателя
                var teacher = subjectOfTeachers.First(x => x.Subject == subject).Teacher;
                //c. Выбираем аудитории с кол-во мест больше чем в группе 
                //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
                NumClassroom = Array.FindIndex(classrooms, x => x.NumberOfSeats >= group.NumberOfPersons);

                //Теперь для каждой  группы, преподавателя подцепляем занятость
                var fillingTeacher = fillingTeachers.First(x => x.Value.TeacherId == teacher.TeacherId);
                var fillingGroup = fillingGroups.First(x => x.Value.GroupId == curricula[0].GroupId);
>>>>>>> 3334538... Создан класс для Создания рассписания!


                //Лучше циклы по аудиториям и по расписаниями поменять местами
                //Добавилась ли пара
                bool success = false;
                //i. Цикл по расписанию
                for (int cu = 0; cu < fillingTeacher.Length; cu++)
                {

                    //d. Цикл по аудиториям
<<<<<<< HEAD
                    for (int cl = NumClassroom; cl < Classrooms.Length; cl++)
                    {
                        //Теперь для аудитории подцепляем занятость
                        var fillingClassroom = FillingClassrooms.First(x => x.Value.Equals(Classrooms[cl]));
=======
                    for (int cl = NumClassroom; cl < classrooms.Length; cl++)
                    {
                        //Теперь для аудитории подцепляем занятость
                        var fillingClassroom = fillingClassrooms.First(x => x.Value.ClassroomId == classrooms[cl].ClassroomId);
>>>>>>> 3334538... Создан класс для Создания рассписания!
                        //Условия что в этот день в эту пару Преподаватель группа и классная комната не заняты
                        bool FT = fillingTeacher[cu].BusyPair == null;
                        bool FG = fillingGroup[cu].BusyPair == null;
                        bool FC = fillingClassroom[cu].BusyPair == null;
                        //1. Если в этот день свободна и группа и преподаватель и аудитория
                        if (FT && FG && FC)
                        {

<<<<<<< HEAD
                            BusyPair busyPair = new BusyPair(Classrooms[cl], teacher, subject, group);
=======
                            BusyPair busyPair = new BusyPair(classrooms[cl], teacher, subject, group);
>>>>>>> 3334538... Создан класс для Создания рассписания!
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

<<<<<<< HEAD
                    int ind = curriculaNot.FindIndex(x => x.Equals(Curricula[0]));
=======
                    int ind = curriculaNot.FindIndex(x => x.CurriculumId == curricula[0].CurriculumId);
>>>>>>> 3334538... Создан класс для Создания рассписания!
                    //i. Если был  такой элемент

                    if (ind == -1)
                    {
                        //1. Сохраняем что не смогли добавить в кол-ве 1 пара
                        curriculaNot.Add(
                            new Curriculum()
                            {
<<<<<<< HEAD
                                CurriculumId = Curricula[0].CurriculumId,
                                Group = Curricula[0].Group,
                                GroupId = Curricula[0].GroupId,
                                Subject = Curricula[0].Subject,
                                SubjectId = Curricula[0].SubjectId,
=======
                                CurriculumId = curricula[0].CurriculumId,
                                Group = curricula[0].Group,
                                GroupId = curricula[0].GroupId,
                                Subject = curricula[0].Subject,
                                SubjectId = curricula[0].SubjectId,
>>>>>>> 3334538... Создан класс для Создания рассписания!
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
<<<<<<< HEAD
                Curricula[0].NumberOfPairs--;
                //g. Сортируем план занятий по кол-во пар(макс первый)
                Curricula = Curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
=======
                curricula[0].NumberOfPairs--;
                //g. Сортируем план занятий по кол-во пар(макс первый)
                curricula = curricula.OrderByDescending(x => x.NumberOfPairs).ToArray();
>>>>>>> 3334538... Создан класс для Создания рассписания!
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
        /// Функция задание расписания с объединение групп:
        /// </summary>
<<<<<<< HEAD
        /// <returns>Массив план не заполненный </returns>
        public Curriculum[] SetScheduleWithUniouGroup()
=======
        /// <param name="fillingTeachers"> занятость преподавателя </param>
        /// <param name="fillingGroups"> занятость группы </param>
        /// <param name="fillingClassrooms"> занятость аудитории </param>
        /// <param name="classrooms"> аудитория </param>
        /// <param name="curricula"> План занятий </param>
        /// <param name="subjectOfTeachers"> Предмет и преподаватель</param>
        /// <returns>Массив план не заполненный </returns>
        public Curriculum[] SetScheduleWithUniouGroup(
            Filling<Teacher>[] fillingTeachers,
            Filling<Group>[] fillingGroups,
            Filling<Classroom>[] fillingClassrooms,
            Classroom[] classrooms,
            Curriculum[] curricula,
            SubjectOfTeacher[] subjectOfTeachers)
>>>>>>> 3334538... Создан класс для Создания рассписания!
        {
            //Объединение групп которое сейчас используется
            List<Group[]> unionGroup;
            {
                // Все группы
<<<<<<< HEAD
                var groups = FillingGroups.Select(x => x.Value).ToArray();
=======
                var groups = fillingGroups.Select(x => x.Value).ToArray();
>>>>>>> 3334538... Создан класс для Создания рассписания!
                // все возможные объединения групп мак кол-во человек первый
                List<Group[]> unionGroups = GetUniouGroup(groups);
                // Объединения по потокам мак кол-во человек первый
                List<Group[]> unionGroupsPotok = GetUnionGroupBy(unionGroups, GroupComparisonPotok);
                // Объединения по Семинарам мак кол-во человек первый
                List<Group[]> unionGroupsSeminar = GetUnionGroupBy(unionGroups, GroupComparisonSeminar);

                unionGroup = unionGroupsSeminar;
            }

            //1. Аудитории сортированы по количеству мест
<<<<<<< HEAD
            Classroom[] Classrooms = FillingClassrooms.Select(x => x.Value).OrderBy(x => x.NumberOfSeats).ToArray();
=======
            classrooms = classrooms.OrderBy(x => x.NumberOfSeats).ToArray();
>>>>>>> 3334538... Создан класс для Создания рассписания!
            //Номер Аудитории из массива которая сейчас будет рассматриваться
            int NumClassroom = 0;
            //2. Сортируем план занятий по кол-во пар(макс первый)
            //Новый план занятий 
            List<Curriculum[]> newCurricula = new List<Curriculum[]>();
            //newCurricula = curricula.OrderByDescending(x => x.NumberOfPairs).Select(x => new Curriculum[] { x }).ToList();
            {


                //Произведена группировка по предметам. Каждый Предмет включает План для нескольких групп по нему
<<<<<<< HEAD
                var SubjectIncludePlans = Curricula.OrderByDescending(x => x.NumberOfPairs).GroupBy(x => x.Subject).Select(g => g.ToList()).ToList();
=======
                var SubjectIncludePlans = curricula.OrderByDescending(x => x.NumberOfPairs).GroupBy(x => x.Subject).Select(g => g.ToList()).ToList();
>>>>>>> 3334538... Создан класс для Создания рассписания!
                // Можно сразу выкинуть из плана если количество элементов в предмете =1
                newCurricula.AddRange(SubjectIncludePlans.Where(x => x.Count == 1).Select(x => x.ToArray()).ToArray());
                SubjectIncludePlans = SubjectIncludePlans.Where(x => x.Count > 1).ToList();

<<<<<<< HEAD
=======
                //TODO: дальше по этому проверка
                //// Можно сразу выкинуть из плана если количество пар в предмете встречается только 1 раз.
                //foreach (var plans in SubjectIncludePlans)
                //{
                //    // одна пара в плане.Группируем по кол-во пар - выбираем группировку где пар==1 -выбираем первый элемент из этой группировки - и все в лист
                //    var onePairInPlan = plans.GroupBy(x=>x.NumberOfPairs).Where(x=>x.Count()==1).Select(x=>x.First()).ToList();
                //    if (onePairInPlan.Count>0)
                //    {
                //        foreach (var item in onePairInPlan)
                //        {
                //            newCurricula.Add(new Curriculum[] { item });
                //            plans.Remove(item);
                //        }
                //    }
                //}

>>>>>>> 3334538... Создан класс для Создания рассписания!
                // Подбираются планы из группировки по предметам (там теперь нет одиночных) и пытаюсь объединить
                //TODO: Просто просто делаю

                //прохожу по предметам с планами
                foreach (var plansInSubject in SubjectIncludePlans)
                {
<<<<<<< HEAD
                    // Console.WriteLine("Предмет - " + plansInSubject[0].Subject + " И план:");
=======
                    Console.WriteLine("Предмет - " + plansInSubject[0].Subject + " И план:");
>>>>>>> 3334538... Создан класс для Создания рассписания!
                    //unionGroup

                    //прохожу по объединению групп где объединение >1
                    foreach (var groups in unionGroup.Where(x => x.Length > 1))
                    {
                        //если plansInSubject содержит все groups то объединяем по этому предмету эти группы 
                        // правда ли  что для всех групп -> хотябы один план содежит группу
<<<<<<< HEAD
                        bool ContainsAllGroups = groups.All(x => plansInSubject.Any(y => y.Group.Equals(x)));
=======
                        bool ContainsAllGroups = groups.All(x => plansInSubject.Any(y => y.Group == x));
>>>>>>> 3334538... Создан класс для Создания рассписания!
                        if (ContainsAllGroups)
                        {
                            Curriculum[] curricula1 = plansInSubject.Where(x => groups.Contains(x.Group)).ToArray();
                            //Проверям что у всех кто объединитсь одинаковое количество пар
                            if (curricula1.All(x => x.NumberOfPairs == curricula1[0].NumberOfPairs))
                            {
                                newCurricula.Add(curricula1);
                                plansInSubject.RemoveAll(x => curricula1.Contains(x));
                            }

                        }
                    }

                    //Добавляю юставшиеся планы в Главный план
                    newCurricula.AddRange(plansInSubject.Select(x => new Curriculum[] { x }).ToArray());
                    //Прохожу по планам занятий в планах предметов
                    foreach (var plan in plansInSubject)
                    {

<<<<<<< HEAD
                        //Console.WriteLine(plan);

                    }
                    //Console.WriteLine();
=======
                        Console.WriteLine(plan);

                    }
                    Console.WriteLine();
>>>>>>> 3334538... Создан класс для Создания рассписания!
                }
                //Сортируем план занятий по кол-во пар(макс первый)
                newCurricula = newCurricula.OrderByDescending(x => x[0].NumberOfPairs).ToList();


            }
            //план который не вошел
            var curriculaNot = new List<Curriculum>();
            //3. Цикл по плану занятий пока первый элемент он же максимальный не равен 0
            while (newCurricula[0][0].NumberOfPairs != 0)
            {

                //a. Из первого элемента плана понимаем что за предмет и какая группа
                var group = newCurricula[0].Select(x => x.Group).ToArray();
                var subject = newCurricula[0][0].Subject;
                //b. Ищем на предмет первого преподавателя
<<<<<<< HEAD
                var teacher = SubjectOfTeachers.First(x => x.Subject.Equals(subject)).Teacher;
                //c. Выбираем аудитории с кол-во мест больше чем в группе 
                //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
                NumClassroom = Array.FindIndex(Classrooms, x => x.NumberOfSeats >= group.Sum(y => y.NumberOfPersons));

                //Теперь для каждой  группы, преподавателя подцепляем занятость
                var fillingTeacher = FillingTeachers.First(x => x.Value.Equals(teacher));
                var fillingGroup = FillingGroups.Where(x => group.Contains(x.Value)).ToList();
=======
                var teacher = subjectOfTeachers.First(x => x.Subject == subject).Teacher;
                //c. Выбираем аудитории с кол-во мест больше чем в группе 
                //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
                NumClassroom = Array.FindIndex(classrooms, x => x.NumberOfSeats >= group.Sum(y => y.NumberOfPersons));

                //Теперь для каждой  группы, преподавателя подцепляем занятость
                var fillingTeacher = fillingTeachers.First(x => x.Value == teacher);
                var fillingGroup = fillingGroups.Where(x => group.Contains(x.Value)).ToList();
>>>>>>> 3334538... Создан класс для Создания рассписания!
                //curricula

                //Лучше циклы по аудиториям и по расписаниями поменять местами
                //Добавилась ли пара
                bool success = false;
                //i. Цикл по расписанию
                for (int cu = 0; cu < fillingTeacher.Length; cu++)
                {

                    //d. Цикл по аудиториям
<<<<<<< HEAD
                    for (int cl = NumClassroom; cl < Classrooms.Length; cl++)
                    {
                        //Теперь для аудитории подцепляем занятость
                        var fillingClassroom = FillingClassrooms.First(x => x.Value.Equals(Classrooms[cl]));
=======
                    for (int cl = NumClassroom; cl < classrooms.Length; cl++)
                    {
                        //Теперь для аудитории подцепляем занятость
                        var fillingClassroom = fillingClassrooms.First(x => x.Value.ClassroomId == classrooms[cl].ClassroomId);
>>>>>>> 3334538... Создан класс для Создания рассписания!
                        //Условия что в этот день в эту пару Преподаватель не занят
                        bool FT = fillingTeacher[cu].BusyPair == null;
                        //Условия что в этот день в эту пару группы не заняты
                        bool FG = true;
                        foreach (var fillingGroup1 in fillingGroup)
                        {
                            bool FG1 = fillingGroup1[cu].BusyPair == null;
                            if (!FG1)
                            {
                                FG = false;
                                break;
                            }
                        }
                        //Условия что в этот день в эту пару классная комната не занята
                        bool FC = fillingClassroom[cu].BusyPair == null;

                        //1. Если в этот день свободна и группа и преподаватель и аудитория
                        if (FT && FG && FC)
                        {

<<<<<<< HEAD
                            BusyPair busyPair = new BusyPair(Classrooms[cl], teacher, subject, group);
=======
                            BusyPair busyPair = new BusyPair(classrooms[cl], teacher, subject, group);
>>>>>>> 3334538... Создан класс для Создания рассписания!
                            //a. Добавляем им пару
                            fillingTeacher[cu].BusyPair = busyPair;
                            foreach (var fillingGroup1 in fillingGroup)
                            {
                                fillingGroup1[cu].BusyPair = busyPair;
                            }
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
                    foreach (var curriculum in newCurricula[0])
                    {
                        //curricula
<<<<<<< HEAD
                        int ind = curriculaNot.FindIndex(x => x.Equals(curriculum));
=======
                        int ind = curriculaNot.FindIndex(x => x.CurriculumId == curriculum.CurriculumId);
>>>>>>> 3334538... Создан класс для Создания рассписания!
                        //i. Если не было  такого элемента

                        if (ind == -1)
                        {
                            //1. Сохраняем что не смогли добавить в кол-ве 1 пара
                            curriculaNot.Add(
                                new Curriculum()
                                {
                                    CurriculumId = curriculum.CurriculumId,
                                    Group = curriculum.Group,
                                    GroupId = curriculum.GroupId,
                                    Subject = curriculum.Subject,
                                    SubjectId = curriculum.SubjectId,
                                    NumberOfPairs = 1
                                }
                            );
                        }
                        //Иначе если был такой элемент
                        else
                        {
                            //1. Добавляем к элементу 1 пару
                            curriculaNot[ind].NumberOfPairs++;
                        }
                        //Если закончено
                    }

                }
                //Если закончено
                //f. Убираем у первого элемента 1 пару
                foreach (var curriculum in newCurricula[0])
                {
                    curriculum.NumberOfPairs--;
                }

                //g. Сортируем план занятий по кол-во пар(макс первый)
                newCurricula = newCurricula.OrderByDescending(x => x[0].NumberOfPairs).ToList();
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



        //Получить объединение групп по  функции 
        private static List<Group[]> GetUnionGroupBy(List<Group[]> unionGroups, Func<Group, Group, bool> FuncCompareGroup)
        {
            List<Group[]> unionGroupsBy = new List<Group[]>(unionGroups);
            //Проходим по всем объединениям
            for (int u = unionGroupsBy.Count - 1; u >= 0; u--)
            {
                //Если количество групп равно 0 в объединении значит нет объединения т.о. удаляем
                if (unionGroupsBy[u].Length == 0)
                {
                    unionGroupsBy.RemoveAt(u);
                }
                //Если количество групп равно 1 в объединении просто пропускаем итерацию
                if (unionGroupsBy[u].Length == 1)
                {
                    continue;
                }
                //Если количество групп > 1 в объединении Проходим по всем начиная со 2-й
                for (int j = 1; j < unionGroupsBy[u].Length; j++)
                {
                    //Проверяем По (функции проверки) с 1 группой если не равен то удаляем объединение
                    if (!FuncCompareGroup(unionGroupsBy[u][0], unionGroupsBy[u][j]))
                    {
                        unionGroupsBy.RemoveAt(u);
                        break;
                    }
                }
            }
            return unionGroupsBy;
        }
        //Сравнение групп по потокам
        private static bool GroupComparisonPotok(Group group1, Group group2)
        {
<<<<<<< HEAD
            return group1.Potok.Equals(group2.Potok);
=======
            return group1.Potok == group2.Potok;
>>>>>>> 3334538... Создан класс для Создания рассписания!
        }
        //Сравнение групп по семинарам
        private static bool GroupComparisonSeminar(Group group1, Group group2)
        {
<<<<<<< HEAD
            return group1.Seminar.Equals(group2.Seminar);
=======
            return group1.Seminar == group2.Seminar;
>>>>>>> 3334538... Создан класс для Создания рассписания!
        }
        private static List<Group[]> GetUniouGroup(Group[] groups)
        {
            List<Group[]> unionGroups = new List<Group[]>();
            foreach (var group in groups)
            {
                int numGroupings = unionGroups.Count;
                for (int i = 0; i < numGroupings; i++)
                {
                    List<Group> newGrouping = new List<Group>(unionGroups[i]);
                    newGrouping.Add(group);
                    unionGroups.Add(newGrouping.ToArray());
                }
                unionGroups.Add(new Group[] { group });
            }
            //Макс первый
            unionGroups = unionGroups.OrderByDescending(x => x.Sum(y => y.NumberOfPersons)).ToList();
            return unionGroups;
        }




    }
}
