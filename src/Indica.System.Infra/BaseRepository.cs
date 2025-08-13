using Indica.System.Domain;
using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Indica.System.Infra
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ProductivityContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ProductivityContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<int> AddRangeAsync(List<T> lista)
        {
            await _dbSet.AddRangeAsync(lista);
            await _context.SaveChangesAsync();
            return lista.Count;
        }

        public virtual async Task<int> UpdateRangeAsync(List<T> lista)
        {
            _dbSet.UpdateRange(lista);
            await _context.SaveChangesAsync();
            return lista.Count;
        }

        public virtual async Task<int> DeleteRangeAsync(List<T> lista)
        {
            _dbSet.RemoveRange(lista);
            await _context.SaveChangesAsync();
            return lista.Count;
        }

        public async Task<T?> FirstOrDefaultByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T?> SingleOrDefaultByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.SingleOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetPagedAndFilteredByExpressionAsync(int offset, int limit, Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> queryable = _dbSet;
            if (filter != null) queryable = queryable.Where(filter);
            return await queryable.Skip((offset - 1) * limit).Take(limit).ToListAsync();
        }
    }
}
