using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
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
