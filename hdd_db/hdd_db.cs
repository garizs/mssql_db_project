using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hdd_db
{
    class hdd_db
    {
        public static SqlConnection SqlCon = new SqlConnection("Server=localhost;Database=hdd_db;Trusted_Connection=True;");
        public static void openDB()
        {
            if (SqlCon.State == System.Data.ConnectionState.Closed)
                SqlCon.Open();
        }
        public static void closeDB()
        {
            if (SqlCon.State == System.Data.ConnectionState.Open)
                SqlCon.Close();
        }
    }
}
