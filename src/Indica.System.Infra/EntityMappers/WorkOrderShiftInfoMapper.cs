using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderShiftInfoMapper : IEntityTypeConfiguration<WorkOrderShiftInfo>
    {
        public void Configure(EntityTypeBuilder<WorkOrderShiftInfo> builder)
        {
            builder.ToTable("servico_turno");
            builder.UseTpcMappingStrategy();
            WorkOrderMapperHelper.ConfigureBase(builder);
            builder.Property(x => x.ShiftStartDate)
                .HasColumnName("inicio_da_turno")
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
                .IsRequired(false);
            builder.Property(x => x.IdTechnicalRegistration)
                .HasColumnName("id_matricula_tecnico")
                .IsRequired();
        }
    }
}