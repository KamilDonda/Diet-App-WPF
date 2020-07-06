using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    public class MealsRepos
    {
        private const string GET_ALL = "SELECT * FROM MEALS";
        private const string INSERT = "INSERT INTO Meals VALUES ";

        public static List<Entities.Meals> GetAll()
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

        public static bool Insert(Entities.Meals meals)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {meals.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                condition = true;
                meals.ID = (int)command.LastInsertedId;
                connection.Close();
            }
            return condition;
        }
    }
}