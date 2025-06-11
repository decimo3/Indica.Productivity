namespace Indica.System.Application.DTO
{
    public class PaymentDTO : EntityBaseDTO
    {
        public int IdContract { get; set; }
        public int IdProcess { get; set; }
        public int PaymentMaster { get; set; }
        public decimal ValueLight { get; set; }
        public decimal ValueHeavy { get; set; }
        public decimal ValueSpecial { get; set; }
    }
}
