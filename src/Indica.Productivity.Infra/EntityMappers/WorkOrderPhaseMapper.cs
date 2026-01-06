using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class WorkOrderPhaseMapper : IEntityTypeConfiguration<WorkOrderPhase>
    {
        public void Configure(EntityTypeBuilder<WorkOrderPhase> builder)
        {
            builder.ToTable("servico_fases");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico_fase")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.PhaseName)
                .HasColumnName("nome_servico_fase")
                .HasMaxLength(16)
                .IsRequired();
            builder.HasIndex(x => x.PhaseName).IsUnique();
            builder.HasData([
                new WorkOrderPhase() { Id = 1, PhaseName = "Monofásico" },
                new WorkOrderPhase() { Id = 2, PhaseName = "Bifásico" },
                new WorkOrderPhase() { Id = 3, PhaseName = "Trifásico" },
            ]);
        }
    }
}