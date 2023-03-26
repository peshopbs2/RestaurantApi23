using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Meal.Response;

namespace RestaurantApi23.Services.Abstractions
{
    public interface IMealService
    {
        Task<MealResponseDto> CreateMeal(string title, string description, string pictureUrl, int restaurantId);
        IEnumerable<MealResponseDto> GetAll();
        Task<MealResponseDto> GetById(int id);
        Task<MealResponseDto> UpdateMeal(int id, string title, string description, string pictureUrl, int restaurantId);
        Task<bool> RemoveMeal(int id);

    }
}
