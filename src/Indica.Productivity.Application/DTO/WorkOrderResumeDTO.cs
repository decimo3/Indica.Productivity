namespace Indica.Productivity.Application.DTO
{
    public class WorkOrderResumeDTO : EntityBaseDTO
    {
        public DateOnly Date { get; set; }
        public String Filename { get; set; }
        public int ResourcesCount { get; set; }
        public int ServiceCount { get; set; }
    }
}
