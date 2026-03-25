using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : GenericController<ContractDTO, Contract>
    {
        public ContractController(IContractService service, ILogger<ContractController> logger) : base(service, logger)
        {
        }
    }
}
