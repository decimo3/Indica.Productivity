using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldTeamController : GenericController<FieldTeamDTO, FieldTeam>
    {
        public FieldTeamController(IFieldTeamService service, ILogger<FieldTeamController> logger) : base(service, logger)
        {
        }
    }
}
