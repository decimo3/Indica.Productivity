using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Domain.Interfaces
{
    public interface IWorkOrderShiftInfoRepository : IBaseRepository<WorkOrderShiftInfo>
    {
        Task<List<(long IdActivity, long Id)>> GetAllIdsByActivityAsync(List<long> ids);
    }
}