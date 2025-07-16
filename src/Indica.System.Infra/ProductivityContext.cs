using Indica.System.Infra.EntityMappers;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.Infra
{
    public class ProductivityContext : DbContext
    {
        public ProductivityContext(DbContextOptions<ProductivityContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProcessMapper());
            modelBuilder.ApplyConfiguration(new ProjectMapper());
            modelBuilder.ApplyConfiguration(new ActivityMapper());

            modelBuilder.ApplyConfiguration(new ContractMapper());
            modelBuilder.ApplyConfiguration(new ObjectiveMapper());

            modelBuilder.ApplyConfiguration(new EmployerFunctionMapper());
            modelBuilder.ApplyConfiguration(new EmployerSituationMapper());
            //modelBuilder.ApplyConfiguration(new EmployerAbilityMapper());
            //modelBuilder.ApplyConfiguration(new EmployerAbilitiesMapper());
            modelBuilder.ApplyConfiguration(new EmployerMapper());

            modelBuilder.ApplyConfiguration(new FieldTeamRegionalMapper());
            modelBuilder.ApplyConfiguration(new FieldTeamFuncionMapper());
            modelBuilder.ApplyConfiguration(new FieldTeamCoupleMapper());
            modelBuilder.ApplyConfiguration(new FieldTeamMapper());

            modelBuilder.ApplyConfiguration(new DamageToProcessMapper());
            modelBuilder.ApplyConfiguration(new CodeFilterMapper());

            modelBuilder.ApplyConfiguration(new FinishingDetailMapper());
            modelBuilder.ApplyConfiguration(new FinishingMapper());

            modelBuilder.ApplyConfiguration(new PaymentMasterMapper());
            modelBuilder.ApplyConfiguration(new PaymentMapper());

            modelBuilder.ApplyConfiguration(new FinishingPaymentMapper());

            modelBuilder.ApplyConfiguration(new WorkOrderSituationMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderAbilitiesMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderIntervalMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderShiftInfoMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderCostumerMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderServiceMapper());
        }
    }
}
