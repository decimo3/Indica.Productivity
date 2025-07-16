using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class FieldTeamCoupleRepository : BaseRepository<FieldTeamCouple>, IFieldTeamCoupleRepository
    {
        public FieldTeamCoupleRepository(ProductivityContext context) : base(context) {}
    }
}