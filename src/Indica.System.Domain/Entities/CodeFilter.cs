namespace Indica.System.Domain.Entities
{
    public class CodeFilter : EntityBase
    {
        public string Code { get; set; }
        public int IdProject { get; set; }
        public Project Project { get; set; }
    }
}