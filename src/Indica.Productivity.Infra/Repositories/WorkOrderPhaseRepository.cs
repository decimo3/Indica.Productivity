using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderPhaseRepository : BaseRepository<WorkOrderPhase>, IWorkOrderPhaseRepository
    {
        public WorkOrderPhaseRepository(ProductivityContext context) : base(context)
        {
        }
    }
}