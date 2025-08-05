using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Indica.System.Domain.Entities;

namespace Indica.System.Infra.EntityMappers
{
    public class ContractMapper : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("contratos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("id_contrato")
                .ValueGeneratedOnAdd()
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
                .HasDefaultValue(DateOnly.MaxValue)
                .IsRequired();
        }
    }
}
