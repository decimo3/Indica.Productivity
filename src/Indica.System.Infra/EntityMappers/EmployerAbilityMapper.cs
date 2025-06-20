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
            builder.ToTable("funcionario_competencias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_funcionario_competencia")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.AbilityName)
                .HasColumnName("nome_funcionario_competencia")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}