namespace Indica.System.Domain.Entities
{
    public class Project : EntityBase
    {
        public string ProjectName { get; set; }
        public int IdProcess { get; set; }
        public virtual Process Process { get; set; }
    }
}
