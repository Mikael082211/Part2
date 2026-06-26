using MySql.Data.MySqlClient;

namespace Part2
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            "server=localhost;database=CyberBot;uid=root;pwd=password;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}