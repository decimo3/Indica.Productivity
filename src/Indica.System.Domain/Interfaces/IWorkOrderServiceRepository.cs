using Indica.System.Domain.Entities;

namespace Indica.System.Domain.Interfaces
{
    public interface IWorkOrderServiceRepository : IBaseRepository<WorkOrderService>
    {
        Task<List<(long IdActivity, long Id)>> GetAllIdsByActivityAsync(List<long> ids);
    }
}