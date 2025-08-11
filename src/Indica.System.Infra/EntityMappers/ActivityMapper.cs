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
        }
    }
}
