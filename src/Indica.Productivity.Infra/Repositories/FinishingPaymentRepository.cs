using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FinishingPaymentRepository : BaseRepository<FinishingPayment>, IFinishingPaymentRepository
    {
        public FinishingPaymentRepository(ProductivityContext context) : base(context) { }
    }
}
