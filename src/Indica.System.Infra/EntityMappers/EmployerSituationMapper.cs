using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerSituationMapper : IEntityTypeConfiguration<EmployerSituation>
    {
        public void Configure(EntityTypeBuilder<EmployerSituation> builder)
        {
            builder.ToTable("EmployerSituations");
            builder.HasKey(x => x.IdSituation);
            builder.Property(x => x.IdSituation)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.SituationName)
                .HasMaxLength(16)
                .IsRequired();
            builder.HasData([
                new EmployerSituation
                {
                    IdSituation = 1,
                    SituationName = "Ativo"
                },
                new EmployerSituation
                {
                    IdSituation = 2,
                    SituationName = "Ferias"
                },
                new EmployerSituation
                {
                    IdSituation = 3,
                    SituationName = "Afastado"
                },
                new EmployerSituation
                {
                    IdSituation = 4,
                    SituationName = "Desligado"
                },
                ]);
        }

    }
}
