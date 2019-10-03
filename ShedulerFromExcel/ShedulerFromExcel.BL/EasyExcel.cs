using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ShedulerFromExcel.BL
{
    /// <summary>
    /// Парсер планов.
    /// </summary>
    public class EasyExcel
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private readonly string FilePath;
        /// <summary>
        /// Титульный лист.
        /// </summary>
        public Title Title { get; private set; } = new Title();
        /// <summary>
        /// Массив курсов.
        /// </summary>
        public List<OneCourse> AllCourses { get; private set; } = new List<OneCourse>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="filePath"> Путь к фалу Excel</param>
        public EasyExcel(string filePath)
        {
            FilePath = filePath;
            Sta();
        }


        /// <summary>
        /// Основная функция для вытягивания из Excel нужных данных
        /// </summary>
        private void Sta()
        {
            //Сюда сохраняем все листы. Создаем таблицу для всех Листов с названием этого листа.
            List<DataTable> AllSheets = new List<DataTable>();

            //Открываем для чтения наш файл
            using (var stream = File.Open(FilePath, FileMode.Open, FileAccess.Read))
            {
                //Наш открытый поток читаем как файл Excel
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    //Номер листа
                    int sheetNumber = 0;
                    //Читаем по листам
                    do
                    {
                        //Название листа
                        var nameList = reader.Name;

                        //Таблица для текущего листа
                        DataTable currentSheet = new DataTable(nameList);

                        //Количество столбцов
                        var columnCount = reader.FieldCount;
                        //Добавляем в таблицу пустые столбцы с названием А+"номер"
                        for (int i = 0; i < columnCount; i++)
                        {
                            //Новый столбец
                            DataColumn columnNew = new DataColumn
                            {
                                DataType = System.Type.GetType("System.String"),
                                ColumnName = "A" + (i + 1)
                            };
                            //Добавляем столбец в таблицу
                            currentSheet.Columns.Add(columnNew);
                        }

                        //Читаем построчно!
                        while (reader.Read())
                        {
                            //Новая строка
                            DataRow rowNew = currentSheet.NewRow();
                            //Проходим по всем столбцам
                            for (int i = 0; i < columnCount; i++)
                            {
                                //Значение ячейки
                                string cellValue = null;

                                //Проверка что текущая ячейка не пуста
                                if (reader.GetValue(i) != null)
                                {
                                    //Удаляем лишние пробелы
                                    cellValue = reader.GetValue(i).ToString().Trim();
                                }

                                if (string.IsNullOrWhiteSpace(cellValue))
                                {
                                    cellValue = null;
                                }

                                //Добавляем в строку с название столбца А+"номер"
                                rowNew["A" + (i + 1)] = cellValue;
                            }

                            //Добавляем готовую стоку в таблицу
                            currentSheet.Rows.Add(rowNew);
                        }

                        //Добавляем готовую таблицу листа в Список всех листов
                        AllSheets.Add(currentSheet);
                        //Кол-во листов +1
                        sheetNumber++;
                        //Читаем следующий лист
                    } while (reader.NextResult());
                }
            }
            //Получит готовые Курсы
            GetCourses(AllSheets);
            //Получить готовый титульный лист
            GetTitle(AllSheets);

            //Вывод на консоль
            ConsoleOut();
        }

        /// <summary>
        /// Вывод на консоль
        /// </summary>
        private void ConsoleOut()
        {
            //Вывод титульного листа
            Console.ForegroundColor = ConsoleColor.Red;
            Title.ConsoleOut();
            Console.ForegroundColor = ConsoleColor.White;
            //Вывод по курсам
            foreach (var item in AllCourses)
            {
                //Вывод семестра 1 в году
                item.ConsoleOutSemester1();
                Console.WriteLine();
                //Вывод семестра 2 в году
                item.ConsoleOutSemester2();
            }
        }
        /// <summary>
        /// Получить готовый титульный лист
        /// </summary>
        /// <param name="AllSheets"> список Таблиц со всеми листами </param>
        private void GetTitle(List<DataTable> AllSheets)
        {
            //Название листа(Таблицы) должно быть - "Титул"
            Regex regex = new Regex(@"^Титул");
            //Проходим по всем таблицам
            foreach (var item in AllSheets)
            {
                //Если название сходится то создаем готовый титульный лист
                if (regex.IsMatch(item.TableName))
                {
                    //Создаем титульный лист
                    Title = new Title(item, FilePath.Split('\\').Last());

                }
            }
        }
        /// <summary>
        /// Получить готовые листы с курсами
        /// </summary>
        /// <param name="AllSheets"> список Таблиц со всеми листами </param>
        private void GetCourses(List<DataTable> AllSheets)
        {
            //Название листа(Таблицы) должно  начинаться на "Курс" и после одна цифра
            Regex regex = new Regex(@"^Курс\d");
            //Проходим по всем таблицам
            foreach (var item in AllSheets)
            {
                //Если название сходится то добавляем в Курсы еще один курс
                if (regex.IsMatch(item.TableName))
                {
                    //Создаем новый один курс
                    OneCourse newOneCourse = new OneCourse(item, item.TableName);
                    //Добавляем курс во все курсы
                    AllCourses.Add(newOneCourse);
                }
            }
        }

    }
}
