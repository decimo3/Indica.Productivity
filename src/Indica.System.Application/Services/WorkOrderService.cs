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

        private async Task<T> GetWorkOrderBaseAsync<T>(WorkOrderDTO entity) where T : WorkOrderBase, new()
        {
            var situation = await situationRepository.GetSingleOrDefaultByExpressionAsync(
                s => s.SituationName == entity.SituationName) ??
                    throw new InvalidOperationException($"A situação {entity.SituationName} não foi encontrada!");
            var dano = entity.TypeOfActivity[..4];
            var typeOfActivity = await damageToProjectRepository.GetSingleOrDefaultByExpressionAsync(
                dm => (dm.Damage + " - " + dm.Description) == entity.TypeOfActivity || dm.Description == entity.TypeOfActivity) ??
                    throw new InvalidOperationException($"O dano {entity.TypeOfActivity} não foi encontrado!");
            var fieldteam = await fieldTeamRepository.GetSingleOrDefaultByExpressionAsync(ft =>
                ft.Resource == entity.Resource && ft.Date == entity.Date);
            return new T()
            {
                Resource = entity.Resource.Trim().Replace('–', '-'),
                Date = entity.Date,
                IdActivity = entity.IdActivity,
                IdSituation = situation.Id,
                StartTime = entity.StartTime,
                FinalTime = entity.FinalTime,
                DurationTime = entity.DurationTime,
                TravellingTime = entity.TravellingTime,
                IdTypeOfActivity = typeOfActivity.Id,
                ActivityBookingTime = entity.ActivityBookingTime,
                EstimatedTravellingTime = entity.EstimatedTravellingTime,
                EstimatedDurationTime = entity.EstimatedDurationTime,
                IdFieldTeam = fieldteam?.Id ?? null,
                DamageToProject = typeOfActivity,
            };
        }

        private async Task<List<Domain.Entities.WorkOrderShiftInfo>> GetWorkOrderShiftInfosAsync(List<WorkOrderDTO> entities)
        {
            var tasks = entities.Select(async entity =>
            {
                var result = await GetWorkOrderBaseAsync<Domain.Entities.WorkOrderShiftInfo>(entity);
                result.ShiftStartDate = entity.ShiftStartDate;
                result.VehicleLabel = entity.VehicleLabel;
                result.IdLeaderRegistration = entity.IdLeaderRegistration;
                result.IdAuxiliaryRegistration = entity.IdAuxiliaryRegistration;
                result.IdTechnicalRegistration = entity.IdTechnicalRegistration;
                return result;
            });
            return (await Task.WhenAll(tasks)).ToList();
        }

        public override async Task<bool> AddAsync(WorkOrderDTO entity)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<int> AddRangeAsync(List<WorkOrderDTO> lista)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DeleteAsync(int id)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<int> DeleteRangeAsync(List<WorkOrderDTO> lista)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<List<WorkOrderDTO>> GetAllAsync()
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<List<WorkOrderDTO>> GetByExpressionAsync(Expression<Func<WorkOrderDTO, bool>> expression)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<WorkOrderDTO> GetByIdAsync(int id)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<bool> UpdateAsync(WorkOrderDTO entity)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<int> UpdateRangeAsync(List<WorkOrderDTO> lista)
            => throw new MethodAccessException("Método não permitido para essa entidade!");
    }
}
