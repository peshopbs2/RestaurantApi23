using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi23.Data;
using RestaurantApi23.Data.Entities;
using RestaurantApi23.Services.Abstractions;

namespace RestaurantApi23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        // GET: api/Meals
        [HttpGet]
        public IEnumerable<Meal> GetMeals()
        {
            return _mealService.GetAll();
        }

        // GET: api/Meals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            var meal = await _mealService.GetById(id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // PUT: api/Meals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, Meal meal)
        {
            await _mealService.UpdateMeal(id, meal.Title, meal.Description, meal.PictureUrl, meal.RestaurantId);
            return NoContent();
        }

        // POST: api/Meals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            meal = await _mealService.CreateMeal(meal.Title, meal.Description, meal.PictureUrl, meal.RestaurantId);

            return CreatedAtAction("GetMeal", new { id = meal.Id }, meal);
        }

        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var result = await _mealService.RemoveMeal(id);
            if(!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
