using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class WorkOrderAreaMapper : IEntityTypeConfiguration<WorkOrderArea>
    {
        public void Configure(EntityTypeBuilder<WorkOrderArea> builder)
        {
            builder.ToTable("servico_localidade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico_localidade")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.AreaNumber)
                .HasColumnName("num_servico_localidade")
                .IsRequired();
            builder.Property(x => x.AreaName)
                .HasColumnName("nome_servico_localidade")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.IdRegion)
                .HasColumnName("id_regional")
                .IsRequired(false);
            builder.HasOne(x => x.Regional)
                .WithMany()
                .HasForeignKey(x => x.IdRegion)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => new { x.AreaNumber, x.AreaName }).IsUnique();
        }
    }
}