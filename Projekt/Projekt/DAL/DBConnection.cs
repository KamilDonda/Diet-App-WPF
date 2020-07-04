using MySql.Data.MySqlClient;

namespace Projekt.DAL
{
    class DBConnection
    {
        private static MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;
        public static DBConnection Instance {
            get {
                if(instance == null) {
                    instance = new DBConnection();
                }
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnection()
        {

            stringBuilder.UserID    = Properties.Settings.Default.User;
            stringBuilder.Password  = Properties.Settings.Default.Password;
            stringBuilder.Server    = Properties.Settings.Default.Server;
            stringBuilder.Database  = Properties.Settings.Default.Database;
            stringBuilder.Port      = Properties.Settings.Default.Port;
        }

    }
}