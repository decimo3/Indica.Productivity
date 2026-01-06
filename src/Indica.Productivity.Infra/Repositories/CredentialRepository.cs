using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;

namespace Indica.Productivity.Infra.Repositories
{
    public class CredentialRepository : BaseRepository<Credential>, ICredentialRepository
    {
        public CredentialRepository(ProductivityContext context) : base(context)
        {
        }
    }
}
