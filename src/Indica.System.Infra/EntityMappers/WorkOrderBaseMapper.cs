using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderBaseMapper : IEntityTypeConfiguration<WorkOrderBase>
    {
        public void Configure(EntityTypeBuilder<WorkOrderBase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Resource)
                .HasColumnName("recurso")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.Date)
                .HasColumnName("dia")
                .IsRequired();
            builder.Property(x => x.IdActivity)
                .HasColumnName("id_atividade")
                .IsRequired();
            builder.Property(x => x.IdSituation)
                .HasColumnName("id_servico_situacao")
                .IsRequired();
            builder.Property(x => x.StartTime)
                .HasColumnName("tempo_inicio")
                .IsRequired();
            builder.Property(x => x.FinalTime)
                .HasColumnName("tempo_final")
                .IsRequired();
            builder.Property(x => x.DurationTime)
                .HasColumnName("tempo_duracao")
                .IsRequired();
            builder.Property(x => x.TravellingTime)
                .HasColumnName("tempo_deslocamento")
                .IsRequired();
            builder.Property(x => x.IdTypeOfActivity)
                .HasColumnName("dano")
                .HasMaxLength(4)
                .IsFixedLength()
                .IsRequired();
            builder.Property(x => x.ActivityBookingTime)
                .HasColumnName("tempo_de_reserva_da_atividade")
                .IsRequired();
            builder.Property(x => x.EstimatedTravellingTime)
                .HasColumnName("desloca_estimado")
                .IsRequired();
            builder.Property(x => x.EstimatedDurationTime)
                .HasColumnName("duracao_estimado")
                .IsRequired();
            builder.Property(x => x.FileName)
                .HasColumnName("nome_do_arquivo")
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.ComposedKey)
                .HasColumnName("identificador")
                .HasMaxLength(32)
                .IsRequired();
            builder.HasOne(x => x.WorkOrderSituation)
                .WithMany()
                .HasForeignKey(x => x.IdSituation)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.DamageToProcess)
                .WithMany()
                .HasForeignKey(x => x.IdTypeOfActivity)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.FieldTeam)
                .WithMany()
                .HasForeignKey(x => x.IdFieldTeam)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => x.IdActivity).IsUnique();
        }
    }
}