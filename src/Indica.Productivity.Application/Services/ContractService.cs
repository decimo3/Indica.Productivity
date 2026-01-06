using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class ContractService : BaseService<ContractDTO, Contract>, IContractService
    {
        public ContractService(IContractRepository repository, IMapper mapper, IFileParser parser) : base(repository, mapper, parser)
        {

        }
    }
}
