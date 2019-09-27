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
        public string Potok { get; private set; }
        public int YearBegin { get; private set; }
        public Title(DataTable ListKurs)
        {
            GetPotok(ListKurs);
        }


        private void GetPotok(DataTable dataTable)
        {

        }
    }
}
