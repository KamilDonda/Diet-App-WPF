using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class DietRepos
    {
        private const string GET_ALL = "SELECT * FROM DIET";
        private const string INSERT = "INSERT INTO DIET VALUES ";

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

        public static bool Update(Entities.Diet diet)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"UPDATE DIET SET LOGIN={diet.Login}, " +
                    $"DAY={diet.Day}, ID_MEALS={diet.ID_Meal} WHERE ID={diet.ID}", connection);
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
