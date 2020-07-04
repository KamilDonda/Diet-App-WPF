using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Contains
    {
        public int ID             { get; private set; }
        public int ID_Meals       { get; private set; }
        public int ID_Ingredients { get; private set; }
        public double Weight      { get; private set; }

        public Contains(MySqlDataReader reader)
        {
            ID             = int.Parse(reader["id"].ToString());
            ID_Meals       = int.Parse(reader["id_meals"].ToString());
            ID_Ingredients = int.Parse(reader["id_ingredients"].ToString());
            Weight         = double.Parse(reader["weight"].ToString());
        }
    }
}
