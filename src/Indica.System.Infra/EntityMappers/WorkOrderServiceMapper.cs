using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderServiceMapper : IEntityTypeConfiguration<WorkOrderService>
    {
        public void Configure(EntityTypeBuilder<WorkOrderService> builder)
        {
            builder.ToTable("servico_servico");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servico_servico")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.WorkOrderNumber)
                .HasColumnName("nota_de_servico")
                .IsRequired();
            builder.Property(x => x.StartOfSLA)
                .HasColumnName("inicio_do_sla")
                .HasDefaultValue(DateTime.MinValue)
                .IsRequired();
            builder.Property(x => x.FinalOfSLA)
                .HasColumnName("final_do_sla")
                .HasDefaultValue(DateTime.MaxValue)
                .IsRequired();
            builder.Property(x => x.IsLgCtrlTypeClosingOk)
                .HasColumnName("eh_lg_ctrl_tipo_fechamento_ok")
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(x => x.IsClosedCodesFilledIn)
                .HasColumnName("codigos_fechamento_preenchido")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.ClosingCodes)
                .HasColumnName("codigos_fechamentos")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.Observation)
                .HasColumnName("observacao")
                .HasMaxLength(1024)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasColumnName("descricao")
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.IsLgFlagPrefillimentoClosing)
                .HasColumnName("eh_lg_flag_preech_fechamento")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.ParentActivityClosingCodesV03)
                .HasColumnName("codigos_de_fechamento_da_atividade_pai")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.IsLgCtrlReprovedFlag)
                .HasColumnName("eh_lg_ctrl_reprovado_flag")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.TypeOfServiceNote)
                .HasColumnName("tipo_da_nota")
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired(false);
            builder.Property(x => x.BucketOrigin)
                .HasColumnName("balde_origem")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.TotalCustomerDebts)
                .HasColumnName("cliente_debitos")
                .IsRequired();
            builder.Property(x => x.HasCustomerSignedToi)
                .HasColumnName("eh_cliente_assinou_toi")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.HasRefusedToSignToi)
                .HasColumnName("eh_cliente_recusa_assinar_toi")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.HasRefusedToReceiveToi)
                .HasColumnName("eh_cliente_recusa_receber_toi")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.CustomerAuthorizedloadAnalysis)
                .HasColumnName("eh_cliente_autorizou_levantar_carga")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.ScopeOfService)
                .HasColumnName("abrangencia")
                .HasDefaultValue(null)
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.CHI)
                .HasColumnName("chi")
                .HasDefaultValue(0)
                .IsRequired(false);
            builder.Property(x => x.InterruptedTime)
                .HasColumnName("tempo_interrompido")
                .IsRequired(false);
            builder.Property(x => x.FinancialCompensationAmount)
                .HasColumnName("valor_compensação_financeira")
                .IsRequired();
            builder.Property(x => x.IdFinishing)
                .HasColumnName("id_finalizacao")
                .IsRequired();
            builder.Property(x => x.IdWorkAbility)
                .HasColumnName("id_habilidade")
                .IsRequired();
            builder.Property(x => x.IdCostumer)
                .HasColumnName("id_cliente")
                .IsRequired();
            builder.HasOne(x => x.Finishing)
                .WithMany()
                .HasForeignKey(x => x.IdFinishing)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.WorkOrderAbility)
                .WithMany()
                .HasForeignKey(x => x.IdWorkAbility)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.WorkOrderCostumer)
                .WithMany()
                .HasForeignKey(x => x.IdCostumer)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}