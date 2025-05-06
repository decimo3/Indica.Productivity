using Indica.System.Domain;
using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
    }
}
