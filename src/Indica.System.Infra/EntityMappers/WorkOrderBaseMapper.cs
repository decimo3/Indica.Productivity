using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class WorkOrderMapper : IEntityTypeConfiguration<WorkOrderBase>
    {
        public void Configure(EntityTypeBuilder<WorkOrderBase> builder)
        {
            builder.ToTable("servicos_base");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_servicos")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Resource)
                .HasColumnName("recurso")
                .IsRequired();
            builder.Property(x => x.Date)
                .HasColumnName("data")
                .IsRequired();
            builder.Property(x => x.IdActivity)
                .HasColumnName("id_da_atividade")
                .IsRequired();
            builder.Property(x => x.IdSituation)
                .HasColumnName("id_status_da_atividade")
                .IsRequired();
            builder.Property(x => x.StartTime)
                .HasColumnName("tempo_inicio")
                .IsRequired();
            builder.Property(x => x.FinalTime)
                .HasColumnName("tempo_final")
                .IsRequired();
            builder.Property(x => x.StartFinal)
                .HasColumnName("inicio_final")
                .HasMaxLength(13)
                .IsFixedLength()
                .IsRequired();
            builder.Property(x => x.StartOfSLA)
                .HasColumnName("inicio_do_sla")
                .IsRequired(false);
            builder.Property(x => x.FinalOfSLA)
                .HasColumnName("final_do_sla")
                .IsRequired(false);
            builder.Property(x => x.DurationTime)
                .HasColumnName("tempo_duracao")
                .IsRequired(false);
            builder.Property(x => x.TravellingTime)
                .HasColumnName("tempo_deslocamento")
                .IsRequired(false);
            builder.Property(x => x.TypeOfActivity)
                .HasColumnName("tipo_atividade")
                .HasDefaultValue("normal")
                .HasMaxLength(6)
                .IsFixedLength()
                .IsRequired();
            builder.Property(x => x.TypeOfActivity_1)
                .HasColumnName("dano")
                .HasMaxLength(4)
                .IsFixedLength()
                .IsRequired();
            builder.Property(x => x.WorkOrderNumber)
                .HasColumnName("nota")
                .IsRequired(false);
            builder.Property(x => x.AccountNumber)
                .HasColumnName("numero_conta")
                .HasDefaultValue(null)
                .IsRequired();
            builder.Property(x => x.IdWorkAbility)
                .HasColumnName("id_habilidade")
                .HasMaxLength(64)
                .IsFixedLength()
                .IsRequired(false);
            builder.Property(x => x.FirstManualOperation)
                .HasColumnName("primeira_operacao_manual")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.FirstManualOperationPerformedByUserLogin)
                .HasColumnName("primeira_operacao_manual_usuario_login")
                .HasMaxLength(64)
                .IsRequired(false);
            builder.Property(x => x.FirstManualOperationPerformedByUserName)
                .HasColumnName("primeira_operacao_manual_usuario_nome")
                .HasMaxLength(64)
                .IsRequired(false);
            builder.Property(x => x.EnRouteTimetable)
                .HasColumnName("horario_en_rota")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.ShiftStartDate)
                .HasColumnName("inicio_da_turno")
                .IsRequired(false);
            builder.Property(x => x.RODate)
                .HasColumnName("data_ro")
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.AutoRoutedToMoment)
                .HasColumnName("roteado_automaticamente_ate_o_momento")
                .IsRequired(false);
            builder.Property(x => x.AutoRoutedToResource)
                .HasColumnName("roteado_automaticamente_ate_o_recurso_id")
                .IsRequired(false);
            builder.Property(x => x.AutoRoutedToResourceName)
                .HasColumnName("roteado_automaticamente_ate_o_recurso_nome")
                .HasMaxLength(64)
                .IsRequired(false);
            builder.Property(x => x.IdResource)
                .HasColumnName("id_recurso")
                .IsRequired(false);
            builder.Property(x => x.FirstManualOperationPerformedByUser)
                .HasColumnName("primeira_operacao_manual_usuario")
                .IsRequired(false);
            builder.Property(x => x.UserConclusion)
                .HasColumnName("conclusao_do_usuario")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.ClosingCodes)
                .HasColumnName("codigos_fechamentos")
                .HasMaxLength(0)
                .HasDefaultValue(null)
                .IsRequired(false);
            builder.Property(x => x.IsLgCtrlTypeClosingOk)
                .HasColumnName("eh_lg_ctrl_tipo_fechamento_ok")
                .IsRequired(false);
            builder.Property(x => x.IsClosedCodesFilledIn)
                .HasColumnName("codigos_fechamento_preenchido")
                .IsRequired(false);
            builder.Property(x => x.ClosingCodes_1)
                .HasColumnName("codigos_fechamentos_1")
                .HasMaxLength(128)
                .IsRequired(false);
            builder.Property(x => x.VehicleLabel)
                .HasColumnName("label_do_veiculo")
                .HasMaxLength(13)
                .IsFixedLength()
                .IsRequired(false);
            builder.Property(x => x.IdLeaderRegistration)
                .HasColumnName("id_matricula_lider")
                .IsRequired(false);
            builder.Property(x => x.IdAuxiliaryRegistration)
                .HasColumnName("id_matricula_auxiliares")
                .IsRequired(false);
            builder.Property(x => x.IdTechnicalRegistration)
                .HasColumnName("id_matricula_tecnico")
                .IsRequired(false);
            builder.Property(x => x.Observation)
                .HasColumnName("observacao")
                .HasMaxLength(1024)
                .IsRequired(false);
            builder.Property(x => x.Description)
                .HasColumnName("descricao")
                .HasMaxLength(64)
                .IsRequired(false);
            builder.Property(x => x.IsLgFlagPrefillimentoClosing)
                .HasColumnName("eh_lg_flag_preech_fechamento")
                .HasDefaultValue(false)
                .IsRequired(false);
            builder.Property(x => x.ParentActivityClosingCodesV03)
                .HasColumnName("codigos_de_fechamento_da_atividade_pai")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.IsLgCtrlReprovedFlag)
                .HasColumnName("lg_ctrl_reprovado_flag")
                .HasDefaultValue(false)
                .IsRequired(false);
            builder.Property(x => x.TimeInterval)
                .HasColumnName("intervalo_de_tempo")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.ReasonForRejection)
                .HasColumnName("motivo_de_rejeicao")
                .IsRequired(false);
            builder.Property(x => x.TypeOfServiceNote)
                .HasColumnName("tipo_da_nota")
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired(false);
            builder.Property(x => x.ActivityBookingTime)
                .HasColumnName("tempo_de_reserva_da_atividade")
                .IsRequired();
            builder.Property(x => x.TotalCustomerDebts)
                .HasColumnName("cliente_debitos")
                .IsRequired(false);
            builder.Property(x => x.BucketOrigin)
                .HasColumnName("balde_origem")
                .IsRequired(false);
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
            builder.Property(x => x.EstimatedTravellingTime)
                .HasColumnName("desloca_estimado")
                .IsRequired(false);
            builder.Property(x => x.EstimatedDurationTime)
                .HasColumnName("duracao_estimado")
                .IsRequired(false);
            builder.Property(x => x.ScopeOfService)
                .HasColumnName("abrangencia")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.ReasonForUnavailability)
                .HasColumnName("motivo_indisponibilidade")
                .HasMaxLength(32)
                .IsRequired(false);
            builder.Property(x => x.CHI)
                .HasColumnName("chi")
                .IsRequired(false);
            builder.Property(x => x.InterruptedTime)
                .HasColumnName("tempo_interrompido")
                .IsRequired(false);
            builder.Property(x => x.FinancialCompensationAmount)
                .HasColumnName("valor_compensação_financeira")
                .IsRequired(false);
            builder.Property(x => x.FileName)
                .HasColumnName("nome_do_arquivo")
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.ComposedKey)
                .HasColumnName("identificador")
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.IdFinishing)
                .HasColumnName("id_finalizacao")
                .IsRequired(false);
            builder.HasOne<WorkOrderAbilities>()
                .WithMany()
                .HasForeignKey(x => x.IdWorkAbility)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne<WorkOrderSituation>()
                .WithMany()
                .HasForeignKey(x => x.IdSituation)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne<DamageToProcess>()
                .WithMany()
                .HasForeignKey(x => x.TypeOfActivity_1)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne<Finishing>()
                .WithMany()
                .HasForeignKey(x => x.IdFinishing)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => x.IdActivity).IsUnique();
        }
    }
}