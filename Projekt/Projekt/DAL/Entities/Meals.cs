using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    public class Meals
    {
        public int? ID { get; set; }
        public string? Name { get; private set; }
        public double? Weight { get; private set; }
        public double? Kcal { get; private set; }
        public double? Protein { get; private set; }
        public double? Fat { get; private set; } 
        public double? Carbs { get; private set; } 
        public string? DietType { get; private set; }

        public Meals(MySqlDataReader reader)
        {
            ID       = int.Parse(reader["id"].ToString());
            Name     = reader["name"].ToString();
            Weight   = double.Parse(reader["weight"].ToString());
            Kcal     = double.Parse(reader["kcal"].ToString());
            Protein  = double.Parse(reader["protein"].ToString());
            Fat      = double.Parse(reader["fat"].ToString());
            Carbs    = double.Parse(reader["carbs"].ToString());
            DietType = reader["diettype"].ToString();

            if (DietType == "0")
                DietType = Properties.Resources.normal;
            if (DietType == "1")
                DietType = Properties.Resources.vegetarian;
            if (DietType == "2")
                DietType = Properties.Resources.vegan;
        }

        public Meals(string name, double weight, double kcal,
                     double protein, double fat, double carbs, string type)
        {
            ID = null;
            Name = name.Trim();
            Weight = weight;
            Kcal = kcal;
            Protein = protein;
            Fat = fat;
            Carbs = carbs;
            DietType = type;
        }

        public Meals(string name)
        {
            ID = null;
            Name = name.Trim();
        }

        public Meals(Meals meals)
        {
            ID = meals.ID;
            Weight = meals.Weight;
            Name = meals.Name;
            Kcal = meals.Kcal;
            Protein = meals.Protein;
            Fat = meals.Fat;
            Carbs = meals.Carbs;
            DietType = meals.DietType;
        }

        public string ToInsert()
        {
            var weight = Weight.ToString().Replace(',', '.');
            var kcal = Kcal.ToString().Replace(',', '.');
            var protein = Protein.ToString().Replace(',', '.');
            var fat = Fat.ToString().Replace(',', '.');
            var carbs = Carbs.ToString().Replace(',', '.');
            return $"('{ID}', '{Name}', '{weight}', '{kcal}', '{protein}', '{fat}', '{carbs}', '{DietType}')";
        }

        public string ToInsertOnlyName()
        {
            return $"('{ID}', '{Name}')";
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Weight}, {Kcal}, {Protein}, {Fat}, {Carbs}, {DietType}";
        }
    }
}