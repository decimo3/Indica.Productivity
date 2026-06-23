using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Interfaces
{
    public interface IWorkOrderService : IBaseService<WorkOrderDTO, WorkOrderBase>
    {
        public Task<List<WorkOrderResumeDTO>> GetResumeAsync(int page);
    }
}
