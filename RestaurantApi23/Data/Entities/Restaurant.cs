namespace RestaurantApi23.Data.Entities
{
    public class Restaurant : BaseEntity
    {
        public Restaurant()
        {
            Meals = new HashSet<Meal>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
