using System.Linq.Expressions;

namespace Indica.Productivity.Domain
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetByExpressionAsync(Expression<Func<T,bool>> e);
        Task<int> AddRangeAsync(List<T> lista);
        Task<int> UpdateRangeAsync(List<T> lista);
        Task<int> DeleteRangeAsync(List<T> lista);
        Task<T?> GetFirstOrDefaultByExpressionAsync(Expression<Func<T, bool>> eexpression);
        Task<T?> GetSingleOrDefaultByExpressionAsync(Expression<Func<T, bool>> eexpression);
        Task<List<T>> GetPagedAndFilteredByExpressionAsync(int offset, int limit, Expression<Func<T, bool>>? filter = null);
    }
}
