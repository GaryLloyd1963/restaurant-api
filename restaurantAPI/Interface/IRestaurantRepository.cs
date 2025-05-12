using RestaurantCore.Model;

namespace restaurantAPI.Interface
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(Guid id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(Restaurant restaurant);
    }
}
