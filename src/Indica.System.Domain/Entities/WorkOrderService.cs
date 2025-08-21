namespace Indica.System.Domain.Entities
{
    public class WorkOrderService : WorkOrderBase
    {
        public long WorkOrderNumber { get; set; }
        public int IdCostumer { get; set; }
        public string WorkOrderAbility { get; set; }
        public DateTime StartOfSLA { get; set; }
        public DateTime FinalOfSLA { get; set; }
        public string ClosingCodes { get; set; }
        public bool IsLgCtrlTypeClosingOk { get; set; }
        public bool IsClosedCodesFilledIn { get; set; }
        public string? Observation { get; set; }
        public string? Description { get; set; }
        public bool IsLgFlagPrefillimentoClosing { get; set; }
        public string ParentActivityClosingCodesV03 { get; set; }
        public bool IsLgCtrlReprovedFlag { get; set; }
        public string TypeOfServiceNote { get; set; }
        public string BucketOrigin { get; set; }
        public decimal TotalCustomerDebts { get; set; }
        public bool? HasCustomerSignedToi { get; set; }
        public bool? HasRefusedToSignToi { get; set; }
        public bool? HasRefusedToReceiveToi { get; set; }
        public bool? CustomerAuthorizedloadAnalysis { get; set; }
        public string ScopeOfService { get; set; }
        public int CHI { get; set; }
        public int InterruptedTime { get; set; }
        public int FinancialCompensationAmount { get; set; }
        public int IdFinishing { get; set; }
        public virtual Finishing Finishing { get; set; }
        public virtual WorkOrderCostumer WorkOrderCostumer { get; set; }
    }
}