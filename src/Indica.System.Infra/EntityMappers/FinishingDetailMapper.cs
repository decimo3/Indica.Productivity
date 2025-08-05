using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class FinishingDetailMapper : IEntityTypeConfiguration<FinishingDetail>
    {
        public void Configure(EntityTypeBuilder<FinishingDetail> builder)
        {
            builder.ToTable("finalizacao_detalhe");
            builder.HasKey(fd => fd.Id);
            builder.Property(fd => fd.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(fd => fd.Detail)
                .HasColumnName("detalhe")
                .HasMaxLength(16)
                .IsRequired();
            builder.Property(fd => fd.IsExecuted)
                .HasColumnName("eh_executacao")
                .IsRequired();
            builder.HasData([
                new FinishingDetail { Id = 1, Detail = "EXEC", IsExecuted = true },
                new FinishingDetail { Id = 2, Detail = "CAPEX", IsExecuted = true },
                new FinishingDetail { Id = 3, Detail = "OPEX", IsExecuted = true },
                new FinishingDetail { Id = 4, Detail = "PGMQ", IsExecuted = true },
                new FinishingDetail { Id = 5, Detail = "VIST", IsExecuted = true },
                new FinishingDetail { Id = 6, Detail = "TOI", IsExecuted = true },
                new FinishingDetail { Id = 7, Detail = "NORM", IsExecuted = true },
                new FinishingDetail { Id = 8, Detail = "NA", IsExecuted = true },
                new FinishingDetail { Id = 9, Detail = "NI", IsExecuted = false },
                new FinishingDetail { Id = 10, Detail = "ELIG", IsExecuted = false },
                new FinishingDetail { Id = 11, Detail = "NEXE", IsExecuted = false },
                new FinishingDetail { Id = 12, Detail = "S_MD", IsExecuted = true },
                new FinishingDetail { Id = 13, Detail = "S_RM", IsExecuted = true },
                new FinishingDetail { Id = 14, Detail = "PROD", IsExecuted = true },
                new FinishingDetail { Id = 14, Detail = "IMPR", IsExecuted = false },
                new FinishingDetail { Id = 99, Detail = "ERRO", IsExecuted = false }
                ]);
        }
    }
}
