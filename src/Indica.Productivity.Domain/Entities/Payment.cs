namespace Indica.Productivity.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int IdContractProject { get; set; }
        public int IdPaymentMaster { get; set; }
        public decimal Valuation { get; set; }
        public virtual ContractProject ContractProject { get; set; }
        public virtual PaymentMaster Mestre { get; set; }
    }
}