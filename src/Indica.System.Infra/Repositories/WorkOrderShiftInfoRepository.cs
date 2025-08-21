using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderShiftInfoRepository : BaseRepository<WorkOrderShiftInfo>, IWorkOrderShiftInfoRepository
    {
        private readonly DbContext context;
        public WorkOrderShiftInfoRepository(ProductivityContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<long>> GetAllIdsByActivityAsync(List<long> ids)
        {
            return await context.Set<WorkOrderShiftInfo>()
                .Where(e => ids.Contains(e.IdActivity))
                .Select(e => e.IdActivity)
                .ToListAsync();
        }
    }
}