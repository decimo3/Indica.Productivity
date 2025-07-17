using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class WorkOrderAbilitiesRepository : BaseRepository<WorkOrderAbilities>, IWorkOrderAbilitiesRepository
    {
        public WorkOrderAbilitiesRepository(ProductivityContext context) : base(context) {}
    }
}