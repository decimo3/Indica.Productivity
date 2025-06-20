namespace Indica.System.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int IdContract { get; set; }
        public int IdProject { get; set; }
        public int IdPaymentMaster { get; set; }
        public decimal ValueLight { get; set; }
        public decimal ValueHeavy { get; set; }
        public decimal ValueSpecial { get; set; }
    }
}