using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class PaymentMasterRepository : BaseRepository<PaymentMaster>, IPaymentMasterRepository
    {
        public PaymentMasterRepository(ProductivityContext context) : base(context) {}
    }
}