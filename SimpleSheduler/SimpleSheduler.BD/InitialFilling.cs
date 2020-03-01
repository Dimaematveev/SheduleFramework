using SimpleSheduler.BD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

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
				new StudyDay(){NumberDayOfWeek=1,FullNameDayOfWeek="Понедельник",AbbreviationDayOfWeek="пн", NumberOfWeek=1},
				new StudyDay(){NumberDayOfWeek=2,FullNameDayOfWeek="Вторник",AbbreviationDayOfWeek="вт", NumberOfWeek=1},
				new StudyDay(){NumberDayOfWeek=3,FullNameDayOfWeek="Среда",AbbreviationDayOfWeek="ср", NumberOfWeek=1},
				new StudyDay(){NumberDayOfWeek=4,FullNameDayOfWeek="Четверг",AbbreviationDayOfWeek="чт", NumberOfWeek=1},
				new StudyDay(){NumberDayOfWeek=5,FullNameDayOfWeek="Пятница",AbbreviationDayOfWeek="пт", NumberOfWeek=1},

				new StudyDay(){NumberDayOfWeek=1,FullNameDayOfWeek="Понедельник",AbbreviationDayOfWeek="пн", NumberOfWeek=2},
				new StudyDay(){NumberDayOfWeek=2,FullNameDayOfWeek="Вторник",AbbreviationDayOfWeek="вт", NumberOfWeek=2},
				new StudyDay(){NumberDayOfWeek=3,FullNameDayOfWeek="Среда",AbbreviationDayOfWeek="ср", NumberOfWeek=2},
				new StudyDay(){NumberDayOfWeek=4,FullNameDayOfWeek="Четверг",AbbreviationDayOfWeek="чт", NumberOfWeek=2},
				new StudyDay(){NumberDayOfWeek=5,FullNameDayOfWeek="Пятница",AbbreviationDayOfWeek="пт", NumberOfWeek=2},
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
				new Group(){FullName="090302_ИСиТ_АПиМОБИС_2017",NumberOfPersons= 32, Potok="090302",Seminar="0903_2017",Abbreviation="0903022017",GroupId=1 },
				new Group(){FullName="090302_ИСиТ_АПиМОБИС_2019",NumberOfPersons= 42, Potok="090302",Seminar="0903_2019",Abbreviation="0903022019",GroupId=2 },

				new Group(){FullName="090301_ИСиТ_АПиМОБИС_2017",NumberOfPersons= 21, Potok="090301",Seminar="0903_2017",Abbreviation="0903012017",GroupId=3 },
				new Group(){FullName="090301_ИСиТ_АПиМОБИС_2019",NumberOfPersons= 66, Potok="090301",Seminar="0903_2019",Abbreviation="0903012019",GroupId=4},
			};
			return AddGroups;
		}
		private static List<Classroom> CreateClassrooms()
		{
			var AddClassrooms = new List<Classroom>
			{
				new Classroom(){FullName="Аудитория №1",NumberOfSeats= 77,Abbreviation="А1" },
				new Classroom(){FullName="Аудитория №2",NumberOfSeats= 31,Abbreviation="А2" },
				new Classroom(){FullName="Аудитория №3",NumberOfSeats= 40,Abbreviation="А3" },
				new Classroom(){FullName="Аудитория №4",NumberOfSeats= 23,Abbreviation="А4" },
				new Classroom(){FullName="Аудитория №5",NumberOfSeats= 45,Abbreviation="А5" },
			};
			return AddClassrooms;
		}
		private static List<Subject> CreateSubjects()
		{

			var AddSubjects = new List<Subject>
			{
				new Subject(){Abbreviation="Фил",FullName="Философия"},
				new Subject(){Abbreviation="П",FullName="Правоведение"},
				new Subject(){Abbreviation="ИЯ",FullName="Иностранный язык"},
				new Subject(){Abbreviation="МА",FullName="Математический анализ"},
				new Subject(){Abbreviation="ДУ",FullName="Дифференциальные уравнения"},
				new Subject(){Abbreviation="ТВМСиСП",FullName="Теория вероятностей, математическая статистика и случайные процессы"},
				new Subject(){Abbreviation="Физ",FullName="Физика"},
				new Subject(){Abbreviation="БЖ",FullName="Безопасность жизнедеятельности"},
				new Subject(){Abbreviation="ФКиС",FullName="Физическая культура и спорт"},
				new Subject(){Abbreviation="ОСИИПТиС",FullName="Основы системной инженерии информационных процессов, технологий и систем"},
				new Subject(){Abbreviation="ТИПиС",FullName="Теория информационных процессов и систем"},
				new Subject(){Abbreviation="ОС",FullName="Операционные системы"},
				new Subject(){Abbreviation="СТ",FullName="Сетевые технологии"},
				new Subject(){Abbreviation="ИСиБД",FullName="Информационные системы и базы данных"},
				new Subject(){Abbreviation="ОИБ",FullName="Основы информационной безопасности"},
				new Subject(){Abbreviation="ИП",FullName="Информационное право"},
				new Subject(){Abbreviation="ППАО",FullName="Прикладное программирование аппаратного обеспечения"},
				new Subject(){Abbreviation="МЛТАиА",FullName="Математическая логика, теория автоматов и алгоритмов"},
				new Subject(){Abbreviation="ФКиСЭД",FullName="Физическая культура и спорт (элективная дисциплина)"},
				new Subject(){Abbreviation="ОМТБС",FullName="Общая математическая теория больших систем"},
				new Subject(){Abbreviation="ТУ",FullName="Теория управления"},
				new Subject(){Abbreviation="МиСППР",FullName="Методы и системы поддержки принятия решений"},
				new Subject(){Abbreviation="МиПОИПС",FullName="Математическое и программное обеспечение информационно-поисковых систем"},
				new Subject(){Abbreviation="КГиГМ",FullName="Компьютерная графика и геометрическое моделирование"},
				new Subject(){Abbreviation="ИСиСПД",FullName="Информационные сети и сети передачи данных"},
				new Subject(){Abbreviation="ФПОИС",FullName="Функциональное программное обеспечение информационных систем"},
				new Subject(){Abbreviation="АПОСРВ",FullName="Аппаратно-программное обеспечение систем реального времени"},
				new Subject(){Abbreviation="ИМСУ",FullName="Исполнительные механизмы систем управления"},
				new Subject(){Abbreviation="РиОТСИС",FullName="Ремонт и обслуживание технических средств информационных систем"},
				new Subject(){Abbreviation="БЖ2",FullName="Безопасность жизнедеятельности 2"},
				new Subject(){Abbreviation="ИТЛРЯ",FullName="Инженерно-техническая лексика русского языка"},
				new Subject(){Abbreviation="ПИК",FullName="Психология (инклюзивный курс)"},
				new Subject(){Abbreviation="ВГиД",FullName="Веб-графика и дизайн"},
				new Subject(){Abbreviation="НСиН",FullName="Нейронные сети и нейрокомпьютеры"},
				new Subject(){Abbreviation="ОИП",FullName="Основы информационного противоборства"},
				new Subject(){Abbreviation="ИМПВСУ",FullName="Инновационные методы проектирования встраиваемых систем управления"},
				new Subject(){Abbreviation="ДМЭИС",FullName="Дистанционный мониторинг элементов информационных систем"},
				new Subject(){Abbreviation="АиМСС",FullName="Анализ и мониторинг социальных сетей"},
				new Subject(){Abbreviation="ВИС",FullName="Высоконагруженные информационные системы"},
				new Subject(){Abbreviation="УББД",FullName="Управление большими базами данных"},
				new Subject(){Abbreviation="ПАвБ",FullName="Прогнозная аналитика в безопасности"},
				new Subject(){Abbreviation="ЛО",FullName="Логическое программирование"},
				new Subject(){Abbreviation="ЯИЗ",FullName="Языки инженерии знаний"},
				new Subject(){Abbreviation="ОБПИТиС",FullName="Основы безопасности прикладных информационных технологий и систем"},
				new Subject(){Abbreviation="ОиПТ",FullName="Оптимизация и построение трансляторов"},
				new Subject(){Abbreviation="РЭА",FullName="Разработка эффективных алгоритмов"},
				new Subject(){Abbreviation="ОСБПО",FullName="Основы создания безопасного программного обеспечения"},
				new Subject(){Abbreviation="АиПСМИС",FullName="Аппаратные и программные средства мобильных информационных систем"},
				new Subject(){Abbreviation="БКС",FullName="Беспроводные компьютерные сети"},
				new Subject(){Abbreviation="ИИРВИ",FullName="История (история России, всеобщая история)"},
				new Subject(){Abbreviation="Э",FullName="Экономика"},
				new Subject(){Abbreviation="И",FullName="Информатика"},
				new Subject(){Abbreviation="ЛАиАГ",FullName="Линейная алгебра и аналитическая геометрия"},
				new Subject(){Abbreviation="ДМ",FullName="Дискретная математика"},
				new Subject(){Abbreviation="ВвПД",FullName="Введение в профессиональную деятельность"},
				new Subject(){Abbreviation="АИС",FullName="Архитектура информационных систем "},
				new Subject(){Abbreviation="ТП",FullName="Технологии программирования"},
				new Subject(){Abbreviation="ОФП",FullName="Общая физическая подготовка"},

			};
			return AddSubjects;
		}

		private static List<TypeOfClasses> CreateTypeOfClasses()
		{

			var AddTypeOfClasses = new List<TypeOfClasses>
			{
				new TypeOfClasses(){Abbreviation="Лек",FullName="Лекция",TypeOfClassesId=1},
				new TypeOfClasses(){Abbreviation="Прак",FullName="Практика",TypeOfClassesId=2},
				new TypeOfClasses(){Abbreviation="Лаб",FullName="Лабораторная",TypeOfClassesId=3},
			};
			return AddTypeOfClasses;
		}
		private static List<Curriculum> CreateCurricula()
		{
			var AddCurricula = new List<Curriculum>
			{

				new Curriculum(){GroupId = 2,SubjectId = 3,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 2,SubjectId = 2,TypeOfClassesId=1,Number=8},  new Curriculum(){GroupId = 2,SubjectId = 2,TypeOfClassesId=2,Number=8},
				new Curriculum(){GroupId = 2,SubjectId = 51,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 2,SubjectId = 51,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 2,SubjectId = 7,TypeOfClassesId=1,Number=16}, new Curriculum(){GroupId = 2,SubjectId = 7,TypeOfClassesId=3,Number=16}, new Curriculum(){GroupId = 2,SubjectId = 7,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 2,SubjectId = 53,TypeOfClassesId=1,Number=32},    new Curriculum(){GroupId = 2,SubjectId = 53,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 2,SubjectId = 4,TypeOfClassesId=1,Number=32}, new Curriculum(){GroupId = 2,SubjectId = 4,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 2,SubjectId = 54,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 2,SubjectId = 54,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 2,SubjectId = 56,TypeOfClassesId=1,Number=32},    new Curriculum(){GroupId = 2,SubjectId = 56,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 2,SubjectId = 57,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 2,SubjectId = 57,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 2,SubjectId = 58,TypeOfClassesId=2,Number=64},


				new Curriculum(){GroupId = 4,SubjectId = 9,TypeOfClassesId=2,Number=62},
				new Curriculum(){GroupId = 4,SubjectId = 3,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 4,SubjectId = 50,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 4,SubjectId = 50,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 4,SubjectId = 52,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 4,SubjectId = 52,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 4,SubjectId = 7,TypeOfClassesId=1,Number=16}, new Curriculum(){GroupId = 4,SubjectId = 7,TypeOfClassesId=3,Number=16}, new Curriculum(){GroupId = 4,SubjectId = 7,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 4,SubjectId = 53,TypeOfClassesId=1,Number=32},    new Curriculum(){GroupId = 4,SubjectId = 53,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 4,SubjectId = 4,TypeOfClassesId=1,Number=32}, new Curriculum(){GroupId = 4,SubjectId = 4,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 4,SubjectId = 55,TypeOfClassesId=1,Number=16},
				new Curriculum(){GroupId = 4,SubjectId = 57,TypeOfClassesId=1,Number=32},    new Curriculum(){GroupId = 4,SubjectId = 57,TypeOfClassesId=2,Number=32},


				new Curriculum(){GroupId = 1,SubjectId = 23,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 23,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 1,SubjectId = 25,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 25,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 1,SubjectId = 25,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 26,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 26,TypeOfClassesId=3,Number=4}, new Curriculum(){GroupId = 1,SubjectId = 26,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 27,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 27,TypeOfClassesId=3,Number=4}, new Curriculum(){GroupId = 1,SubjectId = 27,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 28,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 28,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 1,SubjectId = 28,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 29,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 29,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 19,TypeOfClassesId=2,Number=54},
				new Curriculum(){GroupId = 1,SubjectId = 30,TypeOfClassesId=1,Number=8},     new Curriculum(){GroupId = 1,SubjectId = 30,TypeOfClassesId=2,Number=8},
				new Curriculum(){GroupId = 1,SubjectId = 31,TypeOfClassesId=1,Number=8},     new Curriculum(){GroupId = 1,SubjectId = 31,TypeOfClassesId=2,Number=8},
				new Curriculum(){GroupId = 1,SubjectId = 32,TypeOfClassesId=1,Number=8},     new Curriculum(){GroupId = 1,SubjectId = 32,TypeOfClassesId=2,Number=8},
				new Curriculum(){GroupId = 1,SubjectId = 36,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 36,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 1,SubjectId = 36,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 37,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 37,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 1,SubjectId = 37,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 38,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 38,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 1,SubjectId = 38,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 1,SubjectId = 39,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 39,TypeOfClassesId=3,Number=12},    new Curriculum(){GroupId = 1,SubjectId = 39,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 1,SubjectId = 40,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 40,TypeOfClassesId=3,Number=12},    new Curriculum(){GroupId = 1,SubjectId = 40,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 1,SubjectId = 41,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 41,TypeOfClassesId=3,Number=12},    new Curriculum(){GroupId = 1,SubjectId = 41,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 1,SubjectId = 45,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 45,TypeOfClassesId=3,Number=4}, new Curriculum(){GroupId = 1,SubjectId = 45,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 1,SubjectId = 46,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 46,TypeOfClassesId=3,Number=4}, new Curriculum(){GroupId = 1,SubjectId = 46,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 1,SubjectId = 47,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 1,SubjectId = 47,TypeOfClassesId=3,Number=4}, new Curriculum(){GroupId = 1,SubjectId = 47,TypeOfClassesId=2,Number=32},

				
				new Curriculum(){GroupId = 3,SubjectId = 20,TypeOfClassesId=1,Number=24},    new Curriculum(){GroupId = 3,SubjectId = 20,TypeOfClassesId=3,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 20,TypeOfClassesId=2,Number=8},
				new Curriculum(){GroupId = 3,SubjectId = 21,TypeOfClassesId=1,Number=32},    new Curriculum(){GroupId = 3,SubjectId = 21,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 3,SubjectId = 21,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 22,TypeOfClassesId=1,Number=16},        new Curriculum(){GroupId = 3,SubjectId = 22,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 3,SubjectId = 24,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 24,TypeOfClassesId=3,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 24,TypeOfClassesId=2,Number=8},
				new Curriculum(){GroupId = 3,SubjectId = 25,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 25,TypeOfClassesId=3,Number=12},    new Curriculum(){GroupId = 3,SubjectId = 25,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 26,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 26,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 3,SubjectId = 26,TypeOfClassesId=2,Number=32},
				new Curriculum(){GroupId = 3,SubjectId = 19,TypeOfClassesId=2,Number=54},
				new Curriculum(){GroupId = 3,SubjectId = 33,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 33,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 3,SubjectId = 33,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 34,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 34,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 3,SubjectId = 34,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 35,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 35,TypeOfClassesId=3,Number=8}, new Curriculum(){GroupId = 3,SubjectId = 35,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 42,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 42,TypeOfClassesId=3,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 43,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 43,TypeOfClassesId=3,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 44,TypeOfClassesId=1,Number=16},    new Curriculum(){GroupId = 3,SubjectId = 44,TypeOfClassesId=3,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 48,TypeOfClassesId=1,Number=16},        new Curriculum(){GroupId = 3,SubjectId = 48,TypeOfClassesId=2,Number=16},
				new Curriculum(){GroupId = 3,SubjectId = 49,TypeOfClassesId=1,Number=16},        new Curriculum(){GroupId = 3,SubjectId = 49,TypeOfClassesId=2,Number=16},


		
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
				var addStudyDays = CreateStudyDays();
				var addPairs = CreatePairs();
				var addTypeOfClasses = CreateTypeOfClasses();
				///Добавляем запись в наш КЭШ но пока не отправили в БД
				context.StudyDays.AddRange(addStudyDays);
				context.Pairs.AddRange(addPairs);
				context.Groups.AddRange(addGroups);
				context.Classrooms.AddRange(addClassrooms);
				context.Subjects.AddRange(addSubjects);
				context.TypeOfClasses.AddRange(addTypeOfClasses);
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
