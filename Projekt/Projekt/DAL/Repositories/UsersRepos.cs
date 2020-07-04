using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class UsersRepos
    {
        private const string ALL_USERS = "SELECT * FROM USERS";

        public static List<Entities.Users> GetAllUsers()
        {
            List<Entities.Users> users = new List<Entities.Users>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Entities.Users(reader));
                connection.Close();
            }
            return users;
        }
    }
}
