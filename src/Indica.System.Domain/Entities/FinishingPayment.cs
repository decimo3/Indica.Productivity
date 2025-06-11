namespace Indica.System.Domain.Entities
{
    public class FinishingPayment : EntityBase
    {
        public string GroupingOfMeasures { get; set; }
        public int IdPaymentMaster { get; set; }
        public int IdFinishingDetail { get; set; }
        public virtual FinishingDetail FinishingDetail { get; set; }
    }
}
