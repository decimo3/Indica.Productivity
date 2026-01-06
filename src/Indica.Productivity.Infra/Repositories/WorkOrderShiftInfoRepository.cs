using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderShiftInfoRepository : BaseRepository<WorkOrderShiftInfo>, IWorkOrderShiftInfoRepository
    {
        private readonly DbContext context;
        public WorkOrderShiftInfoRepository(ProductivityContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<(long IdActivity, long Id)>> GetAllIdsByActivityAsync(List<long> ids)
        {
            return await context.Set<WorkOrderShiftInfo>()
                .Where(e => ids.Contains(e.IdActivity))
                .Select(e => new ValueTuple<long, long>(e.IdActivity, e.Id))
                .ToListAsync();
        }
    }
}