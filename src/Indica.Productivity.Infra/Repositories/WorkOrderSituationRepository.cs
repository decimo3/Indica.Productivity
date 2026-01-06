using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderSituationRepository : BaseRepository<WorkOrderSituation>, IWorkOrderSituationRepository
    {
        public WorkOrderSituationRepository(ProductivityContext context) : base(context) {}
    }
}