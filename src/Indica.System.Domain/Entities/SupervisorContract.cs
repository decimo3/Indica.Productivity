namespace Indica.System.Domain.Entities
{
    public class ContractProject : EntityBase
    {
        public int IdContract { get; set; }
        public int IdRegional { get; set; }
        public int IdProject { get; set; }
        public Contract Contract { get; set; }
        public FieldTeamRegional Regional { get; set; }
        public Project Project { get; set; }
    }
}
