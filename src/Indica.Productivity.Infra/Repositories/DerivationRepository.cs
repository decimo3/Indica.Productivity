using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class DerivationRepository : BaseRepository<Derivation>, IDerivationRepository
    {
        public DerivationRepository(ProductivityContext context) : base(context)
        {
        }
    }
}