using RestaurantApi23.Data.Entities;

namespace RestaurantApi23.Services.Abstractions
{
    public interface IMealService
    {
        Task<Meal> CreateMeal(string title, string description, string pictureUrl, int restaurantId);
        IEnumerable<Meal> GetAll();
        Task<Meal> GetById(int id);
        Task<Meal> UpdateMeal(int id, string title, string description, string pictureUrl, int restaurantId);
        Task<bool> RemoveMeal(int id);

    }
}
