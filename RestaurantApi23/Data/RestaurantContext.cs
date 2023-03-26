using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantApi23.Data.Entities;

namespace RestaurantApi23.Data
{
    public class RestaurantContext : IdentityDbContext
    {
        public RestaurantContext(DbContextOptions options)
            : base (options)
        {

        }

        public DbSet<Restaurant> Resturants { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
