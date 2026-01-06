using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class EmployerMapper : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("funcionarios");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id_funcionario")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.IndicaRegistry)
                .HasColumnName("matricula_indica")
                .IsRequired();
            builder.Property(e => e.ClientRegistry)
                .HasColumnName("matricula_cliente")
                .IsRequired();
            builder.Property(e => e.FullName)
                .HasColumnName("nome_funcionario")
                .IsRequired();
            builder.Property(e => e.Admission)
                .HasColumnName("data_admissao")
                .IsRequired();
            builder.Property(e => e.Demission)
                .HasColumnName("data_demissao")
                .IsRequired(false);
            builder.Property(e => e.IdFunction)
                .HasColumnName("id_funcionario_funcao")
                .IsRequired();
            builder.Property(e => e.IdSituation)
                .HasColumnName("id_funcionario_situacao")
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
            builder.HasIndex(x => new { x.IndicaRegistry, x.ClientRegistry }).IsUnique();
        }
    }
}
