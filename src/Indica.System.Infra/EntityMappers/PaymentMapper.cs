using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class PaymentMapper : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("pagamentos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id_pagamento")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.IdContractProject)
                .HasColumnName("id_contrato_projeto")
                .IsRequired();
            builder.Property(p => p.IdPaymentMaster)
                .HasColumnName("id_mestre")
                .IsRequired();
            builder.Property(p => p.Valuation)
                .HasColumnName("valoracao")
                .HasColumnType("decimal(6,2)")
                .IsRequired();
            builder.HasOne(x => x.ContractProject)
                .WithMany()
                .HasForeignKey(p => p.IdContractProject)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(p => p.Mestre)
                .WithMany()
                .HasForeignKey(p => p.IdPaymentMaster)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => new { x.IdContractProject, x.IdPaymentMaster }).IsUnique();
        }
    }
}
