using restaurantAPI.Model;

namespace restaurantAPI.Interface
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetAll();
    }
}
