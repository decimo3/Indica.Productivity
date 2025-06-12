using System.Linq.Expressions;

namespace Indica.System.Domain
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetByExpression(Expression<Func<T,bool>> e);
        Task<int> AddRangeAsync(List<T> lista);
        Task<int> UpdateRangeAsync(List<T> lista);
    }
}
