using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
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
            builder.Property(a => a.IsBasketTruck)
                .HasColumnName("eh_caminhao")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(a => a.IsHalfPrice)
                .HasColumnName("eh_metade")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(a => a.IsSpecial)
                .HasColumnName("eh_especial")
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne(a => a.Project)
                .WithMany()
                .HasForeignKey(a => a.IdProject)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(x => x.ActivityName).IsUnique();
            builder.HasData([
                new Activity() { Id = 1, ActivityName = "CORTE", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 1 },
                new Activity() { Id = 2, ActivityName = "CORTE PILOTO", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 1 },
                new Activity() { Id = 3, ActivityName = "CORTE ESPECIAL", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 1 },
                new Activity() { Id = 4, ActivityName = "RELIGA", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 2 },
                new Activity() { Id = 5, ActivityName = "RELIGA POSTO", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 2 },
                new Activity() { Id = 6, ActivityName = "RELIGA CAMINHÃO", IsBasketTruck = true, IsHalfPrice = false, IsSpecial = false, IdProject = 2 },
                new Activity() { Id = 7, ActivityName = "LIDE", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 3 },
                new Activity() { Id = 8, ActivityName = "LIDE VISTORIADOR", IsBasketTruck = false, IsHalfPrice = true, IsSpecial = false, IdProject = 3 },
                new Activity() { Id = 9, ActivityName = "LIDE PESADO", IsBasketTruck = true, IsHalfPrice = false, IsSpecial = true, IdProject = 3 },
                new Activity() { Id = 10, ActivityName = "ANEXO IV", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 4 },
                new Activity() { Id = 11, ActivityName = "ANEXO IV VISTORIADOR", IsBasketTruck = false, IsHalfPrice = true, IsSpecial = true, IdProject = 4 },
                new Activity() { Id = 12, ActivityName = "ANEXO IV PESADO", IsBasketTruck = true, IsHalfPrice = false, IsSpecial = false, IdProject = 4 },
                new Activity() { Id = 13, ActivityName = "EMERGÊNCIA", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = true, IdProject = 11 },
                new Activity() { Id = 14, ActivityName = "PQM", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 10 },
                new Activity() { Id = 15, ActivityName = "ATENDIMENTO COLETIVO", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 11 },
                new Activity() { Id = 16, ActivityName = "CONVENCIONAL", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 6 },
                new Activity() { Id = 17, ActivityName = "EXTERNALIZAÇÃO", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 7 },
                new Activity() { Id = 18, ActivityName = "LABORATÓRIO", IsBasketTruck = false, IsHalfPrice = true, IsSpecial = false, IdProject = 3 },
                new Activity() { Id = 19, ActivityName = "CORTE OSDC", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 1 },
                new Activity() { Id = 20, ActivityName = "BAIXA RENDA", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 1 },
                new Activity() { Id = 21, ActivityName = "MANUTENÇÃO BT", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 9 },
                new Activity() { Id = 22, ActivityName = "MEDIDOR OBSOLETO", IsBasketTruck = false, IsHalfPrice = false, IsSpecial = false, IdProject = 8 }
            ]);
        }
    }
}
