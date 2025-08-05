namespace Indica.System.Domain.Entities
{
    public class Finishing : EntityBase
    {
        public string GroupingOfMeasures { get; set; }
        public int IdFinishingDetail { get; set; }
        public FinishingDetail Detail { get; set; }
    }    
}