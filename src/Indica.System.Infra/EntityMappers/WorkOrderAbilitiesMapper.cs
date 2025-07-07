using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderAbilitiesMapper : IEntityTypeConfiguration<WorkOrderAbilities>
    {
        public void Configure(EntityTypeBuilder<WorkOrderAbilities> builder)
        {
            builder.ToTable("servico_habilidades");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico_habilidades")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.AbilityName)
                .HasColumnName("nome_servico_habilidades")
                .HasMaxLength(32)
                .IsRequired();
            builder.HasIndex(x => x.AbilityName).IsUnique();
        }
    }
}