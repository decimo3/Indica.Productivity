using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinishingController : GenericController<FinishingDTO, Finishing>
    {
        public FinishingController(IFinishingService service, ILogger<FinishingController> logger) : base(service, logger)
        {
        }
    }
}
