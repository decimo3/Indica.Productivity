namespace Indica.System.Domain.Entities
{
    public class ContractProject : EntityBase
    {
        public int IdContract { get; set; }
        public int IdRegional { get; set; }
        public int IdProject { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual FieldTeamRegional Regional { get; set; }
        public virtual Project Project { get; set; }
    }
}
