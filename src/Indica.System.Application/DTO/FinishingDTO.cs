namespace Indica.System.Application.DTO
{
    public class FinishingPaymentDTO : EntityBaseDTO
    {
        public string GroupingOfMeasures { get; set; }
        public string FinishingDetail { get; set; }
        public string PaymentMasters { get; set; }
    }
}