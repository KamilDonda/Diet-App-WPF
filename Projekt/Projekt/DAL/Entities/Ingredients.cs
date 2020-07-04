using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Ingredients
    {
        public int ID           { get; private set; }
        public string Name      { get; private set; }
        public double Kcal      { get; private set; }
        public double Protein   { get; private set; }
        public double Fat       { get; private set; }
        public double Carbs     { get; private set; }
        public uint Type        { get; private set; }


        public Ingredients(MySqlDataReader reader)
        {
            ID      = int.Parse(reader["id"].ToString());
            Name    = reader["name"].ToString();
            Kcal    = double.Parse(reader["kcal"].ToString());
            Protein = double.Parse(reader["protein"].ToString());
            Fat     = double.Parse(reader["fat"].ToString());
            Carbs   = double.Parse(reader["carbs"].ToString());
            Type    = uint.Parse(reader["type"].ToString());
        }

        /*public override string ToString()
        {
            //return $"{ID} {Name} {Kcal} {Protein} {Fat} {Carbs} {Type}";
        }*/
    }
}