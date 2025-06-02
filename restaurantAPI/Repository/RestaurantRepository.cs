using Microsoft.Data.Sqlite;
using restaurantAPI.Interface;
using RestaurantCore.Model;

namespace restaurantAPI.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private static readonly Restaurant[] restaurantData = new[]
        {
            new Restaurant { Id = Guid.NewGuid(), Name = "Casa Roberto", Address = "1 Acacia Avenue", Phone = "1234567890" },
            new Restaurant { Id = Guid.NewGuid(), Name = "Kaths Cafe", Address = "Albert Square", Phone = "0987654321" },
            new Restaurant { Id = Guid.NewGuid(), Name = "Loads Of Nosh", Address = "Binks Yard", Phone = "1122334455" },
            new Restaurant { Id = Guid.NewGuid(), Name = "Hot Curry Time", Address = "Maid Marion Way", Phone = "2233445566" },
            new Restaurant { Id = Guid.NewGuid(), Name = "Mexican Standoff", Address = "Hockley", Phone = "3344556677" }
        };

        private readonly IConfiguration _configuration;

        public RestaurantRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var connectionString = _configuration.GetConnectionString("RestaurantsDB");
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = $"SELECT * FROM Restaurants;";
                    var result = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
            return [.. restaurantData];
        }
        public Restaurant GetById(Guid id)
        {
            return restaurantData[0];
        }
        public void Add(Restaurant restaurant)
        {
        }
        public void Update(Restaurant restaurant)
        {
        }
        public void Delete(Restaurant restaurant)
        {
        }
    }
}
