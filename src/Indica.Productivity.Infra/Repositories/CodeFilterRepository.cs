using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class CodeFilterRepository : BaseRepository<CodeFilter>, ICodeFilterRepository
    {
        public CodeFilterRepository(ProductivityContext context) : base(context) {}
    }
}
