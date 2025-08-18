using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;
using System.Linq.Expressions;

namespace Indica.System.Application.Services
{
    public class FieldTeamService : BaseService<FieldTeamDTO, FieldTeam>, IFieldTeamService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IFieldTeamRepository _fieldteamRepository;
        private readonly IFieldTeamRegionalRepository _regionalRepository;
        private readonly IFieldTeamFunctionRepository _functionRepository;
        public FieldTeamService
        (
            IMapper mapper,
            IFileParser parser,
            IActivityRepository activityRepository,
            IEmployerRepository employerRepository,
            IFieldTeamRepository fieldteamRepository,
            IFieldTeamRegionalRepository regionalRepository,
            IFieldTeamFunctionRepository functionRepository
        ) : base(fieldteamRepository, mapper, parser)
        {
            _activityRepository = activityRepository;
            _employerRepository = employerRepository;
            _fieldteamRepository = fieldteamRepository;
            _regionalRepository = regionalRepository;
            _functionRepository = functionRepository;
        }
        private async Task<FieldTeamRegional> GetRegionalAsync(string name)
        {
            return await _regionalRepository.GetSingleOrDefaultByExpressionAsync(r => r.RegionName == name.ToUpper()) ??
                throw new InvalidOperationException($"A regional {name} não foi encontrada!");
        }
        private async Task<FieldTeamCouple> GetCoupleAsync(int registry, string name, int function)
        {
            var employer = await _employerRepository.GetSingleOrDefaultByExpressionAsync(e => e.ClientRegistry == registry) ??
                throw new InvalidOperationException($"A matrícula {registry} não foi encontrada!");
            if (!employer.FullName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException($"O nome {name} não condiz com a matrícula!");
            if (employer.Demission is not null)
                throw new InvalidOperationException($"O funcionário {name} foi desligado!");
            return new FieldTeamCouple() { IdEmployer = employer.Id, IdFunction = function };
        }
        private async Task<List<FieldTeam>> GetFieldTeamAsync(List<FieldTeamDTO> entities)
        {
            if (entities is null || entities.Count == 0)
                throw new ArgumentException();
            var regional = await GetRegionalAsync(entities.First().WorkArea);
            var activities = await _activityRepository.GetAllAsync();
            var tasks = entities.Select(async entity =>
            {
                return new FieldTeam
                {
                    Date = entity.Date,
                    Order = entity.Order,
                    Plate = entity.Plate,
                    Resource = entity.Resource,
                    Cellphone = entity.Cellphone,
                    IdActivity = activities.Single(y => y.ActivityName == entity.ActivityName).Id,
                    IdRegion = regional.Id,
                    Couples = [
                        await GetCoupleAsync(entity.EmployerRegistry1, entity.EmployerName1, 2),
                        await GetCoupleAsync(entity.EmployerRegistry2, entity.EmployerName2, 3),
                        await GetCoupleAsync(entity.SupervisorRegistry, entity.SupervisorName, 1)
                    ],
                    IsConsidered = true
                };
            });
            return (await Task.WhenAll(tasks)).ToList();
        }
        public override async Task<bool> AddAsync(FieldTeamDTO entity)
        {
            var converted = await GetFieldTeamAsync([entity]);
            return await _fieldteamRepository.AddAsync(converted.Single());
        }
        public override async Task<int> AddRangeAsync(List<FieldTeamDTO> lista)
        {
            throw new NotImplementedException();
        }
        public override async Task<bool> UpdateAsync(FieldTeamDTO entity)
        {
            throw new NotImplementedException();
        }
        public override async Task<int> UpdateRangeAsync(List<FieldTeamDTO> lista)
        {
            throw new NotImplementedException();
        }
    }
}
