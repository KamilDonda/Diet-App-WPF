using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Projekt.DAL.Repositories
{
    public class MealsRepos
    {
        private const string GET_ALL = "SELECT * FROM MEALS";
        private const string INSERT = "INSERT INTO MEALS VALUES ";

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

        public static List<Entities.Meals> GetByLogin(string login)
        {
            List<Entities.Meals> meals = new List<Entities.Meals>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"SELECT M.* " +
                    $"FROM MEALS M, DIET D " +
                    $"WHERE D.LOGIN = '{login}' AND D.ID_MEALS = M.ID", connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    meals.Add(new Entities.Meals(reader));
                connection.Close();
            }
            return meals;
        }

        public static void UpdateMeals()
        {
            var mealsRepos = GetAll();

            foreach (var meal in mealsRepos)
            {
                var ingredientsRepos = IngredientsRepos.GetByID(meal.ID.Value);

                int n = ingredientsRepos.Count;

                int? ID = meal.ID;
                string Name = meal.Name;
                double Kcal = 0;
                double Prot = 0;
                double Fat = 0;
                double Carbs = 0;
                double Weight = 0;
                var Type = new int[n];

                for (int j = 0; j < n; j++)
                {
                    var weight = ingredientsRepos[j].Weight;

                    Kcal += ingredientsRepos[j].Kcal * weight * 0.01;
                    Prot += ingredientsRepos[j].Protein * weight * 0.01;
                    Fat += ingredientsRepos[j].Fat * weight * 0.01;
                    Carbs += ingredientsRepos[j].Carbs * weight * 0.01;
                    Weight += ingredientsRepos[j].Weight;

                    var t = ingredientsRepos[j].Type;

                    if (t == Projekt.Properties.Resources.normal)
                        Type[j] = 0;
                    if (t == Projekt.Properties.Resources.vegetarian)
                        Type[j] = 1;
                    if (t == Projekt.Properties.Resources.vegan)
                        Type[j] = 2;
                }
                var type = Type.Min().ToString();

                var newMeal = new Entities.Meals(Name, Weight, Kcal, Prot, Fat, Carbs, type);

                Update(newMeal, ID);
            }
        }
    }
}