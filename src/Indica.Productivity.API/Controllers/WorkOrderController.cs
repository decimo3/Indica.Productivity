using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
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
