using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases.Models
{
    public static class Connexion
    {
        static SqlConnection connection = null;
        static string conecctionstring = "Data Source=DESKTOP-IJ864J6\\SQLEXPRESS;Initial Catalog=GPRS; Integrated Security=true;";

        public static SqlConnection Connect()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(conecctionstring);
                }
                else
                {
                    CloseConnection();
                    connection = new SqlConnection(conecctionstring);
                }

                return connection;
            }
            catch (SqlException se)
            {
                Console.WriteLine("No Conectado "+se.Message.ToString());
                return connection;
            }
        }

        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                
            }
        }

        
    }
}
