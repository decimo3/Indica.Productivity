using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class DamageToProcessMapper : IEntityTypeConfiguration<DamageToProcess>
    {
        public void Configure(EntityTypeBuilder<DamageToProcess> builder)
        {
            builder.ToTable("dano_processo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_dano_processo")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Damage)
                .HasColumnName("dano")
                .HasMaxLength(4)
                .IsFixedLength(true)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasColumnName("descricao")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.IdProject)
                .HasColumnName("id_projeto")
                .IsRequired();
            builder.HasIndex(x => new { x.Damage, x.IdProject }).IsUnique();
        }
    }
}