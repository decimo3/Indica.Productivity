namespace Indica.System.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int IdContract { get; set; }
        public int IdProcess { get; set; }
        public int PaymentMaster { get; set; }
        public decimal ValueLight { get; set; }
        public decimal ValueHeavy { get; set; }
        public decimal ValueSpecial { get; set; }
        public Contract Contract { get; set; }
        public Process Process { get; set; }
    }
}