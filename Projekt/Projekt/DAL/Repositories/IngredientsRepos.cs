using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class IngredientsRepos
    {
        private const string ALL_INGREDIENTS_QUERY = "SELECT * FROM Ingredients";

        public static List<Ingredients> GetAllIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            try
            {
                using var connection = DBConnection.Instance.Connection;
                MySqlCommand command = new MySqlCommand(ALL_INGREDIENTS_QUERY, connection);
                connection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    ingredients.Add(new Ingredients(dataReader));
                connection.Close();
            }
            catch
            {

            }
            return ingredients;
        }
    }
}