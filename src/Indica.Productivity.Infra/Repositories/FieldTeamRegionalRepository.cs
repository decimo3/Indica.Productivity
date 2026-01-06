using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FieldTeamRegionalRepository : BaseRepository<FieldTeamRegional>, IFieldTeamRegionalRepository
    {
        public FieldTeamRegionalRepository(ProductivityContext context) : base(context) {}
    }
}