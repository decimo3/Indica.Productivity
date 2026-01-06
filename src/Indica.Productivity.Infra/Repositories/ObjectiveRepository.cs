using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class ObjectiveRepository : BaseRepository<Objective>, IObjectiveRepository
    {
        public ObjectiveRepository(ProductivityContext context) : base(context) {}
    }
}