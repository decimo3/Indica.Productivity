namespace Indica.Productivity.Application.DTO
{
    public class WorkOrderResumeDTO : EntityBaseDTO
    {
        public String Filename { get; set; }
        public int ResourcesCount { get; set; }
        public int ServiceCount { get; set; }
    }
}
