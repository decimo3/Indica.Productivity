using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class CodeFilterRepository : BaseRepository<CodeFilter>, ICodeFilterRepository
    {
        public CodeFilterRepository(ProductivityContext context) : base(context) {}
    }
}
