using RestaurantApi23.Data.Entities;
using RestaurantApi23.Models.Restaurant.Responses;
using RestaurantApi23.Repositories.Abstractions;
using RestaurantApi23.Services.Abstractions;

namespace RestaurantApi23.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        public RestaurantService(IRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository= restaurantRepository;
        }

        public async Task<RestaurantResponseDto> CreateRestaurant(string name, string description, string address)
        {
            var item = await _restaurantRepository.CreateOrUpdate(new Restaurant()
            {
                Name= name,
                Description = description,
                Address = address
            });

            //TODO: upgrade to automapper
            return new RestaurantResponseDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Address = item.Address,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public async Task<bool> RemoveRestaurant(int id)
        {
            return await _restaurantRepository.RemoveById(id);
        }

        public IEnumerable<RestaurantResponseDto> GetAll()
        {
            return _restaurantRepository.GetAll()
                .Select(item => new RestaurantResponseDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Address = item.Address,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                });
        }

        public async Task<RestaurantResponseDto> GetById(int id)
        {
            var item = await _restaurantRepository.GetById(id);
            return new RestaurantResponseDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Address = item.Address,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public async Task<RestaurantResponseDto> UpdateRestaurant(int id, string name, string description, string address)
        {
            var item = await _restaurantRepository.GetById(id);
            if (item != null)
            {
                item.Id = id;
                item.Name = name;
                item.Description = description;
                item.Address = address;

                item = await _restaurantRepository.CreateOrUpdate(item);

                return new RestaurantResponseDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Address = item.Address,
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
