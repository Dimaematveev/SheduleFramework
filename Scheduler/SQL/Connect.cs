using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQL
{
    public class Connect : DbContext
    {
        public Connect()
        {
            BaseConnect();
        }
        public void BaseConnect()
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"(localdb)\MSSQLLocalDB; Initial Catalog = Shed; Persist Security Info = False;";

            SqlConnection conn = new SqlConnection(connString);
        }
    }
}
