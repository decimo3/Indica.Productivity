using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerSituationMapper : IEntityTypeConfiguration<EmployerSituation>
    {
        public void Configure(EntityTypeBuilder<EmployerSituation> builder)
        {
            builder.ToTable("funcionario_situacoes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_funcionario_situacao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.SituationName)
                .HasColumnName("nome_funcionario_situacao")
                .HasMaxLength(16)
                .IsRequired();
            builder.HasData([
                new EmployerSituation { Id = 1, SituationName = "ativo" },
                new EmployerSituation { Id = 2, SituationName = "inss" },
                new EmployerSituation { Id = 3, SituationName = "ferias" },
                new EmployerSituation { Id = 4, SituationName = "suspenso" },
                new EmployerSituation { Id = 5, SituationName = "desligado" }
                ]);
        }

    }
}
