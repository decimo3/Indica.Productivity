using Indica.System.Domain.Entities;
using Indica.System.Infra.EntityMappers;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.Infra
{
    public class ProductivityContext : DbContext
    {
        public ProductivityContext(DbContextOptions<ProductivityContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployerMapper());
            modelBuilder.ApplyConfiguration(new ContractMapper());
            modelBuilder.ApplyConfiguration(new RoleMapper());
        }
    }
}
