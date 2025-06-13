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
            builder.Property(cf => cf.IdProcess)
                .HasColumnName("id_process")
                .IsRequired();
            builder.HasOne<Process>()
                .WithMany()
                .HasForeignKey(cf => cf.IdProcess)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(cf => new { cf.Code, cf.IdProcess })
                .IsUnique();
        }
    }
}
