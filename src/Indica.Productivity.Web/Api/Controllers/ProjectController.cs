using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.Web.Api.Controllers
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
