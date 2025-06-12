namespace Indica.System.Application.DTO
{
    public class FinishingPaymentDTO : EntityBaseDTO
    {
        public string GroupingOfMeasures { get; set; }
        public int IdFinishingDetail { get; set; }
        public int IdPaymentMaster { get; set; }
    }
}
