using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderAreaRepository : BaseRepository<WorkOrderArea>, IWorkOrderAreaRepository
    {
        public WorkOrderAreaRepository(ProductivityContext context) : base(context)
        {
        }
    }
}