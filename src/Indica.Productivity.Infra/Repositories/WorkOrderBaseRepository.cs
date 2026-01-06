using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderBaseRepository : BaseRepository<WorkOrderBase>, IWorkOrderBaseRepository
    {
        public WorkOrderBaseRepository(ProductivityContext context) : base(context)
        {
        }
    }
}