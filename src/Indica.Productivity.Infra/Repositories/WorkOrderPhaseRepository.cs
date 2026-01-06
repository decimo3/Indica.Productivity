using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderPhaseRepository : BaseRepository<WorkOrderPhase>, IWorkOrderPhaseRepository
    {
        public WorkOrderPhaseRepository(ProductivityContext context) : base(context)
        {
        }
    }
}