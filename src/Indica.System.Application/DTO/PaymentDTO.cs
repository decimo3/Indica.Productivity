namespace Indica.System.Application.DTO
{
    public class PaymentDTO : EntityBaseDTO
    {
        public int IdContractProject { get; set; }
        public int IdPaymentMaster { get; set; }
        public decimal Valuation { get; set; }
    }
}
