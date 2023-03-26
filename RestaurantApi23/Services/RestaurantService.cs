using RestaurantApi23.Data.Entities;
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

        public async Task<Restaurant> CreateRestaurant(string name, string description, string address)
        {
            var item = await _restaurantRepository.CreateOrUpdate(new Restaurant()
            {
                Name= name,
                Description = description,
                Address = address
            });

            return item;
        }

        public async Task<bool> RemoveRestaurant(int id)
        {
            return await _restaurantRepository.RemoveById(id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await _restaurantRepository.GetById(id);
        }

        public async Task<Restaurant> UpdateRestaurant(int id, string name, string description, string address)
        {
            var item = await _restaurantRepository.GetById(id);
            if (item != null)
            {
                item.Id = id;
                item.Name = name;
                item.Description = description;
                item.Address = address;

                return await _restaurantRepository.CreateOrUpdate(item);
            }
            else
            {
                return null;
            }
        }
    }
}
