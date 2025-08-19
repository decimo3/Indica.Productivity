namespace Indica.System.Domain.Entities
{
    public class FinishingPayment : EntityBase
    {
        public string IdFinishing { get; set; }
        public int IdPaymentMaster { get; set; }
        public virtual PaymentMaster Mestre { get; set; }
    }
}
