using Indica.System.Domain.Entities;

namespace Indica.System.Domain.Interfaces
{
    public interface IWorkOrderServiceRepository : IBaseRepository<WorkOrderService>
    {
        Task<List<long>> GetAllIdsByActivityAsync(List<long> ids);
    }
}