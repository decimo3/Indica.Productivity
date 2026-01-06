using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class DerivationMapper : IEntityTypeConfiguration<Derivation>
    {
        public void Configure(EntityTypeBuilder<Derivation> builder)
        {
            builder.ToTable("derivacoes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_derivacao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.DerivationName)
                .HasColumnName("nome_derivacao")
                .HasMaxLength(32)
                .IsRequired();
            builder.HasIndex(x => new { x.DerivationName }).IsUnique();
            builder.HasData([
                new Derivation() { Id = 1,  DerivationName = "CONVENCIONAL" },
                new Derivation() { Id = 2,  DerivationName = "PESADO" },
                new Derivation() { Id = 3,  DerivationName = "INICIATIVA" },
                new Derivation() { Id = 4,  DerivationName = "MANUTENÇÃO BT" },
                new Derivation() { Id = 5, DerivationName = "EXTERNALIZAÇÃO" },
                new Derivation() { Id = 6, DerivationName = "MODERNIZAÇÃO" },
                new Derivation() { Id = 7, DerivationName = "NORMALIZAÇÃO" },
                new Derivation() { Id = 8,  DerivationName = "VISTORIADOR" },
                new Derivation() { Id = 9,  DerivationName = "EMERGÊNCIA" },
                new Derivation() { Id = 10,  DerivationName = "ESTOQUE DE CORTADOS" },
            ]);
        }
    }
}