using Indica.System.Domain.Entities;

namespace Indica.System.Domain.Interfaces
{
    public interface IWorkOrderShiftInfoRepository : IBaseRepository<WorkOrderShiftInfo>
    {
        Task<List<long>> GetAllIdsByActivityAsync(List<long> ids);
    }
}