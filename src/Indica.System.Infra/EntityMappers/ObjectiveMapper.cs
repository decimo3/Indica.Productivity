using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
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
            builder.Property(x => x.IdContract)
                .HasColumnName("id_contrato")
                .IsRequired();
            builder.Property(x => x.IdProcess)
                .HasColumnName("id_processo")
                .IsRequired();
            builder.Property(x => x.IsBasketTruck)
                .HasColumnName("eh_caminhao")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.IsHalfPrice)
                .HasColumnName("eh_metade")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.IsEspecial)
                .HasColumnName("eh_especial")
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
            builder.HasIndex(x => new {x.IdContract, x.IdProcess, x.IsBasketTruck, x.IsHalfPrice, x.IsEspecial}).IsUnique();
        }
    }
}