using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class ProcessMapper : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("processos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.ProcessName)
                .HasColumnName("nome")
                .HasMaxLength(100)
                .IsRequired();
            builder.HasData([
                new Process { Id = 1, ProcessName = "CORE" },
                new Process { Id = 2, ProcessName = "LIDE" },
                new Process { Id = 3, ProcessName = "REN" },
                new Process { Id = 4, ProcessName = "ANEXO" },
                ]);
        }
    }
}
