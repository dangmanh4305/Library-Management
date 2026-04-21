using MySql.Data.MySqlClient;


namespace QLTV
{
    public class DBConnection
    {
        private static string _connStr =
            "Server=192.168.1.155;" +
            "Port=3306;" +
            "Database=LibraryManagement;" +
            "Uid=root;" +
            "Pwd=123456;" +
            "CharSet=utf8mb4;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connStr);
        }
    }
}