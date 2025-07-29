using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class PaymentService : BaseService<PaymentDTO, Payment>, IPaymentService
    {
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IFileParser parser) : base(paymentRepository, mapper, parser)
        {
        }
    }
}
