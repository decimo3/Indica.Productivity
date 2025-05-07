
using Indica.System.Domain.Entities;

namespace Indica.System.Application
{
    public interface IBaseService<T, Y> where T : class where Y : class
    {
        Task<T> GetByIdAsync(object id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(object id);
    }
}
