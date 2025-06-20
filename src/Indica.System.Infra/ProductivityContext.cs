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
            modelBuilder.ApplyConfiguration(new EmployerAbilityMapper());
            modelBuilder.ApplyConfiguration(new EmployerFunctionMapper());
            modelBuilder.ApplyConfiguration(new EmployerSituationMapper());
            modelBuilder.ApplyConfiguration(new ProcessMapper());
            modelBuilder.ApplyConfiguration(new ProjectMapper());
            modelBuilder.ApplyConfiguration(new ActivityMapper());
            modelBuilder.ApplyConfiguration(new PaymentMasterMapper());
            modelBuilder.ApplyConfiguration(new PaymentMapper());
            modelBuilder.ApplyConfiguration(new FinishingDetailMapper());
            modelBuilder.ApplyConfiguration(new FinishingMapper());
            modelBuilder.ApplyConfiguration(new FinishingPaymentMapper());
            modelBuilder.ApplyConfiguration(new CodeFilterMapper());
        }
    }
}
