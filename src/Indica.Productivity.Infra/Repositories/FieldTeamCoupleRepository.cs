using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class FieldTeamCoupleRepository : BaseRepository<FieldTeamCouple>, IFieldTeamCoupleRepository
    {
        public FieldTeamCoupleRepository(ProductivityContext context) : base(context) {}
    }
}