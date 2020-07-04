using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Ingredients
    {
        public int? ID { get; set; }
        public string Name { get; private set; }
        public double Kcal { get; private set; }
        public double Protein { get; private set; }
        public double Fat { get; private set; }
        public double Carbs { get; private set; }
        public string Type { get; private set; }


        public Ingredients(MySqlDataReader reader)
        {
            ID = int.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
            Kcal = double.Parse(reader["kcal"].ToString());
            Protein = double.Parse(reader["protein"].ToString());
            Fat = double.Parse(reader["fat"].ToString());
            Carbs = double.Parse(reader["carbs"].ToString());
            Type = reader["type"].ToString();
        }

        public Ingredients(string name, double kcal, double protein,
                           double fat, double carbs, string type)
        {
            ID = null;
            Name = name.Trim();
            Kcal = kcal;
            Protein = protein;
            Fat = fat;
            Carbs = carbs;
            Type = type;
        }

        public Ingredients(Ingredients ingredients)
        {
            ID = ingredients.ID;
            Name = ingredients.Name;
            Kcal = ingredients.Kcal;
            Protein = ingredients.Protein;
            Fat = ingredients.Fat;
            Carbs = ingredients.Carbs;
            Type = ingredients.Type;
        }

        public string ToInsert()
        {
            return $"('{ID}', '{Name}', '{Kcal}', '{Protein}', '{Fat}', '{Carbs}', '{Type}')";
        }
    } 
}