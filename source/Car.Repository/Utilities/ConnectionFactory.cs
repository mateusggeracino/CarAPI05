using System.Data.SqlClient;

namespace Car.Repository.Utilities
{
    public class ConnectionFactory
    {
        private static string _sqlConnection = "server=23.98.153.101;database=DeveloperDB05;user=developer;password=dev123DEV123";

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(_sqlConnection);
            conn.Open();
            return conn;
        }
    }
}