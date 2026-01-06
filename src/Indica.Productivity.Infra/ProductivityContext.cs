using Indica.System.Infra.EntityMappers;
using Indica.System.Domain.Entities;
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
            modelBuilder.ApplyConfiguration(new DerivationMapper());
            modelBuilder.ApplyConfiguration(new SelectionMapper());

            modelBuilder.ApplyConfiguration(new ContractMapper());
            modelBuilder.ApplyConfiguration(new ContractProjectMapper());
            modelBuilder.ApplyConfiguration(new ObjectiveMapper());

            modelBuilder.ApplyConfiguration(new EmployerFunctionMapper());
            modelBuilder.ApplyConfiguration(new EmployerSituationMapper());
            modelBuilder.ApplyConfiguration(new EmployerMapper());

            modelBuilder.ApplyConfiguration(new FieldTeamRegionalMapper());
            modelBuilder.ApplyConfiguration(new FieldTeamFuncionMapper());
            modelBuilder.ApplyConfiguration(new FieldTeamCoupleMapper());
            modelBuilder.ApplyConfiguration(new FieldTeamMapper());

            modelBuilder.ApplyConfiguration(new DamageToProjectMapper());
            modelBuilder.ApplyConfiguration(new CodeFilterMapper());
            modelBuilder.ApplyConfiguration(new CredentialMapper());

            modelBuilder.ApplyConfiguration(new FinishingDetailMapper());
            modelBuilder.ApplyConfiguration(new FinishingMapper());

            modelBuilder.ApplyConfiguration(new PaymentMasterMapper());
            modelBuilder.ApplyConfiguration(new PaymentMapper());

            modelBuilder.ApplyConfiguration(new FinishingPaymentMapper());

            modelBuilder.ApplyConfiguration(new WorkOrderAreaMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderPhaseMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderAccuracyMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderSituationMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderBaseMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderShiftInfoMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderCostumerMapper());
            modelBuilder.ApplyConfiguration(new WorkOrderServiceMapper());

            // Explicitly configure EF Core with TPT
            // because EF Core configure TPH by default
            modelBuilder.Entity<WorkOrderBase>().ToTable("servico_base");
            modelBuilder.Entity<WorkOrderService>().ToTable("servico_servico");
            modelBuilder.Entity<WorkOrderShiftInfo>().ToTable("servico_turnoinfo");
        }
    }
}
