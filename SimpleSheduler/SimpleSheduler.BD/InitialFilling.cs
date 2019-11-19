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
                new StudyDay(){NumberDayOfWeek=1, AbbreviationDayOfWeek="Понедельник", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=2,AbbreviationDayOfWeek="Вторник", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=3,AbbreviationDayOfWeek="Среда", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=4,AbbreviationDayOfWeek="Четверг", NumberOfWeek=1},
                new StudyDay(){NumberDayOfWeek=5,AbbreviationDayOfWeek="Пятница", NumberOfWeek=1},

                new StudyDay(){NumberDayOfWeek=1,AbbreviationDayOfWeek="Понедельник", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=2,AbbreviationDayOfWeek="Вторник", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=3,AbbreviationDayOfWeek="Среда", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=4,AbbreviationDayOfWeek="Четверг", NumberOfWeek=2},
                new StudyDay(){NumberDayOfWeek=5,AbbreviationDayOfWeek="Пятница", NumberOfWeek=2},
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
                new Group(){Abbreviation="090302_ИСиТ_АПиМОБИС_2017",NumberOfPersons= 32, Potok="090302",Seminar="0903_2017" },
                new Group(){Abbreviation="090302_ИСиТ_АПиМОБИС_2019",NumberOfPersons= 42, Potok="090302",Seminar="0903_2019" },

                new Group(){Abbreviation="090301_ИСиТ_АПиМОБИС_2017",NumberOfPersons= 21, Potok="090301",Seminar="0903_2017" },
                new Group(){Abbreviation="090301_ИСиТ_АПиМОБИС_2019",NumberOfPersons= 66, Potok="090301",Seminar="0903_2019" },
            };
            return AddGroups;
        }
        private static List<Classroom> CreateClassrooms()
        {
            var AddClassrooms = new List<Classroom>
            {
                new Classroom(){Abbreviation="Аудитория №1",NumberOfSeats= 77 },
                new Classroom(){Abbreviation="Аудитория №2",NumberOfSeats= 31 },
                new Classroom(){Abbreviation="Аудитория №3",NumberOfSeats= 40 },
                new Classroom(){Abbreviation="Аудитория №4",NumberOfSeats= 23 },
                new Classroom(){Abbreviation="Аудитория №5",NumberOfSeats= 45 },
            };
            return AddClassrooms;
        }
        private static List<Subject> CreateSubjects()
        {

            var AddSubjects = new List<Subject>
            {
                new Subject(){Abbreviation="Философия"},
                new Subject(){Abbreviation="Правоведение"},
                new Subject(){Abbreviation="Иностранный язык"},
                new Subject(){Abbreviation="Математический анализ"},
                new Subject(){Abbreviation="Дифференциальные уравнения"},
                new Subject(){Abbreviation="Теория вероятностей, математическая статистика и случайные процессы"},
                new Subject(){Abbreviation="Физика"},
                new Subject(){Abbreviation="Безопасность жизнедеятельности"},
                new Subject(){Abbreviation="Физическая культура и спорт"},
                new Subject(){Abbreviation="Основы системной инженерии информационных процессов, технологий и систем"},
                new Subject(){Abbreviation="Теория информационных процессов и систем"},
                new Subject(){Abbreviation="Операционные системы"},
                new Subject(){Abbreviation="Сетевые технологии"},
                new Subject(){Abbreviation="Информационные системы и базы данных"},
                new Subject(){Abbreviation="Основы информационной безопасности"},
                new Subject(){Abbreviation="Информационное право"},
                new Subject(){Abbreviation="Прикладное программирование аппаратного обеспечения"},
                new Subject(){Abbreviation="Математическая логика, теория автоматов и алгоритмов"},
                new Subject(){Abbreviation="Физическая культура и спорт (элективная дисциплина)"},
                new Subject(){Abbreviation="Общая математическая теория больших систем"},
                new Subject(){Abbreviation="Теория управления"},
                new Subject(){Abbreviation="Методы и системы поддержки принятия решений"},
                new Subject(){Abbreviation="Математическое и программное обеспечение информационно-поисковых систем"},
                new Subject(){Abbreviation="Компьютерная графика и геометрическое моделирование"},
                new Subject(){Abbreviation="Информационные сети и сети передачи данных"},
                new Subject(){Abbreviation="Функциональное программное обеспечение информационных систем"},
                new Subject(){Abbreviation="Аппаратно-программное обеспечение систем реального времени"},
                new Subject(){Abbreviation="Исполнительные механизмы систем управления"},
                new Subject(){Abbreviation="Ремонт и обслуживание технических средств информационных систем"},
                new Subject(){Abbreviation="Безопасность жизнедеятельности 2"},
                new Subject(){Abbreviation="Инженерно-техническая лексика русского языка"},
                new Subject(){Abbreviation="Психология (инклюзивный курс)"},
                new Subject(){Abbreviation="Веб-графика и дизайн"},
                new Subject(){Abbreviation="Нейронные сети и нейрокомпьютеры"},
                new Subject(){Abbreviation="Основы информационного противоборства"},
                new Subject(){Abbreviation="Инновационные методы проектирования встраиваемых систем управления"},
                new Subject(){Abbreviation="Дистанционный мониторинг элементов информационных систем"},
                new Subject(){Abbreviation="Анализ и мониторинг социальных сетей"},
                new Subject(){Abbreviation="Высоконагруженные информационные системы"},
                new Subject(){Abbreviation="Управление большими базами данных"},
                new Subject(){Abbreviation="Прогнозная аналитика в безопасности"},
                new Subject(){Abbreviation="Логическое программирование"},
                new Subject(){Abbreviation="Языки инженерии знаний"},
                new Subject(){Abbreviation="Основы безопасности прикладных информационных технологий и систем"},
                new Subject(){Abbreviation="Оптимизация и построение трансляторов"},
                new Subject(){Abbreviation="Разработка эффективных алгоритмов"},
                new Subject(){Abbreviation="Основы создания безопасного программного обеспечения"},
                new Subject(){Abbreviation="Аппаратные и программные средства мобильных информационных систем"},
                new Subject(){Abbreviation="Беспроводные компьютерные сети"},
                new Subject(){Abbreviation="История (история России, всеобщая история)"},
                new Subject(){Abbreviation="Экономика"},
                new Subject(){Abbreviation="Информатика"},
                new Subject(){Abbreviation="Линейная алгебра и аналитическая геометрия"},
                new Subject(){Abbreviation="Дискретная математика"},
                new Subject(){Abbreviation="Введение в профессиональную деятельность"},
                new Subject(){Abbreviation="Архитектура информационных систем "},
                new Subject(){Abbreviation="Технологии программирования"},
                new Subject(){Abbreviation="Общая физическая подготовка"},

            };
            return AddSubjects;
        }

      
        private static List<Curriculum> CreateCurricula()
        {
            var AddCurricula = new List<Curriculum>
            {
                //new Curriculum(){GroupId = 1,SubjectId = 23,NumberOfLectures = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 1,SubjectId = 25,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 26,NumberOfLectures = 16,Number = 4,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 27,NumberOfLectures = 16,Number = 4,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 28,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 29,NumberOfLectures = 16,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 19,NumberOfPractical = 54,},
                //new Curriculum(){GroupId = 1,SubjectId = 30,NumberOfLectures = 8,NumberOfPractical = 8,},
                //new Curriculum(){GroupId = 1,SubjectId = 31,NumberOfLectures = 8,NumberOfPractical = 8,},
                //new Curriculum(){GroupId = 1,SubjectId = 32,NumberOfLectures = 8,NumberOfPractical = 8,},
                //new Curriculum(){GroupId = 1,SubjectId = 36,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 37,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 38,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 1,SubjectId = 39,NumberOfLectures = 16,Number = 12,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 1,SubjectId = 40,NumberOfLectures = 16,Number = 12,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 1,SubjectId = 41,NumberOfLectures = 16,Number = 12,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 1,SubjectId = 45,NumberOfLectures = 16,Number = 4,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 1,SubjectId = 46,NumberOfLectures = 16,Number = 4,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 1,SubjectId = 47,NumberOfLectures = 16,Number = 4,NumberOfPractical = 32,},

                //new Curriculum(){GroupId = 2,SubjectId = 3,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 2,SubjectId = 2,NumberOfLectures = 8,NumberOfPractical = 8,},
                //new Curriculum(){GroupId = 2,SubjectId = 51,NumberOfLectures = 16,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 2,SubjectId = 7,NumberOfLectures = 16,Number = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 2,SubjectId = 53,NumberOfLectures = 32,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 2,SubjectId = 4,NumberOfLectures = 32,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 2,SubjectId = 54,NumberOfLectures = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 2,SubjectId = 56,NumberOfLectures = 32,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 2,SubjectId = 57,NumberOfLectures = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 2,SubjectId = 58,NumberOfPractical = 64,},


                //new Curriculum(){GroupId = 3,SubjectId = 20,NumberOfLectures = 24,Number = 16,NumberOfPractical = 8,},
                //new Curriculum(){GroupId = 3,SubjectId = 21,NumberOfLectures = 32,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 22,NumberOfLectures = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 3,SubjectId = 24,NumberOfLectures = 16,Number = 16,NumberOfPractical = 8,},
                //new Curriculum(){GroupId = 3,SubjectId = 25,NumberOfLectures = 16,Number = 12,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 26,NumberOfLectures = 16,Number = 8,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 3,SubjectId = 19,NumberOfPractical = 54,},
                //new Curriculum(){GroupId = 3,SubjectId = 33,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 34,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 35,NumberOfLectures = 16,Number = 8,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 42,NumberOfLectures = 16,Number = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 43,NumberOfLectures = 16,Number = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 44,NumberOfLectures = 16,Number = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 48,NumberOfLectures = 16,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 3,SubjectId = 49,NumberOfLectures = 16,NumberOfPractical = 16,},


                //new Curriculum(){GroupId = 4,SubjectId = 9,NumberOfPractical = 62,},
                //new Curriculum(){GroupId = 4,SubjectId = 3,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 4,SubjectId = 50,NumberOfLectures = 16,NumberOfPractical = 16,},
                //new Curriculum(){GroupId = 4,SubjectId = 52,NumberOfLectures = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 4,SubjectId = 7,NumberOfLectures = 16,Number = 16,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 4,SubjectId = 53,NumberOfLectures = 32,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 4,SubjectId = 4,NumberOfLectures = 32,NumberOfPractical = 32,},
                //new Curriculum(){GroupId = 4,SubjectId = 55,NumberOfLectures = 16,},
                //new Curriculum(){GroupId = 4,SubjectId = 57,NumberOfLectures = 32,NumberOfPractical = 32,},
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
                foreach (var item in curricula)
                {
                    item.Number /= 8;
                    //item.NumberOfLectures /= 8;
                    //item.NumberOfPractical /= 8;

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
