using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class FieldTeamFuncionMapper : IEntityTypeConfiguration<FieldTeamFunction>
    {
        public void Configure(EntityTypeBuilder<FieldTeamFunction> builder)
        {
            builder.ToTable("composicao_funcao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_composicao_funcao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.FunctionName)
                .HasColumnName("nome_composicao_funcao")
                .HasMaxLength(32)
                .IsRequired();
            builder.HasIndex(x => x.FunctionName).IsUnique();
        }
    }
}