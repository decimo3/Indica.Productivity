using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DamageToProjectController : GenericController<DamageToProjectDTO, DamageToProject>
    {
        public DamageToProjectController(IDamageToProjectService service, ILogger<DamageToProjectController> logger) : base(service, logger)
        {
        }
    }
}
