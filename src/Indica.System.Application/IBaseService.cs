using System.Linq.Expressions;
using Indica.System.Domain.Entities;

namespace Indica.System.Application
{
    public interface IBaseService<T, Y> where T : class where Y : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetByExpression(Expression<Func<T, bool>> expression);
        Task<int> AddRangeAsync(List<T> lista);
        Task<int> UpdateRangeAsync(List<T> lista);
        Task<int> DeleteRangeAsync(List<T> lista);
        Task<int> AddRangeAsync(Stream arquivo, string filename);
    }
}
