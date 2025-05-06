using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.Infra.Repositories
{
    public class ElectricianRepository : BaseRepository<Electrician>, IElectricianRepository
    {
        public ElectricianRepository(ProductivityContext context) : base(context) {}
    }
}