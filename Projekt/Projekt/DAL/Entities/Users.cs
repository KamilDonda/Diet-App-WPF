using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Users
    {
        public string Login   { get; private set; }
        public string Name    { get; private set; }
        public string Surname { get; private set; }
        public uint   Age     { get; private set; }
        public double Height  { get; private set; }
        public double Weight  { get; private set; }
        public uint   Goal    { get; private set; }
        public uint   Sex     { get; private set; }
        public uint   ActivityLevel { get; private set; }
        public double Kcal       { get; private set; }
        public uint   DietType   { get; private set; }
        public uint   MealsCount { get; private set; }
        public string Password   { get; private set; }

        public Users(MySqlDataReader reader)
        {
            Login          = reader["login"].ToString();
            Name           = reader["name"].ToString();
            Surname        = reader["surname"].ToString();
            Age            = uint.Parse(reader["age"].ToString());
            Height         = double.Parse(reader["height"].ToString());
            Weight         = double.Parse(reader["weight"].ToString());
            Goal           = uint.Parse(reader["goal"].ToString());
            Sex            = uint.Parse(reader["sex"].ToString());
            ActivityLevel  = uint.Parse(reader["activitylevel"].ToString());
            Kcal           = double.Parse(reader["kcal"].ToString());
            DietType       = uint.Parse(reader["diettype"].ToString());
            MealsCount     = uint.Parse(reader["mealscount"].ToString());
            Password       = reader["password"].ToString();
        }
    }
}
