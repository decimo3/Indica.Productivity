using Indica.System.Shared;
namespace Indica.System.Application.DTO
{
    public class WorkOrderDTO : EntityBaseDTO
    {
        [Alias("Recurso")]
        public string Resource { get; set; }
        [Alias("Data")]
        public DateOnly Date { get; set; }
        [Alias("ID da Atividade")]
        public int IdActivity { get; set; }
        [Alias("Status da Atividade")]
        public string SituationName { get; set; }
        [Alias("Nome")]
        public string? CostumerName { get; set; }
        [Alias("Endereço")]
        public string? CostumerAddress { get; set; }
        [Alias("Cidade")]
        public string? CostumerCity { get; set; }
        [Alias("Estado")]
        public string? CostumerState { get; set; }
        [Alias("CEP/Código Postal")]
        public int? CostumerPostalCode { get; set; }
        [Alias("Telefone")]
        public long? CostumerTelephone { get; set; }
        [Alias("Telefone Celular")]
        public long? CostumerCellphone { get; set; }
        [Alias("E-mail")]
        public string? CostumerEmail { get; set; }
        [Alias("Início")]
        public TimeOnly StartTime { get; set; }
        [Alias("Fim")]
        public TimeOnly FinalTime { get; set; }
        [Alias("Início do SLA")]
        public DateTime StartOfSLA { get; set; }
        [Alias("Fim do SLA")]
        public DateTime FinalOfSLA { get; set; }
        [Alias("Duração")]
        public TimeSpan DurationTime { get; set; }
        [Alias("Tempo de Deslocamento")]
        public TimeSpan TravellingTime { get; set; }
        [Alias("Tipo de Atividade")]
        [Alias("Tipo de Atividade")]
        public string TypeOfActivity { get; set; }
        [Alias("Ordem de Serviço")]
        public long WorkOrderNumber { get; set; }
        [Alias("Habilidade de Trabalho")]
        public string WorkOrderAbility { get; set; }
        [Alias("Área de Trabalho")]
        public string WorkOrderArea { get; set; }
        [Alias("Data de Início de turno")]
        public DateTime ShiftStartDate { get; set; }
        [Alias("Coordenada X")]
        public double CoordinateX { get; set; }
        [Alias("Coordenada Y")]
        public double CoordinateY { get; set; }
        [Alias("Exatidão das Coordenadas")]
        public string CoordinateAccuracy { get; set; }
        [Alias("Status da Coordenada")]
        public bool IsFoundCoordinateStatus { get; set; }
        [Alias("Códigos Fechamento")]
        public string ClosingCodes { get; set; }
        [Alias("LG_CTRL_TipoFechamento_Ok")]
        public bool IsLgCtrlTypeClosingOk { get; set; }
        [Alias("Cod. Fechamento Preenchido")]
        public bool IsClosedCodesFilledIn { get; set; }
        [Alias("Códs. de Fechamento")]
        [Alias("Motivo de Rejeição")]
        public string ClosingCodes_1 { get; set; }
        [Alias("Label do veículo")]
        public string VehicleLabel { get; set; }
        [Alias("IdMatriculaLider")]
        public int IdLeaderRegistration { get; set; }
        [Alias("IdMatriculaAuxiliares")]
        public int IdAuxiliaryRegistration { get; set; }
        [Alias("IdMatriculaGuarda")]
        public int IdTechnicalRegistration { get; set; }
        [Alias("Observação")]
        public string Observation { get; set; }
        [Alias("Descrição breve do conteúdo da nota")]
        public string Description { get; set; }
        [Alias("Sub-bairro")]
        public string SubNeighborhood { get; set; }
        [Alias("LG_FLAG_PREECH_FECHAMENTO")]
        public bool IsLgFlagPrefillimentoClosing { get; set; }
        [Alias("Codigos de fechametno da atividade Pai v03")]
        public string ParentActivityClosingCodesV03 { get; set; }
        [Alias("LG_CTRL_REPROV_FLAG")]
        public bool IsLgCtrlReprovedFlag { get; set; }
        [Alias("Número da Instalação")]
        public long InstallationNumber { get; set; }
        [Alias("Edifício (nº ou sigla)")]
        public string BuildingNumberOrAcronym { get; set; }
        [Alias("Complemento do nº")]
        public string NumberComplement { get; set; }
        [Alias("Intervalo de Tempo")]
        [Alias("Motivo indisponibilidade")]
        public string UnavailableReasonOrIntervalDescription { get; set; }
        [Alias("Tipo de Nota de Serviço")]
        public string TypeOfServiceNote { get; set; }
        [Alias("Tempo de Reserva da Atividade")]
        public DateTime ActivityBookingTime { get; set; }
        [Alias("Total de Débitos")]
        public decimal TotalCustomerDebts { get; set; }
        [Alias("Balde Origem")]
        public string BucketOrigin { get; set; }
        [Alias("Tipo de ligação")]
        public int ConnectionType { get; set; }
        [Alias("Cliente assinou TOI?")]
        public bool HasCustomerSignedToi { get; set; }
        [Alias("Recusou a assinar TOI?")]
        public bool HasRefusedToSignToi { get; set; }
        [Alias("Recusou receber TOI?")]
        public bool HasRefusedToReceiveToi { get; set; }
        [Alias("Cliente autorizou levantamento de Carga")]
        public string CustomerAuthorizedloadAnalysis { get; set; }
        [Alias("Deslocamento estimado")]
        public TimeSpan EstimatedTravellingTime { get; set; }
        [Alias("Duração padrão")]
        public TimeSpan EstimatedDurationTime { get; set; }
        [Alias("Abrangência")]
        public string ScopeOfService { get; set; }
        [Alias("CHI")]
        public int CHI { get; set; }
        [Alias("Tempo Interrompido")]
        public int InterruptedTime { get; set; }
        [Alias("Valor Compensação Financeira")]
        public int FinancialCompensationAmount { get; set; }
    }
}