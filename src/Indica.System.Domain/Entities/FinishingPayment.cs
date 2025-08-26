namespace Indica.System.Domain.Entities
{
    public class FinishingPayment : EntityBase
    {
        public int IdFinishing { get; set; }
        public int IdPayment { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
