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
        public async Task<bool> AddAsync(FieldTeamDTO entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var erros = entity.Validate();
            if (erros.Count != 0)
                throw new InvalidOperationException("Há erros de validação na informação enviada!");
            var regional = await _regionalRepository.GetSingleOrDefaultByExpressionAsync(
                r => r.RegionName == entity.WorkArea) ??
                    throw new InvalidOperationException("A regional informada não foi encontrada!");
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
                    new FieldTeamCouple()
                    {
                        IdEmployer = employers.Single(e =>
                            e.ClientRegistry == entity.EmployerRegistry1).Id,
                        IdFunction = functions.Where(f =>
                            f.FunctionName == "executor1").Single().Id,
                    },
                    new FieldTeamCouple()
                    {
                        IdEmployer = employers.Single(e =>
                            e.ClientRegistry == entity.EmployerRegistry2).Id,
                        IdFunction = functions.Where(f =>
                            f.FunctionName == "executor2").Single().Id,
                    },
                    new FieldTeamCouple()
                    {
                        IdEmployer = employers.Single(e =>
                            e.ClientRegistry == entity.SupervisorRegistry).Id,
                        IdFunction = functions.Where(f =>
                            f.FunctionName == "supervisor").Single().Id,
                    }
                ]};
            await _fieldteamRepository.AddAsync(fieldteam);
            return true;
        }
        public Task<int> AddRangeAsync(List<FieldTeamDTO> lista)
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
        public Task<int> DeleteRangeAsync(List<FieldTeamDTO> lista)
        {
            throw new NotImplementedException();
        }
        public Task<List<FieldTeamDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<FieldTeamDTO>> GetByExpressionAsync(Expression<Func<FieldTeamDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public Task<FieldTeamDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateAsync(FieldTeamDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateRangeAsync(List<FieldTeamDTO> lista)
        {
            throw new NotImplementedException();
        }
    }
}
