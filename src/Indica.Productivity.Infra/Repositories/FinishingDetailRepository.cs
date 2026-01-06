using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FinishingDetailRepository : BaseRepository<FinishingDetail>, IFinishingDetailRepository
    {
        public FinishingDetailRepository(ProductivityContext context) : base(context) {}
    }
}