namespace Indica.Productivity.Domain.Entities
{
    public class WorkOrderResume : EntityBase
    {
        public String Filename { get; set; }
        public int ResourceCount { get; set; }
        public int ServiceCount { get; set; }
    }
}
