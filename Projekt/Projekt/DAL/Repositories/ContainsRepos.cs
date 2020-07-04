using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class ContainsRepos
    {
        private const string CONTAINS = "SELECT * FROM CONTAINS";

        public static List<Entities.Contains> GetAllContainers()
        {
            List<Entities.Contains> contains = new List<Entities.Contains>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(CONTAINS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    contains.Add(new Entities.Contains(reader));
                connection.Close();
            }
            return contains;
        }
    }
}
