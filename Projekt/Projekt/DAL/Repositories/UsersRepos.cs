using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class UsersRepos
    {
        private const string GET_ALL = "SELECT * FROM USERS";

        public static List<Entities.Users> GetAllUsers()
        {
            List<Entities.Users> users = new List<Entities.Users>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
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
