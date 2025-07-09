using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderServiceRepository : BaseRepository<WorkOrderService>, IWorkOrderServiceRepository
    {
        public WorkOrderServiceRepository(ProductivityContext context) : base(context) {}
    }
}