using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.Infra.Repositories
{
    public class SupervisorRepository : BaseRepository<Supervisor>, ISupervisorRepository
    {
        public SupervisorRepository(ProductivityContext context) : base(context) {}
    }
}