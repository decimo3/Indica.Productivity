using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrderController : GenericController<WorkOrderDTO, WorkOrderBase>
    {
        public WorkOrderController(IWorkOrderService service, ILogger<WorkOrderController> logger) : base(service, logger)
        {
        }
    }
}
