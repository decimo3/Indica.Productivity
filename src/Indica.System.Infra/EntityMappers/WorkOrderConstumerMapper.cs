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
                .HasColumnName("id_servico_cliente")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.InstallationNumber)
                .HasColumnName("instalacao")
                .IsRequired(false);
            builder.Property(x => x.CostumerName)
                .HasColumnName("nome_cliente")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.CostumerAddress)
                .HasColumnName("cliente_logradouro")
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.BuildingNumberOrAcronym)
                .HasColumnName("numero_de_rua")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.NumberComplement)
                .HasColumnName("complemento_de_numero")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.SubNeighborhood)
                .HasColumnName("subbairro")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.WorkAreaNumber)
                .HasColumnName("area_de_trabalho")
                .IsRequired(false);
            builder.Property(x => x.CostumerCity)
                .HasColumnName("cliente_cidade")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.CostumerState)
                .HasColumnName("cliente_estado")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.CostumerPostalCode)
                .HasColumnName("cliente_codigo_postal")
                .IsRequired();
            builder.Property(x => x.CostumerTelephone)
                .HasColumnName("cliente_telefone")
                .IsRequired();
            builder.Property(x => x.CostumerCellphone)
                .HasColumnName("cliente_celular")
                .IsRequired();
            builder.Property(x => x.CostumerEmail)
                .HasColumnName("cliente_email")
                .IsRequired();
            builder.Property(x => x.CoordinateX)
                .HasColumnName("coordenada_x")
                .IsRequired(false);
            builder.Property(x => x.CoordinateY)
                .HasColumnName("coordenada_y")
                .IsRequired(false);
            builder.Property(x => x.IdCoordinateAccuracy)
                .HasColumnName("id_coordenadas_precisao")
                .HasMaxLength(5)
                .IsRequired(false);
            builder.Property(x => x.IsFoundCoordinateStatus)
                .HasColumnName("eh_encontrada_coordenadas")
                .IsRequired(false);
        }
    }
}