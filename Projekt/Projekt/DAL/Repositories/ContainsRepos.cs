using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    public class ContainsRepos
    {
        private const string GET_ALL = "SELECT * FROM CONTAINS";
        private const string INSERT = "INSERT INTO Contains VALUES ";

        public static List<Entities.Contains> GetAll()
        {
            List<Entities.Contains> contains = new List<Entities.Contains>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    contains.Add(new Entities.Contains(reader));
                connection.Close();
            }
            return contains;
        }

        public static bool Insert(Entities.Contains contains)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {contains.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                condition = true;
                contains.ID = (int)command.LastInsertedId;
                connection.Close();
            }
            return condition;
        }
    }
}
