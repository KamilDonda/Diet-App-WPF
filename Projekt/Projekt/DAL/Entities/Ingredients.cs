using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    public class Ingredients
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

            if (Type == "0")
                Type = Properties.Resources.normal;
            if (Type == "1")
                Type = Properties.Resources.vegetarian;
            if (Type == "2")
                Type = Properties.Resources.vegan;
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
            var kcal = Kcal.ToString().Replace(',', '.');
            var protein = Protein.ToString().Replace(',','.');
            var fat = Fat.ToString().Replace(',', '.');
            var carbs = Carbs.ToString().Replace(',', '.');
            return $"('{ID}', '{Name}', '{kcal}', '{protein}', '{fat}', '{carbs}', '{Type}')";
        }

        public override string ToString()
        {
            return $"'{ID}', '{Name}', '{Kcal}', '{Protein}', '{Fat}', '{Carbs}', '{Type}'";
        }
    } 
}