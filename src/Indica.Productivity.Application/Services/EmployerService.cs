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
        private readonly IMapper _mapper;
        private readonly IFileParser _parser;
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
            _mapper = mapper;
            _parser = parser;
            _repository = repository;
            _situationRepository = situationRepository;
        }

        public override async Task<int> AddRangeAsync(Stream file, string filename)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("O file está vazio!");

            var employers = await _repository.GetAllAsync();
            var existingIDs = employers.Select(e => e.IndicaRegistry).ToHashSet();

            var entities = _parser.ParseByFilepath<EmployerDTO>(file, filename);

            var entityMapped = _mapper.Map<List<Employer>>(entities);
            var currentIDs = entityMapped.Select(e => e.IndicaRegistry).ToHashSet();

            var employersToAdd = entityMapped
                .Where(e => !existingIDs.Contains(e.IndicaRegistry))
                .ToList();

            var employersToDel = employers
                    .Where(e => !currentIDs.Contains(e.IndicaRegistry))
                    .Select(e => new EmployerDTO() { Id = e.Id })
                    .ToList();

            await _repository.AddRangeAsync(employersToAdd);
            await this.DeleteRangeAsync(employersToDel);

            return employersToAdd.Count + employersToDel.Count;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var employer = await _repository.GetByIdAsync(id) ?? throw new ArgumentException();
            employer.Demission = DateOnly.FromDateTime(DateTime.Now);
            employer.Situation = await _situationRepository.GetByIdAsync(TERMINATED_CODE);
            await _repository.UpdateAsync(employer);
            return true;
        }

        public override async Task<int> DeleteRangeAsync(List<EmployerDTO> employersToDel)
        {
            var employers = await _repository.GetAllAsync();
            var situationID = (await _situationRepository.GetByIdAsync(TERMINATED_CODE)).Id;
            var deletingIDs = employersToDel.Select(e => e.Id).ToHashSet();
            employers = employers.Where(e => deletingIDs.Contains(e.Id)).ToList();
            employers.ForEach(e =>
            {
                e.Demission = DateOnly.FromDateTime(DateTime.Now);
                e.IdSituation = situationID;
                e.Situation = null;
                e.Function = null;
            });
            return await _repository.UpdateRangeAsync(employers);
        }
    }
}
