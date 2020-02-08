using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSheduler.CMD
{
    /// <summary>
    /// Таблица в консоли
    /// </summary>
    public class ConsoleTable
    {
        /// <summary>
        /// Количество столбцов
        /// </summary>
        private int column;
        /// <summary>
        /// Ширина столбцов
        /// </summary>
        private int[] columnWidth;

        

        /// <summary>
        /// Имя таблицы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Имена столбцов
        /// </summary>
        public string[] NameColumn { get; set; } 

        /// <summary>
        /// Значения в таблице
        /// </summary>
        public List<string[]> Value { get; private set; }

        /// <summary>
        /// Конструктор таблицы
        /// </summary>
        /// <param name="column">Количество столбцов</param>
        public ConsoleTable()
        {
            this.column = 0;
            columnWidth = new int[0];
            NameColumn = new string[0];
            Value = new List<string[]>();
        }
        /// <summary>
        /// Добавить столбец - всем значениям добавляется null на этот столбец
        /// </summary>
        /// <param name="nameColumn">Название столбца</param>
        public void AddColumn(string nameColumn)
        {
            column++;
            NameColumn = AddToArray(NameColumn, nameColumn);
            columnWidth = AddToArray(columnWidth, nameColumn.Length);
            var tempValue = new List<string[]>();
            foreach (var value in Value)
            {
                tempValue.Add(AddToArray(value, null));
            }
            Value = tempValue;
        }
        /// <summary>
        /// Добавить в массив
        /// </summary>
        ///<typeparam name="T">тип массива и переменной</typeparam>
        /// <param name="mas">Массив</param>
        /// <param name="value">что добавить</param>
        /// <returns>Увеличенный массив на 1 элемент</returns>
        private T[] AddToArray<T>(T[] mas, T value)
        {
            T[] res = new T[mas.Length+1];
            for (int i = 0; i < mas.Length; i++)
            {
                res[i] = mas[i];
            }
            res[mas.Length] = value;
            return res;
        }
        public void Add(string[] value)
        {
            if (value.Length != column)
            {
                throw new ArgumentException($"Количество столбцов должно быть равным {column}, а у вас {value.Length}!", nameof(value));
            }
            Value.Add(value);
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].Length>columnWidth[i])
                {
                    columnWidth[i] = value[i].Length;
                }
            }
        }

        public void ToConsole()
        {
            int allColumn = columnWidth.Aggregate(0, (x, y) => x + y)+ columnWidth.Length*2;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Name.PadLeft((allColumn+Name.Length)/2));
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < NameColumn.Length; i++)
            {
                Console.Write(" " + NameColumn[i].PadRight(columnWidth[i]) + "|");
            }
            Console.WriteLine();
            foreach (var line in columnWidth)
            {
                Console.Write(new string('─', line + 1));
                Console.Write("┼");
            }
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in Value)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(" " + item[i].PadRight(columnWidth[i]) + "|");
                }
                Console.WriteLine();
                foreach (var line in columnWidth)
                {
                    Console.Write(new string('─', line + 1));
                    Console.Write("┼");
                }
                Console.WriteLine();
            }
        }


    }
}
