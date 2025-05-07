using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Indica.System.Domain.Entities;

namespace Indica.System.Infra.AutoMappers
{
    public class ContractMapper : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");
            builder.HasKey(c => c.IdContract);
            builder.Property(c => c.IdContract)
                .HasColumnName("identificador")
                .IsRequired();
            builder.Property(c => c.ContractNumber)
                .HasColumnName("contrato")
                .IsRequired();
            builder.Property(c => c.AdditiveNumber)
                .HasColumnName("aditivo")
                .IsRequired();
            builder.Property(c => c.StartDate)
                .HasColumnName("inicio_vigencia")
                .IsRequired();
            builder.Property(c => c.FinalDate)
                .HasColumnName("final_vigencia")
                .IsRequired();

        }
    }
}
