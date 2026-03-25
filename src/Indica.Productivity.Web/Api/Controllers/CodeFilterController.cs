using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeFilterController : GenericController<CodeFilterDTO, CodeFilter>
    {
        public CodeFilterController(ICodeFilterService service, ILogger<CodeFilterController> logger) : base(service, logger)
        {
        }
    }
}
