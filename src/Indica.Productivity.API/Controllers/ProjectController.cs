using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : GenericController<ProjectDTO, Project>
    {
        public ProjectController(IProjectService service, ILogger<ProjectController> logger) : base(service, logger)
        {
        }
    }
}
