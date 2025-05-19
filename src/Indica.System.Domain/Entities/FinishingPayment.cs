namespace Indica.System.Domain.Entities
{
    public class FinishingPayment : EntityBase
    {
        public string GroupingOfMeasures { get; set; }
        public int IdPaymentMaster { get; set; }
    }
}
