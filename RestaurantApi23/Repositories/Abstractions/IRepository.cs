using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantApi23.Data.Entities;

namespace RestaurantApi23.Repositories.Abstractions
{
    public interface IRepository<T> where T: BaseEntity
    {
        public Task<T> CreateOrUpdate(T item);
        public Task<T> GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Filter(Func<T, bool> predicate);
        public Task<bool> Remove(T item);
        public Task<bool> RemoveById(int id);
    }
}
