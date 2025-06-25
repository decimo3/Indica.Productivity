using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class ObjectiveRepository : BaseRepository<Objective>, IObjectiveRepository
    {
        public ObjectiveRepository(ProductivityContext context) : base(context) {}
    }
}