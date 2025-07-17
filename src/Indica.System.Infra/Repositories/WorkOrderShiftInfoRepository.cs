using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderShiftInfoRepository : BaseRepository<WorkOrderShiftInfo>, IWorkOrderShiftInfoRepository
    {
        public WorkOrderShiftInfoRepository(ProductivityContext context) : base(context) {}
    }
}