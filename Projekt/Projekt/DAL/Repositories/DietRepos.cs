using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class DietRepos
    {
        private const string GET_ALL = "SELECT * FROM DIET";
        private const string INSERT = "REPLACE INTO DIET VALUES ";

        public static List<Entities.Diet> GetAll()
        {
            List<Entities.Diet> diet = new List<Entities.Diet>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    diet.Add(new Entities.Diet(reader));
                connection.Close();
            }
            return diet;
        }

        public static bool Insert(Entities.Diet diet)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {diet.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                condition = true;
                diet.ID = (int)command.LastInsertedId;
                connection.Close();
            }
            return condition;
        }

        public static bool Delete(string login)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM DIET WHERE LOGIN='{login}'", connection);
                connection.Open();

                var n = command.ExecuteNonQuery();
                if (n == 1)
                    condition = true;

                connection.Close();
            }
            return condition;
        }
    }
}
