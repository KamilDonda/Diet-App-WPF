using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Diet
    {
        public int ID       { get; set; }
        public string Login { get; private set; }
        public int ID_Meal  { get; private set; }
        public string Day   { get; private set; }

        public Diet(MySqlDataReader reader)
        {
            ID      = int.Parse(reader["id"].ToString());
            Login   = reader["id_user"].ToString();
            ID_Meal = int.Parse(reader["id_meal"].ToString());
            Day     = reader["day"].ToString();
        }

        public Diet(string login, int id_meal, string day)
        {
            Login   = login;
            ID_Meal = id_meal;
            Day     = day;
        }

        public Diet(Diet diet)
        {
            ID      = diet.ID;
            Login   = diet.Login;
            ID_Meal = diet.ID_Meal;
            Day     = diet.Day;
        }

        public string ToInsert()
        {
            return $"('{ID}', '{Login}', '{Day}', '{ID_Meal}')";
        }
    }
}
