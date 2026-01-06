using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class EmployerSituationRepository : BaseRepository<EmployerSituation>, IEmployerSituationRepository
    {
        public EmployerSituationRepository(ProductivityContext context) : base(context) {}
    }
}