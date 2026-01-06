using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ProductivityContext context) : base(context) { }
    }
}
