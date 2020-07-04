using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class HistoryRepos
    {
        private const string HISTORY = "SELECT * FROM HISTORY";

        public static List<Entities.History> GetAllHistories()
        {
            List<Entities.History> history = new List<Entities.History>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(HISTORY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    history.Add(new Entities.History(reader));
                connection.Close();
            }
            return history;
        }
    }
}
