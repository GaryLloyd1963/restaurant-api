using restaurantAPI.Interface;
using RestaurantCore.Model;

namespace restaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }
        public Restaurant GetById(Guid id)
        {
            return _restaurantRepository.GetById(id);
        }
        public void Add(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }
        public void Update(Restaurant restaurant)
        {
            _restaurantRepository.Update(restaurant);
        }
        public void Delete(Restaurant restaurant)
        {
            _restaurantRepository.Delete(restaurant);
        }
    }
}
