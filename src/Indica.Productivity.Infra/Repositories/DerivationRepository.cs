using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class DerivationRepository : BaseRepository<Derivation>, IDerivationRepository
    {
        public DerivationRepository(ProductivityContext context) : base(context)
        {
        }
    }
}