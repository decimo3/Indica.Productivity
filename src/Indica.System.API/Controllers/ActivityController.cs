using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : GenericController<ActivityDTO, Activity>
    {
        public ActivityController(IActivityService service, ILogger<ActivityController> logger) : base(service, logger)
        {
        }
    }
}
