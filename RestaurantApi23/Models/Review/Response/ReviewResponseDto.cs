using RestaurantApi23.Models.Meal.Response;
using RestaurantApi23.Models.Restaurant.Responses;
using RestaurantApi23.Models.User.Response;

namespace RestaurantApi23.Models.Review.Response
{
    public class ReviewResponseDto : BaseResponeDto
    {
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public UserPairResponseDto User { get; set; }
        public MealPairResponseDto Meal { get; set; }
    }
}
