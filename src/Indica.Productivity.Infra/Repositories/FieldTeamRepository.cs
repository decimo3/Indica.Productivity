using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FieldTeamRepository : BaseRepository<FieldTeam>, IFieldTeamRepository
    {
        public FieldTeamRepository(ProductivityContext context) : base(context) {}
    }
}