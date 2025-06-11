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
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.GroupingOfMeasures)
                .HasColumnName("agrupamento_medidas")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.IdPaymentMaster)
                .HasColumnName("id_mestre_pagamento")
                .IsRequired();
            builder.Property(x => x.IdFinishingDetail)
                .HasColumnName("id_finalizacao_detalhe")
                .IsRequired();
            builder.HasOne(fp => fp.FinishingDetail)
                .WithMany()
                .HasForeignKey(x => x.IdFinishingDetail)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}
