using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class ContractService : BaseService<ContractDTO, Contract>, IContractService
    {
        public ContractService(IContractRepository repository, IMapper mapper, IFileParser parser) : base(repository, mapper, parser)
        {

        }
    }
}
