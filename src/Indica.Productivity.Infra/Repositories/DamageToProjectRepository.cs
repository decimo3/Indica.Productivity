using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class DamageToProjectRepository : BaseRepository<DamageToProject>, IDamageToProjectRepository
    {
        public DamageToProjectRepository(ProductivityContext context) : base(context) {}
    }
}