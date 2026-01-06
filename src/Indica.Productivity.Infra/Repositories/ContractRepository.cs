using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(ProductivityContext context) : base(context) {}
    }
}
