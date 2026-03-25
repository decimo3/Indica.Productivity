using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMasterController : GenericController<PaymentMasterDTO, PaymentMaster>
    {
        public PaymentMasterController(IPaymentMasterService service, ILogger<PaymentMasterController> logger) : base(service, logger)
        {
        }
    }
}
