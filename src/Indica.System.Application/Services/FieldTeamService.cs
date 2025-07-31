using System.Linq.Expressions;
using AutoMapper;
using Indica.System.Application.Common;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class FieldTeamService : IBaseService<FieldTeamDTO, FieldTeam>, IFieldTeamService
    {
        private readonly IFileParser _parser;
        private readonly IFieldTeamRepository _fieldTeamRepository;
        private readonly IFieldTeamRegionalRepository _regionalRepository;
        private readonly IFieldTeamFunctionRepository _functionRepository;
        private readonly IActivityRepository _activityRepository;
        public FieldTeamService
        (
            IFileParser parser,
            IFieldTeamRepository fieldTeamRepository,
            IFieldTeamRegionalRepository regionalRepository,
            IFieldTeamFunctionRepository functionRepository,
            IActivityRepository activityRepository
        )
        {
            _parser = parser;
            _fieldTeamRepository = fieldTeamRepository;
            _regionalRepository = regionalRepository;
            _functionRepository = functionRepository;
            _activityRepository = activityRepository;
        }

        public async Task<bool> AddAsync(FieldTeamDTO entity)
        {
            var fieldteam = (await _fieldTeamRepository.GetByExpression(f =>
                f.Resource == entity.Resource && f.Date == entity.Date)).FirstOrDefault();
            if (fieldteam is not null)
                throw new Exception("Já existe um registro para este recurso e data!");
            var region = (await _regionalRepository.GetByExpression(r =>
                r.RegionName == entity.WorkArea)).Single();
            var activity = (await _activityRepository.GetByExpression(a =>
                a.ActivityName == entity.ActivityName)).Single();
            var functions = await _functionRepository.GetAllAsync();
            if (functions is null || functions.Count == 0)
                throw new Exception("Tabela função está vazia!");
            fieldteam = new FieldTeam()
            {
                Date = entity.Date,
                Order = entity.Order,
                Plate = entity.Plate,
                IdActivity = activity.Id,
                Resource = entity.Resource,
                Cellphone = entity.Cellphone,
                IdRegion = region.Id,
                Couples = 
                [
                    new FieldTeamCouple()
                    {
                        IdEmployer = entity.EmployerRegistry1,
                        IdFunction = functions.Where(f =>
                            f.FunctionName == "executor1").Single().Id
                    },
                    new FieldTeamCouple()
                    {
                        IdEmployer = entity.EmployerRegistry2,
                        IdFunction = functions.Where(f =>
                            f.FunctionName == "executor2").Single().Id
                    },
                    new FieldTeamCouple()
                    {
                        IdEmployer = entity.SupervisorRegistry,
                        IdFunction = functions.Where(f =>
                            f.FunctionName == "supervisor").Single().Id    
                    }
                ]
            };
            await _fieldTeamRepository.AddAsync(fieldteam);
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

        public Task<List<FieldTeamDTO>> GetByExpression(Expression<Func<FieldTeamDTO, bool>> expression)
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
