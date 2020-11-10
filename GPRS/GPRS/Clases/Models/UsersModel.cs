using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases.Models
{
    public class UsersModel
    {
        private SqlConnection sqlConnection;
        //command.CommandText = "Insert into users (name,email,username,password) values('" + name + "','" + email + "','" + user + "','" + pass + "')";
        public Boolean InsertUser(string name, string email, string user, string pass)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                sqlConnection = Connexion.Connect();
                command.Connection = sqlConnection;

                command.CommandType = CommandType.Text;
                command.CommandText = "Insert into users (name,email,username,password) values(@name,@email,@user,@pass)";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@user",user);
                command.Parameters.AddWithValue("@pass",pass);

                sqlConnection.Open();
                command.ExecuteNonQuery();

                command.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message.ToString());
                return false;
            }

        }

        public bool LogIn(string username, string password)
        {
            bool sesion = false;
            try
            {
                sqlConnection = Connexion.Connect();
                sqlConnection.Open();

                SqlParameter user = new SqlParameter("@username",username);
                SqlParameter pass = new SqlParameter("@password",password);

                string consulta = "select * from users where username like @username and password like @password";

                SqlCommand command = new SqlCommand(consulta, sqlConnection);
                command.Parameters.Add(user);
                command.Parameters.Add(pass);

                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    sesion = true;
                }

                dr.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Excepcion Sql producida: " + se.Message.ToString());
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return sesion;
        }

        public DataTable getAllUsers()
        {
            DataTable dataTable = new DataTable();
            try
            {
                sqlConnection = Connexion.Connect();

                string consulta = "select id, name, username from users";
                SqlCommand command = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dataTable);

                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Excepcion Sql producida: " + se.Message.ToString());
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return dataTable;
        }

        public bool deleteUser(string id)
        {
            bool deleted = false;
            sqlConnection = Connexion.Connect();
            sqlConnection.Open();

            string consulta = "delete from users where id = @id";

            SqlCommand command = new SqlCommand(consulta, sqlConnection);


            command.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(id);


            int x = command.ExecuteNonQuery();

            if (x>0)
            {
                deleted = true;
            }

            sqlConnection.Close();
            sqlConnection.Dispose();

            return deleted;
        }

        public bool FindUser(string username)
        {
            bool sesion = false;
            try
            {
                sqlConnection = Connexion.Connect();
                sqlConnection.Open();

                SqlParameter user = new SqlParameter("@username", username);

                string consulta = "select * from users where username like @username";

                SqlCommand command = new SqlCommand(consulta, sqlConnection);
                command.Parameters.Add(user);

                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    sesion = true;
                }

                dr.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Excepcion Sql producida: " + se.Message.ToString());
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return sesion;
        }

        public bool UpdateUser(string id, string name, string email, string password)
        {
            bool sesion = false;
            try
            {
                sqlConnection = Connexion.Connect();
                sqlConnection.Open();

                string consulta = "update users set name = @name , email = @email, password = @password where id = @id";

                SqlCommand command = new SqlCommand(consulta, sqlConnection);
                command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                command.Parameters.AddWithValue("@name",name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                //command

                int x = command.ExecuteNonQuery();

                if (x>0)
                {
                    sesion = true;
                }

                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Excepcion Sql producida: " + se.Message.ToString());
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return sesion;
        }

        public bool getSesionUser(string username)
        {
            bool sesion = false;
            try
            {
                sqlConnection = Connexion.Connect();
                sqlConnection.Open();

                SqlParameter user = new SqlParameter("@username", username);

                string consulta = "select * from users where username like @username";

                SqlCommand command = new SqlCommand(consulta, sqlConnection);
                command.Parameters.Add(user);

                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    sesion = true;
                    while (dr.Read())
                    {
                        Session.id = Int32.Parse(dr[0].ToString());
                        Session.name = dr[1].ToString();
                        Session.email = dr[2].ToString();
                        Session.user = dr[3].ToString();
                    }
                }

                dr.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Excepcion Sql producida: " + se.Message.ToString());
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return sesion;
        }
    }
}
