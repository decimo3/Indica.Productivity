using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
    {
        public EmployerRepository(ProductivityContext context) : base(context) {}
    }
}