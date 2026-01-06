using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class ActivityMapper : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("atividades");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("id_atividade")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(a => a.ActivityName)
                .HasColumnName("nome_atividade")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(a => a.IdProject)
                .HasColumnName("id_projeto")
                .IsRequired();
            builder.HasOne(a => a.Project)
                .WithMany()
                .HasForeignKey(a => a.IdProject)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(x => x.ActivityName).IsUnique();
            builder.HasData([
                new Activity() { Id = 1, ActivityName = "CORTE", IdProject = 1 },
                new Activity() { Id = 2, ActivityName = "CORTE PILOTO", IdProject = 1 },
                new Activity() { Id = 3, ActivityName = "CORTE ESPECIAL", IdProject = 1 },
                new Activity() { Id = 4, ActivityName = "RELIGA", IdProject = 2 },
                new Activity() { Id = 5, ActivityName = "RELIGA POSTO", IdProject = 2 },
                new Activity() { Id = 6, ActivityName = "RELIGA CAMINHÃO", IdProject = 2 },
                new Activity() { Id = 7, ActivityName = "LIDE", IdProject = 3 },
                new Activity() { Id = 8, ActivityName = "LIDE VISTORIADOR", IdProject = 3 },
                new Activity() { Id = 9, ActivityName = "LIDE PESADO", IdProject = 3 },
                new Activity() { Id = 10, ActivityName = "ANEXO IV", IdProject = 4 },
                new Activity() { Id = 11, ActivityName = "ANEXO IV VISTORIADOR", IdProject = 4 },
                new Activity() { Id = 12, ActivityName = "ANEXO IV PESADO", IdProject = 4 },
                new Activity() { Id = 13, ActivityName = "EMERGÊNCIA", IdProject = 11 },
                new Activity() { Id = 14, ActivityName = "PQM", IdProject = 10 },
                new Activity() { Id = 15, ActivityName = "ATENDIMENTO COLETIVO", IdProject = 11 },
                new Activity() { Id = 16, ActivityName = "CONVENCIONAL", IdProject = 6 },
                new Activity() { Id = 17, ActivityName = "EXTERNALIZAÇÃO", IdProject = 7 },
                new Activity() { Id = 18, ActivityName = "LABORATÓRIO", IdProject = 3 },
                new Activity() { Id = 19, ActivityName = "CORTE OSDC", IdProject = 1 },
                new Activity() { Id = 20, ActivityName = "BAIXA RENDA", IdProject = 1 },
                new Activity() { Id = 21, ActivityName = "MANUTENÇÃO BT", IdProject = 9 },
                new Activity() { Id = 22, ActivityName = "MEDIDOR OBSOLETO", IdProject = 8 }
            ]);
        }
    }
}
