using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Meal.Response;
using RestaurantApi23.Models.Restaurant.Responses;
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

        public async Task<MealResponseDto> CreateMeal(string title, string description, string pictureUrl, int restaurantId)
        {
            var item = await _mealRepository.CreateOrUpdate(new Meal()
            {
                Title = title,
                Description = description,
                PictureUrl = pictureUrl,
                RestaurantId = restaurantId
            });

            return new MealResponseDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                PictureUrl = item.PictureUrl,
                Restaurant = new RestaurantPairResponseDto()
                {
                    RestaurantId = item.Restaurant.Id,
                    RestaurantName = item.Restaurant.Name
                },
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public IEnumerable<MealResponseDto> GetAll()
        {
            return _mealRepository.GetAll()
                .Select(item => new MealResponseDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    PictureUrl = item.PictureUrl,
                    Restaurant = new RestaurantPairResponseDto()
                    {
                        RestaurantId = item.Restaurant.Id,
                        RestaurantName = item.Restaurant.Name
                    },
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
        }

        public async Task<MealResponseDto> GetById(int id)
        {
            var item = await _mealRepository.GetById(id);
            return new MealResponseDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                PictureUrl = item.PictureUrl,
                Restaurant = new RestaurantPairResponseDto()
                {
                    RestaurantId = item.Restaurant.Id,
                    RestaurantName = item.Restaurant.Name
                },
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public async Task<bool> RemoveMeal(int id)
        {
            return await _mealRepository.RemoveById(id);
        }

        public async Task<MealResponseDto> UpdateMeal(int id, string title, string description, string pictureUrl, int restaurantId)
        {
            var item = await _mealRepository.GetById(id);
            if (item != null)
            {
                item.Id = id;
                item.Title = title;
                item.Description = description;
                item.PictureUrl = pictureUrl;
                item.RestaurantId = restaurantId;

                item = await _mealRepository.CreateOrUpdate(item);
                return new MealResponseDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    PictureUrl = item.PictureUrl,
                    Restaurant = new RestaurantPairResponseDto()
                    {
                        RestaurantId = item.Restaurant.Id,
                        RestaurantName = item.Restaurant.Name
                    },
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                };
            }
            else
            {
                return null;
            }
        }
    }
}
