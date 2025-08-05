namespace Indica.System.Domain.Entities
{
    public class FieldTeam : EntityBase
    {
        public DateOnly Date { get; set; }
        public int Order { get; set; }
        public string Plate { get; set; }
        public string Resource { get; set; }
        public int IdActivity { get; set; }
        public long Cellphone { get; set; }
        public int IdRegion { get; set; }
        public bool IsConsidered { get; set; }
        public Activity Activity { get; set; }
        public FieldTeamRegional Regional { get; set; }
        public List<FieldTeamCouple> Couples { get; set; }
    }
}