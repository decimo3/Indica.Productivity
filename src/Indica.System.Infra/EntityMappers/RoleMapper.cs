using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class RoleMapper : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("cargos");
            builder.HasKey(e => e.IdRole);
            builder.Property(e => e.IdRole)
                .HasColumnName("id_cargo")
                .IsRequired();
            builder.Property(e => e.RoleName)
                .HasColumnName("cargo")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasColumnName("descricao")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
