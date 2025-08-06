namespace Indica.System.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int IdContractProject { get; set; }
        public int IdPaymentMaster { get; set; }
        public bool IsCaminhao { get; set; }
        public bool IsEspecial { get; set; }
        public decimal Valuation { get; set; }
        public ContractProject ContractProject { get; set; }
        public PaymentMaster Mestre { get; set; }
    }
}