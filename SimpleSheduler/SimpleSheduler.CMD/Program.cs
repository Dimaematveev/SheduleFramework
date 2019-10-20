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
            WorkToMyDbContext.RepositoryBase();
            Console.WriteLine("Привет мир!");

            ///Создаем подключение к БД
            ///т.к. работает с внешним хранилищем и за безопасность
            ///
            
            //WorkToMyDbContext.AddNewBD()


            // Filling<Teacher>[] fillingTeachers;

            Filling<Group>[] fillingGroups;
            Filling<Classroom>[] fillingClassrooms;

            Classroom[] classrooms;
            Group[] groups;
            Subject[] subjects;
            Curriculum[] curricula;
            Pair[] pairs;
            StudyDay[] studyDays;
            {
                WorkToMyDbContext.ReadDB();
                classrooms = WorkToMyDbContext.classrooms;
                groups = WorkToMyDbContext.groups;
                subjects = WorkToMyDbContext.subjects;
                curricula = WorkToMyDbContext.curricula;
                pairs = WorkToMyDbContext.pairs;
                studyDays = WorkToMyDbContext.studyDays;
                
            }

            //Выводы на консоль
            //ConsoleOut.ConsoleClassroom(classrooms, 0);

            //ConsoleOut.ConsoleGroup(groups, 0, false);
            //ConsoleOut.ConsoleSubject(subjects, 0, false);
            //ConsoleOut.ConsoleTeacher(teachers, 0, false);

            //ConsoleOut.ConsoleCurriculum(curricula);
            //ConsoleOut.ConsoleSubjectOfTeacher(subjectOfTeachers);

            //ConsoleOut.ConsolePair(pairs);
            //ConsoleOut.ConsoleStudyDay(studyDays);

            ///Получили когда возможно свободные  пары по дням и по преподавателям
            //fillingTeachers = GetFilling(teachers, pairs, studyDays);
            ///Получили когда возможно свободные  пары по дням и по группам
            fillingGroups = GetFilling(groups, pairs, studyDays);
            ///Получили когда возможно свободные  пары по дням и по аудиториям
            fillingClassrooms = GetFilling(classrooms, pairs, studyDays);

            //TODO: первый без объединения групп второй с объединением
            CreateScheduler createScheduler1 = new CreateScheduler( groups, classrooms, subjects, curricula, fillingGroups, fillingClassrooms);

            

            //TODO: первый без объединения групп второй с объединением
            //CreateScheduler createScheduler = new CreateScheduler();
           
            //var NotFill = createScheduler.SetSchedule(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
            //CreateScheduler createSchedulerUnion = new CreateScheduler();
            //var NotFillUnion = createSchedulerUnion.SetScheduleWithUniouGroup(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
            //CreateScheduler createScheduler = new CreateScheduler();
            ////var NotFill = createScheduler.SetSchedule(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
            //var NotFillUnion = createScheduler.SetScheduleWithUniouGroup(fillingTeachers, fillingGroups, fillingClassrooms, classrooms, curricula, subjectOfTeachers);
            ////var Not1Fill = FillingMaxNumberPair(fillingTeachers, fillingGroups, fillingClassrooms,possibleFillings, classrooms, curricula, subjectOfTeachers);

            //Для вывода лучше сдать таблицу, потом выводить
            ConsoleOut.ConsoleFilling(fillingClassrooms, "РАСПРЕДЕЛЕНИЕ ПО АУДИТОРИЯМ");
            //ConsoleOut.ConsoleFilling(fillingTeachers, "РАСПРЕДЕЛЕНИЕ ПО ПРЕПОДАВАТЕЛЯМ");
            ConsoleOut.ConsoleFilling(fillingGroups, "РАСПРЕДЕЛЕНИЕ ПО ГРУППАМ");

            //ConsoleOut.ConsoleFilling(createSchedulerUnion.FillingClassrooms, "РАСПРЕДЕЛЕНИЕ ПО АУДИТОРИЯМ");
            //ConsoleOut.ConsoleFilling(createSchedulerUnion.FillingTeachers, "РАСПРЕДЕЛЕНИЕ ПО ПРЕПОДАВАТЕЛЯМ");
            //ConsoleOut.ConsoleFilling(createSchedulerUnion.FillingGroups, "РАСПРЕДЕЛЕНИЕ ПО ГРУППАМ");

            Console.ReadLine();

        }

        /// <summary>
        /// Получить заполнение по каждому (преподавателю,группе,аудитории)
        /// </summary>
        /// <typeparam name="T">(преподавателю,группе,аудитории)</typeparam>
        /// <param name="array">массив (преподавателю,группе,аудитории)</param>
        /// <param name="pairs"> массив пар</param>
        /// <param name="studyDays">Массив учебных дней</param>
        /// <returns>массив заполнение по каждому (преподавателю,группе,аудитории)</returns>
        private static Filling<T>[] GetFilling<T>(T[] array, Pair[] pairs , StudyDay[] studyDays) where T:class,IName
        {
            var result = new List<Filling<T>>();
            foreach (var item in array)
            {
                result.Add(new Filling<T>(item, pairs , studyDays));
            }
            return result.ToArray();
        }

        


        
    }
}
