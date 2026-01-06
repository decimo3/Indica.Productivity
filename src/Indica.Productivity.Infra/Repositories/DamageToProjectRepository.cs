using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class DamageToProjectRepository : BaseRepository<DamageToProject>, IDamageToProjectRepository
    {
        public DamageToProjectRepository(ProductivityContext context) : base(context) {}
    }
}