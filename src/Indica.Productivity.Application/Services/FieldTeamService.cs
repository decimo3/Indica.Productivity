using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;
using System.Linq.Expressions;

namespace Indica.Productivity.Application.Services
{
    public class FieldTeamService : BaseService<FieldTeamDTO, FieldTeam>, IFieldTeamService
    {
        private readonly IFileParser _parser;
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
            _parser = parser;
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
            var dates = entities.GroupBy(e => e.Date)
                .Select(group => new { Key = group.Key, Count = group.Count() });
            if (dates.Count() != 1)
                throw new InvalidOperationException("Mais de uma data na planilha!");
            var regional = await GetRegionalAsync(entities.First().WorkArea);
            var activities = await _activityRepository.GetAllAsync();
            var tasks = entities.Select(async entity =>
            {
                var activity = activities.Single(a => a.ActivityName == entity.ActivityName) ??
                    throw new InvalidOperationException($"A atividade {entity.ActivityName} não foi encontrada!");
                var couples = new List<FieldTeamCouple>
                {
                    await GetCoupleAsync(entity.SupervisorRegistry, entity.SupervisorName, 1),
                    await GetCoupleAsync(entity.EmployerRegistry1, entity.EmployerName1, 2)
                };
                if (!entity.ActivityName.Contains("VISTORIADOR"))
                    couples.Add(await GetCoupleAsync(entity.EmployerRegistry2, entity.EmployerName2, 3));
                return new FieldTeam
                {
                    Date = entity.Date,
                    Order = entity.Order,
                    Plate = entity.Plate,
                    Resource = entity.Resource,
                    Cellphone = entity.Cellphone,
                    IdActivity = activity.Id,
                    IdRegion = regional.Id,
                    Couples = couples,
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
            var converted = await GetFieldTeamAsync(lista);
            return await _fieldteamRepository.AddRangeAsync(converted);
        }
        public override async Task<bool> UpdateAsync(FieldTeamDTO entity)
        {
            var converted = await GetFieldTeamAsync([entity]);
            return await _fieldteamRepository.UpdateAsync(converted.Single());
        }
        public override async Task<int> UpdateRangeAsync(List<FieldTeamDTO> lista)
        {
            var converted = await GetFieldTeamAsync(lista);
            return await _fieldteamRepository.UpdateRangeAsync(converted);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var fieldteam = await _fieldteamRepository.GetByIdAsync(id) ?? throw new ArgumentException();
            fieldteam.IsConsidered = false;
            await _fieldteamRepository.UpdateAsync(fieldteam);
            return true;
        }

        public override async Task<int> AddRangeAsync(Stream file, string filename)
        {
            if (file == null || file.Length == 0) throw new ArgumentException("O file está vazio!");

            var entities = _parser.ParseByFilepath<FieldTeamDTO>(file, filename);

            var converted = await GetFieldTeamAsync(entities);

            return await _fieldteamRepository.UpdateRangeAsync(converted);
        }
    }
}
