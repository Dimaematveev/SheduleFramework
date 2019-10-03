using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShedulerFromExcel.BL
{
    public class Title
    {
        /// <summary>
        /// Название потока
        /// </summary>
        public string Potok { get; private set; } = null;
        /// <summary>
        /// Год начала обучения
        /// </summary>
        public string YearBegin { get; private set; } = null;
        /// <summary>
        /// Направление обучения
        /// </summary>
        public string Napravl { get; private set; } = null;
        /// <summary>
        /// Профиль обучения
        /// </summary>
        public string Profil { get; private set; } = null;
        /// <summary>
        /// Кафедра
        /// </summary>
        public string Kafedra { get; private set; } = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="courseSheets"> таблица с Листом курса </param>
        /// <param name="nameFile"> Название файла (только название,не путь)</param>
        public Title(DataTable courseSheets, string nameFile)
        {
            //Что можно узнать из имени
            //Разбиваем имя по "_"
            var infoFromNameTable = nameFile.Split('_');
            //Поток из имени
            string Potok = infoFromNameTable[0];
            //Профиль из имени
            string Profil = infoFromNameTable[1];
            //Не знаю что это такое  из имени
            string NoSavvy = infoFromNameTable[2];
            //Год из имени
            string Year = infoFromNameTable[3].Split('.').First();

            //Получить поток - из названия файла беру поток и пытаюсь его найти 
            GetPotok(courseSheets, Potok);
            //Получить Год - сравнивается с годом который получили из названия файла
            GetYear(courseSheets, Year);
            //Получить Направление
            GetNapravl(courseSheets);
            //Получить Профиль
            GetProfil(courseSheets);
            //Получить Кафедру
            GetKafedra(courseSheets);
        }

        public Title()
        {
        }

        //Вывод на консоль
        public void ConsoleOut()
        {
            Console.WriteLine($"Поток:{Potok}, \nГод начала: {YearBegin}, \nНаправление: {Napravl}, \nПрофиль: {Profil}, \nКафедра: {Kafedra}.");
        }

        /// <summary>
        ///  Получит поток из Титульного листа -  из названия файла беру поток и пытаюсь его найти
        /// </summary>
        /// <param name="dataTable"> Таблица с Титульным листом</param>
        /// <param name="potok"> название потока который надо найти </param>
        private void GetPotok(DataTable dataTable, string potok)
        {
            //Цикл по строкам
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                //Цикл по столбцам
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    //Пропуск пустых значений ячейки
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }

                    //Если находим поток в ячейке 
                    if (string.Compare(potok, dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        // Присваиваем потоку этот поток
                        Potok = potok;
                        // Выходим из метода
                        return;
                    }
                }
            }
        }
        
       
        
        /// <summary>
        /// Получит год из Титульного листа - из названия файла беру год и сравниваю с тем что нашел по "Год начала"
        /// </summary>
        /// /// <param name="dataTable"> Таблица с Титульным листом</param>
        /// <param name="year"> год с которым надо сравнить </param>
        private void GetYear(DataTable dataTable, string year)
        {
            //Если есть ячейка содержащая "Год начала" 
            //Получаем строку и столбец ячейки 
            var pairsRowColumn = GetRowColPoisk(dataTable, "Год начала");
            if (pairsRowColumn!=null)
            {
                int row = pairsRowColumn[0].Key;
                int col = pairsRowColumn[0].Value;
                //Найденный год в таблице
                string foundYear = "";
                //Проходим по всем столбцам от Найденного нами +1 до конца 
                for (int j = col + 1; j < dataTable.Columns.Count; j++)
                {
                    //Если строка не пуста не содержит только пробелы или символы разделители 
                    if (!string.IsNullOrWhiteSpace(dataTable.Rows[row][j].ToString()))
                    {
                        foundYear = dataTable.Rows[row][j].ToString().Trim();
                        break;
                    }

                }
                //Если найденный год равен году который пришел в метод
                if (foundYear == year.Trim())
                {
                    //Устанавливаем год начала обучения
                    YearBegin = foundYear;
                }
            }
        }
        /// <summary>
        /// Получит Направление из Титул -> Ищет строку содержащую "Направление:"
        /// </summary>
        /// <param name="dataTable"> Таблица с Титульным листом</param>
        private void GetNapravl(DataTable dataTable)
        {
            //Если есть ячейка содержащая "Направление:" 
            //Получаем строку и столбец ячейки 
            var pairsRowColumn = GetRowColPoisk(dataTable, "Направление:");
            if (pairsRowColumn != null)
            {
                int row = pairsRowColumn[0].Key;
                int col = pairsRowColumn[0].Value;
                //Найденная строка
                string foundNapravl = dataTable.Rows[row][col].ToString().Trim();
                //Из найденной строки выделяем строку в кавычках
                foundNapravl = foundNapravl.Split('"')[1];
                //Это и будет направление
                Napravl = foundNapravl;
            }
            //Если не нашли строку содержащую "НАправление:"
            else
            {
                //Другой метод получения НАпрвления - 
                GetNapravlPotok(dataTable);
            }
        }
        /// <summary>
        /// Получит Направление из Титул -> Ищу строку содержащую поток
        /// </summary>
        /// <param name="dataTable"> Таблица с Титульным листом</param>
        private void GetNapravlPotok(DataTable dataTable)
        {
            //Если есть ячейка содержащая "Направление:" 
            //Получаем строку и столбец ячейки 
            var pairsRowColumn = GetRowColPoisk(dataTable, Potok);
            if (pairsRowColumn != null)
            {
                string Naiden = null;
                foreach (var pairRowColumn in pairsRowColumn)
                {
                    int row = pairRowColumn.Key;
                    int col = pairRowColumn.Value;
                    if (dataTable.Rows[row][col].ToString().Trim().Length > Potok.Trim().Length)
                    {
                        Naiden = dataTable.Rows[row][col].ToString();
                        break;
                    }
                }
                if (Naiden != null)
                {
                    Naiden = Naiden.Substring(Potok.Length).Trim();
                    Napravl = Naiden;
                    //Console.WriteLine($"Нашел {Naiden}  ");
                }
                else
                {
                    Console.WriteLine("Нету");
                }
            }
            //string Naiden = "";
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dataTable.Columns.Count; j++)
            //    {
            //        if (dataTable.Rows[i][j] == null)
            //        {
            //            continue;
            //        }

            //        if (dataTable.Rows[i][j].ToString().Contains(Potok))
            //        {
            //            if (dataTable.Rows[i][j].ToString().Length> Potok.Length)
            //            {
            //                Naiden = dataTable.Rows[i][j].ToString();
            //                break;
            //            }
                        
                        
            //        }
            //    }
            //    if (Naiden != "")
            //    {
            //        break;
            //    }
            //}

            //if (Naiden != "")
            //{
            //    Naiden = Naiden.Substring(Potok.Length).Trim();
            //    Napravl = Naiden;
            //    //Console.WriteLine($"Нашел {Naiden}  ");
            //}
            //else
            //{
            //    Console.WriteLine("Нету");
            //}
        }
        //Получит Профиль из Титул -> Ищу строку содерж "Профиль:"
        private void GetProfil(DataTable dataTable)
        {
            string Naiden = "";

            var pairsRowColumn = GetRowColPoisk(dataTable, "Профиль:");
            if (pairsRowColumn != null)
            {
                int row = pairsRowColumn[0].Key;
                int col = pairsRowColumn[0].Value;
                Naiden = dataTable.Rows[row][col].ToString();
                Naiden = Naiden.Split('"')[1];
                Profil = Naiden;
                //Console.WriteLine($"Нашел {Naiden}  ");
            }
            else
            {
                GetProfilSmesh(dataTable);
            }
        }
        //Получит Профиль из Титул -> Ищу строку содерж Профиль и перехожу правее
        private void GetProfilSmesh(DataTable dataTable)
        {
            var pairsRowColumn = GetRowColPoisk(dataTable, "Профиль");
            if (pairsRowColumn != null)
            {
                int row = pairsRowColumn[0].Key;
                int col = pairsRowColumn[0].Value;
                string Poisk = "";
                for (int j = col + 1; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[row][j] != null && dataTable.Rows[row][j].ToString() != "")
                    {
                        Poisk = dataTable.Rows[row][j].ToString();
                        break;
                    }

                }
                if (Poisk != "")
                {
                    //Console.WriteLine($"Нашел {Poisk} ");
                    Profil = Poisk;
                }
                else
                {
                    Console.WriteLine("Не найдено");
                }
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }


        //Получит Профиль из Титул -> Ищу строку содерж "Профиль:"
        private void GetKafedra(DataTable dataTable)
        {
            var pairsRowColumn = GetRowColPoisk(dataTable, "Кафедра:");
            if (pairsRowColumn != null)
            {
                int row = pairsRowColumn[0].Key;
                int col = pairsRowColumn[0].Value;
                string Poisk = "";
                for (int j = col + 1; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[row][j] != null && dataTable.Rows[row][j].ToString() != "")
                    {
                        Poisk = dataTable.Rows[row][j].ToString();
                        break;
                    }

                }

                if (Poisk != "")
                {
                    //Console.WriteLine($"Нашел {Poisk} ");
                    Kafedra = Poisk;
                }
                else
                {
                    Console.WriteLine("Не найдено");
                }
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }


        /// <summary>
        /// Поиск во всей таблицы ячейку содержащую ... и Вывод массива пар где Key-строка Value-столбец которые нашли или null если не нашли
        /// </summary>
        /// <param name="dataTable"> Таблица для поиска</param>
        /// <param name="poisk"> Что содержит ячейка </param>
        /// <returns>
        /// Вывод массива пар где Key-строка Value-столбец которые нашли,
        /// Если ничего не нашли то вывод null
        /// </returns>

        private KeyValuePair<int, int>[] GetRowColPoisk(DataTable dataTable, string poisk)
        {
            //Список для найденных пар где Key-строка Value-столбец 
            var tempKeyRowValueColumn = new List<KeyValuePair<int, int>>();
            //Цикл по строкам
            for (int r = 0; r < dataTable.Rows.Count; r++)
            {
                //Цикл по столбцам
                for (int c = 0; c < dataTable.Columns.Count; c++)
                {
                    //Если ячейка пуста то пропускаем
                    if (dataTable.Rows[r][c] == null)
                    {
                        continue;
                    }
                    //Если ячейка содержит нашу строку 
                    if (dataTable.Rows[r][c].ToString().Contains(poisk))
                    {
                        //Добавляем пару
                        tempKeyRowValueColumn.Add(new KeyValuePair<int, int>(r, c));
                    }
                }
            }
           
            if (tempKeyRowValueColumn.Count>0)
            {
                //Выходим из метода c массивом пар - так как нашли т.е. список с парами не пуст
                return tempKeyRowValueColumn.ToArray();
            }
            else
            {
                //Выходим из метода c null - так как не нашли т.е. список с парами пуст
                return null;
            }
        }

    }
}
