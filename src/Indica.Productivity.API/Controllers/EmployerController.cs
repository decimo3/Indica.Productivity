using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
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