using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class WorkOrderShiftInfoMapper : IEntityTypeConfiguration<WorkOrderShiftInfo>
    {
        public void Configure(EntityTypeBuilder<WorkOrderShiftInfo> builder)
        {
            builder.ToTable("servico_turnoinfo");
            builder.Property(x => x.ShiftStartDate)
                .HasColumnName("inicio_do_turno")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.VehicleLabel)
                .HasColumnName("label_do_veiculo")
                .HasDefaultValue(null)
                .HasMaxLength(13)
                .IsFixedLength()
                .IsRequired(false);
            builder.Property(x => x.IdLeaderRegistration)
                .HasColumnName("id_matricula_lider")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.IdAuxiliaryRegistration)
                .HasColumnName("id_matricula_auxiliares")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.IdTechnicalRegistration)
                .HasColumnName("id_matricula_tecnico")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.UnavailableReasonOrIntervalDescription)
                .HasColumnName("motivo_indisponibilidade_ou_descricao_intervalo")
                .HasDefaultValue(null)
                .HasMaxLength(32)
                .IsRequired(false);
        }
    }
}