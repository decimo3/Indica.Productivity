using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : GenericController<ProcessDTO, Process>
    {
        public ProcessController(IProcessService service, ILogger<ProcessController> logger) : base(service, logger)
        {
        }
    }
}
