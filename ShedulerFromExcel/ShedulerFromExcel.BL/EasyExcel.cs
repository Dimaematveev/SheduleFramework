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

        public void sta()
        {
            var filePath = "..\\..\\..\\ShedulerFromExcel.CMD\\Need\\09.03.02_АПиМОБИС_ИКБСП_2019.plx.xls";

            var kurs = new List<Kurs>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        var nameList = reader.Name;
                        Regex regex = new Regex(@"^Курс\d");
                        if (regex.IsMatch(nameList))
                        {
                            DataTable ListKurs = new DataTable("List");
                            DataColumn columnList;
                            DataRow rowList;
                            var row = reader.RowCount;
                            var col = reader.FieldCount;
                            for (int i = 0; i < col; i++)
                            {
                                columnList = new DataColumn();
                                columnList.DataType = System.Type.GetType("System.String");
                                columnList.ColumnName = "A" + (i + 1);
                                ListKurs.Columns.Add(columnList);
                            }


                            while (reader.Read())
                            {

                                rowList = ListKurs.NewRow();
                                for (int i = 0; i < col; i++)
                                {
                                    string str = "";
                                    if (reader.GetValue(i)!=null)
                                    {
                                        str = reader.GetValue(i).ToString().Trim();
                                    }
                                    rowList["A" + (i + 1)] = str;
                                }
                                ListKurs.Rows.Add(rowList);
                            }
                            kurs.Add(new Kurs(ListKurs,nameList));

                        }
                    } while (reader.NextResult());

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
