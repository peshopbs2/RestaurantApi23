using RestaurantApi23.Models.Restaurant.Responses;

namespace RestaurantApi23.Models.Meal.Response
{
    public class MealResponseDto : BaseResponeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public RestaurantPairResponseDto Restaurant { get; set; }
    }
}
