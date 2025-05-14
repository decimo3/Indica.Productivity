using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
    {
        public EmployerRepository(ProductivityContext context) : base(context) {}
    }
}