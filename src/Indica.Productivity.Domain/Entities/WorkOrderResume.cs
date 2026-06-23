namespace Indica.Productivity.Domain.Entities
{
    public class WorkOrderResume : EntityBase
    {
        public DateOnly Date { get; set; }
        public String Filename { get; set; }
        public int ResourceCount { get; set; }
        public int ServiceCount { get; set; }
    }
}
