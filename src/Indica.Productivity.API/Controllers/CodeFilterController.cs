using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
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
