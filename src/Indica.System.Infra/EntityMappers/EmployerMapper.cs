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
            builder.HasKey(e => e.Registry);
            builder.Property(e => e.Registry)
                .HasColumnName("matricula")
                .IsRequired();
            builder.Property(e => e.FullName)
                .HasColumnName("nome_colaborador")
                .IsRequired();
            builder.Property(e => e.Admission)
                .HasColumnName("admissao")
                .IsRequired();
            builder.Property(e => e.Demission)
                .HasColumnName("demissao");
            builder.Property(e => e.IdRole)
                .HasColumnName("id_cargo")
                .IsRequired();
            builder.Property(e => e.IdSituation)
                .HasColumnName("id_situacao")
                .IsRequired();
        }
    }
}
