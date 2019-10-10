﻿using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.CMD
{
    /// <summary>
    /// Первоначально заполнение для тестирования!
    /// </summary>
    public class InitialFilling
    {
        private static List<StudyDay> CreateStudyDays()
        {
            var AddStudyDays = new List<StudyDay>
            {
                new StudyDay(){NumberDayOfWeek=1, NameDayOfWeek="Понедельник", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=2,NameDayOfWeek="Вторник", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=3,NameDayOfWeek="Среда", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=4,NameDayOfWeek="Четверг", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=5,NameDayOfWeek="Пятница", NumberOfWeek=1},

                new StudyDay(){NumberDayOfWeek=1,NameDayOfWeek="Понедельник", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=2,NameDayOfWeek="Вторник", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=3,NameDayOfWeek="Среда", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=4,NameDayOfWeek="Четверг", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=5,NameDayOfWeek="Пятница", NumberOfWeek=2},
            };
            return AddStudyDays;
        }
        private static List<Pair> CreatePairs()
        {
            var AddPairs = new List<Pair>
                {
                    new Pair(){NameThePair="Пара-1", NumberThePair=1},
                    new Pair(){NameThePair="Пара-2", NumberThePair=2},
                    new Pair(){NameThePair="Пара-3", NumberThePair=3},
                    new Pair(){NameThePair="Пара-4", NumberThePair=4},
                    new Pair(){NameThePair="Пара-5", NumberThePair=5},
                    new Pair(){NameThePair="Пара-6", NumberThePair=6},
                };
            return AddPairs;
        }
        private static List<Group> CreateGroups()
        {
            var AddGroups = new List<Group>
                {
                    new Group(){Name="09.03.02_ИСиТ_АПиМОБИС_2017",NumberOfPersons= 32, Potok="09.03.02",Seminar="09.03_2017" },
                    new Group(){Name="09.03.02_ИСиТ_АПиМОБИС_2019",NumberOfPersons= 42, Potok="09.03.02",Seminar="09.03_2019" },

                    new Group(){Name="09.03.01_ИСиТ_АПиМОБИС_2017",NumberOfPersons= 21, Potok="09.03.01",Seminar="09.03_2017" },
                    new Group(){Name="09.03.01_ИСиТ_АПиМОБИС_2019",NumberOfPersons= 66, Potok="09.03.01",Seminar="09.03_2019" },
                };
            return AddGroups;
        }
        private static List<Classroom> CreateClassrooms()
        {
            var AddClassrooms = new List<Classroom>
                {
                    new Classroom(){Name="Аудитория №1",NumberOfSeats= 77 },
                    new Classroom(){Name="Аудитория №2",NumberOfSeats= 31 },
                    new Classroom(){Name="Аудитория №3",NumberOfSeats= 40 },
                    new Classroom(){Name="Аудитория №4",NumberOfSeats= 23 },
                    new Classroom(){Name="Аудитория №5",NumberOfSeats= 45 },
                };
            return AddClassrooms;
        }
        private static List<Subject> CreateSubjects()
        {

            var AddSubjects = new List<Subject>
                {
                    new Subject(){Name="Русский язык" },
                    new Subject(){Name="Литературное чтение"},
                    new Subject(){Name="Русский родной язык"},
                    new Subject(){Name="Литературное чтение на русском родном языке"},
                    new Subject(){Name="Иностранный язык (англ.)"},
                    new Subject(){Name="Второй язык"},
                    new Subject(){Name="Математика"},
                    new Subject(){Name="Окружающий мир"},
                    new Subject(){Name="Основы религиозных культур и светской этики"},
                    new Subject(){Name="Музыка"},
                    new Subject(){Name="Изобразительное искусство"},
                    new Subject(){Name="Технология "},
                    new Subject(){Name="Физическая культура"},
                };
            return AddSubjects;
        }


        public static void FillingAll()
        {
            using (var context = new MyDbContext())
            {
                var addGroups = CreateGroups();
                var addClassrooms = CreateClassrooms();
                var addSubjects = CreateSubjects();
                var AddStudyDays = CreateStudyDays();
                var AddPairs = CreatePairs();
                ///Добавляем запись в наш КЭШ но пока не отправили в БД
                context.StudyDays.AddRange(AddStudyDays);
                context.Pairs.AddRange(AddPairs);
                context.Groups.AddRange(addGroups);
                context.Classrooms.AddRange(addClassrooms);
                context.Subjects.AddRange(addSubjects);
                ///Все изменения из локального хранилища в БД
                ///
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        Console.Write("Object: " + validationError.Entry.Entity.ToString());
                        Console.Write("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Console.Write(err.ErrorMessage + "");
                        }
                        Console.WriteLine();
                    }
                }
            }
            FillingCurriculum();
        }


        private static void FillingCurriculum()
        {
            using (var context = new MyDbContext())
            {
                var groups = context.Groups.ToArray();
                var classrooms = context.Classrooms.ToArray();
               
                var subjects = context.Subjects.ToArray();
                //Сколько часов по парам у классов
                //У меня на  несколько месяцев что бы было для 2-х недель разделим на 8
                int[][] ClassYear = new int[][] 
                {
                    new int[] { 165, 132, 0, 0, 0, 0, 132, 66, 0, 33, 33, 33, 99 },
                    new int[] { 136, 102, 34, 34, 68, 0, 136, 68, 0, 34, 34, 34, 102 },
                    new int[] { 170, 136, 0, 0, 68, 0, 136, 68, 0, 34, 34, 34, 102 },
                    new int[] { 170, 102, 0, 0, 68, 0, 136, 68, 34, 34, 34, 34, 102 },
                };
                var curricula = new List<Curriculum>();
                for (int i = 0; i < groups.Length; i++)
                {
                    for (int j = 0; j < subjects.Length; j++)
                    {
                        if (ClassYear[i][j]/8>0)
                        {
                            var curriculum = new Curriculum()
                            {
                                GroupId = groups[i].GroupId,
                                SubjectId = subjects[j].SubjectId,
                                NumberOfPairs = ClassYear[i][j]/8
                            };
                            curricula.Add(curriculum);
                        }
                    }
                }
                context.Curricula.AddRange(curricula);
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        Console.Write("Object: " + validationError.Entry.Entity.ToString());
                        Console.Write("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Console.Write(err.ErrorMessage + "");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Что-то неверно! ");
                    Console.ReadLine();
                }


            }
        }


    }
}
