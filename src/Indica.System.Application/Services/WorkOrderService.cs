using System.Linq.Expressions;
using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class WorkOrderService : IBaseService<WorkOrderDTO, WorkOrderBase>, IWorkOrderService
    {
        public WorkOrderService
        (
            IMapper mapper, IFileParser parser,
            IWorkOrderServiceRepository serviceRepository,
            IWorkOrderCostumerRepository costumerRepository,
            IWorkOrderIntervalRepository intervalRepository,
            IWorkOrderShiftInfoRepository shiftInfoRepository,
            IWorkOrderSituationRepository situationRepository
        )
        {

        }

        public Task<bool> AddAsync(WorkOrderDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(List<WorkOrderDTO> lista)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(Stream arquivo, string filename)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRangeAsync(List<WorkOrderDTO> lista)
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkOrderDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkOrderDTO>> GetByExpression(Expression<Func<WorkOrderDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<WorkOrderDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(WorkOrderDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRangeAsync(List<WorkOrderDTO> lista)
        {
            throw new NotImplementedException();
        }
    }
}
