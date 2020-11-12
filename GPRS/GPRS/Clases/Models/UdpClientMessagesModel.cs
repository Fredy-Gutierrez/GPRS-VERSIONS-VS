using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases.Models
{
    public class UdpClientMessagesModel
    {
        //private SqlConnection sqlConnection=null;
        /*sqlConnection = Connexion.Connect();
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "Insert into udpclientmessages (name,message,ip,date,hour,type) values('" + name + "','" + message + "','" + ip + "','" + date + "','" + hour + "','" + type + "')";
                
                command.Connection = sqlConnection;
                command.ExecuteNonQuery();
                sqlConnection.Close();*/
        public Boolean InsertMessage(string name,string message,string ip,string date,string hour,string type)
        {
            
            using (SqlConnection connection = Connexion.Connect())
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into udpclientmessages (name,message,ip,date,hour,type) values('" + name + "','" + message + "','" + ip + "','" + date + "','" + hour + "','" + type + "');" +
                        "DELETE FROM udpclientmessages WHERE id NOT IN (SELECT TOP(select case when count(id) > 12000 then 12000 else count(id) end as countid from udpclientmessages)id FROM udpclientmessages ORDER BY id DESC);";
                    command.Connection = connection;

                    command.ExecuteNonQuery();
                    
                    return true;
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se.Message.ToString());
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return false;
                }
            }
        }

        public DataTable readMessages(string name, string type, string msg)
        {
            DataTable t = new DataTable();
            
            using (SqlConnection connection = Connexion.Connect())
            {
                try
                {
                    connection.Open();

                    string consulta = "select * from udpclientmessages where  type like '" + type + "' and name like '" + name + "' and id not in (select top((select case when count(*)>50 then count(*)-50 else 0 end as countid from udpclientmessages where type like '" + type + "' and name like '" + name + "')) id from udpclientmessages where type like '" + type + "' and name like '" + name + "')";

                    SqlCommand command = new SqlCommand(consulta, connection);

                    SqlDataAdapter a = new SqlDataAdapter(command);

                    a.Fill(t);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

            }
            
            return t;
        }
        /*
        public void closeConnection()
        {
            if (sqlConnection != null)
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
                else
                {
                    sqlConnection = null;
                }
            }
        }*/
    }
}
