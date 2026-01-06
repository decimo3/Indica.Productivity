using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Domain.Interfaces
{
    public interface IWorkOrderCostumerRepository : IBaseRepository<WorkOrderCostumer>
    {
        Task<List<(long InstallationNumber, long Id)>> GetAllIdsByInstallationAsync(List<long> ids);
    }
}