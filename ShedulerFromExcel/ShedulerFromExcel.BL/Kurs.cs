using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShedulerFromExcel.BL
{
    public class Kurs
    {
        public DataTable Semester1 { get; private set; }
        public DataTable Semester2 { get; private set; }

        public Kurs(DataTable ListKurs, string nameList)
        {
            Semester(ListKurs, nameList);
        }
        public void ConsoleOutSemester2()
        {
            ConsoleOut(Semester2);
        }
        public void ConsoleOutSemester1()
        {
            ConsoleOut(Semester1);
        }
        private void ConsoleOut(DataTable table)
        {

            int[] dlinastroki = new int[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].Caption.Length > dlinastroki[i])
                {
                    dlinastroki[i] = table.Columns[i].Caption.Length;
                }
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (table.Rows[j][i].ToString().Length > dlinastroki[i])
                    {
                        dlinastroki[i] = table.Rows[j][i].ToString().Length;
                    }
                }
            }

            int lengTable = dlinastroki.Sum();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(table.TableName.PadLeft((lengTable+ table.TableName.Length) /2));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string str = table.Columns[i].Caption.PadRight(dlinastroki[i]);
                Console.Write( str + "|");

            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    string str = table.Rows[i][j].ToString().PadRight(dlinastroki[j]);
                    Console.Write( str + "|");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        private void Semester(DataTable dataTable,string nameList)
        {
            int Sem1Beg = -1;
            int Sem2Beg = -1;
            int Sem2End = -1;
            List<string> sem = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j].ToString().Contains("Семестр "))
                    {
                        sem.Add(dataTable.Rows[i][j].ToString());
                    } 
                }
            }



            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }

                    if ( string.Compare(sem[0], dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        Sem1Beg = j;
                        continue;
                    }
                    if (string.Compare(sem[1], dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        Sem2Beg = j;
                        continue;
                    }
                    if (string.Compare("Итого за курс", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        Sem2End = j - 1;
                        continue;
                    }
                }
                if (Sem1Beg >= 0 && Sem2Beg >= 0 && Sem2End >= 0)
                {
                    break;
                }
            }

            DataTable tableGeneral = TableGeneral(dataTable, Sem1Beg);

            Semester1 = TableSem(dataTable, Sem1Beg, Sem2Beg - 1, tableGeneral, nameList+ sem[0]);

            Semester2 = TableSem(dataTable, Sem2Beg, Sem2End, tableGeneral, nameList+ sem[1]);

            tableGeneral.Dispose();
        }

        private static DataTable TableSem(DataTable dataTable, int SemBeg, int SemEnd, DataTable tableGeneral, string nameTable)
        {
            DataTable tableSem = tableGeneral.Copy();
            tableSem.TableName = nameTable;
            DataColumn columnSem;
            columnSem = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Контроль"
            };
            tableSem.Columns.Add(columnSem);
            columnSem = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Лекции",
                Caption ="Лек"
                
            };
            tableSem.Columns.Add(columnSem);
            columnSem = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Лабораторные",
                Caption = "Лаб"
            };
            tableSem.Columns.Add(columnSem);
            columnSem = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Практические",
                Caption = "Прак"
            };
            tableSem.Columns.Add(columnSem);
            int colLek = -1;
            int colLab = -1;
            int colPra = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = SemBeg; j < SemEnd + 1; j++)
                {
                    var kpop = dataTable.Rows[i][j].ToString();
                    if (dataTable.Rows[i][j] == null || kpop == "")
                    {
                        continue;
                    }

                    if (string.Compare("Лек", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colLek = j;
                    }
                    if (string.Compare("Лаб", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colLab = j;
                    }
                    if (string.Compare("Пр", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colPra = j;
                    }
                }
                if (colLek >= 0 && colLab >= 0 && colPra >= 0)
                {
                    break;
                }
            }

            //Количество удаленных, для того чтобы не сбилось добавление
            int numDelete = 0;
            //Последний номер в списке в одной из предыдущих итераций
            int last = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var con = dataTable.Rows[i][SemBeg].ToString().Trim();
                var lek = dataTable.Rows[i][colLek].ToString().Trim();
                var lab = dataTable.Rows[i][colLab].ToString().Trim();
                var pra = dataTable.Rows[i][colPra].ToString().Trim();
                if (!int.TryParse(tableSem.Rows[i - numDelete][0].ToString(), out int nen))
                {
                    tableSem.Rows[i - numDelete].Delete();
                    numDelete++;
                    continue;
                }
                else
                {

                    if (nen == 1 && last > 0)
                    {
                        int z = i - numDelete;
                        for (int k = 0; k < z; k++)
                        {
                            tableSem.Rows[0].Delete();
                            numDelete++;
                        }
                    }
                    last = nen;
                }
                if ((con == null && lek == null && lab == null && pra == null) || (con.ToString() == "" && lek.ToString() == "" && lab.ToString() == "" && pra.ToString() == ""))
                {
                    tableSem.Rows[i - numDelete].Delete();
                    numDelete++;
                    continue;
                }
                
                tableSem.Rows[i - numDelete]["Контроль"] = con;
                tableSem.Rows[i - numDelete]["Лекции"] = lek;
                tableSem.Rows[i - numDelete]["Лабораторные"] = lab;
                tableSem.Rows[i - numDelete]["Практические"] = pra;
            }
            return tableSem;
        }

        private static DataTable TableGeneral(DataTable dataTable, int Sem1Beg)
        {
            DataTable tableGeneral = new DataTable("General");
            DataColumn columnGeneral;
            DataRow rowGeneral;
            columnGeneral = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "№",
                Caption = "№"
            };
            tableGeneral.Columns.Add(columnGeneral);
            columnGeneral = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Индекс",
                Caption = "Инд"
            };
            tableGeneral.Columns.Add(columnGeneral);
            columnGeneral = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Наименование",
                Caption = "Наим"
            };
            tableGeneral.Columns.Add(columnGeneral);


            int colNum = -1;
            int colInd = -1;
            int colName = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < Sem1Beg; j++)
                {
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }

                    if (string.Compare("№", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colNum = j;
                    }
                    if (string.Compare("Индекс", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colInd = j;
                    }
                    if (string.Compare("Наименование", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colName = j;
                    }
                }
                if (colNum >= 0 && colInd >= 0 && colName >= 0)
                {
                    break;
                }
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                rowGeneral = tableGeneral.NewRow();
                rowGeneral["№"] = dataTable.Rows[i][colNum].ToString().Trim();
                rowGeneral["Индекс"] = dataTable.Rows[i][colInd].ToString().Trim();
                rowGeneral["Наименование"] = dataTable.Rows[i][colName].ToString().Trim();
                tableGeneral.Rows.Add(rowGeneral);
            }
            return tableGeneral;
        }

    }
}
