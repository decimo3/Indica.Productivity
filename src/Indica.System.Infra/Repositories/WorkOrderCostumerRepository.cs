using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderCostumerRepository : BaseRepository<WorkOrderCostumer>, IWorkOrderCostumerRepository
    {
        public WorkOrderCostumerRepository(ProductivityContext context) : base(context) {}
    }
}