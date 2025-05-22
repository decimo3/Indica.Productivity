using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class PaymentMapper : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("mestres");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.IdProcess)
                .HasColumnName("id_processo")
                .IsRequired();
            builder.Property(p => p.IdContract)
                .HasColumnName("id_contrato")
                .IsRequired();
            builder.Property(p => p.PaymentMaster)
                .HasColumnName("id_mestre")
                .IsRequired();
            builder.Property(p => p.Value)
                .HasColumnName("valor")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.HasOne<Contract>(p => p.Contract)
                .WithMany()
                .HasForeignKey(p => p.IdContract)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne<Process>(p => p.Process)
                .WithMany()
                .HasForeignKey(p => p.IdProcess)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
