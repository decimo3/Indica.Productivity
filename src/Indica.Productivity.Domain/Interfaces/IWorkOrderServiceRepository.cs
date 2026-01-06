using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Domain.Interfaces
{
    public interface IWorkOrderServiceRepository : IBaseRepository<WorkOrderService>
    {
        Task<List<(long IdActivity, long Id)>> GetAllIdsByActivityAsync(List<long> ids);
    }
}