using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class WorkOrderResumeMapper : IEntityTypeConfiguration<WorkOrderResume>
    {
        public void Configure(EntityTypeBuilder<WorkOrderResume> builder)
        {
            builder.ToTable("servico_resumo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_resumo")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Filename)
                .HasColumnName("arquivo")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.ResourceCount)
                .HasColumnName("recursos")
                .IsRequired();
            builder.Property(x => x.ServiceCount)
                .HasColumnName("servicos")
                .IsRequired();
        }
    }
}
