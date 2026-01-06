using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FieldTeamFunctionRepository : BaseRepository<FieldTeamFunction>, IFieldTeamFunctionRepository
    {
        public FieldTeamFunctionRepository(ProductivityContext context) : base(context) {}
    }
}