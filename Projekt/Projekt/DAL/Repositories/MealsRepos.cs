using MySql.Data.MySqlClient;
using Projekt.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class MealsRepos
    {
        //Komenda wypisująca polecenie MySQL
        private const string ALL_MEALS_QUERY = "SELECT * FROM MEALS";

        public static List<Entities.Meals> GetAllMeals()
        {
            List<Entities.Meals> meals = new List<Entities.Meals>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand(ALL_MEALS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        meals.Add(new Entities.Meals(dataReader));
                    connection.Close();
                }
            }
            catch 
            {

            }
            return meals;
        }
    }
}