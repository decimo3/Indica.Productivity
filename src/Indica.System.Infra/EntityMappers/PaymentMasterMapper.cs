using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Indica.System.Infra.EntityMappers
{
    public class PaymentMasterMapper : IEntityTypeConfiguration<PaymentMaster>
    {
        public void Configure(EntityTypeBuilder<PaymentMaster> builder)
        {
            builder.ToTable("mestres");
            builder.HasKey(pm => pm.Id);
            builder.Property(pm => pm.Id)
                .HasColumnName("id_mestre")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(pm => pm.Master)
                .HasColumnName("mestre")
                .IsRequired();
            builder.Property(pm => pm.Description)
                .HasColumnName("descricao")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
