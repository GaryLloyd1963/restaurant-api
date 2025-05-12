using Microsoft.Data.Sqlite;

namespace SqliteInfrastructure
{
    public class SqliteDBBuilder
    {
        private static readonly string restaurantDbConnectionString = "Data Source=restaurants.db";

        public static string BuildDatabase()
        {
            return BuildRestaurantDatabase();
        }

        private static bool TableExists(SqliteConnection connection, string tableName)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            var result = command.ExecuteScalar();
            return result != null;
        }

        private static void CreateAndBuildRestaurantsTable(SqliteConnection connection)
        {
            if (TableExists(connection, "Restaurants"))
                return;

            var command = connection.CreateCommand();
            command.CommandText = @" CREATE TABLE Restaurants (
                        Id INTEGER PRIMARY KEY,
                        UUID TEXT NOT NULL,
                        Name TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        Phone TEXT NOT NULL )";
            command.ExecuteNonQuery();
        }

        private static string BuildRestaurantDatabase()
        {
            try
            {
                using (var connection = new SqliteConnection(restaurantDbConnectionString))
                {
                    connection.Open();
                    CreateAndBuildRestaurantsTable(connection);
                }
                Console.WriteLine("Built Restaurant Database");
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
                return "failure";
            }   
        }

    }
}
