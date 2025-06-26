namespace Indica.System.Domain.Entities
{
    public class Payment : EntityBase
    {
        public int IdContract { get; set; }
        public int IdProject { get; set; }
        public int IdPaymentMaster { get; set; }
        public bool IsCaminhao { get; set; }
        public bool IsEspecial { get; set; }
        public decimal Valuation { get; set; }
    }
}