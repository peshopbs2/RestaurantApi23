using RestaurantApi23.Data;
using RestaurantApi23.Data.Entities;
using RestaurantApi23.Repositories.Abstractions;

namespace RestaurantApi23.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly RestaurantContext _context;
        public Repository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<T> CreateOrUpdate(T item)
        {
            if(item.Id != 0)
            {
                item.ModifiedAt = DateTime.Now;
                _context.Set<T>().Update(item);
            }
            else
            {
                item.CreatedAt = DateTime.Now;
                _context.Set<T>().Add(item);
            }

            await _context.SaveChangesAsync();

            return item;
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _context.Set<T>()
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Remove(T item)
        {
            _context.Set<T>().Remove(item);
            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> RemoveById(int id)
        {
            var item = await GetById(id);
            if (item != null)
            {
                return await this.Remove(item);
            }
            else
            {
                return false;
            }
        }
    }
}
