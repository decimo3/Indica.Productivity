using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderCostumerRepository : BaseRepository<WorkOrderCostumer>, IWorkOrderCostumerRepository
    {
        private readonly DbContext context;
        public WorkOrderCostumerRepository(ProductivityContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<(long InstallationNumber, long Id)>> GetAllIdsByInstallationAsync(List<long> ids)
        {
            return await context.Set<WorkOrderCostumer>()
                .Where(e => ids.Contains(e.InstallationNumber))
                .Select(e => new ValueTuple<long, long>(e.InstallationNumber, e.Id))
                .ToListAsync();
        }
    }
}