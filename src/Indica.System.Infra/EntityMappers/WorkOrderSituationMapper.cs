using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderSituationMapper : IEntityTypeConfiguration<WorkOrderSituation>
    {
        public void Configure(EntityTypeBuilder<WorkOrderSituation> builder)
        {
            builder.ToTable("servico_situacao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico_situacao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.SituationName)
                .HasColumnName("nome_servico_situacao")
                .HasMaxLength(16)
                .IsRequired();
            builder.HasIndex(x => x.SituationName).IsUnique();
            builder.HasData([
                new WorkOrderSituation() { Id = 1, SituationName = "pendente" },
                new WorkOrderSituation() { Id = 2, SituationName = "em rota" },
                new WorkOrderSituation() { Id = 3, SituationName = "iniciado" },
                new WorkOrderSituation() { Id = 4, SituationName = "concluído" },
                new WorkOrderSituation() { Id = 5, SituationName = "não concluído" },
                new WorkOrderSituation() { Id = 6, SituationName = "cancelado" },
            ]);
        }
    }
}