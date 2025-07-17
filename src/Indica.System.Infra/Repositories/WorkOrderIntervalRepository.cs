using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderIntervalRepository : BaseRepository<WorkOrderInterval>, IWorkOrderIntervalRepository
    {
        public WorkOrderIntervalRepository(ProductivityContext context) : base(context) {}
    }
}