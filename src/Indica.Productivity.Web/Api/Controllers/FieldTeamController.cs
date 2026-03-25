using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
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
