namespace RestaurantApi23.Models
{
    public abstract class BaseResponeDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}