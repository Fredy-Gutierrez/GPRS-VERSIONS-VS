﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases.Models
{
    public class TcpServerMessagesModel
    {

        public Boolean InsertMessage(string name, string message, string ip, string date, string hour, string type)
        {
            using (SqlConnection connection = Connexion.Connect())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into tcpservermessages (name,message,ip,date,hour,type) values('" + name + "','" + message + "','" + ip + "','" + date + "','" + hour + "','" + type + "');" +
                        "DELETE FROM tcpservermessages WHERE id NOT IN (SELECT TOP(select case when count(id) > 12000 then 12000 else count(id) end as countid from tcpservermessages)id FROM tcpservermessages ORDER BY id DESC);"
                        ;

                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    /*try
                    {

                        command.CommandText = "DELETE FROM tcpservermessages WHERE id NOT IN (SELECT TOP(select case when count(id) > 12000 then 12000 else count(id) end as countid from tcpservermessages)id FROM tcpservermessages ORDER BY id DESC)";
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException se)
                    {
                        Console.WriteLine(se.Message.ToString());
                    }*/

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

        public DataTable readMessages(string name, string type,string msg)
        {
            DataTable t = new DataTable();
            using (SqlConnection connection = Connexion.Connect())
            {
                try
                {
                    connection.Open();

                    string consulta = " select * from tcpservermessages where  type like '" + type + "' and name like '" + name + "' and id not in (select top((select case when count(*)>50 then count(*)-50 else 0 end as countid from tcpservermessages where type like '" + type + "' and name like '" + name + "')) id from tcpservermessages where type like '" + type + "' and name like '" + name + "')";

                    SqlCommand command = new SqlCommand(consulta, connection);
                    /*SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        if (msg.Equals(""))
                        {
                            msg = dr[2].ToString() + " " + dr[3].ToString() + ": " + dr[1].ToString() + "    [" + dr[4].ToString() + "   " + dr[5].ToString() + "]";
                        }
                        else
                        {
                            msg += "\n" + dr[2].ToString() + " " + dr[3].ToString() + ": " + dr[1].ToString() + "    [" + dr[4].ToString() + "   " + dr[5].ToString() + "]";
                        }
                    }
                    dr.Close();*/

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
