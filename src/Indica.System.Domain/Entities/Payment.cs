namespace Indica.System.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int IdContract { get; set; }
        public int IdProcess { get; set; }
        public int PaymentMaster { get; set; }
        public decimal Value { get; set; }
        public Contract Contract { get; set; }
        public Process Process { get; set; }
    }
}