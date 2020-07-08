using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Users
    {
        public string Login    { get; private set; }
        public string? Name    { get; private set; }
        public string? Surname { get; private set; }
        public uint?   Age     { get; private set; }
        public double? Height  { get; private set; }
        public double? Weight  { get; private set; }
        public uint?   Goal    { get; private set; }
        public uint?   Sex     { get; private set; }
        public uint?   ActivityLevel { get; private set; }
        public double? Kcal       { get; private set; }
        public uint?   DietType   { get; private set; }
        public uint?   MealsCount { get; private set; }
        public string Password    { get; private set; }

        public Users(MySqlDataReader reader)
        {
            Login = reader["login"].ToString();
            Name = reader["name"].ToString();
            Surname = reader["surname"].ToString();
            Age = uint.Parse(reader["age"].ToString());
            Height = double.Parse(reader["height"].ToString());
            Weight = double.Parse(reader["weight"].ToString());
            Goal = uint.Parse(reader["goal"].ToString());
            Sex = uint.Parse(reader["sex"].ToString());
            ActivityLevel = uint.Parse(reader["activitylevel"].ToString());
            Kcal = double.Parse(reader["kcal"].ToString());
            DietType = uint.Parse(reader["diettype"].ToString());
            MealsCount = uint.Parse(reader["mealscount"].ToString());
            Password = reader["password"].ToString();
        }

        public Users(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public Users(string login, string name, string surname, uint age, double height, double weight,
            uint goal, uint sex, uint activitylevel, double kcal, uint diettype, uint mealscount)
        {
            Login = login;
            Name = name;
            Surname = surname;
            Age = age;
            Height = height;
            Weight = weight;
            Goal = goal;
            Sex = sex;
            ActivityLevel = activitylevel;
            Kcal = kcal;
            DietType = diettype;
            MealsCount = mealscount;
        }

        public Users(Users user)
        {
            Login = user.Login;
            Name = user.Name;
            Surname = user.Surname;
            Age = user.Age;           
            Height = user.Height;      
            Weight = user.Weight;       
            Goal = user.Goal;   
            Sex = user.Sex;      
            ActivityLevel = user.ActivityLevel; 
            Kcal = user.Kcal;   
            DietType = user.DietType;   
            MealsCount = user.MealsCount;
            Password = user.Password;
        }

        public override string ToString()
        {
            return $"{Login}, {Name}, {Surname}, {Age}, {Height}, {Weight}, " +
                $"{Goal}, {Sex}, {ActivityLevel}, {Kcal}, {DietType}, {MealsCount}, {Password}";
        }
    }
}
