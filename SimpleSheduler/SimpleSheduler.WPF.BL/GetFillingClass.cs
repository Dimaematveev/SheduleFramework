using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System.Collections.Generic;
using System.Data;

namespace SimpleSheduler.WPF.BL
{
    public class GetFillingClass
    {
        public List<Filling<Group>> fillingGroups;
        public List<Filling<Classroom>> fillingClassrooms;


        /// <summary>
        /// Получить заполнение по каждому (группе,аудитории)
        /// </summary>
        /// <typeparam name="T">(группе,аудитории)</typeparam>
        /// <param name="array">массив (группе,аудитории)</param>
        /// <param name="pairs"> массив пар</param>
        /// <param name="studyDays">Массив учебных дней</param>
        /// <returns>массив заполнение по каждому (группе,аудитории)</returns>
        private List<Filling<T>> GetFilling<T>(List<T> array, List<Pair> pairs, List<StudyDay> studyDays) where T : class, IAbbreviation 
        {
            var result = new List<Filling<T>>();
            foreach (var item in array)
            {
                result.Add(new Filling<T>(item, pairs, studyDays));
            }
            return result;
        }

        /// <summary>
        /// Поличть все заполения
        /// </summary>
        /// <param name="getDataFromBD">БД</param>
        public void GetFilling()
        {
            fillingGroups = GetFilling(WorkToMyDbContext.groups, WorkToMyDbContext.pairs, WorkToMyDbContext.studyDays);
            fillingClassrooms = GetFilling(WorkToMyDbContext.classrooms, WorkToMyDbContext.pairs, WorkToMyDbContext.studyDays);
        }


        /// <summary>
        /// Получить таблицу с Данными по заполнению
        /// </summary>
        /// <param name="sNamespace"> Какую таблицу получаем typeof(Class).FullName</param>
        /// <param name="createScheduler"> Созданое рассписание</param>
        /// <returns></returns>
        public DataTable GetDateTableFilling(string sNamespace, CreateScheduler createScheduler)
        {
            if (sNamespace == typeof(Filling<Classroom>).FullName)
            {
                DataTable table = GetDateTableFilling(createScheduler.FillingClassrooms, false);
                table.TableName = "Заполнение Аудиторий";
                table.Namespace = typeof(Filling<Classroom>).FullName;
                return table;

            }
            if (sNamespace == typeof(Filling<Group>).FullName)
            {
                DataTable table = GetDateTableFilling(createScheduler.FillingGroups, false);
                table.TableName = "Заполнение Групп";
                table.Namespace = typeof(Filling<Group>).FullName;
                return table;
            }
            return null;
        }
        /// <summary>
        /// Получит таблицу для заполнения.
        /// </summary>
        /// <param name="sNamespace"> Какую таблицу получаем typeof(Class).FullName</param>
        /// <returns></returns>
        public DataTable GetDateTableFilling(string sNamespace)
        {
            if (sNamespace==typeof(Filling<Classroom>).FullName)
            {
                DataTable table = GetDateTableFilling(fillingClassrooms, true);
                table.TableName = "Заполнение Аудиторий";
                table.Namespace = typeof(Filling<Classroom>).FullName;
                return table;

            }
            if (sNamespace == typeof(Filling<Group>).FullName)
            {
                DataTable table = GetDateTableFilling(fillingGroups, true);
                table.TableName = "Заполнение Групп";
                table.Namespace = typeof(Filling<Group>).FullName;
                return table;
            }
            return null;
        }

        private DataTable GetDateTableFilling<T>(List<Filling<T>> fillings, bool set = true) where T : class, IAbbreviation 
        {
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "NumberOfWeek",
                    Caption = "Номер недели"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    ColumnName = "NameDayOfWeek",
                    Caption = "День недели"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "NumberThePair",
                    Caption = "Номер Пары"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                foreach (var filling in fillings)
                {
                    if (set)
                    {
                        column = new DataColumn
                        {

                            DataType = typeof(string),
                            ColumnName = $"{filling.Value.AbbreviationString()}",
                            Caption = $"{filling.Value.AbbreviationString()}"
                        };
                    }
                    else
                    {
                        column = new DataColumn
                        {

                            DataType = typeof(BusyPair),
                            ColumnName = $"{filling.Value.AbbreviationString()}",
                            Caption = $"{filling.Value.AbbreviationString()}"
                        };
                    }

                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                }
            }
            for (int i = 0; i < fillings[0].PossibleFillings.Count; i++)
            {
                DataRow row;
                row = table.NewRow();
                var temp = fillings[0].PossibleFillings[i];
                row[0] = $"{temp.StudyDay.NumberOfWeek}";
                row[1] = $"{temp.StudyDay.AbbreviationDayOfWeek}";
                row[2] = $"{temp.Pair.NumberThePair}";
                int stolb = 3;
                foreach (var filling in fillings)
                {
                    if (set)
                    {
                        string IsPair;
                        var BusyPair = filling.PossibleFillings[i].BusyPair;
                        IsPair = BusyPair == null ? null : BusyPair.Subject.Abbreviation;
                        row[stolb] = IsPair;
                    }
                    else
                    {
                        row[stolb] = filling.PossibleFillings[i].BusyPair;
                    }

                    stolb++;
                }
                table.Rows.Add(row);
            }
            return table;
        }


        public void SetDateTableFilling(DataTable dataTable)
        {
            if (dataTable.Namespace == typeof(Filling<Group>).FullName)
            {
                SetDateTableFilling(dataTable, fillingGroups);
            }
            if (dataTable.Namespace == typeof(Filling<Classroom>).FullName)
            {
                SetDateTableFilling(dataTable, fillingClassrooms);
            }
        }

        private void SetDateTableFilling<T>(DataTable dataTable, List<Filling<T>> fillings) where T : class, IAbbreviation 
        {

            for (int i = 0; i < fillings.Count; i++)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    BusyPair busyPair;
                    if (dataTable.Rows[j][3 + i].ToString() == "")
                    {
                        busyPair = null;
                    }
                    else
                    {
                        busyPair = new BusyPair(new Classroom(), new Subject() { Abbreviation = (string)dataTable.Rows[j][3 + i] }, new Group());
                    }
                    fillings[i].PossibleFillings[j].BusyPair = busyPair;
                }

            }

        }


    }
}
