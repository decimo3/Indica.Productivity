namespace Indica.System.Domain.Entities
{
    public class FieldTeamCouple : EntityBase
    {
        public int IdFieldTeam { get; set; }
        public int IdEmployer { get; set; }
        public int IdFunction { get; set; }
        public virtual FieldTeam FieldTeam { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual FieldTeamFunction Function { get; set; }
    }
}
