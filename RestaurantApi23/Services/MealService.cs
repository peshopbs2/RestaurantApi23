using RestaurantApi23.Data.Entities;
using RestaurantApi23.Repositories.Abstractions;
using RestaurantApi23.Services.Abstractions;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace RestaurantApi23.Services
{
    public class MealService : IMealService
    {
        private readonly IRepository<Meal> _mealRepository;
        public MealService(IRepository<Meal> mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<Meal> CreateMeal(string title, string description, string pictureUrl, int restaurantId)
        {
            var item = await _mealRepository.CreateOrUpdate(new Meal()
            {
                Title = title,
                Description = description,
                PictureUrl = pictureUrl,
                RestaurantId = restaurantId
            });

            return item;
        }

        public IEnumerable<Meal> GetAll()
        {
            return _mealRepository.GetAll();
        }

        public async Task<Meal> GetById(int id)
        {
            return await _mealRepository.GetById(id);
        }

        public async Task<bool> RemoveMeal(int id)
        {
            return await _mealRepository.RemoveById(id);
        }

        public async Task<Meal> UpdateMeal(int id, string title, string description, string pictureUrl, int restaurantId)
        {
            var item = await _mealRepository.GetById(id);
            if (item != null)
            {
                item.Id = id;
                item.Title = title;
                item.Description = description;
                item.PictureUrl = pictureUrl;
                item.RestaurantId = restaurantId;

                return await _mealRepository.CreateOrUpdate(item);
            }
            else
            {
                return null;
            }
        }
    }
}
