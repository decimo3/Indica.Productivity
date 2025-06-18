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
            builder.Property(p => p.IdProject)
                .HasColumnName("id_projeto")
                .IsRequired();
            builder.Property(p => p.IdContract)
                .HasColumnName("id_contrato")
                .IsRequired();
            builder.Property(p => p.PaymentMaster)
                .HasColumnName("id_mestre")
                .IsRequired();
            builder.Property(p => p.ValueLight)
                .HasColumnName("valor_leve")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(p => p.ValueHeavy)
                .HasColumnName("valor_pesado")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(p => p.ValueSpecial)
                .HasColumnName("valor_especial")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.HasOne<Contract>(p => p.Contract)
                .WithMany()
                .HasForeignKey(p => p.IdContract)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(p => p.IdProject)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
