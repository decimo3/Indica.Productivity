using System.Linq.Expressions;
using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class WorkOrderService : BaseService<WorkOrderDTO, WorkOrderBase>, IWorkOrderService
    {
        private readonly IWorkOrderSituationRepository situationRepository;
        private readonly IWorkOrderAccuracyRepository accuracyRepository;
        private readonly IWorkOrderPhaseRepository phaseRepository;
        private readonly IWorkOrderServiceRepository serviceRepository;
        private readonly IWorkOrderCostumerRepository costumerRepository;
        private readonly IWorkOrderShiftInfoRepository shiftInfoRepository;
        private readonly IDamageToProjectRepository damageToProjectRepository;
        private readonly IFieldTeamRepository fieldTeamRepository;
        private readonly ICodeFilterRepository codeFilterRepository;
        private readonly IFinishingRepository finishingRepository;
        public WorkOrderService
        (
            IMapper mapper, IFileParser parser,
            IWorkOrderBaseRepository workOrderBaseRepository,
            IWorkOrderServiceRepository serviceRepository,
            IWorkOrderCostumerRepository costumerRepository,
            IWorkOrderShiftInfoRepository shiftInfoRepository,
            IWorkOrderSituationRepository situationRepository,
            IWorkOrderAccuracyRepository accuracyRepository,
            IWorkOrderPhaseRepository phaseRepository,
            IDamageToProjectRepository damageToProjectRepository,
            IFieldTeamRepository fieldTeamRepository,
            ICodeFilterRepository codeFilterRepository,
            IFinishingRepository finishingRepository
        ) : base(workOrderBaseRepository, mapper, parser)
        {
            this.serviceRepository = serviceRepository;
            this.costumerRepository = costumerRepository;
            this.shiftInfoRepository = shiftInfoRepository;
            this.situationRepository = situationRepository;
            this.accuracyRepository = accuracyRepository;
            this.phaseRepository = phaseRepository;
            this.damageToProjectRepository = damageToProjectRepository;
            this.fieldTeamRepository = fieldTeamRepository;
            this.finishingRepository = finishingRepository;
            this.codeFilterRepository = codeFilterRepository;
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

        public Task<List<WorkOrderDTO>> GetByExpressionAsync(Expression<Func<WorkOrderDTO, bool>> expression)
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
