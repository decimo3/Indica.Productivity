using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerMapper : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("funcionarios");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.IndicaRegistry)
                .HasColumnName("matricula_indica")
                .IsRequired();
            builder.Property(e => e.ClientRegistry)
                .HasColumnName("matricula_cliente")
                .IsRequired();
            builder.Property(e => e.FullName)
                .HasColumnName("nome_colaborador")
                .IsRequired();
            builder.Property(e => e.Admission)
                .HasColumnName("admissao")
                .IsRequired();
            builder.Property(e => e.Demission)
                .HasColumnName("demissao");
            builder.Property(e => e.IdFunction)
                .HasColumnName("id_cargo")
                .IsRequired();
            builder.Property(e => e.IdSituation)
                .HasColumnName("id_situacao")
                .IsRequired();
            builder.HasOne(e => e.Function)
                .WithMany()
                .HasForeignKey(e => e.IdFunction)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            builder.HasOne(e => e.Situation)
                .WithMany()
                .HasForeignKey(e => e.IdSituation)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
