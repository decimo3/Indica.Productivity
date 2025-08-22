using Indica.System.Domain.Entities;

namespace Indica.System.Domain.Interfaces
{
    public interface IWorkOrderCostumerRepository : IBaseRepository<WorkOrderCostumer>
    {
        Task<List<(long InstallationNumber, long Id)>> GetAllIdsByInstallationAsync(List<long> ids);
    }
}