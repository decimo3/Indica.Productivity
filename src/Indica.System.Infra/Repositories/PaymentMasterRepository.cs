using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class PaymentMasterRepository : BaseRepository<PaymentMaster>, IPaymentMasterRepository
    {
        public PaymentMasterRepository(ProductivityContext context) : base(context) {}
    }
}