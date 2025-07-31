using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class FieldTeamMapper : IEntityTypeConfiguration<FieldTeam>
    {
        public void Configure(EntityTypeBuilder<FieldTeam> builder)
        {
            builder.ToTable("composicao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_composicao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Date)
                .HasColumnName("dia")
                .IsRequired();
            builder.Property(x => x.Resource)
                .HasColumnName("recurso")
                .IsRequired();
            builder.Property(x => x.Order)
                .HasColumnName("ordem")
                .IsRequired();
            builder.Property(x => x.Plate)
                .HasColumnName("placa")
                .IsFixedLength()
                .HasMaxLength(7)
                .IsRequired();
            builder.Property(x => x.Cellphone)
                .HasColumnName("telefone")
                .IsRequired();
            builder.Property(x => x.IdFieldTeam)
                .HasColumnName("abreviatura")
                .IsRequired();
            builder.Property(x => x.IdActivity)
                .HasColumnName("id_atividade")
                .IsRequired();
            builder.Property(x => x.IdRegion)
                .HasColumnName("id_regional")
                .IsRequired();
            builder.Property(x => x.IsConsidered)
                .HasColumnName("eh_considerado")
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(x => x.IsSpecial)
                .HasColumnName("eh_especial")
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne(f => f.Activity)
                .WithMany()
                .HasForeignKey(x => x.IdActivity)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(f => f.Regional)
                .WithMany()
                .HasForeignKey(x => x.IdRegion)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasMany(x => x.Couples)
                .WithOne()
                .HasForeignKey(y => y.IdFieldTeam)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
                
        }
    }
}