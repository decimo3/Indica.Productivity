using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.Productivity.Infra.Repositories
{
    public class WorkOrderResumeRepository : BaseRepository<WorkOrderResume>, IWorkOrderResumeRepository
    {
        public WorkOrderResumeRepository(ProductivityContext context) : base(context) { }
    }
}
