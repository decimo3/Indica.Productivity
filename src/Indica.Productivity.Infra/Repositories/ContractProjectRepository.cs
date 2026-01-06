using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class ContractProjectRepository : BaseRepository<ContractProject>, IContractProjectRepository
    {
        public ContractProjectRepository(ProductivityContext context) : base(context)
        {
        }
    }
}
