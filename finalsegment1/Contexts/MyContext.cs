using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsegment1.Contexts
{
    public class MyContext
    {
        private static SqlConnection connection;

        private static string connectionString = "Data Source=ARUMNOTEBOOK;Initial Catalog = db_penjualan; Integrated Security = True; Connect Timeout = 30";
           
        public static SqlConnection GetConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }
    }

}
