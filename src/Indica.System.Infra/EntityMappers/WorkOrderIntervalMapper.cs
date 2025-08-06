using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderIntervalMapper : IEntityTypeConfiguration<WorkOrderInterval>
    {
        public void Configure(EntityTypeBuilder<WorkOrderInterval> builder)
        {
            builder.ToTable("servico_intervalo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico_intervalo")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.UnavailableReasonOrIntervalDescription)
                .HasColumnName("motivo_indisponibilidade_ou_descricao_intervalo")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}