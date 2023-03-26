using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Restaurant.Responses;

namespace RestaurantApi23.Services.Abstractions
{
    public interface IRestaurantService
    {
        Task<RestaurantResponseDto> CreateRestaurant(string name, string description, string address);
        IEnumerable<RestaurantResponseDto> GetAll();
        Task<RestaurantResponseDto> GetById(int id);
        Task<RestaurantResponseDto> UpdateRestaurant(int id, string name, string description, string address);
        Task<bool> RemoveRestaurant(int id);
    }
}
