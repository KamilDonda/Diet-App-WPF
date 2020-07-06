using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    public class IngredientsRepos
    {
        private const string GET_ALL = "SELECT * FROM Ingredients";
        private const string INSERT = "INSERT INTO Ingredients VALUES ";

        public static List<Entities.Ingredients> GetAll()
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

        public static List<Entities.IngredientsWithWeight> GetByID(int id)
        {
            List<Entities.IngredientsWithWeight> ingredients = new List<Entities.IngredientsWithWeight>();

            using (var connection = DBConnection.Instance.Connection)
            {
                //MySqlCommand command = new MySqlCommand($"SELECT * FROM INGREDIENTS WHERE ID IN " +
                //    $"(SELECT ID_INGREDIENTS FROM CONTAINS WHERE ID_MEALS = {id})", connection);

                MySqlCommand command = new MySqlCommand($"SELECT I.*, C.WEIGHT " +
                    $"FROM INGREDIENTS I, MEALS M, CONTAINS C " +
                    $"WHERE M.ID = {id} AND C.ID_MEALS = M.ID AND C.ID_INGREDIENTS = I.ID", connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    ingredients.Add(new IngredientsWithWeight(reader));
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