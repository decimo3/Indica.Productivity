namespace Indica.Productivity.Domain.Entities
{
    public class FinishingDetail : EntityBase
    {
        public string Detail { get; set; }
        public bool IsExecuted { get; set; }
    }
}
