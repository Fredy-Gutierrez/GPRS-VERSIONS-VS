using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases.Models
{
    public class UdpServerMessagesModel
    {
        public bool InsertMessage(string name, string message, string ip, string date, string hour, string type)
        {
            using (SqlConnection connection = Connexion.Connect())
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand
                    {
                        CommandText = "Insert into udpservermessages (name,message,ip,date,hour,type) values('" + name + "','" + message + "','" + ip + "','" + date + "','" + hour + "','" + type + "');" +
                        "DELETE FROM udpservermessages WHERE id NOT IN (SELECT TOP(select case when count(id) > 12000 then 12000 else count(id) end as countid from udpservermessages)id FROM udpservermessages ORDER BY id DESC);",
                        
                        Connection = connection
                    };

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

        public DataTable readMessages(string name, string type)
        {
            DataTable t = new DataTable();
            using (SqlConnection connection = Connexion.Connect())
            {
                try
                {
                    connection.Open();
                    string consulta = " select * from udpservermessages where  type like '" + type + "' and name like '" + name + "' and id not in (select top((select case when count(*)>50 then count(*)-50 else 0 end as countid from udpservermessages where type like '" + type + "' and name like '" + name + "')) id from udpservermessages where type like '" + type + "' and name like '" + name + "')";

                    SqlCommand command = new SqlCommand(consulta, connection);
                    
                    SqlDataAdapter a = new SqlDataAdapter(command);
                    
                    a.Fill(t);
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return t;
        }
    }
}
