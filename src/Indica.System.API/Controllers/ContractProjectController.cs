using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractProjectController : GenericController<ContractProjectDTO, ContractProject>
    {
        public ContractProjectController(IContractProjectService service, ILogger<ContractProjectController> logger) : base(service, logger)
        {
        }
    }
}
