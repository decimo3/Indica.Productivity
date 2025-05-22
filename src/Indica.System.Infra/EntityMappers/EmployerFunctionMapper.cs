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
                new EmployerFunction { Id = 1, FunctionName = "Eletricista" },
                new EmployerFunction { Id = 2, FunctionName = "Supervisor" },
                new EmployerFunction { Id = 3, FunctionName = "Controlador" },
                new EmployerFunction { Id = 4, FunctionName = "Qualidade" },
                new EmployerFunction { Id = 5, FunctionName = "Administrador"},
                new EmployerFunction { Id = 6, FunctionName = "Proprietario" },
                ]);
        }
    }
}
