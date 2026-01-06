using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class ProcessRepository : BaseRepository<Process>, IProcessRepository
    {
        public ProcessRepository(ProductivityContext context) : base(context) {}
    }
}