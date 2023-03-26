using Microsoft.AspNetCore.Mvc;
using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Restaurant.Requests;
using RestaurantApi23.Models.Restaurant.Responses;
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
        public IEnumerable<RestaurantResponseDto> GetAll()
        {
            return _restaurantService.GetAll();
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantResponseDto>> Get(int id)
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
        public async Task<ActionResult<RestaurantResponseDto>> Post([FromBody] RestaurantRequestDto restaurant)
        {
            var result = await _restaurantService.CreateRestaurant(restaurant.Name, restaurant.Description, restaurant.Address);
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RestaurantRequestDto restaurant)
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
