using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerAbilitiesMapper : IEntityTypeConfiguration<EmployerAbilities>
    {
        public void Configure(EntityTypeBuilder<EmployerAbilities> builder)
        {
            builder.ToTable("qualificacoes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_qualificacoes")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.IdEmployer)
                .HasColumnName("id_funcionario")
                .IsRequired();
            builder.Property(x => x.IdAbility)
                .HasColumnName("id_competencia")
                .IsRequired();
            builder.HasOne<Employer>()
                .WithMany()
                .HasForeignKey(x => x.IdEmployer)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne<EmployerAbility>()
                .WithMany()
                .HasForeignKey(x => x.IdAbility)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}