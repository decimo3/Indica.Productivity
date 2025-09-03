using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class ProjectMapper : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projetos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id_projeto")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.ProjectName)
                .HasColumnName("nome_projeto")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.UsesDamage)
                .HasColumnName("usar_dano")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(p=> p.IdProcess)
                .HasColumnName("id_processo")
                .IsRequired();
            builder.HasOne(p => p.Process)
                .WithMany()
                .HasForeignKey(p => p.IdProcess)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(x => x.ProjectName).IsUnique();
            builder.HasData(
                new Project { Id = 1, ProjectName = "CORTE", IdProcess = 1 },
                new Project { Id = 2, ProjectName = "RELIGA", IdProcess = 1 },
                new Project { Id = 3, ProjectName = "LIDE", IdProcess = 2 },
                new Project { Id = 4, ProjectName = "ANEXO", IdProcess = 2 },
                new Project { Id = 5, ProjectName = "AFERICAO", IdProcess = 2 },
                new Project { Id = 6, ProjectName = "INSPECAO", IdProcess = 3 },
                new Project { Id = 7, ProjectName = "EXTERNALIZACAO", IdProcess = 3 },
                new Project { Id = 8, ProjectName = "MODERNIZACAO", IdProcess = 3 },
                new Project { Id = 9, ProjectName = "MANUTENCAO", IdProcess = 3 },
                new Project { Id = 10, ProjectName = "PQM", IdProcess = 4 },
                new Project { Id = 11, ProjectName = "EMERGENCIA", IdProcess = 4 },
                new Project { Id = 12, ProjectName = "MANOBRA", IdProcess = 4 }
            );
        }
    }
}