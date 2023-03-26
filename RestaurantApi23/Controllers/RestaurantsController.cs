using Microsoft.AspNetCore.Mvc;
using RestaurantApi23.Data.Entities;
using RestaurantApi23.Services.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
    
        // GET: api/<RestaurantsController>
        [HttpGet]
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantService.GetAll();
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> Get(int id)
        {
            var item = await _restaurantService.GetById(id);
            if(item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public async Task<ActionResult<Restaurant>> Post([FromBody] Restaurant restaurant)
        {
            restaurant = await _restaurantService.CreateRestaurant(restaurant.Name, restaurant.Description, restaurant.Address);
            return CreatedAtAction("Get", new { id = restaurant.Id }, restaurant);
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Restaurant restaurant)
        {
            await _restaurantService.UpdateRestaurant(id, restaurant.Name, restaurant.Description, restaurant.Address);
            return NoContent();
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _restaurantService.RemoveRestaurant(id);

            if(!removed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
