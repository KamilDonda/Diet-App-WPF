using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    public class IngredientsWithWeight
    {
        public int? ID          { get; set; }
        public string Name      { get; set; }
        public double Kcal      { get; set; }
        public double Protein   { get; set; }
        public double Fat       { get; set; }
        public double Carbs     { get; set; }
        public string Type      { get; set; }
        public double Weight    { get; set; }

        public IngredientsWithWeight(MySqlDataReader reader)
        {
            ID = int.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
            Kcal = double.Parse(reader["kcal"].ToString());
            Protein = double.Parse(reader["protein"].ToString());
            Fat = double.Parse(reader["fat"].ToString());
            Carbs = double.Parse(reader["carbs"].ToString());
            Type = reader["type"].ToString();
            Weight = double.Parse(reader["weight"].ToString());

            if (Type == "0")
                Type = Properties.Resources.normal;
            if (Type == "1")
                Type = Properties.Resources.vegetarian;
            if (Type == "2")
                Type = Properties.Resources.vegan;
        }

        public IngredientsWithWeight(string name, double kcal, double protein,
                           double fat, double carbs, string type, double weight)
        {
            ID = null;
            Name = name.Trim();
            Kcal = kcal;
            Protein = protein;
            Fat = fat;
            Carbs = carbs;
            Type = type;
            Weight = weight;
        }

        public IngredientsWithWeight(IngredientsWithWeight ingredients)
        {
            ID = ingredients.ID;
            Name = ingredients.Name;
            Kcal = ingredients.Kcal;
            Protein = ingredients.Protein;
            Fat = ingredients.Fat;
            Carbs = ingredients.Carbs;
            Type = ingredients.Type;
            Weight = ingredients.Weight;
        }

        public string ToInsert()
        {
            var kcal = Kcal.ToString().Replace(',', '.');
            var protein = Protein.ToString().Replace(',', '.');
            var fat = Fat.ToString().Replace(',', '.');
            var carbs = Carbs.ToString().Replace(',', '.');
            var weight = Weight.ToString().Replace(',', '.');
            return $"('{ID}', '{Name}', '{kcal}', '{protein}', '{fat}', '{carbs}', '{Type}', {weight})";
        }

    }
}
