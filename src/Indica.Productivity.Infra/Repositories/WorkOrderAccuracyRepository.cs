using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderAccuracyRepository : BaseRepository<WorkOrderAccuracy>, IWorkOrderAccuracyRepository
    {
        public WorkOrderAccuracyRepository(ProductivityContext context) : base(context)
        {
        }
    }
}