using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class ObjectiveMapper : IEntityTypeConfiguration<Objective>
    {
        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.ToTable("objetivos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_objetivo")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.IdContractProject)
                .HasColumnName("id_contrato_projeto")
                .IsRequired();
            builder.Property(x => x.IsBasketTruck)
                .HasColumnName("eh_caminhao")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.IsHalfPrice)
                .HasColumnName("eh_metade")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.MonthlyProfitGoal)
                .HasColumnName("mensal_valor_meta")
                .IsRequired();
            builder.Property(x => x.FixedDivisorByMonth)
                .HasColumnName("mensal_divisor_fixo")
                .IsRequired();
            builder.Property(x => x.TargetOfTeamCountOnWorkday)
                .HasColumnName("meta_apresentacao_util")
                .IsRequired();
            builder.Property(x => x.TargetOfTeamCountOnHoliday)
                .HasColumnName("meta_apresentacao_feriado")
                .IsRequired();
            builder.Property(x => x.TargetOfExecutionsPerDay)
                .HasColumnName("meta_execucoes_diaria")
                .IsRequired();
            builder.HasOne(x => x.ContractProject)
                .WithMany()
                .HasForeignKey(x => x.IdContractProject)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => new {x.IdContractProject, x.IsBasketTruck, x.IsHalfPrice}).IsUnique();
        }
    }
}