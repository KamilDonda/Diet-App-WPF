using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class DietRepos
    {
        private const string GET_ALL = "SELECT * FROM DIET";

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
    }
}
