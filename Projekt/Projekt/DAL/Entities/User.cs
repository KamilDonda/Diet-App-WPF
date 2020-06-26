using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Entities
{
    class User
    {
        public string UserID
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public User(MySqlDataReader mySqlDataReader)
        {
            UserID = mySqlDataReader["nickname"].ToString();
            Password = mySqlDataReader["password"].ToString();
        }
    }
}
