namespace Indica.Productivity.Application.DTO
{
    public class FinishingDTO : EntityBaseDTO
    {
        public string GroupingOfMeasures { get; set; }
        public string FinishingDetail { get; set; }
        public string PaymentMasters { get; set; }
        public bool IsAlternative { get; set; }
    }
}