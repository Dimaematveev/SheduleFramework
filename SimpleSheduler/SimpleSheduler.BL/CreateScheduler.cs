using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    public class CreateScheduler
    {
        /// <summary>
        /// Массив групп
        /// </summary>
        private List<Group> Groups { get; set; }
        /// <summary>
        /// Массив аудиторий
        /// </summary>
        private List<Classroom> Classrooms { get; set; }
        /// <summary>
        /// Массив предметов
        /// </summary>
        private List<Subject> Subjects { get; set; }
        /// <summary>
        /// Массив плана занятий
        /// </summary>
        private List<Curriculum> Curricula { get; set; }

        /// <summary>
        /// Количество учебных дней
        /// </summary>
        private int NumberStudyDays { get; set; }

        /// <summary>
        /// Заполнение групп
        /// </summary>
        public List<Filling<Group>> FillingGroups { get; private set; }
        /// <summary>
        /// Заполнение Аудиторий
        /// </summary>
        public List<Filling<Classroom>> FillingClassrooms { get; private set; }

        /// <summary>
        /// Общее заполнение по всему)) то есть и группы и аудитории
        /// </summary>
        public List<Filling<IAbbreviation >> Fillings1 {  get; private set; }
        public CreateScheduler()
        {
        }

        /// <summary>
        /// Для создания расписания мы подаем
        /// </summary>
        /// <param name="groups">Все Группы</param>
        /// <param name="classrooms">Все аудитории</param>
        /// <param name="subjects">Все предметы</param>
        /// <param name="curricula">Полный учебный план</param>
        /// <param name="fillingGroups">По каждой группе массив дней когда может учиться</param>
        /// <param name="fillingClassrooms">По каждой аудитории массив дней когда свободна</param>
        public CreateScheduler(
            List<Group> groups,
            List<Classroom> classrooms,
            List<Subject> subjects,
            List<Curriculum> curricula,
            List<Filling<Group>> fillingGroups,
            List<Filling<Classroom>> fillingClassrooms )
        {
            ExceptionIfArrayNullorEmpty(groups, nameof(groups));
            ExceptionIfArrayNullorEmpty(classrooms, nameof(classrooms));
            ExceptionIfArrayNullorEmpty(subjects, nameof(subjects));
            ExceptionIfArrayNullorEmpty(curricula, nameof(curricula));
            ExceptionIfArrayNullorEmpty(fillingGroups, nameof(fillingGroups));
            ExceptionIfArrayNullorEmpty(fillingClassrooms, nameof(fillingClassrooms));
            Groups = groups;
            Classrooms = classrooms;
            Subjects = subjects;
            Curricula = curricula;
            FillingGroups = GetFillings(fillingGroups);
            FillingClassrooms = GetFillings(fillingClassrooms);
            NumberStudyDays = FillingClassrooms[0].Length;

            var sss = SetScheduleWithUniouGroup();
        }
        /// <summary>
        /// Создает ArgumentNullException массиву если он пуст или null
        /// </summary>
        /// <typeparam name="T">Тип массива</typeparam>
        /// <param name="array">Массив для проверки</param>
        /// <param name="nameParam">Название параметра вызывающего его обычно задается nameof()</param>
        private void ExceptionIfArrayNullorEmpty<T>(List<T> array, string nameParam)
        {
            if (array == null || array.Count == 0)
            {
                throw new ArgumentNullException($"Список  {array.GetType().Name} null или пуст!", nameParam);
            }
        }

        private List<Filling<T>> GetFillings<T>( List<Filling<T>> fillingsOld)where T:class,IAbbreviation 
        {
            List<Filling<T>>  fillingsNew = new List<Filling<T>>();
            
            foreach (var fillingOld in fillingsOld)
            {
                Filling<T> fillingNew = new Filling<T>();
                fillingNew.Value = fillingOld.Value;
                fillingNew.PossibleFillings = new List<PossibleFilling>();
                foreach (var fillingOldPossibleFilling in fillingOld.PossibleFillings)
                {

                    if (fillingOldPossibleFilling.BusyPair!=null)
                    {
                        BusyPair busyPairFree = new BusyPair(new Classroom(),  fillingOldPossibleFilling.BusyPair.Subject, new Group()); 
                        fillingNew.PossibleFillings.Add(new PossibleFilling(fillingOldPossibleFilling.Pair, fillingOldPossibleFilling.StudyDay) { BusyPair = busyPairFree });
                    }
                    else
                    {
                        fillingNew.PossibleFillings.Add(new PossibleFilling(fillingOldPossibleFilling.Pair, fillingOldPossibleFilling.StudyDay));
                    }
                }
                fillingsNew.Add(fillingNew);
            }
            return fillingsNew;
        }

        /// <summary>
        /// Функция задание расписания с объединение групп:
        /// </summary>
        /// <param name="fillingTeachers"> занятость преподавателя </param>
        /// <param name="fillingGroups"> занятость группы </param>
        /// <param name="fillingClassrooms"> занятость аудитории </param>
        /// <param name="classrooms"> аудитория </param>
        /// <param name="curricula"> План занятий </param>
        /// <param name="subjectOfTeachers"> Предмет и преподаватель</param>
        /// <returns>Массив план не заполненный </returns>
        public Curriculum[] SetScheduleWithUniouGroup()
        {
            //Объединение групп которое сейчас используется
            List<Group[]> unionGroups;
            {
                // все возможные объединения групп мак кол-во человек первый
                List<Group[]> tempUnionGroups = GetUniouGroup();


                // Без объединения
                List<Group[]> notUnionGroups = GetUnionGroupBy(tempUnionGroups, GroupNotComparison);
                // Объединения по потокам мак кол-во человек первый
                List<Group[]> unionGroupsPotok = GetUnionGroupBy(tempUnionGroups, GroupComparisonPotok);
                // Объединения по Семинарам мак кол-во человек первый
                List<Group[]> unionGroupsSeminar = GetUnionGroupBy(tempUnionGroups, GroupComparisonSeminar);

                unionGroups = unionGroupsSeminar;
            }

            //1. Аудитории сортированы по количеству мест
            Classrooms = Classrooms.OrderBy(x => x.NumberOfSeats).ToList();
            
            ///2.Новый план занятий который включает: 
                /// несколько планов из объединения n групп и 
                /// значением равным количеству оставшихся пар 
                /// также переменная bool Показывающая стоит дальше проверять или нет  - пока не реализовано
            CurriculaWithAmountPair[] curriculaAndNumPairs = CurriculaWithUnionGroupsAndNumberOfPairs(unionGroups);


            // TODO: При объединении групп учитывать что хотябы одна аудитория может быть заполнена! 
            // т.е. кол-во чел в объединении < Кол-во мест в аудитории
            var curriculaNot = CreateCurriculum(curriculaAndNumPairs);
            //Цикл плана закончен
            foreach (var curriculumNot in curriculaNot)
            {
                Console.WriteLine($"Не получилось(( {curriculumNot.ToString()}");
            }
            //4. На выход отдаём что не смогли добавить из п.3, e, i
            return curriculaNot.ToArray();
            //Конец функции задание расписания

        }

        /// <summary>
        /// Создать учебный план.
        /// </summary>
        /// <param name="curriculaAndNumPairs"> Учебный план с объединением </param>
        /// <returns> План который не вошел </returns>
        private List<Curriculum> CreateCurriculum( CurriculaWithAmountPair[] curriculaAndNumPairs)
        {
            //план который не вошел пустой
            var curriculaNot = new List<Curriculum>();
            //Элемент который будет проверятся у меня это макс число оставшихся пар
            var MaxCurricula = curriculaAndNumPairs.Aggregate((l, r) => l.NumberOfPair > r.NumberOfPair ? l : r);
            //3. Цикл по плану занятий не равен 0
            while (MaxCurricula.NumberOfPair != 0)
            {
                // Добавить один предмет в учебный план и выводит которые не получилось добавить
                var tempCurriculaNot = AddOneSubjectInCurriculum(MaxCurricula);

                //Добавляем не получившиеся добавить в общий список
                curriculaNot.AddRange(tempCurriculaNot);
                //f. Убираем у первого элемента 1 пару
                MaxCurricula.RemoveOnePair();
                //g. Сортируем план занятий по кол-во пар(макс первый)
                MaxCurricula = curriculaAndNumPairs.Aggregate((l, r) => l.NumberOfPair > r.NumberOfPair ? l : r);
            }

            //план не получившийся добавить
            return curriculaNot;
        }

        /// <summary>
        /// Добавить один предмет в учебный план и выводит которые не получилось добавить
        /// </summary>
        /// <param name="MaxCurricula"> План для добавления предмета </param>
        /// <returns> Выводить список планов которые не удалось добавить</returns>
        private List<Curriculum> AddOneSubjectInCurriculum( CurriculaWithAmountPair MaxCurricula)
        {
            //Пустой план не получившийся добавить
            List<Curriculum> curriculaNot = new List<Curriculum>();
            //a. Из элемента плана понимаем что за предмет и какая группа
            var group = MaxCurricula.GetGroups();
            var subject = MaxCurricula.GetSubject();
            //c. Выбираем аудитории с кол-во мест больше чем в группе 
            //(так как они отсортированы по возрастанию то просто номер первой подходящей аудитории)
            //Номер Аудитории из массива которая сейчас будет рассматриваться

            int NumClassroom = Classrooms.FindIndex(x => x.NumberOfSeats >= group.Sum(y => y.NumberOfPersons));
            //Теперь для каждой  группы подцепляем занятость
            var fillingGroup = FillingGroups.Where(x => group.Contains(x.Value)).ToList();
            //Добавилась ли пара
            bool success = false;
            //i. Цикл по расписанию
            for (int cu = 0; cu < NumberStudyDays; cu++)
            {
                //d. Цикл по аудиториям
                for (int cl = NumClassroom; cl < Classrooms.Count; cl++)
                {
                    //Теперь для аудитории подцепляем занятость
                    var fillingClassroom = FillingClassrooms.First(x => x.Value.ClassroomId == Classrooms[cl].ClassroomId);
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
                    //ToDO: в день не должно быть более 2-х одинаковых пар
                    //все пары в этот день у этой группы
                    var allPairsInGroup = fillingGroup[0].PossibleFillings.Where(x => x.StudyDay == fillingGroup[0].PossibleFillings[cu].StudyDay).ToArray();
                    //одинаковые пары в день
                    int numOfThisLesson = allPairsInGroup.Where(x => x.BusyPair != null && x.BusyPair.Subject == subject).Count();
                    //Кол-во пар в день не более 2
                    bool FNT = true;
                    if (numOfThisLesson >= 2)
                    {
                        FNT = false;
                    }
                    //1. Если в этот день свободна и группа и преподаватель и аудитория
                    if (FNT && FG && FC)
                    {

                        BusyPair busyPair = new BusyPair(Classrooms[cl], subject, group);
                        //a. Добавляем им пару

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
                //Так как несколько планов то проходим по всем
                for (int i = 0; i < MaxCurricula.GetNumberPlan(); i++)
                {
                    //индекс в учебном плане
                    int ind = curriculaNot.FindIndex(x => x.CurriculumId == MaxCurricula.GetCurriculumId()[i]);
                    //i. Если был  такой элемент

                    if (ind == -1)
                    {
                        //1. Сохраняем что не смогли добавить в кол-ве 1 пара
                        curriculaNot.Add(MaxCurricula.NewCurriculum(i, 1));
                    }
                    //Иначе если не было такого элемента
                    else
                    {
                        //1. Добавляем к элементу 1 пару
                        curriculaNot[ind].Number++;
                    }
                    //Если закончено
                }
            }
            //Если закончено
            //план не получившийся добавить
            return curriculaNot;
        }



        /// <summary>
        /// Создает План занятий с объединением планов групп и количеством пар которые можно изменить
        /// </summary>
        /// <param name="unionGroups"> Возможные объедиения групп</param>
        /// <returns>Объединенный план занятий</returns>
        private CurriculaWithAmountPair[] CurriculaWithUnionGroupsAndNumberOfPairs(List<Group[]> unionGroups)
        {
            
            //Произведена группировка по предметам. Каждый Предмет включает План для нескольких групп по нему
            var SubjectIncludePlans = Curricula.OrderByDescending(x => x.Number).GroupBy(x => x.Subject).Select(g => g.ToList()).ToList();
            // Можно сразу выкинуть из объединенного плана если количество элементов в предмете =1 так как не с чем объединять
            //Добавляем эти одиночные предметы в объединенный план
            List<CurriculaWithAmountPair> CurriculaAndNumPairs = SubjectIncludePlans.Where(x => x.Count == 1).Select(c => new CurriculaWithAmountPair(c[0])).ToList();
            //Убираем из группировки по предметам одиночные предметы
            SubjectIncludePlans = SubjectIncludePlans.Where(x => x.Count > 1).ToList();

            // Подбираются планы из группировки по предметам (там теперь нет одиночных) и пытаюсь объединить
            //TODO: Просто просто делаю

            //прохожу по предметам с планами
            foreach (var plansInSubject in SubjectIncludePlans)
            {
                //прохожу по объединению групп где объединение >1
                foreach (var groups in unionGroups.Where(x => x.Length > 1))
                {
                    //если план по предмету содержит все объединенные группы то объединяем по этому предмету эти группы 
                    // правда ли  что для всех групп -> хотябы один план содежит группу
                    bool ContainsAllGroups = groups.All(x => plansInSubject.Any(y => y.Group == x));
                    if (ContainsAllGroups)
                    {
                        //Выбираю планы, только для объединенных групп
                        Curriculum[] curriculaUnionGroup = plansInSubject.Where(x => groups.Contains(x.Group)).ToArray();
                        //Проверям что у всех кто объединитсь одинаковое количество пар
                        if (curriculaUnionGroup.All(x => x.Number == curriculaUnionGroup[0].Number))
                        {
                            //Создаем план с возможностью изменения кол-во пар только для первой группы
                            CurriculaWithAmountPair tempCurriculaWithAmountPair = new CurriculaWithAmountPair(curriculaUnionGroup[0]);
                            //добавляем в этот объединенный план все остальные группы и если удалось то add->true
                            bool add = tempCurriculaWithAmountPair.AddCurriculum(curriculaUnionGroup.Skip(1).ToArray());
                            //Если удалось добавить
                            if (add)
                            {
                                //Добавляем этот план в объединенный план
                                CurriculaAndNumPairs.Add(tempCurriculaWithAmountPair);
                                //Удаляем из плана добавления в предмете что уже добавили тоесть все группы объединенные удаляем.
                                plansInSubject.RemoveAll(x => curriculaUnionGroup.Contains(x));
                            }
                        }

                    }
                }

                //Добавляю оставшиеся планы в Главный план
                CurriculaAndNumPairs.AddRange(plansInSubject.Select(x => new CurriculaWithAmountPair(x)).ToArray());

            }
            //План занятий с объединенными планами и кол-вом пар
            return CurriculaAndNumPairs.ToArray();
        }



        /// <summary>
        /// Получить объединение групп по  функции 
        /// </summary>
        /// <param name="unionGroups"> Список все возможных групп которые были объединены</param>
        /// <param name="FuncCompareGroup"> Функция по которой будут сравниваться группы </param>
        /// <returns> Список объединения групп по нашей функции </returns>
        private List<Group[]> GetUnionGroupBy(List<Group[]> unionGroups, Func<Group, Group, bool> FuncCompareGroup)
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

                //Кол-во человек в объединениии
                int numPeople = 0;
                for (int j = 0; j < unionGroupsBy[u].Length; j++)
                {
                    numPeople += unionGroupsBy[u][j].NumberOfPersons;
                }
                if (numPeople> Classrooms.Max(x=>x.NumberOfSeats))
                {
                    unionGroupsBy.RemoveAt(u);
                }
            }
            return unionGroupsBy;
        }
        /// <summary>
        /// Функция Сравнение групп по потокам
        /// </summary>
        /// <param name="group1"> Первая группа для сравнения </param>
        /// <param name="group2"> Вторая группа для сравнения </param>
        /// <returns> True если потоки одинаковы, False  если разные</returns>
        private bool GroupComparisonPotok(Group group1, Group group2)
        {
            return group1.Potok == group2.Potok;
        }

        /// <summary>
        /// Функция Сравнение групп по семинарам
        /// </summary>
        /// <param name="group1"> Первая группа для сравнения </param>
        /// <param name="group2"> Вторая группа для сравнения </param>
        /// <returns> True если семинары одинаковы, False  если разные</returns>
        private bool GroupComparisonSeminar(Group group1, Group group2)
        {
            return group1.Seminar == group2.Seminar;
        }

        /// <summary>
        /// Функция Сравнение групп нет сравнения, только отдельные группы
        /// </summary>
        /// <param name="group1"> Первая группа для сравнения </param>
        /// <param name="group2"> Вторая группа для сравнения </param>
        /// <returns> False  всегда</returns>
        private bool GroupNotComparison(Group group1, Group group2)
        {
            return false;
        }


        /// <summary>
        /// получить Все возможные объединения групп. Каждая с каждой. Упорядоченно по убывания
        /// </summary>
        /// <returns> Список со все возможными объединениями групп.</returns>
        private List<Group[]> GetUniouGroup()
        {
            //Пустой список объединения групп
            List<Group[]> unionGroups = new List<Group[]>();
            //Проходим по группам
            foreach (var group in Groups)
            {
                //Количество объединенных групп
                int numGroupings = unionGroups.Count;
                // Цикл по всем объединениям до этого момента
                for (int i = 0; i < numGroupings; i++)
                {
                    // Новая группировка содержащая объединение по i
                    List<Group> newGrouping = new List<Group>(unionGroups[i]);
                    //И добавляем к этой новой группировке нашу группу
                    newGrouping.Add(group);

                    //Добавляем эту новую группировку в общий список
                    unionGroups.Add(newGrouping.ToArray());
                }
                //Добавляем к общему списку нашу одну группу 
                unionGroups.Add(new Group[] { group });
            }
            // Сортируем от максимального кол-во человек в объединении
            unionGroups = unionGroups.OrderByDescending(x => x.Sum(y => y.NumberOfPersons)).ToList();

            return unionGroups;
        }




    }
}
