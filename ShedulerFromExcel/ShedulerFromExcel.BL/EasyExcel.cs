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
    public class EasyExcel
    {
        public void sta()
        {
            var filePath = "..\\..\\..\\ShedulerFromExcel.BL\\Easy.xlsx";
            
            DataTable tableList = new DataTable("List");
            DataColumn columnList;
            DataRow rowList;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
               
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                       
                       
                        var row = reader.RowCount;
                        var col = reader.FieldCount;
                        for (int i = 0; i < col; i++)
                        {
                            columnList = new DataColumn();
                            columnList.DataType = System.Type.GetType("System.Object");
                            columnList.ColumnName = "A"+(i+1);
                            tableList.Columns.Add(columnList);
                        }
                       
                      
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);

                            rowList = tableList.NewRow();
                            for (int i = 0; i < col; i++)
                            {
                                rowList["A" + (i + 1)] = reader.GetValue(i);
                            }
                            tableList.Rows.Add(rowList);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    //var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                }

            }
            DataTable sem1;
            DataTable sem2;
            Semester(tableList,out sem1,out sem2);
            ConsoleOut(sem1);
            ConsoleOut(sem2);
        }


        private void ConsoleOut(DataTable table)
        {
            
            int[] dlinastroki = new int[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].ColumnName.Length > dlinastroki[i])
                {
                    dlinastroki[i] = table.Columns[i].ColumnName.Length;
                }
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (table.Rows[j][i].ToString().Length > dlinastroki[i])
                    {
                        dlinastroki[i] = table.Rows[j][i].ToString().Length;
                    }
                }
            }


            Console.WriteLine(table.TableName);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string str = table.Columns[i].ColumnName.PadRight(dlinastroki[i]);
                Console.Write("|" + str+ "|");
                
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    string str = table.Rows[i][j].ToString().PadRight(dlinastroki[j]);
                    Console.Write("|"+str+"|");
                }
            }
            Console.WriteLine();
        }
        /*
        Что я хочу
        Просто распарсить первый лист "Курс"
        Выбираю все связаное с Семестр 1
        Нужно 
        Контроль
        Лек
        Лаб
        Пр
        */
        private void Semester(DataTable dataTable, out DataTable tableSem1, out DataTable tableSem2)
        {
            


            int Sem1Beg = -1;
            int Sem2Beg = -1;
            int Sem2End = -1;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }
                    
                    if (string.Compare("Семестр 1", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        Sem1Beg = j;
                        continue;
                    }
                    if (string.Compare("Семестр 2", dataTable.Rows[i][j].ToString(), true) == 0)
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

            DataTable tableGeneral = new DataTable("General");
            DataColumn columnGeneral;
            DataRow rowGeneral;
            columnGeneral = new DataColumn();
            
            columnGeneral.DataType = System.Type.GetType("System.String");
            columnGeneral.ColumnName = "№";
            tableGeneral.Columns.Add(columnGeneral);
            columnGeneral = new DataColumn();
            columnGeneral.DataType = System.Type.GetType("System.String");
            columnGeneral.ColumnName = "Индекс";
            tableGeneral.Columns.Add(columnGeneral);
            columnGeneral = new DataColumn();
            columnGeneral.DataType = System.Type.GetType("System.String");
            columnGeneral.ColumnName = "Наименование";
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


            tableSem1 = tableGeneral.Copy();
            tableSem1.TableName = "Семестер 1";
            DataColumn columnSem1;
            DataRow rowSem1;
            columnSem1 = new DataColumn();
            columnSem1.DataType = System.Type.GetType("System.String");
            columnSem1.ColumnName = "Контроль";
            tableSem1.Columns.Add(columnSem1);
            columnSem1 = new DataColumn();
            columnSem1.DataType = System.Type.GetType("System.String");
            columnSem1.ColumnName = "Лекции";
            tableSem1.Columns.Add(columnSem1);
            columnSem1 = new DataColumn();
            columnSem1.DataType = System.Type.GetType("System.String");
            columnSem1.ColumnName = "Лабораторные";
            tableSem1.Columns.Add(columnSem1);
            columnSem1 = new DataColumn();
            columnSem1.DataType = System.Type.GetType("System.String");
            columnSem1.ColumnName = "Практические";
            tableSem1.Columns.Add(columnSem1);
            int colLek1 = -1;
            int colLab1 = -1;
            int colPra1 = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = Sem1Beg; j < Sem2Beg; j++)
                {
                    var kpop = dataTable.Rows[i][j].ToString();
                    if (dataTable.Rows[i][j] == null || kpop == "")
                    {
                        continue;
                    }

                    if (string.Compare("Лек", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colLek1 = j;
                    }
                    if (string.Compare("Лаб", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colLab1 = j;
                    }
                    if (string.Compare("Пр", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colPra1 = j;
                    }
                }
                if (colLek1 >= 0 && colLab1 >= 0 && colPra1 >= 0)
                {
                    break;
                }
            }

            //Количество удаленных, для того чтобы не сбилось добавление
            int numDelete = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var con = dataTable.Rows[i][Sem1Beg].ToString().Trim();
                var lek = dataTable.Rows[i][colLek1].ToString().Trim();
                var lab = dataTable.Rows[i][colLab1].ToString().Trim();
                var pra = dataTable.Rows[i][colPra1].ToString().Trim();
                if ((con == null && lek == null && lab == null && pra == null) || (con.ToString() == "" && lek.ToString() == "" && lab.ToString() == "" && pra.ToString() == ""))
                {
                    tableSem1.Rows[i - numDelete].Delete();
                    numDelete++;
                    continue;
                }
                if (!int.TryParse(tableSem1.Rows[i - numDelete][0].ToString(), out int nen))
                {
                    tableSem1.Rows[i - numDelete].Delete();
                    numDelete++;
                    continue;
                }
                tableSem1.Rows[i - numDelete]["Контроль"] = con;
                tableSem1.Rows[i - numDelete]["Лекции"] = lek;
                tableSem1.Rows[i - numDelete]["Лабораторные"] = lab;
                tableSem1.Rows[i - numDelete]["Практические"] = pra;
            }



            tableSem2 = tableGeneral.Copy();
            tableSem2.TableName = "Семестер 2";
            DataColumn columnSem2;
            DataRow rowSem2;
            columnSem2 = new DataColumn();
            columnSem2.DataType = System.Type.GetType("System.String");
            columnSem2.ColumnName = "Контроль";
            tableSem2.Columns.Add(columnSem2);
            columnSem2 = new DataColumn();
            columnSem2.DataType = System.Type.GetType("System.String");
            columnSem2.ColumnName = "Лекции";
            tableSem2.Columns.Add(columnSem2);
            columnSem2 = new DataColumn();
            columnSem2.DataType = System.Type.GetType("System.String");
            columnSem2.ColumnName = "Лабораторные";
            tableSem2.Columns.Add(columnSem2);
            columnSem2 = new DataColumn();
            columnSem2.DataType = System.Type.GetType("System.String");
            columnSem2.ColumnName = "Практические";
            tableSem2.Columns.Add(columnSem2);
            int colLek2 = -1;
            int colLab2 = -1;
            int colPra2 = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = Sem2Beg; j < Sem2End+1; j++)
                {
                    var kpop = dataTable.Rows[i][j].ToString();
                    if (dataTable.Rows[i][j] == null || kpop == "")
                    {
                        continue;
                    }

                    if (string.Compare("Лек", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colLek2 = j;
                    }
                    if (string.Compare("Лаб", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colLab2 = j;
                    }
                    if (string.Compare("Пр", dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        colPra2 = j;
                    }
                }
                if (colLek2 >= 0 && colLab2 >= 0 && colPra2 >= 0)
                {
                    break;
                }
            }

            //Количество удаленных, для того чтобы не сбилось добавление
            numDelete = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var con = dataTable.Rows[i][Sem2Beg].ToString().Trim();
                var lek = dataTable.Rows[i][colLek2].ToString().Trim();
                var lab = dataTable.Rows[i][colLab2].ToString().Trim();
                var pra = dataTable.Rows[i][colPra2].ToString().Trim();
                if ((con == null && lek == null && lab == null && pra == null) || (con.ToString() == "" && lek.ToString() == "" && lab.ToString() == "" && pra.ToString() == ""))
                {
                    tableSem2.Rows[i - numDelete].Delete();
                    numDelete++;
                    continue;
                }
                if (!int.TryParse(tableSem2.Rows[i - numDelete][0].ToString(), out int nen))
                {
                    tableSem2.Rows[i - numDelete].Delete();
                    numDelete++;
                    continue;
                }
                tableSem2.Rows[i - numDelete]["Контроль"] = con;
                tableSem2.Rows[i - numDelete]["Лекции"] = lek;
                tableSem2.Rows[i - numDelete]["Лабораторные"] = lab;
                tableSem2.Rows[i - numDelete]["Практические"] = pra;
            }
        }
    }
}
