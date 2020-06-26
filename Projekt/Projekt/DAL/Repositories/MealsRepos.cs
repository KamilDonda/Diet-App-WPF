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

        public static List<Meals> GetAllMeals()
        {
            List<Meals> meals = new List<Meals>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand(ALL_MEALS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        meals.Add(new Meals(dataReader));
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