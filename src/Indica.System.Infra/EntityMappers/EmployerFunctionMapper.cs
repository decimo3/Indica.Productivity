using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class EmployerFunctionMapper : IEntityTypeConfiguration<EmployerFunction>
    {
        public void Configure(EntityTypeBuilder<EmployerFunction> builder)
        {
            builder.ToTable("cargos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.FunctionName)
                .HasColumnName("cargo")
                .HasMaxLength(16)
                .IsRequired();
            builder.HasData([
                new EmployerFunction { FunctionName = "Eletricista" },
                new EmployerFunction { FunctionName = "Supervisor" },
                new EmployerFunction { FunctionName = "Controlador" },
                new EmployerFunction { FunctionName = "Qualidade" },
                new EmployerFunction { FunctionName = "Administrador"},
                new EmployerFunction { FunctionName = "Proprietario" },
                ]);
        }
    }
}
