using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderAreaRepository : BaseRepository<WorkOrderArea>, IWorkOrderAreaRepository
    {
        public WorkOrderAreaRepository(ProductivityContext context) : base(context)
        {
        }
    }
}