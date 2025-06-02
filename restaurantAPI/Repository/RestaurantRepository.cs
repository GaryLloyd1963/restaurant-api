using Microsoft.Data.Sqlite;
using restaurantAPI.Interface;
using RestaurantCore.Model;

namespace restaurantAPI.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IConfiguration _configuration;

        public RestaurantRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var connectionString = _configuration.GetConnectionString("RestaurantsDB");
            var selectedRestaurants = new List<Restaurant>();
            try
            {

                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = $"SELECT * FROM Restaurants;";
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var restaurant = new Restaurant
                        {
                            Id = Guid.Parse(reader["UUID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = reader["Phone"].ToString()
                        };
                        selectedRestaurants.Add(restaurant);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
            return [.. selectedRestaurants];
        }
        public Restaurant GetById(Guid id)
        {
            return new Restaurant { Id = Guid.NewGuid(), Name = "Casa Roberto", Address = "1 Acacia Avenue", Phone = "1234567890" };
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
