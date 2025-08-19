namespace Indica.System.Domain.Entities
{
    public class Finishing : EntityBase
    {
        public string GroupingOfMeasures { get; set; }
        public int IdFinishingDetail { get; set; }
        public virtual FinishingDetail Detail { get; set; }
        public virtual List<FinishingPayment> Payments { get; set; }
    }    
}