using RestaurantCore.Model;

namespace restaurantAPI.Interface
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetAll();
    }
}
