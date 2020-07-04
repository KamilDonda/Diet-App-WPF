using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class Diet
    {
        public int ID      { get; private set; }
        public int ID_User { get; private set; }
        public int ID_Meal { get; private set; }
        public uint Day    { get; private set; }

        public Diet(MySqlDataReader reader)
        {
            ID      = int.Parse(reader["id"].ToString());
            ID_User = int.Parse(reader["id_user"].ToString());
            ID_Meal = int.Parse(reader["id_meal"].ToString());
            Day     = uint.Parse(reader["day"].ToString());
        }
    }
}
