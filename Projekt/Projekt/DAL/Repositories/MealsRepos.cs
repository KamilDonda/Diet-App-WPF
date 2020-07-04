using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class MealsRepos
    {
        private const string GET_ALL = "SELECT * FROM MEALS";

        public static List<Entities.Meals> GetAllMeals()
        {
            List<Entities.Meals> meals = new List<Entities.Meals>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    meals.Add(new Entities.Meals(reader));
                connection.Close();
            }
            return meals;
        }
    }
}