using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class EmployerFunctionRepository : BaseRepository<EmployerFunction>, IEmployerFunctionRepository
    {
        public EmployerFunctionRepository(ProductivityContext context) : base(context) {}
    }
}