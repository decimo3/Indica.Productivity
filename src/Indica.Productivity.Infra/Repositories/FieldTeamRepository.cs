using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FieldTeamRepository : BaseRepository<FieldTeam>, IFieldTeamRepository
    {
        public FieldTeamRepository(ProductivityContext context) : base(context) {}
    }
}