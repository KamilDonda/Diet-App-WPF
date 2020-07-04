using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class History
    {
        public int ID      { get; private set; }
        public uint Day    { get; private set; }
        public int ID_Diet { get; private set; }

        public History(MySqlDataReader reader)
        {
            ID      = int.Parse(reader["id"].ToString());
            Day     = uint.Parse(reader["day"].ToString());
            ID_Diet = int.Parse(reader["id_diet"].ToString());      
        }
    }
}
