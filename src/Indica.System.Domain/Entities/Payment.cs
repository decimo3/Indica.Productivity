namespace Indica.System.Domain.Entities
{
    public class Payment
    {
        public double IdContract { get; set; }
        public string ProcessName { get; set; }
        public int PaymentMaster { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}