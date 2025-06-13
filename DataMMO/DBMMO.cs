using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClassLibrary1;
using DataLayer;

namespace DataMMO
{
    public class DBMMO : DLMMO
    {
        private static string connectionString = "Data Source=localhost; Initial Catalog=MMO; Integrated Security=True;";
        private static SqlConnection sqlConnection;

        public DBMMO()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void RegisterGuest(Guest guest)
        {
            string query = "INSERT INTO Guests (Name, Role, TimeIn) VALUES (@Name, @Role, @TimeIn)";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", guest.Name);
                command.Parameters.AddWithValue("@Role", guest.Role);
                command.Parameters.AddWithValue("@TimeIn", guest.TimeIn);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void ExitGuest(Guest guest)
        {
            string query = "UPDATE Guests SET TimeOut = @TimeOut WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", guest.Name);
                command.Parameters.AddWithValue("@TimeOut", guest.TimeOut);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Guest> GetAllGuests()
        {
            List<Guest> guests = new List<Guest>();
            string query = "SELECT * FROM Guests";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest

                        {
                            Name = reader["Name"].ToString(),
                            Role = reader["Role"].ToString(),
                            TimeIn = Convert.ToDateTime(reader["TimeIn"]),
                            TimeOut = reader["TimeOut"] != DBNull.Value ? Convert.ToDateTime(reader["TimeOut"]) : (DateTime?)null
                        };
                        guests.Add(guest);
                    }
                }
                sqlConnection.Close();
            }

            return guests;
        }
    }
}
