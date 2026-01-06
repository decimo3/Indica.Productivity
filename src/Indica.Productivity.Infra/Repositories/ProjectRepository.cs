using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;

namespace Indica.System.Infra.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProductivityContext context) : base(context) {}
    }
}