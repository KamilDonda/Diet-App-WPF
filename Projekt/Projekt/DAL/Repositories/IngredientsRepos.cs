using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class IngredientsRepos
    {
        private const string ALL_INGREDIENTS = "SELECT * FROM Ingredients";

        public static List<Entities.Ingredients> GetAllIngredients()
        {
            List<Entities.Ingredients> ingredients = new List<Entities.Ingredients>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_INGREDIENTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    ingredients.Add(new Ingredients(reader));
                connection.Close();
            }
            return ingredients;
        }
    }
}