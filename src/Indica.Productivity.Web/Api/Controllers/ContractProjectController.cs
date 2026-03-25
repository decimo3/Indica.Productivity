using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
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
