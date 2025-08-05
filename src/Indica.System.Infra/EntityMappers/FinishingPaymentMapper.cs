using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class FinishingPaymentMapper : IEntityTypeConfiguration<FinishingPayment>
    {
        public void Configure(EntityTypeBuilder<FinishingPayment> builder)
        {
            builder.ToTable("finalizacao_pagamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_finalizacao_pagamento")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.IdFinishing)
                .HasColumnName("id_finalizacao")
                .IsRequired();
            builder.Property(x => x.IdPaymentMaster)
                .HasColumnName("id_mestre")
                .IsRequired();
            builder.HasOne(x => x.Mestre)
                .WithMany()
                .HasForeignKey(x => x.IdPaymentMaster)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}
