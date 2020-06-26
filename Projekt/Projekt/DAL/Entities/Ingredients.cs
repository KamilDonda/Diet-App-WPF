using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Ingredients
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Kcal
        {
            get;
            set;
        }
        public int Protein
        {
            get;
            set;
        }
        public int Fat
        {
            get;
            set;
        }
        public int Carbs
        {
            get;
            set;
        }
        public enum Type
        {
            dessert, meat, dairy_products, nuts, breads, spices, fish, seafood, candies
        }

        public Ingredients(MySqlDataReader mySqlDataReader)
        {
            ID = (int)mySqlDataReader["id"];
            Name = mySqlDataReader["name"].ToString();
            Kcal = (int)mySqlDataReader["kcal"];
            Protein = (int)mySqlDataReader["protein"];
            Fat = (int)mySqlDataReader["fat"];
            Carbs = (int)mySqlDataReader["carbs"];
            //Type = mySqlDataReader["type"]; Nie wiem jak enuma tu zrobić
        }

        /*public override string ToString()
        {
            //return $"{ID} {Name} {Kcal} {Protein} {Fat} {Carbs} {Type}";
        }*/
    }
}