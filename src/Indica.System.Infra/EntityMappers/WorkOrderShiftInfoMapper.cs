using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderShiftInfoMapper : IEntityTypeConfiguration<WorkOrderShiftInfo>
    {
        public void Configure(EntityTypeBuilder<WorkOrderShiftInfo> builder)
        {
            builder.ToTable("servico_turnoinfo");
            builder.Property(x => x.ShiftStartDate)
                .HasColumnName("inicio_do_turno")
                .IsRequired();
            builder.Property(x => x.VehicleLabel)
                .HasColumnName("label_do_veiculo")
                .HasMaxLength(13)
                .IsFixedLength()
                .IsRequired();
            builder.Property(x => x.IdLeaderRegistration)
                .HasColumnName("id_matricula_lider")
                .IsRequired();
            builder.Property(x => x.IdAuxiliaryRegistration)
                .HasColumnName("id_matricula_auxiliares")
                .IsRequired();
            builder.Property(x => x.IdTechnicalRegistration)
                .HasColumnName("id_matricula_tecnico")
                .IsRequired();
            builder.Property(x => x.UnavailableReasonOrIntervalDescription)
                .HasColumnName("motivo_indisponibilidade_ou_descricao_intervalo")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}