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
            builder.HasData([
                new Role
                {
                    IdRole = 0,
                    RoleName = "Eletricista",
                    Description = "Responsável pela execução do serviço"
                },
                new Role
                {
                    IdRole = 1,
                    RoleName = "Supervisor",
                    Description = "Responsável pela gestão de equipes"
                },
                new Role
                {
                    IdRole = 2,
                    RoleName = "Controlador",
                    Description = "Responsável pelo suporte as equipes"
                },
                new Role
                {
                    IdRole = 3,
                    RoleName = "Comunicador",
                    Description = "Responsável pela gestão de qualidade"
                },
                new Role
                {
                    IdRole = 4,
                    RoleName = "Administrador",
                    Description = "Responsável pela gestão de supervisores e comunicadores"
                },
                new Role
                {
                    IdRole = 5,
                    RoleName = "Proprietario",
                    Description = "Responsável pela gestão de administradores"
                },
                ]);
        }
    }
}
