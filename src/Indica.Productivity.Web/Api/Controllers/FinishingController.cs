using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.Web.Api.Controllers
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
