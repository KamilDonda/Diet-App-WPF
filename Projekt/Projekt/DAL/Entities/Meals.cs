using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Meals
    {
        public int ID           { get; private set; }
        public string Name      { get; private set; }
        public double Weight    { get; private set; }
        public double Kcal      { get; private set; }
        public double Protein   { get; private set; }
        public double Fat       { get; private set; }
        public double Carbs     { get; private set; }
        public uint DietType    { get; private set; }

        public Meals(MySqlDataReader reader)
        {
            ID       = int.Parse(reader["id"].ToString());
            Name     = reader["name"].ToString();
            Weight   = double.Parse(reader["weight"].ToString());
            Kcal     = double.Parse(reader["kcal"].ToString());
            Protein  = double.Parse(reader["protein"].ToString());
            Fat      = double.Parse(reader["fat"].ToString());
            Carbs    = double.Parse(reader["carbs"].ToString());
            DietType = uint.Parse(reader["diettype"].ToString());
        }

        /*public override string ToString()
        {
            //return $"{ID} {Name} {Weight} {Kcal} {Protein} {Fat} {Carbs} {User}";
        }*/
    }
}