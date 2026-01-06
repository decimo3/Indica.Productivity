namespace Indica.Productivity.Domain.Entities
{
    public class Project : EntityBase
    {
        public string ProjectName { get; set; }
        public int IdProcess { get; set; }
        public bool UsesDamage { get; set; } = false;
        public virtual Process Process { get; set; }
    }
}
