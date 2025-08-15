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
        public override async Task<bool> AddAsync(FieldTeamDTO entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var erros = entity.Validate();
            if (erros.Count != 0)
                throw new InvalidOperationException("Há erros de validação na informação enviada!");
            var regional = await GetRegionalAsync(entity.WorkArea);
            var activity = await _activityRepository.GetSingleOrDefaultByExpressionAsync(
                a => a.ActivityName == entity.ActivityName) ??
                    throw new InvalidOperationException("A atividade informada não foi encontrada!");
            var functions = await _functionRepository.GetAllAsync() ??
                throw new InvalidOperationException("A tabela de funções da composição está vazia!");
            var employers = await _employerRepository.GetByExpressionAsync(e =>
                e.ClientRegistry == entity.EmployerRegistry1 ||
                e.ClientRegistry == entity.EmployerRegistry2 ||
                e.ClientRegistry == entity.SupervisorRegistry
            );
            if (employers.Count != 3)
                throw new InvalidOperationException("Não foram encontrados todos os funcionarios");
            
            var fieldteam = new FieldTeam()
            {
                Date = entity.Date,
                Order = entity.Order,
                Plate = entity.Plate,
                Resource = entity.Resource,
                Cellphone = entity.Cellphone,
                IdActivity = activity.Id,
                IdRegion = regional.Id,
                Couples = [
                    await GetCoupleAsync(entity.EmployerRegistry1, entity.EmployerName1, 2),
                    await GetCoupleAsync(entity.EmployerRegistry2, entity.EmployerName2, 3),
                    await GetCoupleAsync(entity.SupervisorRegistry, entity.SupervisorName, 1)
                ],
                IsConsidered = true
            };
            await _fieldteamRepository.AddAsync(fieldteam);
            return true;
        }
        public override async Task<int> AddRangeAsync(List<FieldTeamDTO> lista)
        {
            throw new NotImplementedException();
        }
        public override async Task<int> AddRangeAsync(Stream arquivo, string filename)
        {
            throw new NotImplementedException();
        }
        public override async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public override async Task<int> DeleteRangeAsync(List<FieldTeamDTO> lista)
        {
            throw new NotImplementedException();
        }
        public override async Task<List<FieldTeamDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public override async Task<List<FieldTeamDTO>> GetByExpressionAsync(Expression<Func<FieldTeamDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public override async Task<FieldTeamDTO> GetByIdAsync(int id)
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
