using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FieldTeamRegionalRepository : BaseRepository<FieldTeamRegional>, IFieldTeamRegionalRepository
    {
        public FieldTeamRegionalRepository(ProductivityContext context) : base(context) {}
    }
}