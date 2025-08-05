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
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(f => f.GroupingOfMeasures)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(f => f.IdFinishingDetail)
                .IsRequired();
            builder.HasOne(f => f.Detail)
                .WithMany()
                .HasForeignKey(f => f.IdFinishingDetail)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(f => f.GroupingOfMeasures)
                .IsUnique()
                .HasDatabaseName("IX_Finishing_GroupingOfMeasures");
        }
    }
}