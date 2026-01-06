using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class SelectionRepository : BaseRepository<Selection>, ISelectionRepository
    {
        public SelectionRepository(ProductivityContext context) : base(context)
        {
        }
    }
}