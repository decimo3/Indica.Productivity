using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerSituationMapper : IEntityTypeConfiguration<EmployerSituation>
    {
        public void Configure(EntityTypeBuilder<EmployerSituation> builder)
        {
            builder.ToTable("funcionario_situacao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.SituationName)
                .HasMaxLength(16)
                .IsRequired();
            builder.HasData([
                new EmployerSituation { SituationName = "Ativo" },
                new EmployerSituation { SituationName = "Ferias" },
                new EmployerSituation { SituationName = "Afastado" },
                new EmployerSituation { SituationName = "Desligado" },
                ]);
        }

    }
}
