using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerFunctionMapper : IEntityTypeConfiguration<EmployerFunction>
    {
        public void Configure(EntityTypeBuilder<EmployerFunction> builder)
        {
            builder.ToTable("funcionario_funcoes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id_funcionario_funcao")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.FunctionName)
                .HasColumnName("nome_funcionario_funcao")
                .HasMaxLength(16)
                .IsRequired();
            builder.HasIndex(x => x.FunctionName).IsUnique();
            builder.HasData([
                new EmployerFunction { Id = 1, FunctionName = "eletricista" },
                new EmployerFunction { Id = 2, FunctionName = "supervisor" },
                new EmployerFunction { Id = 3, FunctionName = "controlador" },
                new EmployerFunction { Id = 4, FunctionName = "administrador" },
                new EmployerFunction { Id = 5, FunctionName = "proprietario"}
                ]);
        }
    }
}
