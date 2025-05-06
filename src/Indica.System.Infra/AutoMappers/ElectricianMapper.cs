using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.AutoMappers
{
    public class ElectricianMapper : IEntityTypeConfiguration<Electrician>
    {
        public void Configure(EntityTypeBuilder<Electrician> builder)
        {
            builder.ToTable("Eletricista");
            builder.HasKey(e => e.Registry);
            builder.Property(e => e.Registry)
                .HasColumnName("matricula")
                .IsRequired();
            builder.Property(e => e.FullName)
                .HasColumnName("nome_colaborador")
                .IsRequired();
            builder.Property(e => e.Admission)
                .HasColumnName("adimissao")
                .IsRequired();
            builder.Property(e => e.Demission)
                .HasColumnName("demissao");
            builder.Property(e => e.Situation)
                .HasColumnName("situacao")
                .IsRequired();
            builder.Property(e => e.IdSupervisor)
                .HasColumnName("id_supervisor")
                .IsRequired();
        }
    }
}
