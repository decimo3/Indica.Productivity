using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderServiceRepository : BaseRepository<WorkOrderService>, IWorkOrderServiceRepository
    {
        private readonly DbContext context;
        public WorkOrderServiceRepository(ProductivityContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<(long IdActivity, long Id)>> GetAllIdsByActivityAsync(List<long> ids)
        {
            return await context.Set<WorkOrderService>()
                .Where(e => ids.Contains(e.IdActivity))
                .Select(e => new ValueTuple<long, long>( e.IdActivity , e.Id))
                .ToListAsync();
        }
    }
}