using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class CodeFilterMapper : IEntityTypeConfiguration<CodeFilter>
    {
        public void Configure(EntityTypeBuilder<CodeFilter> builder)
        {
            builder.ToTable("code_filter");
            builder.HasKey(cf => cf.Id);
            builder.Property(cf => cf.Id)
                .HasColumnName("id_code_filter")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(cf => cf.Code)
                .HasColumnName("code")
                .HasMaxLength(4)
                .IsRequired();
            builder.Property(cf => cf.IdProject)
                .HasColumnName("id_projeto")
                .IsRequired();
            builder.HasOne(cf => cf.Project)
                .WithMany()
                .HasForeignKey(cf => cf.IdProject)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(cf => new { cf.Code, cf.IdProject })
                .IsUnique();
        }
    }
}
