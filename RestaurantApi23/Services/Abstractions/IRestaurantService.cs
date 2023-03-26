using RestaurantApi23.Data.Entities;

namespace RestaurantApi23.Services.Abstractions
{
    public interface IRestaurantService
    {
        Task<Restaurant> CreateRestaurant(string name, string description, string address);
        IEnumerable<Restaurant> GetAll();
        Task<Restaurant> GetById(int id);
        Task<Restaurant> UpdateRestaurant(int id, string name, string description, string address);
        Task<bool> RemoveRestaurant(int id);
    }
}
