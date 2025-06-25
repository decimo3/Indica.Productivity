using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class EmployerAbilityRepository : BaseRepository<EmployerAbility>, IEmployerAbilityRepository
    {
        public EmployerAbilityRepository(ProductivityContext context) : base(context) {}
    }
}