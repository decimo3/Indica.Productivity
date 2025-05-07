using Indica.System.Domain.Entities;

namespace Indica.System.Domain
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(object id);
    }
}
