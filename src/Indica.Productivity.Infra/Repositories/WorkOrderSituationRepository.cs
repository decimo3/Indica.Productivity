using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderSituationRepository : BaseRepository<WorkOrderSituation>, IWorkOrderSituationRepository
    {
        public WorkOrderSituationRepository(ProductivityContext context) : base(context) {}
    }
}