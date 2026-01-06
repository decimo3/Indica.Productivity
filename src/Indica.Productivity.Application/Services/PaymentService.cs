using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class PaymentService : BaseService<PaymentDTO, Payment>, IPaymentService
    {
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IFileParser parser) : base(paymentRepository, mapper, parser)
        {
        }
    }
}
