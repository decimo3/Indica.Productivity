using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class ContractProjectService : BaseService<ContractProjectDTO, ContractProject>, IContractProjectService
    {
        private readonly IContractRepository contractRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IDerivationRepository derivationRepository;
        private readonly IFieldTeamRegionalRepository regionalRepository;
        private readonly IContractProjectRepository contractProjectRepository;
        public ContractProjectService
        (
            IMapper mapper,
            IFileParser parser,
            IContractRepository contractRepository,
            IProjectRepository projectRepository,
            IDerivationRepository derivationRepository,
            IFieldTeamRegionalRepository regionalRepository,
            IContractProjectRepository contractProjectRepository
        ) : base(contractProjectRepository, mapper, parser)
        {
            this.contractRepository = contractRepository;
            this.projectRepository = projectRepository;
            this.derivationRepository = derivationRepository;
            this.regionalRepository = regionalRepository;
            this.contractProjectRepository = contractProjectRepository;
        }
        private async Task<List<ContractProject>> GetContractProject(List<ContractProjectDTO> entities)
        {
            var contracts = await contractRepository.GetAllAsync();
            var projects = await projectRepository.GetAllAsync();
            var derivations = await derivationRepository.GetAllAsync();
            var regions = await regionalRepository.GetAllAsync();
            var tasks = entities.Select(async e =>
            {
                return new ContractProject
                {
                    IdContract = contracts.Single(c => c.ContractNumber == e.Contract && c.AdditiveNumber == e.Additive).Id,
                    IdProject = projects.Single(p => p.ProjectName == e.Project).Id,
                    IdDerivation = derivations.Single(d => d.DerivationName == e.Derivation).Id,
                    IdRegional = regions.Single(r => r.RegionName == e.Regional).Id
                };
            });
            return (await Task.WhenAll(tasks)).ToList();
        }
        public override async Task<bool> AddAsync(ContractProjectDTO entity)
        {
            var convertedEntities = await GetContractProject([entity]);
            return await contractProjectRepository.AddAsync(convertedEntities.Single());
        }
        public override async Task<int> AddRangeAsync(List<ContractProjectDTO> entities)
        {
            var convertedEntities = await GetContractProject(entities);
            return await contractProjectRepository.AddRangeAsync(convertedEntities);
        }
        public override async Task<bool> UpdateAsync(ContractProjectDTO entity)
        {
            var convertedEntities = await GetContractProject([entity]);
            return await contractProjectRepository.UpdateAsync(convertedEntities.Single());
        }
        public override async Task<int> UpdateRangeAsync(List<ContractProjectDTO> entities)
        {
            var convertedEntities = await GetContractProject(entities);
            return await contractProjectRepository.UpdateRangeAsync(convertedEntities);
        }
    }
}