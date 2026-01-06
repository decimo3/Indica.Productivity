using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class FieldTeamRegionalMapper : IEntityTypeConfiguration<FieldTeamRegional>
    {
        public void Configure(EntityTypeBuilder<FieldTeamRegional> builder)
        {
            builder.ToTable("regionais");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_regional")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.RegionName)
                .HasColumnName("nome_regional")
                .HasMaxLength(32)
                .IsRequired();
            builder.HasIndex(x => x.RegionName).IsUnique();
            builder.HasData([
                new FieldTeamRegional() { Id = 1, RegionName = "CAMPO GRANDE" },
                new FieldTeamRegional() { Id = 2, RegionName = "BAIXADA"}
            ]);
        }
    }
}