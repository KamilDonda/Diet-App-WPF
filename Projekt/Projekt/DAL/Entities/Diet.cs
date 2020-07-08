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
        public string NR    { get; private set; }

        public Diet(MySqlDataReader reader)
        {
            ID      = int.Parse(reader["id"].ToString());
            Login   = reader["id_user"].ToString();
            ID_Meal = int.Parse(reader["id_meal"].ToString());
            NR = reader["nr"].ToString();
        }

        public Diet(string login, int id_meal, string nr)
        {
            Login   = login;
            ID_Meal = id_meal;
            NR      = nr;
        }

        public Diet(Diet diet)
        {
            ID      = diet.ID;
            Login   = diet.Login;
            ID_Meal = diet.ID_Meal;
            NR      = diet.NR;
        }

        public string ToInsert()
        {
            return $"({ID}, '{Login}', {ID_Meal}, '{NR}')";
        }
    }
}
