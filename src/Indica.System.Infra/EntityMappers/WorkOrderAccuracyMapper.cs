using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderAccuracyMapper : IEntityTypeConfiguration<WorkOrderAccuracy>
    {
        public void Configure(EntityTypeBuilder<WorkOrderAccuracy> builder)
        {
            builder.ToTable("coordenadas_exatidao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_coordenadas_exatidao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.AccuracyLevel)
                .HasColumnName("nome_coordenadas_exatidao")
                .HasMaxLength(8)
                .IsRequired();
            builder.HasIndex(x => x.AccuracyLevel).IsUnique();
            builder.HasData([
                new WorkOrderAccuracy() { Id = 1, AccuracyLevel = "Alto" },
                new WorkOrderAccuracy() { Id = 2, AccuracyLevel = "Médio" },
                new WorkOrderAccuracy() { Id = 3, AccuracyLevel = "Baixo" },
            ]);
        }
    }
}