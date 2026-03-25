using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;

namespace Indica.Productivity.Web.Api.Controllers
{
    public class PaymentController : GenericController<PaymentDTO, Payment>
    {
        public PaymentController(IPaymentService service, ILogger<Payment> logger) : base(service, logger) {}
    }
}
