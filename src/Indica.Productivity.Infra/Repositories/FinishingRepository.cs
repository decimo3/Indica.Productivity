using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FinishingRepository : BaseRepository<Finishing>, IFinishingRepository
    {
        public FinishingRepository(ProductivityContext context) : base(context) { }
    }
}
