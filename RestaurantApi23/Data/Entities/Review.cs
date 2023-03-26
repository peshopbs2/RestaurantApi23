namespace RestaurantApi23.Data.Entities
{
    public class Review : BaseEntity
    {
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string UserId { get; set; }
        public virtual User? User{ get; set; }
        public int MealId { get; set; }
        public virtual Meal? Meal { get; set; }
    }
}
