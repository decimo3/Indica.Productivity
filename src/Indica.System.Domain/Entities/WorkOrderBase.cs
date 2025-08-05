namespace Indica.System.Domain.Entities
{
    public class WorkOrderBase : EntityBase
    {
        public string Resource { get; set; }
        public DateOnly Date { get; set; }
        public long IdActivity { get; set; }
        public int IdSituation { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly FinalTime { get; set; }
        public TimeSpan DurationTime { get; set; }
        public TimeSpan TravellingTime { get; set; }
        public int IdTypeOfActivity { get; set; }
        public DateTime ActivityBookingTime { get; set; }
        public TimeSpan EstimatedTravellingTime { get; set; }
        public TimeSpan EstimatedDurationTime { get; set; }
        public string FileName { get; set; }
        public string ComposedKey { get; set; }
        public virtual DamageToProcess DamageToProcess { get; set; }
        public virtual WorkOrderSituation WorkOrderSituation { get; set; }
    }
}