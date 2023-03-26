namespace RestaurantApi23.Models.Meal.Request
{
    public class MealRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int RestaurantId { get; set; }
    }
}
