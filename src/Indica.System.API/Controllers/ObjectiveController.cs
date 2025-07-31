using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
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
