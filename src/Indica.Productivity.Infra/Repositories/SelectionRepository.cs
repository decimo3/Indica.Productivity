using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class SelectionRepository : BaseRepository<Selection>, ISelectionRepository
    {
        public SelectionRepository(ProductivityContext context) : base(context)
        {
        }
    }
}