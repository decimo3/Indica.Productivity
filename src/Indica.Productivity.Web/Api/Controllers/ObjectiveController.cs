using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectiveController : GenericController<ObjectiveDTO, Objective>
    {
        public ObjectiveController(IObjectiveService service, ILogger<ObjectiveController> logger) : base(service, logger)
        {
        }
    }
}
