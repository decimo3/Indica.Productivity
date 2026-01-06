using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FinishingRepository : BaseRepository<Finishing>, IFinishingRepository
    {
        public FinishingRepository(ProductivityContext context) : base(context) { }
    }
}
