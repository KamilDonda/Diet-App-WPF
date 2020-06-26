using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Meals
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
        public int Weight
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
        public enum User
        {
            all, vegetarian, vegan
        }

        public Meals(MySqlDataReader mySqlDataReader)
        {
            ID = (int)mySqlDataReader["id"];
            Name = mySqlDataReader["name"].ToString();
            Weight = (int)mySqlDataReader["weight"];
            Kcal = (int)mySqlDataReader["kcal"];
            Protein = (int)mySqlDataReader["protein"];
            Fat = (int)mySqlDataReader["fat"];
            Carbs = (int)mySqlDataReader["carbs"];
            //User = mySqlDataReader["user"]; Nie wiem jak enuma tu zrobić
        }

        /*public override string ToString()
        {
            //return $"{ID} {Name} {Weight} {Kcal} {Protein} {Fat} {Carbs} {User}";
        }*/
    }
}