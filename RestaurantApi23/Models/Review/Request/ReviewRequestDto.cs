namespace RestaurantApi23.Models.Review.Request
{
    public class ReviewRequestDto
    {
        public string Title { get; set; }
        public string ReviewText { get; set; }
        //UserId will be detected by the controller
        public int MealId { get; set; }
    }
}
