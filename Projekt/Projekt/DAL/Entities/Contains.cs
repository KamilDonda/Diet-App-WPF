using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    public class Contains
    {
        public int? ID { get; set; }
        public int ID_Meals { get; private set; }
        public int ID_Ingredients { get; private set; }
        public double Weight { get; private set; }

        public Contains(MySqlDataReader reader)
        {
            ID             = int.Parse(reader["id"].ToString());
            ID_Meals       = int.Parse(reader["id_meals"].ToString());
            ID_Ingredients = int.Parse(reader["id_ingredients"].ToString());
            Weight         = double.Parse(reader["weight"].ToString());
        }

        public Contains(int id_meals, int id_ingredients, double weight)
        {
            ID = null;
            ID_Meals = id_meals;
            ID_Ingredients = id_ingredients;
            Weight = weight;
        }

        public Contains(Contains contains)
        {
            ID = contains.ID;
            ID_Meals = contains.ID_Meals;
            ID_Ingredients = contains.ID_Ingredients;
            Weight = contains.Weight;
        }

        public string ToInsert()
        {
            var weight = Weight.ToString().Replace(',', '.');
            return $"('{ID}', '{ID_Meals}', '{ID_Ingredients}', '{weight}')";
        }
    }
}
