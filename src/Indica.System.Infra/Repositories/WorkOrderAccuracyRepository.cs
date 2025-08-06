using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderAccuracyRepository : BaseRepository<WorkOrderAccuracy>, IWorkOrderAccuracyRepository
    {
        public WorkOrderAccuracyRepository(ProductivityContext context) : base(context)
        {
        }
    }
}