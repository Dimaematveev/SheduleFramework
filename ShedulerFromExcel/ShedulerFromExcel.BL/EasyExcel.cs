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
    public class EasyExcel
    {

        public void Sta()
        {
            var filePath19 = "..\\..\\..\\ShedulerFromExcel.CMD\\Need\\09.03.02_АПиМОБИС_ИКБСП_2019.plx.xls";
            var filePath17 = "..\\..\\..\\ShedulerFromExcel.CMD\\Need\\09.03.02_АПиМОБИС_ИКБСП_2017.plm.xml.xls";

            var filePath = filePath19;
            var kurs = new List<Kurs>();
            //Сюда сохраняем все листы
            List< DataTable> AllList = new List<DataTable>();
            
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int numList = 0;
                    do
                    {

                        var nameList = reader.Name;
                        AllList.Add(new DataTable(nameList));
                       
                        DataColumn columnList;
                        DataRow rowList;
                        var row = reader.RowCount;
                        var col = reader.FieldCount;
                        for (int i = 0; i < col; i++)
                        {
                            columnList = new DataColumn
                            {
                                DataType = System.Type.GetType("System.String"),
                                ColumnName = "A" + (i + 1)
                            };
                            AllList[numList].Columns.Add(columnList);
                        }


                        while (reader.Read())
                        {

                            rowList = AllList[numList].NewRow();
                            for (int i = 0; i < col; i++)
                            {
                                string str = "";
                                if (reader.GetValue(i)!=null)
                                {
                                    str = reader.GetValue(i).ToString().Trim();
                                }
                                rowList["A" + (i + 1)] = str;
                            }
                            AllList[numList].Rows.Add(rowList);
                        }
                        numList++;
                    } while (reader.NextResult());
                }
            }
            //Для листов курс*
            Regex regex = new Regex(@"^Курс\d");
            foreach (var item in AllList)
            {
                if (regex.IsMatch(item.TableName))
                {
                    kurs.Add(new Kurs(item, item.TableName));

                }
            }

            //Для листов Титул
            regex = new Regex(@"^Титул");
            Title title;
            foreach (var item in AllList)
            {
                if (regex.IsMatch(item.TableName))
                {
                    title= new Title(item, filePath.Split('\\').Last());

                }
            }


            foreach (var item in kurs)
            {
                item.ConsoleOutSemester1();
                Console.WriteLine();
                item.ConsoleOutSemester2();

            }
        }
    }
}
