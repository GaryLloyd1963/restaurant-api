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

        public IEnumerable<Restaurant> GetAll()
        {
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
