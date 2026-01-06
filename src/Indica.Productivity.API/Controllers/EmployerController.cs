using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerController : GenericController<EmployerDTO, Employer>
    {
        public EmployerController(IEmployerService service, ILogger<EmployerController> logger) : base(service, logger)
        {
        }
    }
}