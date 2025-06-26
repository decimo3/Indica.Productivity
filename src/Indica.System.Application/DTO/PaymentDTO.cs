namespace Indica.System.Application.DTO
{
    public class PaymentDTO : EntityBaseDTO
    {
        public int IdContract { get; set; }
        public int IdProject { get; set; }
        public int IdPaymentMaster { get; set; }
        public bool IsCaminhao { get; set; }
        public bool IsEspecial { get; set; }
        public decimal Valuation { get; set; }
    }
}
