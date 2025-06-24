using System.Globalization;
using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerAbilityMapper : IEntityTypeConfiguration<EmployerAbility>
    {
        public void Configure(EntityTypeBuilder<EmployerAbility> builder)
        {
            builder.ToTable("competencias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_competencia")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.AbilityName)
                .HasColumnName("nome_competencia")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}