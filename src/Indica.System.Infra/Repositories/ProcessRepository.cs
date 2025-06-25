using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class ProcessRepository : BaseRepository<Process>, IProcessRepository
    {
        public ProcessRepository(ProductivityContext context) : base(context) {}
    }
}