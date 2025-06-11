using Indica.System.Domain.Entities;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;

namespace Indica.System.API.Controllers
{
    public class PaymentController : GenericController<PaymentDTO, Payment>
    {
        public PaymentController(IPaymentService service, ILogger<Payment> logger) : base(service, logger) {}
    }
}
