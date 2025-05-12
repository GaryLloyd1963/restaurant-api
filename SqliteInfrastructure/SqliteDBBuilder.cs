using Microsoft.Data.Sqlite;

namespace SqliteInfrastructure
{
    public class SqliteDBBuilder
    {
        private static readonly string restaurantDbConnectionString = "Data Source=restaurants.db";

        public static string BuildDatabase(bool populate)
        {
            return BuildRestaurantDatabase(populate);
        }

        private static bool TableExists(SqliteConnection connection, string tableName)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            var result = command.ExecuteScalar();
            return result != null;
        }

        private static void CreateRestaurantsTable(SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = @" CREATE TABLE Restaurants (
                        Id INTEGER PRIMARY KEY,
                        UUID TEXT NOT NULL,
                        Name TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        Phone TEXT NOT NULL )";
            command.ExecuteNonQuery();
        }

        private static void PopulateRestaurantsTable(SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            foreach (var restaurant in SqliteDBTestData.restaurantData)
            {
                command.CommandText = @"INSERT INTO Restaurants (UUID, Name, Address, Phone) VALUES
                    ('" + restaurant.Id + "', '" + restaurant.Name + "', '" + restaurant.Address + "', '" + restaurant.Phone + "')";
                command.ExecuteNonQuery();
            }
        }

        private static string BuildRestaurantDatabase(bool populate)
        {
            try
            {
                using (var connection = new SqliteConnection(restaurantDbConnectionString))
                {
                    connection.Open();
                    if (!TableExists(connection, "Restaurants"))
                    {
                        CreateRestaurantsTable(connection);
                        if (populate)
                            PopulateRestaurantsTable(connection);
                    }
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
