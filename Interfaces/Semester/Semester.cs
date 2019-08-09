﻿using DaysOfStudy.Interfaces;
using Interface.Interface;
using Interface.Interfaces;
using Semester.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Semester
{
    /// <summary>
    /// Класс семестр.
    /// </summary>
    public class Semester : ISemesterWithConsole
    {
        /// <value>Дата начала семестра.</value>
        public DateTime BeginSemestr { get; set ; }
        /// <value>Дата окончания семестра.</value>
        public DateTime EndSemestr { get ; set; }
        /// <value>Список по дням указывающий выходной или учебный.</value>
        public IDaysOfStudy[] DaysOfStudies { get; set; }
        /// <summary>
        /// Стандартный конструктор. Воскресенье выходные.
        /// </summary>
        /// <param name="beginSemestr">Дата начала семестра.</param>
        /// <param name="endSemestr">Дата окончания семестра.</param>
        public Semester(DateTime beginSemestr, DateTime endSemestr)
        {
            if (beginSemestr < new DateTime(DateTime.Now.Year-7,1,1))
            {
                throw new ArgumentException($"Дата начала семестра не должна быть меньше {new DateTime(DateTime.Now.Year - 7, 1, 1).ToShortDateString()}! Сейчас={beginSemestr.ToShortDateString()}", nameof(beginSemestr));
            }
            if (endSemestr > new DateTime(DateTime.Now.Year + 7, 1, 1))
            {
                throw new ArgumentException($"Дата окончания семестра не должна быть больше {new DateTime(DateTime.Now.Year + 7, 1, 1).ToShortDateString()}! Сейчас={endSemestr.ToShortDateString()}", nameof(endSemestr));
            }
            if (beginSemestr >= endSemestr) 
            {
                throw new ArgumentException($"'Дата начала семестра ={beginSemestr.ToShortDateString()}' должен быть меньше 'Даты окончания семестра={endSemestr.ToShortDateString()}'! ", nameof(endSemestr) + "," + nameof(beginSemestr));
            }
            if ((endSemestr - beginSemestr).Days > 180)
            {
                throw new ArgumentException($"Семестр не должен быть больше 180 дней! А сейчас {(endSemestr - beginSemestr).Days}!", nameof(endSemestr)+"-"+nameof(beginSemestr));
            }
            BeginSemestr = beginSemestr;
            EndSemestr = endSemestr;
            var  tempDaysOfStudies = new List<IDaysOfStudy>();
            for (var i = BeginSemestr; i <= EndSemestr; i=i.AddDays(1))
            {
                tempDaysOfStudies.Add(new DaysOfStudy.DaysOfStudy(i,HowDays.WorkingDay));
            }
            DaysOfStudies = tempDaysOfStudies.ToArray();
            AddDayWeekConsole(DayOfWeek.Sunday, HowDays.DayOff);
        }
        /// <summary>
        /// У указанного дня недели устанавливает тип дня.
        /// </summary>
        /// <param name="dayOfWeek">День недели.</param>
        /// <param name="numberOfPairsPerDay">Тип дня(выходной, учебный..)</param>
        public void AddDayWeekConsole(DayOfWeek dayOfWeek ,HowDays numberOfPairsPerDay)
        {
            for (int i = 0; i < DaysOfStudies.Length; i++)
            {
                if (DaysOfStudies[i].Date.DayOfWeek == dayOfWeek)
                {
                    DaysOfStudies[i].Study = numberOfPairsPerDay;
                    i += 6;
                }
            }
            
            
        }
        /// <summary>
        /// Вывод на консоль.
        /// </summary>
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
                if (item.Date.Day==1)
                {
                    Console.WriteLine();
                    MethodConsole(cultureDataFormat, item.Date);
                }
                if(item.Date.DayOfWeek== cultureDataFormat.FirstDayOfWeek)
                {
                    Console.WriteLine();
                }
                ((IConsole)item).ToConsole();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит на консоль название месяца и дни недели и также пробелы до первого дня в месяце.
        /// </summary>
        /// <param name="cultureDataFormat">Образно язык используемый в приложении.</param>
        /// <param name="dateTime">Месяц</param>
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

        /// <summary>
        /// Возможные команды в консоли.
        /// </summary>
        public void CommandConsole()
        {
            Console.WriteLine();
            //char - указывает на какой символ сработает, string что выведется в консоль.
            List<KeyValuePair<char, string>> command = new List<KeyValuePair<char, string>>()
            {
                new KeyValuePair<char, string>('0',"выход"),
                new KeyValuePair<char, string>('1',"вывод на консоль"),
                new KeyValuePair<char, string>('2',"добавления выходного"),
                new KeyValuePair<char, string>('3',"добавления рабочего дня")
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
            Console.WriteLine($"Вы ввели '{command.First(x=> x.Key == characterInput).Key}' - {command.First(x => x.Key == characterInput).Value}.");
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
                AddDayConsole(HowDays.DayOff);
            }
            if (characterInput == command[3].Key)
            {
                AddDayConsole(HowDays.WorkingDay);
            }
            CommandConsole();
        }
        /// <summary>
        /// Функция изменения типа дней.!!! Рефакторинг
        /// </summary>
        /// <param name="howDays">На какой день поменять.</param>
        public void AddDayConsole(HowDays howDays)
        {
            Console.WriteLine();
            string dayIs = "сокращенных дней";
            if (howDays == HowDays.WorkingDay)
            {
                dayIs = "рабочих дней";
            }
            if (howDays == HowDays.DayOff)
            {
                dayIs = "выходных дней";
            }
            List<KeyValuePair<char, string>> command = new List<KeyValuePair<char, string>>()
            {
                new KeyValuePair<char, string>('0',"выход"),
                new KeyValuePair<char, string>('1',"добавления одного"),
                new KeyValuePair<char, string>('2',"добавления диапазона")
            };
            Console.WriteLine($"Возможные команды для добавления {dayIs}.");
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
                AddDayOneConsole(howDays);
            }
            if (characterInput == command[2].Key)
            {
                AddDayManyConsole(howDays);
            }
            AddDayConsole(howDays);
        }
        /// <summary>
        /// Изменить один день.
        /// </summary>
        /// <param name="numberOfPairsPerDay">На какой изменить.</param>
        public void AddDayOneConsole(HowDays numberOfPairsPerDay)
        {
            char characterInput;
            do
            {
                DateTime date = DateValidationCheckConsole("Введите дату между", BeginSemestr, EndSemestr);
                DaysOfStudies.First(d => d.Date == date).Study = numberOfPairsPerDay;
                Console.WriteLine($"Введите 'y' если хотите добавить еще один день.");
                characterInput = Console.ReadKey(true).KeyChar;
            } while (characterInput == 'y');
        }
        /// <summary>
        /// Изменить Несколько дней.
        /// </summary>
        /// <param name="numberOfPairsPerDay">На какой изменить.</param>
        public void AddDayManyConsole(HowDays numberOfPairsPerDay)
        {
            char characterInput;
            do
            {
                DateTime dateBegin = DateValidationCheckConsole("Введите дату начала диапазона между", BeginSemestr, EndSemestr);
                DateTime dateEnd = DateValidationCheckConsole("Введите дату окончания диапазона между", dateBegin, EndSemestr);
                int beginInd = Array.FindIndex(DaysOfStudies,d => d.Date == dateBegin);
                int endInd = Array.FindIndex(DaysOfStudies,d => d.Date == dateEnd);
                for (int i = beginInd; i <= endInd; i++)
                {
                    DaysOfStudies[i].Study = numberOfPairsPerDay;
                }
                Console.WriteLine($"Введите 'y' если хотите добавить еще один диапазон дней.");
                characterInput = Console.ReadKey(true).KeyChar;
            } while (characterInput == 'y');

        }
        /// <summary>
        /// Проверка корректности веденной даты.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
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
