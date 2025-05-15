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
            builder.HasData([
                new Role
                {
                    IdRole = 1,
                    RoleName = "Eletricista",
                },
                new Role
                {
                    IdRole = 2,
                    RoleName = "Supervisor",
                },
                new Role
                {
                    IdRole = 3,
                    RoleName = "Controlador",
                },
                new Role
                {
                    IdRole = 4,
                    RoleName = "Qualidade",
                },
                new Role
                {
                    IdRole = 5,
                    RoleName = "Administrador",
                },
                new Role
                {
                    IdRole = 6,
                    RoleName = "Proprietario",
                },
                ]);
        }
    }
}
