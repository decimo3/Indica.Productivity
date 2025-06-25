using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class DamageToProcessRepository : BaseRepository<DamageToProcess>, IDamageToProcessRepository
    {
        public DamageToProcessRepository(ProductivityContext context) : base(context) {}
    }
}