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
                dm => dm.Damage == dano || dm.Description == entity.TypeOfActivity ||
                (dm.Damage + " - " + dm.Description) == entity.TypeOfActivity) ??
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

        private async Task<List<Domain.Entities.WorkOrderService>> GetWorkOrderServiceAsync(List<WorkOrderDTO> entities)
        {
            if (entities is null || entities.Count == 0)
                throw new ArgumentException();
            var accuracies = await accuracyRepository.GetAllAsync();
            var phasing = await phaseRepository.GetAllAsync();
            var codeFilter = await codeFilterRepository.GetAllAsync();
            var tasks = entities.Select(async entity =>
            {
                var result = await GetWorkOrderBaseAsync<Domain.Entities.WorkOrderService>(entity);
                var orderedCodes = entity.ClosingCodes.Split(';').Order().ToList();
                var allowedCodes = codeFilter.Where(c =>
                    c.IdProject == result.DamageToProject.IdProject).Select(a => a.Code).ToList();
                var filteredCodes = string.Join(string.Empty, orderedCodes.Where(c => allowedCodes.Contains(c)).ToList());
                var finishing = await finishingRepository.GetSingleOrDefaultByExpressionAsync(
                    f => f.GroupingOfMeasures == filteredCodes);
                result.WorkOrderNumber = entity.WorkOrderNumber;
                result.StartOfSLA = entity.StartOfSLA;
                result.FinalOfSLA = entity.FinalOfSLA;
                result.WorkOrderAbility = entity.WorkOrderAbility;
                result.ClosingCodes = string.Join(';', orderedCodes);
                result.IsLgCtrlTypeClosingOk = entity.IsLgCtrlTypeClosingOk;
                result.IsClosedCodesFilledIn = entity.IsClosedCodesFilledIn;
                result.Observation = entity.Observation;
                result.Description = entity.Description;
                result.IsLgFlagPrefillimentoClosing = entity.IsLgFlagPrefillimentoClosing;
                result.ParentActivityClosingCodesV03 = entity.ParentActivityClosingCodesV03;
                result.IsLgCtrlReprovedFlag = entity.IsLgCtrlReprovedFlag;
                result.TypeOfServiceNote = entity.TypeOfServiceNote;
                result.BucketOrigin = entity.BucketOrigin;
                result.TotalCustomerDebts = entity.TotalCustomerDebts;
                result.HasCustomerSignedToi = entity.HasCustomerSignedToi;
                result.HasRefusedToSignToi = entity.HasRefusedToSignToi;
                result.HasRefusedToReceiveToi = entity.HasRefusedToReceiveToi;
                result.CustomerAuthorizedloadAnalysis = entity.CustomerAuthorizedloadAnalysis;
                result.ScopeOfService = entity.ScopeOfService;
                result.CHI = entity.CHI;
                result.InterruptedTime = entity.InterruptedTime;
                result.FinancialCompensationAmount = entity.FinancialCompensationAmount;
                result.IdFinishing = finishing?.Id ?? null;
                result.WorkOrderCostumer = await costumerRepository.GetSingleOrDefaultByExpressionAsync(
                    c => c.InstallationNumber == entity.InstallationNumber) ?? new WorkOrderCostumer
                    {
                        InstallationNumber = entity.InstallationNumber,
                        CostumerName = entity.CostumerName,
                        CostumerAddress = entity.CostumerAddress,
                        BuildingNumberOrAcronym = entity.BuildingNumberOrAcronym,
                        NumberComplement = entity.NumberComplement,
                        SubNeighborhood = entity.SubNeighborhood,
                        WorkAreaNumber = entity.WorkOrderArea,
                        CostumerCity = entity.CostumerCity,
                        CostumerState = entity.CostumerState,
                        CostumerPostalCode = entity.CostumerPostalCode,
                        CostumerTelephone = entity.CostumerTelephone,
                        CostumerCellphone = entity.CostumerCellphone,
                        CostumerEmail = entity.CostumerEmail,
                        IsFoundCoordinateStatus = entity.IsFoundCoordinateStatus,
                        CoordinateX = entity.CoordinateX,
                        CoordinateY = entity.CoordinateY,
                        IdConnectionType = phasing.Single(ph =>
                            ph.PhaseName == entity.ConnectionType).Id,
                        IdCoordinateAccuracy = accuracies.Single(ac =>
                            ac.AccuracyLevel == entity.CoordinateAccuracy).Id
                    };
                return result;
            });
            return (await Task.WhenAll(tasks)).ToList();
        }

        public override async Task<bool> AddAsync(WorkOrderDTO entity)
            => throw new MethodAccessException("Método não permitido para essa entidade!");

        public override async Task<int> AddRangeAsync(List<WorkOrderDTO> lista)
        {
            var serviceToAdd = new List<Domain.Entities.WorkOrderService>();
            var serviceToUpd = new List<Domain.Entities.WorkOrderService>();
            var shiftinfoToAdd = new List<Domain.Entities.WorkOrderShiftInfo>();
            var shiftinfoToUpd = new List<Domain.Entities.WorkOrderShiftInfo>();

            var serviceDTO = lista.Where(x => x.WorkOrderNumber != 0).ToList();
            var shiftinfoDTO = lista.Where(x => x.WorkOrderNumber == 0).ToList();
            var convertedShiftInfo = await GetWorkOrderShiftInfosAsync(shiftinfoDTO);
            var convertedServices = await GetWorkOrderServiceAsync(serviceDTO);

            var existingShiftInfoIds = await shiftInfoRepository
                .GetAllIdsByActivityAsync(convertedShiftInfo.Select(s => s.IdActivity).ToList());

            var existingServiceIds = await serviceRepository
                .GetAllIdsByActivityAsync(convertedServices.Select(s => s.IdActivity).ToList());

            foreach (var shiftInfo in convertedShiftInfo)
            {
                if (existingShiftInfoIds.Contains(shiftInfo.IdActivity))
                    shiftinfoToUpd.Add(shiftInfo);
                else
                    shiftinfoToAdd.Add(shiftInfo);
            }

            foreach (var service in convertedServices)
            {
                if (existingServiceIds.Contains(service.Id))
                    serviceToUpd.Add(service);
                else
                    serviceToAdd.Add(service);
            }

            await shiftInfoRepository.UpdateRangeAsync(shiftinfoToUpd);
            await shiftInfoRepository.AddRangeAsync(shiftinfoToAdd);
            await serviceRepository.UpdateRangeAsync(serviceToUpd);
            await serviceRepository.AddRangeAsync(serviceToAdd);

            return lista.Count;
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
