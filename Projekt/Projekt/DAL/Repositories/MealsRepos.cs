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

        public static bool Update(Entities.Meals meals, int? id)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                var kcal = meals.Kcal.ToString().Replace(',', '.');
                var protein = meals.Protein.ToString().Replace(',', '.');
                var fat = meals.Fat.ToString().Replace(',', '.');
                var carbs = meals.Carbs.ToString().Replace(',', '.');
                var weight = meals.Weight.ToString().Replace(',', '.');

                MySqlCommand command = new MySqlCommand($"UPDATE Meals SET WEIGHT={weight}, " +
                    $"KCAL={kcal}, PROTEIN={protein}, FAT={fat}, CARBS={carbs}, " +
                    $"DIETTYPE='{meals.DietType}' WHERE ID={id}", connection);
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