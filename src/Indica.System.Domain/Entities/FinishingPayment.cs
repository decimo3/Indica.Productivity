namespace Indica.System.Domain.Entities
{
    public class FinishingPayment : EntityBase
    {
        public int IdFinishing { get; set; }
        public int IdMaster { get; set; }
        public bool IsAlternative { get; set; }
        public virtual PaymentMaster Master { get; set; }
        public virtual Finishing Finishing { get; set; }
    }
}
