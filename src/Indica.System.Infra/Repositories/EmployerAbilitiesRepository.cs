using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class EmployerAbilitiesRepository : BaseRepository<EmployerAbilities>, IEmployerAbilitiesRepository
    {
        public EmployerAbilitiesRepository(ProductivityContext context) : base(context) {}
    }
}