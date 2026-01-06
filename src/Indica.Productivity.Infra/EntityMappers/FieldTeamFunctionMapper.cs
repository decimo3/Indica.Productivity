using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class FieldTeamFuncionMapper : IEntityTypeConfiguration<FieldTeamFunction>
    {
        public void Configure(EntityTypeBuilder<FieldTeamFunction> builder)
        {
            builder.ToTable("composicao_funcoes");
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
            builder.HasData([
                new FieldTeamFunction() { Id = 1, FunctionName = "supervisor" },
                new FieldTeamFunction() { Id = 2, FunctionName = "executor1" },
                new FieldTeamFunction() { Id = 3, FunctionName = "executor2" },
                new FieldTeamFunction() { Id = 4, FunctionName = "executor3" },
                ]);
        }
    }
}