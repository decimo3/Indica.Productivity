using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FinishingPaymentRepository : BaseRepository<FinishingPayment>, IFinishingPaymentRepository
    {
        public FinishingPaymentRepository(ProductivityContext context) : base(context) { }
    }
}
