namespace Indica.Productivity.Domain.Entities
{
    public class WorkOrderSituation : EntityBase
    {
        public string SituationName { get; set; }
        public bool IsFinished { get; set; }
    }
}
