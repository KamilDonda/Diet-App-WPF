using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class IngredientsRepos
    {
        private const string GET_ALL = "SELECT * FROM Ingredients";
        private const string INSERT = "INSERT INTO Ingredients VALUES ";

        public static List<Entities.Ingredients> GetAllIngredients()
        {
            List<Entities.Ingredients> ingredients = new List<Entities.Ingredients>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    ingredients.Add(new Ingredients(reader));
                connection.Close();
            }
            return ingredients;
        }

        public static bool Insert(Ingredients ingredients)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {ingredients.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                condition = true;
                ingredients.ID = (int)command.LastInsertedId;
                connection.Close();
            }
            return condition;
        }
    }
}