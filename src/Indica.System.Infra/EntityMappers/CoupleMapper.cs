using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class CoupleMapper : IEntityTypeConfiguration<Couple>
    {
        public void Configure(EntityTypeBuilder<Couple> builder)
        {
            builder.ToTable("equipe");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_equipe")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.IdFieldTeam)
                .HasColumnName("id_composicao")
                .IsRequired();
            builder.Property(x => x.IdEmployer)
                .HasColumnName("id_funcionario")
                .IsRequired();
            builder.Property(x => x.IdFunction)
                .HasColumnName("id_composicao_funcao")
                .IsRequired();
            builder.HasOne<Fieldteam>()
                .WithMany()
                .HasForeignKey(x => x.IdFieldTeam)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne<Employer>()
                .WithMany()
                .HasForeignKey(x => x.IdEmployer)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne<FieldTeamFunction>()
                .WithMany()
                .HasForeignKey(x => x.IdFunction)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}