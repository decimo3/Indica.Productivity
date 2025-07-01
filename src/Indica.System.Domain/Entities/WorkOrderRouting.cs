namespace Indica.System.Domain.Entities
{
    public class WorkOrderRouting : WorkOrderBase
    {
        public int IdFirstManualOperation { get; set; }
        public string FirstManualOperationPerformedByUserLogin { get; set; }
        public string FirstManualOperationPerformedByUserName { get; set; }
        public string EnRouteTimetable { get; set; }
        public string RODate { get; set; }
        public DateOnly AutoRoutedToMoment { get; set; }
        public int AutoRoutedToResourceId { get; set; }
        public string AutoRoutedToResourceName { get; set; }
        public int IdResource { get; set; }
        public int FirstManualOperationPerformedByUser { get; set; }
        public string UserConclusion { get; set; }
        public string BucketOrigin { get; set; }
    }
}