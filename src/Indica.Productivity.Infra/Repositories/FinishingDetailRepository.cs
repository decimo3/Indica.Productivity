using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FinishingDetailRepository : BaseRepository<FinishingDetail>, IFinishingDetailRepository
    {
        public FinishingDetailRepository(ProductivityContext context) : base(context) {}
    }
}