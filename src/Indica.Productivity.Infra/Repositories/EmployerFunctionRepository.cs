using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class EmployerFunctionRepository : BaseRepository<EmployerFunction>, IEmployerFunctionRepository
    {
        public EmployerFunctionRepository(ProductivityContext context) : base(context) {}
    }
}