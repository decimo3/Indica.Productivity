namespace Indica.System.Domain.Entities
{
    public class Payment
    {
        public int ContractNumber { get; set; }
        public int AdditiveNumber { get; set; }
        public int IdProcess { get; set; }
        public int PaymentMaster { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}