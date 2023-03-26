using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Meal.Request;
using RestaurantApi23.Models.Meal.Response;
using RestaurantApi23.Models.Review.Request;
using RestaurantApi23.Models.Review.Response;
using RestaurantApi23.Services;
using RestaurantApi23.Services.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<User> _userManager;
        public ReviewsController(IReviewService reviewService, UserManager<User> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<ReviewResponseDto> GetReviews()
        {
            return _reviewService.GetAll();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewResponseDto>> GetReview(int id)
        {
            var review = await _reviewService.GetById(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewRequestDto review)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            //TODO: check if the user is trying to edit his/her own review

            await _reviewService.UpdateReview(id, review.Title, review.ReviewText, user.Id, review.MealId);
            return NoContent();
        }

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ReviewResponseDto>> PostReview(ReviewRequestDto review)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var result = await _reviewService.CreateReview(review.Title, review.ReviewText, user.Id, review.MealId);

            return CreatedAtAction("GetReview", new { id = result.Id }, result);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.RemoveReview(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
