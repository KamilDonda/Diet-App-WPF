using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.DAL.Repositories
{
    class UsersRepos
    {
        private const string GET_ALL = "SELECT * FROM USERS";

        public static List<Entities.Users> GetAll()
        {
            List<Entities.Users> users = new List<Entities.Users>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Entities.Users(reader));
                connection.Close();
            }
            return users;
        }

        public static bool CreateUser(string Login, string Password)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                var command_CreateUser       = new MySqlCommand($"CREATE USER '{Login}' IDENTIFIED BY '{Password}'", connection);
                var command_GrantContains    = new MySqlCommand($"GRANT SELECT ON CONTAINS TO '{Login}'", connection);
                var command_GrantDiet        = new MySqlCommand($"GRANT SELECT ON DIET TO '{Login}'", connection);
                var command_GrantIngredients = new MySqlCommand($"GRANT SELECT ON INGREDIENTS TO '{Login}'", connection);
                var command_GrantMeals       = new MySqlCommand($"GRANT SELECT ON MEALS TO '{Login}'", connection);
                var command_AddUser          = new MySqlCommand($"INSERT INTO USERS (LOGIN, PASSWORD, AGE, HEIGHT, WEIGHT, KCAL) VALUES (" +
                    $"'{Login}', '{Password}', 0, 0, 0, 0)", connection);

                connection.Open();
                command_CreateUser.ExecuteNonQuery();
                command_GrantContains.ExecuteNonQuery();
                command_GrantDiet.ExecuteNonQuery();
                command_GrantIngredients.ExecuteNonQuery();
                command_GrantMeals.ExecuteNonQuery();
                command_AddUser.ExecuteNonQuery();
                condition = true;
                connection.Close();
            }
            return condition;
        }

        public static bool Update(Entities.Users user)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                var height = user.Height.ToString().Replace(',', '.');
                var weight = user.Weight.ToString().Replace(',', '.');
                var kcal = user.Kcal.ToString().Replace(',', '.');

                var command_AddUser = new MySqlCommand($"UPDATE USERS SET " +
                    $"NAME='{user.Name}', SURNAME='{user.Surname}', AGE={user.Age}, HEIGHT={height}, " +
                    $"WEIGHT={weight}, GOAL='{user.Goal}', SEX='{user.Sex}', " +
                    $"ACTIVITYLEVEL='{user.ActivityLevel}', KCAL={kcal}, DIETTYPE='{user.DietType}', " +
                    $"MEALSCOUNT='{user.MealsCount}' WHERE LOGIN='{user.Login}'", connection);

                //var command_AddUser = new MySqlCommand($"INSERT INTO USERS (LOGIN, PASSWORD) VALUES (" +
                //    $"'{user.Login}', {user.Password})", connection);

                connection.Open();
                command_AddUser.ExecuteNonQuery();
                condition = true;
                connection.Close();
            }
            return condition;
        }

    }
}
