using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class EmployerSituationRepository : BaseRepository<EmployerSituation>, IEmployerSituationRepository
    {
        public EmployerSituationRepository(ProductivityContext context) : base(context) {}
    }
}