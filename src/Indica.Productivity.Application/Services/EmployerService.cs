using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class EmployerService : BaseService<EmployerDTO, Employer>, IEmployerService
    {
        private static readonly int TERMINATED_CODE = 5;
        private readonly IEmployerRepository _repository;
        private readonly IEmployerSituationRepository _situationRepository;
        public EmployerService
        (
            IMapper mapper,
            IFileParser parser,
            IEmployerRepository repository,
            IEmployerSituationRepository situationRepository
        ) : base(repository, mapper, parser)
        {
            _repository = repository;
            _situationRepository = situationRepository;
        }
        public override async Task<bool> DeleteAsync(int id)
        {
            var employer = await _repository.GetByIdAsync(id) ?? throw new ArgumentException();
            employer.Demission = DateOnly.FromDateTime(DateTime.Now);
            employer.Situation = await _situationRepository.GetByIdAsync(TERMINATED_CODE);
            await _repository.UpdateAsync(employer);
            return true;
        }
    }
}
