using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class FieldTeamRegionalMapper : IEntityTypeConfiguration<Regional>
    {
        public void Configure(EntityTypeBuilder<Regional> builder)
        {
            builder.ToTable("composicao_regional");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_composicao_regional")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.RegionName)
                .HasColumnName("nome_composicao_regional")
                .HasMaxLength(32)
                .IsRequired();
            builder.HasIndex(x => x.RegionName).IsUnique();
        }
    }
}