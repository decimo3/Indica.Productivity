using System.Linq.Expressions;
using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class WorkOrderService : BaseService<WorkOrderDTO, WorkOrderBase>, IWorkOrderService
    {
        private readonly IWorkOrderAreaRepository orderAreaRepository;
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
        private readonly IDerivationRepository derivationRepository;
        private readonly ISelectionRepository selectionRepository;
        private readonly IWorkOrderResumeRepository resumeRepository;
        private readonly IFileParser fileParser;
        public WorkOrderService
        (
            IMapper mapper, IFileParser parser,
            IWorkOrderAreaRepository orderAreaRepository,
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
            IFinishingRepository finishingRepository,
            IDerivationRepository derivationRepository,
            ISelectionRepository selectionRepository,
            IWorkOrderResumeRepository resumeRepository
        ) : base(workOrderBaseRepository, mapper, parser)
        {
            this.orderAreaRepository = orderAreaRepository;
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
            this.derivationRepository = derivationRepository;
            this.selectionRepository = selectionRepository;
            this.resumeRepository = resumeRepository;
            this.fileParser = parser;
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
                FieldTeam = fieldteam,
                DamageToProject = typeOfActivity,
                WorkOrderTotalTime = (float)(entity.DurationTime + entity.TravellingTime).TotalHours
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
                result.UnavailableReasonOrIntervalDescription += entity.UnavailableReason;
                result.UnavailableReasonOrIntervalDescription += entity.IntervalDescription;
                result.FieldTeam = null;
                result.DamageToProject = null;
                return result;
            });
            return (await Task.WhenAll(tasks)).ToList();
        }

        private static bool IfItIsAlternative(string? activity, string? project)
        {
            if (string.IsNullOrWhiteSpace(activity) || string.IsNullOrWhiteSpace(project))
                return false;
            return (activity.Contains("VISTORIADOR") && project == "ANEXO") ||
                    (activity.Contains("VISTORIADOR") && project == "LIDE") ||
                    (activity.Contains("PESADO") && project == "LIDE") ||
                    (activity == "NORMALIZAÇÃO" && project == "INSPECAO");
        }

        private async Task<List<Domain.Entities.WorkOrderService>> GetWorkOrderServiceAsync(List<WorkOrderDTO> entities)
        {
            if (entities is null || entities.Count == 0)
                throw new ArgumentException();
            var accuracies = await accuracyRepository.GetAllAsync();
            var phasing = await phaseRepository.GetAllAsync();
            var codeFilter = await codeFilterRepository.GetAllAsync();
            var workareas = await orderAreaRepository.GetAllAsync();
            var derivation = await derivationRepository.GetAllAsync();
            var selections = await selectionRepository.GetAllAsync();
            var tasks = entities.Select(async entity =>
            {
                var result = await GetWorkOrderBaseAsync<Domain.Entities.WorkOrderService>(entity);
                List<string> orderedCodes = new();
                if (!string.IsNullOrWhiteSpace(entity.ClosingCodes))
                    orderedCodes.AddRange(entity.ClosingCodes.Split(';').Order());
                if (!string.IsNullOrWhiteSpace(entity.ReasonOfRejection))
                    orderedCodes.Add(entity.ReasonOfRejection[..4]);
                var allowedCodes = codeFilter.Where(c =>
                    c.IdProject == result.DamageToProject.IdProject).Select(a => a.Code).ToList();
                var filteredCodes = string.Join(string.Empty, orderedCodes.Where(c => allowedCodes.Contains(c)).ToList());
                if (result.DamageToProject.Project.UsesDamage || string.IsNullOrWhiteSpace(filteredCodes))
                    filteredCodes = result.DamageToProject.Damage + filteredCodes;
                filteredCodes = entity.TypeOfServiceNote + filteredCodes;
                var isAlternative = IfItIsAlternative(result.FieldTeam?.Activity.ActivityName, result.DamageToProject.Project.ProjectName);
                var finishing = await finishingRepository.GetSingleOrDefaultByExpressionAsync(
                    f => f.GroupingOfMeasures == filteredCodes && f.IsAlternative == isAlternative);
                result.IdDerivation = derivation.SingleOrDefault(
                        d => result.FieldTeam?.Activity?.ActivityName?.Contains(d.DerivationName) == true)?.Id ??
                                selections.SingleOrDefault(
                                        s => entity.Description.Contains(s.SelectionPattern))?.Derivation.Id ?? 1;
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
                result.WorkOrderCostumer = new WorkOrderCostumer()
                    {
                        InstallationNumber = entity.InstallationNumber,
                        CostumerName = entity.CostumerName,
                        CostumerAddress = entity.CostumerAddress,
                        BuildingNumberOrAcronym = entity.BuildingNumberOrAcronym,
                        NumberComplement = entity.NumberComplement,
                        SubNeighborhood = entity.SubNeighborhood,
                        IdWorkOrderArea = workareas.Single(a =>
                            a.AreaNumber == entity.WorkOrderArea).Id,
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
                        IdCoordinateAccuracy = accuracies.SingleOrDefault(ac =>
                            ac.AccuracyLevel == entity.CoordinateAccuracy)?.Id ?? null
                    };
                result.FieldTeam = null;
                result.DamageToProject = null;
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
            var costumerToAdd = new List<Domain.Entities.WorkOrderCostumer>();
            var costumerToUpd = new List<Domain.Entities.WorkOrderCostumer>();
            var shiftinfoToAdd = new List<Domain.Entities.WorkOrderShiftInfo>();
            var shiftinfoToUpd = new List<Domain.Entities.WorkOrderShiftInfo>();

            var serviceDTO = lista.Where(x => x.WorkOrderNumber != 0).ToList();
            var shiftinfoDTO = lista.Where(x => x.WorkOrderNumber == 0).ToList();
            var convertedShiftInfo = await GetWorkOrderShiftInfosAsync(shiftinfoDTO);
            var convertedServices = await GetWorkOrderServiceAsync(serviceDTO);
            var convertedCostumers = convertedServices.Select(s => s.WorkOrderCostumer).ToList();

            var existingShiftInfoIds = await shiftInfoRepository
                .GetAllIdsByActivityAsync(convertedShiftInfo.Select(s => s.IdActivity).ToList());

            var existingServiceIds = await serviceRepository
                .GetAllIdsByActivityAsync(convertedServices.Select(s => s.IdActivity).ToList());

            var existingCostumerIdsAndInstallation = await costumerRepository
                .GetAllIdsByInstallationAsync(convertedServices.Select(
                    s => s.WorkOrderCostumer.InstallationNumber).ToList());

            foreach (var shiftInfo in convertedShiftInfo)
            {
                var existingShiftInfo = existingShiftInfoIds.FirstOrDefault(
                    s => s.IdActivity == shiftInfo.IdActivity);
                if (existingShiftInfo.Id != 0)
                {
                    shiftInfo.Id = (int)existingShiftInfo.Id;
                    shiftinfoToUpd.Add(shiftInfo);
                    continue;
                }
                shiftinfoToAdd.Add(shiftInfo);
            }

            foreach (var costumer in convertedCostumers)
            {
                // Remove duplicated values
                if (costumerToUpd.Any(c => c.InstallationNumber == costumer.InstallationNumber) ||
                    costumerToAdd.Any(c => c.InstallationNumber == costumer.InstallationNumber))
                    continue;
                var existingCostumer = existingCostumerIdsAndInstallation.FirstOrDefault(
                    c => c.InstallationNumber == costumer.InstallationNumber);
                if (existingCostumer.Id != 0)
                {
                    costumer.Id = (int)existingCostumer.Id;
                    costumerToUpd.Add(costumer);
                    continue;
                }
                costumerToAdd.Add(costumer);
            }

            await costumerRepository.UpdateRangeAsync(costumerToUpd);
            await costumerRepository.AddRangeAsync(costumerToAdd);

            existingCostumerIdsAndInstallation = await costumerRepository
                .GetAllIdsByInstallationAsync(convertedServices.Select(
                    s => s.WorkOrderCostumer.InstallationNumber).ToList());

            foreach (var service in convertedServices)
            {
                service.IdCostumer = (int)existingCostumerIdsAndInstallation.Single(
                    c => c.InstallationNumber == service.WorkOrderCostumer!.InstallationNumber).Id;
                service.WorkOrderCostumer = null;
                var existingService = existingServiceIds.FirstOrDefault(
                    s => s.IdActivity == service.IdActivity);
                if (existingService.Id != 0)
                {
                    service.Id = (int)existingService.Id;
                    serviceToUpd.Add(service);
                    continue;
                }
                serviceToAdd.Add(service);
            }

            await shiftInfoRepository.UpdateRangeAsync(shiftinfoToUpd);
            await shiftInfoRepository.AddRangeAsync(shiftinfoToAdd);
            await serviceRepository.UpdateRangeAsync(serviceToUpd);
            await serviceRepository.AddRangeAsync(serviceToAdd);

            return lista.Count;
        }

        public override async Task<int> AddRangeAsync(Stream stream, String filename)
        {
            if (stream == null || stream.Length == 0)
                throw new InvalidOperationException(
                        "O arquivo enviado está vazio!");
            var entities = fileParser.ParseByFilepath<WorkOrderDTO>(stream, filename);

            entities.ForEach(e => e.Filename = filename);

            await this.AddRangeAsync(entities);

            var resume = (await resumeRepository.GetByExpressionAsync(
                    x => x.Filename == filename)).FirstOrDefault() ?? new WorkOrderResume();

            resume.Filename = filename;
            resume.ResourceCount = entities.DistinctBy(x => x.Resource).Count();
            resume.ServiceCount = entities.Where(x => x.WorkOrderNumber > 0).Count();

            if (resume.Id == 0)
                await resumeRepository.AddAsync(resume);
            else
                await resumeRepository.UpdateAsync(resume);

            return entities.Count;
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

        public async Task<List<WorkOrderResumeDTO>> GetResumeAsync(int page)
        {
            var entities = await resumeRepository.GetPagedAndFilteredByExpressionAsync(page);
            return entities.Select(x => new WorkOrderResumeDTO
            {
                Id = x.Id,
                Filename = x.Filename,
                ResourcesCount = x.ResourceCount,
                ServiceCount = x.ServiceCount
            }).ToList();
        }
    }
}
