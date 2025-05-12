using Microsoft.AspNetCore.Mvc;
using restaurantAPI.Model;
using restaurantAPI.Interface;

namespace restaurantAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<RestaurantsController> _logger;

        public RestaurantsController(IRestaurantService restaurantService, ILogger<RestaurantsController> logger)
        {
            _restaurantService = restaurantService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _restaurantService.GetAll();
        }
    }
}
