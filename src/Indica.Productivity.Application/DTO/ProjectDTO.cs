namespace Indica.Productivity.Application.DTO
{
    public class ProjectDTO : EntityBaseDTO
    {
        public string ProjectName { get; set; }
        public bool UsesDamage { get; set; } = false;
        public int IdProcess { get; set; }
    }
}
