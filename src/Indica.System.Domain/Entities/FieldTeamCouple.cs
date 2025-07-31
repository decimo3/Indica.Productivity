namespace Indica.System.Domain.Entities
{
    public class FieldTeamCouple : EntityBase
    {
        public int IdFieldTeam { get; set; }
        public int IdEmployer { get; set; }
        public int IdFunction { get; set; }
        public Employer Employer { get; set; }
        public FieldTeamFunction Function { get; set; }
    }
}
