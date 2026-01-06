using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FieldTeamFunctionRepository : BaseRepository<FieldTeamFunction>, IFieldTeamFunctionRepository
    {
        public FieldTeamFunctionRepository(ProductivityContext context) : base(context) {}
    }
}