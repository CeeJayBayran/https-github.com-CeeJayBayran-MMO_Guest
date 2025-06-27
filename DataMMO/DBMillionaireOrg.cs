using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ClassLibrary1;

namespace DataMMO.DataLayer
{
    public class DBMillionaireOrg : IMMO
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-P50D8E4\\SQLEXPRESS;Initial Catalog=MillionairesDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool Register(string name, string role)
        {
            

            string query = "INSERT INTO  Members (Name, Role, TimeIn) VALUES (@Name, @Role, @TimeIn)";
            using SqlConnection conn = new(connectionString);
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@TimeIn", DateTime.Now);

            return cmd.ExecuteNonQuery() > 0;
        }


        public bool ExitGuest(string name)
        {
            string query = "UPDATE Members SET TimeOut = @TimeOut WHERE Name = @Name AND TimeOut IS NULL";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@TimeOut", DateTime.Now);

                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<Guest> GetAllGuests()
        {
            List<Guest> guests = new List<Guest>();
            string query = "SELECT * FROM Members WHERE TimeOut IS NULL";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        guests.Add(new Guest
                        {
                            Name = reader["Name"].ToString(),
                            Role = reader["Role"].ToString(),
                            TimeIn = Convert.ToDateTime(reader["TimeIn"]),
                            TimeOut = reader["TimeOut"] != DBNull.Value ? Convert.ToDateTime(reader["TimeOut"]) : (DateTime?)null
                 });
                 }
                }
            }

            return guests;
        }

        public Guest SearchGuest(string name)
        {
            string query = "SELECT * FROM Members WHERE Name = @Name AND TimeOut IS NULL";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", name);

                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Guest
                        {
                            Name = reader["Name"].ToString(),
                            Role = reader["Role"].ToString(),
                            TimeIn = Convert.ToDateTime(reader["TimeIn"]),
                            TimeOut = reader["TimeOut"] != DBNull.Value ? Convert.ToDateTime(reader["TimeOut"]) : (DateTime?)null
                        };
                            }
                }
            }
            return null;
        }

        public bool Exists(string name)
        {
            string query = "SELECT COUNT(*) FROM Members WHERE Name = @Name AND TimeOut IS NULL";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", name);

                sqlConnection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
