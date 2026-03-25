using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.Web.Api.Controllers
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
