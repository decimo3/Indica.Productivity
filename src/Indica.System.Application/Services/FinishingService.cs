using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class FinishingPaymentService : BaseService<FinishingPaymentDTO, FinishingPayment>, IFinishingPaymentService
    {
        public FinishingPaymentService(IFinishingPaymentRepository repository, IMapper mapper, IFileParser parser) : base(repository, mapper, parser) { }
    }
}
