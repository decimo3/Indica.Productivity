using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;
using System.Linq.Expressions;

namespace Indica.System.Application.Services
{
    public class FieldTeamService : IBaseService<FieldTeamDTO, FieldTeam>, IFieldTeamService
    {
        private readonly IFileParser _parser;
        private readonly IActivityRepository _activityRepository;
        private readonly IFieldTeamRepository _fieldteamRepository;
        private readonly IFieldTeamCoupleRepository _coupleRepository;
        private readonly IFieldTeamRegionalRepository _regionalRepository;
        private readonly IFieldTeamFunctionRepository _functionRepository;
        public FieldTeamService
        (
            IFileParser parser,
            IActivityRepository activityRepository,
            IFieldTeamRepository fieldteamRepository,
            IFieldTeamCoupleRepository coupleRepository,
            IFieldTeamRegionalRepository regionalRepository,
            IFieldTeamFunctionRepository functionRepository
        )
        {
            _parser = parser;
            _activityRepository = activityRepository;
            _fieldteamRepository = fieldteamRepository;
            _coupleRepository = coupleRepository;
            _regionalRepository = regionalRepository;
            _functionRepository = functionRepository;
        }
        public async Task<bool> AddAsync(FieldTeamDTO entity)
        {
            throw new NotImplementedException();
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
