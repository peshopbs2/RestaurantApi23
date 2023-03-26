namespace RestaurantApi23.Data.Entities
{
    public class Meal : BaseEntity
    {
        public Meal()
        {
            Reviews = new HashSet<Review>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}