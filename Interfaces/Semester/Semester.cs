using Interface.Interface;
using Interface.Interfaces;
using Semester.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester
{
    class Semester : ISemesterWithConsole<IDaysOfStudyWithConsole>
    {
       
        public DateTime BeginSemestr { get; set ; }
        public DateTime EndSemestr { get ; set; }
        public List<IDaysOfStudyWithConsole> DaysOfStudies { get; set; }
        public Semester(DateTime beginSemestr, DateTime endSemestr)
        {
            //TODO: BeginSemestr < EndSemestr
            //TODO: Их разница не более полугода.
            BeginSemestr = beginSemestr;
            EndSemestr = endSemestr;
            DaysOfStudies = new List<IDaysOfStudyWithConsole>();
            for (var i = BeginSemestr; i <= EndSemestr; i=i.AddDays(1))
            {
                if (i.DayOfWeek==DayOfWeek.Sunday)
                {
                    DaysOfStudies.Add(new DaysOfStudy(i, 0));
                }
                else
                {
                    DaysOfStudies.Add(new DaysOfStudy(i, 1));
                }
            }
        }
        public void ToConsole()
        {
            CultureInfo culInf = new CultureInfo("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentCulture = culInf;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culInf;
            var cultureDataFormat = DateTimeFormatInfo.CurrentInfo;
            cultureDataFormat.FirstDayOfWeek=DayOfWeek.Monday;
            if (BeginSemestr.Day!=1)
            {
                MethodConsole(cultureDataFormat, BeginSemestr);
            }
            foreach (var item in DaysOfStudies)
            {
                if (item.Day.Day==1)
                {
                    Console.WriteLine();
                    MethodConsole(cultureDataFormat, item.Day);

                }
                if(item.Day.DayOfWeek== cultureDataFormat.FirstDayOfWeek)
                {
                    Console.WriteLine();
                }
                item.ToConsole();
            }
            Console.WriteLine();
        }

        void MethodConsole( DateTimeFormatInfo cultureDataFormat, DateTime dateTime)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{cultureDataFormat.MonthNames[dateTime.Month - 1],10}");
            Console.ForegroundColor = ConsoleColor.White;

            for (var i = (int)cultureDataFormat.FirstDayOfWeek; i < (int)(7 + cultureDataFormat.FirstDayOfWeek); i++)
            {
                Console.Write($"{cultureDataFormat.AbbreviatedDayNames[i % 7],4}");
            }
            if (dateTime.DayOfWeek != cultureDataFormat.FirstDayOfWeek)
            {
                Console.WriteLine();
                string sss = new string(' ', 4 * (int)(dateTime.DayOfWeek - 1));
                Console.Write($"{sss}");
            }

        }

        public void CommandConsole()
        {
            
            List<KeyValuePair<char, string>> command = new List<KeyValuePair<char, string>>()
            {
                new KeyValuePair<char, string>('0',"выход"),
                new KeyValuePair<char, string>('1',"вывод на консоль"),
                new KeyValuePair<char, string>('2',"добавления выходного"),
                //new KeyValuePair<char, string>('2',"удаления выходного")
            };
            Console.WriteLine("Все возможные команды.");
            Console.WriteLine("Введите:");
            foreach (var item in command)
            {
                Console.WriteLine($"'{item.Key}' - {item.Value}.");
            }

            char characterInput;
            do
            {
                characterInput=Console.ReadKey(true).KeyChar;
            }while (!command.Exists(x => x.Key == characterInput));
            Console.WriteLine($"Вы ввели '{command.Find(x => x.Key == characterInput).Key}' - {command.Find(x => x.Key == characterInput).Value}.");
            if (characterInput == command[0].Key)
            {
                return;
            }
            if (characterInput== command[1].Key)
            {
                ToConsole();
            }
            if (characterInput == command[2].Key)
            {
                AddDayOffConsole();
            }
            CommandConsole();
        }

        public void AddDayOffConsole()
        {
            List<KeyValuePair<char, string>> command = new List<KeyValuePair<char, string>>()
            {
                new KeyValuePair<char, string>('0',"выход"),
                new KeyValuePair<char, string>('1',"добавления одного выходного"),
                new KeyValuePair<char, string>('2',"добавления диапазона выходных")
            };
            Console.WriteLine("Возможные команды для добавления выходного.");
            Console.WriteLine("Введите:");
            foreach (var item in command)
            {
                Console.WriteLine($"'{item.Key}' - {item.Value}.");
            }
            char characterInput;
            do
            {
                characterInput = Console.ReadKey(true).KeyChar;
            } while (!command.Exists(x => x.Key == characterInput));

            Console.WriteLine($"Вы ввели '{command.Find(x => x.Key == characterInput).Key}' - {command.Find(x => x.Key == characterInput).Value}.");
            if (characterInput == command[0].Key)
            {
                return;
            }
            if (characterInput == command[1].Key)
            {
                AddDayOffOneConsole();
            }
            if (characterInput == command[2].Key)
            {
                AddDayOffManyConsole();
            }
            AddDayOffConsole();
        }
        public void AddDayOffOneConsole()
        {
            char characterInput;
            do
            {
                DateTime date = DateValidationCheckConsole("Введите дату между", BeginSemestr, EndSemestr);
                DaysOfStudies.Find(x => x.Day == date).Study = 0;
                Console.WriteLine($"Введите 'y' если хотите добавить еще один выходной.");
                characterInput = Console.ReadKey(true).KeyChar;
            } while (characterInput == 'y');
        }

        public void AddDayOffManyConsole()
        {
            char characterInput;
            do
            {
                DateTime dateBegin = DateValidationCheckConsole("Введите дату начала диапазона между", BeginSemestr, EndSemestr);
                DateTime dateEnd = DateValidationCheckConsole("Введите дату окончания диапазона между", dateBegin, EndSemestr);
                DaysOfStudies.FindAll(x => x.Day >= dateBegin && x.Day <= dateEnd).ForEach(y=>y.Study= 0);
                Console.WriteLine($"Введите 'y' если хотите добавить еще один диапазон выходных.");
                characterInput = Console.ReadKey(true).KeyChar;
            } while (characterInput == 'y');

        }
        public DateTime DateValidationCheckConsole(string str, DateTime dateBegin, DateTime dateEnd)
        {
            DateTime date;
            while (true)
            {
                Console.WriteLine($"{str} {dateBegin.ToShortDateString()} и {dateEnd.ToShortDateString()}");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    if (date < dateBegin || date > dateEnd)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Дата не в интервале от {dateBegin.ToShortDateString()} до {dateEnd.ToShortDateString()}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неправильный формат ввода даты! Должно быть {DateTime.Today.ToShortDateString()}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return date;
        }
    }

   
}
