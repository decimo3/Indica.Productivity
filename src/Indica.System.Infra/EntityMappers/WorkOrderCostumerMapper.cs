using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderCostumerMapper : IEntityTypeConfiguration<WorkOrderCostumer>
    {
        public void Configure(EntityTypeBuilder<WorkOrderCostumer> builder)
        {
            builder.ToTable("servico_cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.InstallationNumber)
                .HasColumnName("instalacao")
                .IsRequired();
            builder.Property(x => x.CostumerName)
                .HasColumnName("nome")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.CostumerAddress)
                .HasColumnName("logradouro")
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.BuildingNumberOrAcronym)
                .HasColumnName("numero")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.NumberComplement)
                .HasColumnName("complemento")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.SubNeighborhood)
                .HasColumnName("sub_bairro")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.WorkAreaNumber)
                .HasColumnName("localidade")
                .IsRequired();
            builder.Property(x => x.CostumerCity)
                .HasColumnName("cidade")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.CostumerState)
                .HasColumnName("estado")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.CostumerPostalCode)
                .HasColumnName("codigo_postal")
                .IsRequired();
            builder.Property(x => x.CostumerTelephone)
                .HasColumnName("telefone")
                .IsRequired();
            builder.Property(x => x.CostumerCellphone)
                .HasColumnName("celular")
                .IsRequired();
            builder.Property(x => x.CostumerEmail)
                .HasColumnName("email")
                .IsRequired();
            builder.Property(x => x.CoordinateX)
                .HasColumnName("coordenada_x")
                .IsRequired();
            builder.Property(x => x.CoordinateY)
                .HasColumnName("coordenada_y")
                .IsRequired();
            builder.Property(x => x.IdCoordinateAccuracy)
                .HasColumnName("id_coordenadas_exatidao")
                .HasMaxLength(5)
                .IsRequired();
            builder.Property(x => x.IsFoundCoordinateStatus)
                .HasColumnName("eh_encontrada_coordenadas")
                .IsRequired();
            builder.Property(x => x.IdConnectionType)
                .HasColumnName("fases")
                .IsRequired();
            builder.HasOne(x => x.Phase)
                .WithMany()
                .HasForeignKey(x => x.IdConnectionType)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.Accuracy)
                .WithMany()
                .HasForeignKey(x => x.IdCoordinateAccuracy)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => x.InstallationNumber).IsUnique();
        }
    }
}