using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderBaseRepository : BaseRepository<WorkOrderBase>, IWorkOrderBaseRepository
    {
        public WorkOrderBaseRepository(ProductivityContext context) : base(context)
        {
        }
    }
}