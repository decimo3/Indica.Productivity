using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class FinishingMapper : IEntityTypeConfiguration<Finishing>
    {
        public void Configure(EntityTypeBuilder<Finishing> builder)
        {
            builder.ToTable("finalizacoes");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                .HasColumnName("id_finalizacao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(f => f.GroupingOfMeasures)
                .HasColumnName("agrupamento_medidas")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(f => f.IdFinishingDetail)
                .HasColumnName("id_categoria")
                .IsRequired();
            builder.Property(f => f.IsAlternative)
                .HasColumnName("eh_alternativo")
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne(f => f.Detail)
                .WithMany()
                .HasForeignKey(f => f.IdFinishingDetail)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(f => new { f.GroupingOfMeasures, f.IsAlternative } ).IsUnique();
        }
    }
}