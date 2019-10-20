using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
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
                new Subject(){Name="Философия"},
                new Subject(){Name="Правоведение"},
                new Subject(){Name="Иностранный язык"},
                new Subject(){Name="Математический анализ"},
                new Subject(){Name="Дифференциальные уравнения"},
                new Subject(){Name="Теория вероятностей, математическая статистика и случайные процессы"},
                new Subject(){Name="Физика"},
                new Subject(){Name="Безопасность жизнедеятельности"},
                new Subject(){Name="Физическая культура и спорт"},
                new Subject(){Name="Основы системной инженерии информационных процессов, технологий и систем"},
                new Subject(){Name="Теория информационных процессов и систем"},
                new Subject(){Name="Операционные системы"},
                new Subject(){Name="Сетевые технологии"},
                new Subject(){Name="Информационные системы и базы данных"},
                new Subject(){Name="Основы информационной безопасности"},
                new Subject(){Name="Информационное право"},
                new Subject(){Name="Прикладное программирование аппаратного обеспечения"},
                new Subject(){Name="Математическая логика, теория автоматов и алгоритмов"},
                new Subject(){Name="Физическая культура и спорт (элективная дисциплина)"},
                new Subject(){Name="Общая математическая теория больших систем"},
                new Subject(){Name="Теория управления"},
                new Subject(){Name="Методы и системы поддержки принятия решений"},
                new Subject(){Name="Математическое и программное обеспечение информационно-поисковых систем"},
                new Subject(){Name="Компьютерная графика и геометрическое моделирование"},
                new Subject(){Name="Информационные сети и сети передачи данных"},
                new Subject(){Name="Функциональное программное обеспечение информационных систем"},
                new Subject(){Name="Аппаратно-программное обеспечение систем реального времени"},
                new Subject(){Name="Исполнительные механизмы систем управления"},
                new Subject(){Name="Ремонт и обслуживание технических средств информационных систем"},
                new Subject(){Name="Безопасность жизнедеятельности 2"},
                new Subject(){Name="Инженерно-техническая лексика русского языка"},
                new Subject(){Name="Психология (инклюзивный курс)"},
                new Subject(){Name="Веб-графика и дизайн"},
                new Subject(){Name="Нейронные сети и нейрокомпьютеры"},
                new Subject(){Name="Основы информационного противоборства"},
                new Subject(){Name="Инновационные методы проектирования встраиваемых систем управления"},
                new Subject(){Name="Дистанционный мониторинг элементов информационных систем"},
                new Subject(){Name="Анализ и мониторинг социальных сетей"},
                new Subject(){Name="Высоконагруженные информационные системы"},
                new Subject(){Name="Управление большими базами данных"},
                new Subject(){Name="Прогнозная аналитика в безопасности"},
                new Subject(){Name="Логическое программирование"},
                new Subject(){Name="Языки инженерии знаний"},
                new Subject(){Name="Основы безопасности прикладных информационных технологий и систем"},
                new Subject(){Name="Оптимизация и построение трансляторов"},
                new Subject(){Name="Разработка эффективных алгоритмов"},
                new Subject(){Name="Основы создания безопасного программного обеспечения"},
                new Subject(){Name="Аппаратные и программные средства мобильных информационных систем"},
                new Subject(){Name="Беспроводные компьютерные сети"},
                new Subject(){Name="История (история России, всеобщая история)"},
                new Subject(){Name="Экономика"},
                new Subject(){Name="Информатика"},
                new Subject(){Name="Линейная алгебра и аналитическая геометрия"},
                new Subject(){Name="Дискретная математика"},
                new Subject(){Name="Введение в профессиональную деятельность"},
                new Subject(){Name="Архитектура информационных систем "},
                new Subject(){Name="Технологии программирования"},
                new Subject(){Name="Общая физическая подготовка"},

            };
            return AddSubjects;
        }

      
        private static List<Curriculum> CreateCurricula()
        {
            var AddCurricula = new List<Curriculum>
            {
                new Curriculum(){GroupId = 1,SubjectId = 23,NumberOfLectures = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 1,SubjectId = 25,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 26,NumberOfLectures = 16,NumberOfLaboratory = 4,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 27,NumberOfLectures = 16,NumberOfLaboratory = 4,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 28,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 29,NumberOfLectures = 16,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 19,NumberOfPractical = 54,},
                new Curriculum(){GroupId = 1,SubjectId = 30,NumberOfLectures = 8,NumberOfPractical = 8,},
                new Curriculum(){GroupId = 1,SubjectId = 31,NumberOfLectures = 8,NumberOfPractical = 8,},
                new Curriculum(){GroupId = 1,SubjectId = 32,NumberOfLectures = 8,NumberOfPractical = 8,},
                new Curriculum(){GroupId = 1,SubjectId = 36,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 37,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 38,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 1,SubjectId = 39,NumberOfLectures = 16,NumberOfLaboratory = 12,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 1,SubjectId = 40,NumberOfLectures = 16,NumberOfLaboratory = 12,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 1,SubjectId = 41,NumberOfLectures = 16,NumberOfLaboratory = 12,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 1,SubjectId = 45,NumberOfLectures = 16,NumberOfLaboratory = 4,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 1,SubjectId = 46,NumberOfLectures = 16,NumberOfLaboratory = 4,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 1,SubjectId = 47,NumberOfLectures = 16,NumberOfLaboratory = 4,NumberOfPractical = 32,},

                new Curriculum(){GroupId = 2,SubjectId = 3,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 2,SubjectId = 2,NumberOfLectures = 8,NumberOfPractical = 8,},
                new Curriculum(){GroupId = 2,SubjectId = 51,NumberOfLectures = 16,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 2,SubjectId = 7,NumberOfLectures = 16,NumberOfLaboratory = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 2,SubjectId = 53,NumberOfLectures = 32,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 2,SubjectId = 4,NumberOfLectures = 32,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 2,SubjectId = 54,NumberOfLectures = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 2,SubjectId = 56,NumberOfLectures = 32,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 2,SubjectId = 57,NumberOfLectures = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 2,SubjectId = 58,NumberOfPractical = 64,},


                new Curriculum(){GroupId = 3,SubjectId = 20,NumberOfLectures = 24,NumberOfLaboratory = 16,NumberOfPractical = 8,},
                new Curriculum(){GroupId = 3,SubjectId = 21,NumberOfLectures = 32,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 22,NumberOfLectures = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 3,SubjectId = 24,NumberOfLectures = 16,NumberOfLaboratory = 16,NumberOfPractical = 8,},
                new Curriculum(){GroupId = 3,SubjectId = 25,NumberOfLectures = 16,NumberOfLaboratory = 12,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 26,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 3,SubjectId = 19,NumberOfPractical = 54,},
                new Curriculum(){GroupId = 3,SubjectId = 33,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 34,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 35,NumberOfLectures = 16,NumberOfLaboratory = 8,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 42,NumberOfLectures = 16,NumberOfLaboratory = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 43,NumberOfLectures = 16,NumberOfLaboratory = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 44,NumberOfLectures = 16,NumberOfLaboratory = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 48,NumberOfLectures = 16,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 3,SubjectId = 49,NumberOfLectures = 16,NumberOfPractical = 16,},


                new Curriculum(){GroupId = 4,SubjectId = 9,NumberOfPractical = 62,},
                new Curriculum(){GroupId = 4,SubjectId = 3,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 4,SubjectId = 50,NumberOfLectures = 16,NumberOfPractical = 16,},
                new Curriculum(){GroupId = 4,SubjectId = 52,NumberOfLectures = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 4,SubjectId = 7,NumberOfLectures = 16,NumberOfLaboratory = 16,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 4,SubjectId = 53,NumberOfLectures = 32,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 4,SubjectId = 4,NumberOfLectures = 32,NumberOfPractical = 32,},
                new Curriculum(){GroupId = 4,SubjectId = 55,NumberOfLectures = 16,},
                new Curriculum(){GroupId = 4,SubjectId = 57,NumberOfLectures = 32,NumberOfPractical = 32,},
            };
            return AddCurricula;
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
        }


        public static void FillingCurriculum()
        {
            using (var context = new MyDbContext())
            {
                //Сколько часов по парам у классов
                //У меня на  несколько месяцев что бы было для 2-х недель разделим на 8
                var curricula = CreateCurricula();
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
