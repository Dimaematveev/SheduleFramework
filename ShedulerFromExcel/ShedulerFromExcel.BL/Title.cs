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
        public string Potok { get; private set; } = null;
        public string YearBegin { get; private set; } = null;
        public string Napravl { get; private set; } = null;
        public string Profil { get; private set; } = null;
        public string Kafedra { get; private set; } = null;

        public Title(DataTable ListKurs, string nameFile)
        {


            var infoFromNameTable = nameFile.Split('_');
            string Potok = infoFromNameTable[0];
            string Profil = infoFromNameTable[1];
            //Не знаю что это такое
            string NoSavvy = infoFromNameTable[2];
            string Year = infoFromNameTable[3].Split('.').First();

            GetPotok(ListKurs, Potok);
            GetYear(ListKurs, Year);
            GetNapravl(ListKurs);
            GetProfil(ListKurs);
            GetKafedra(ListKurs);
        }

        public Title()
        {
        }

        public void ConsoleOut()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Поток:{Potok}, \nГод начала: {YearBegin}, \nНаправление: {Napravl}, \nПрофиль: {Profil}, \nКафедра: {Kafedra}.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Получит поток из Титул ->из названия файла беру поток и пытаюсь его найти
        private void GetPotok(DataTable dataTable, string potok)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }

                    if (string.Compare(potok, dataTable.Rows[i][j].ToString(), true) == 0)
                    {
                        Potok = potok;

                        return;
                    }
                }
            }
        }
        //Получить строку и столбец с элементом
        private void GetRowColPoisk(DataTable dataTable, string poisk, out int row,out int col)
        {
            row = -1;
            col = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }

                    if (dataTable.Rows[i][j].ToString().Contains(poisk))
                    {
                        row = i;
                        col = j;

                        break;
                    }
                }
                if (row > 0 && col > 0)
                {
                    break;
                }
            }

        }
        //Получит год из Титул ->из названия файла беру год и сравниваю с тем что нашел по ""Год начала""
        private void GetYear(DataTable dataTable, string year)
        {
            GetRowColPoisk(dataTable, "Год начала", out int row, out int col);

            string Poisk = "";
            for (int j = col+1; j < dataTable.Columns.Count; j++)
            {
                if (dataTable.Rows[row][j] != null && dataTable.Rows[row][j].ToString()!="")
                {
                    Poisk = dataTable.Rows[row][j].ToString();
                    break;
                }

            }
            //Console.WriteLine($"Нашел {Poisk}  был {year}");
            if (Poisk == year)
            {
                YearBegin = Poisk;
            }
        }
        //Получит Направление из Титул -> Ищу строку содерж "Направление:"
        private void GetNapravl(DataTable dataTable)
        {
            GetRowColPoisk(dataTable, "Направление:", out int row, out int col);
           
            if (row!=-1 && col!=-1)
            {
                string Naiden = dataTable.Rows[row][col].ToString();
                Naiden = Naiden.Split('"')[1];
                Napravl = Naiden;
                //Console.WriteLine($"Нашел {Naiden}  ");
            }
            else
            {
                GetNapravlPotok(dataTable);
            }
        }
        //Получит Направление из Титул -> Ищу строку содерж поток
        private void GetNapravlPotok(DataTable dataTable)
        {
            
            string Naiden = "";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j] == null)
                    {
                        continue;
                    }

                    if (dataTable.Rows[i][j].ToString().Contains(Potok))
                    {
                        if (dataTable.Rows[i][j].ToString().Length> Potok.Length)
                        {
                            Naiden = dataTable.Rows[i][j].ToString();
                            break;
                        }
                        
                        
                    }
                }
                if (Naiden != "")
                {
                    break;
                }
            }

            if (Naiden != "")
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
        //Получит Профиль из Титул -> Ищу строку содерж "Профиль:"
        private void GetProfil(DataTable dataTable)
        {
            string Naiden = "";
            GetRowColPoisk(dataTable, "Профиль:", out int row, out int col);
            if (row>0 && col>0)
            {
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
            GetRowColPoisk(dataTable, "Профиль", out int row, out int col);
            string Poisk = "";
            for (int j = col + 1; j < dataTable.Columns.Count; j++)
            {
                if (dataTable.Rows[row][j] != null && dataTable.Rows[row][j].ToString() != "")
                {
                    Poisk = dataTable.Rows[row][j].ToString();
                    break;
                }

            }
            if (Poisk!="")
            {
                //Console.WriteLine($"Нашел {Poisk} ");
                Profil = Poisk;
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }


        //Получит Профиль из Титул -> Ищу строку содерж "Профиль:"
        private void GetKafedra(DataTable dataTable)
        {
            GetRowColPoisk(dataTable, "Кафедра:", out int row, out int col);
            
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

    }
}
